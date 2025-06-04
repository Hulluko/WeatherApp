using System;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private string apiKey = "dd576a76eae194a3009cfd364f1b49d4";

        public Form1()
        {
            InitializeComponent();

            // Handle Enter key
            txtCity.KeyDown += TxtCity_KeyDown;
            txtCity.PreviewKeyDown += TxtCity_PreviewKeyDown;
        }

        // Allow Enter key in textbox
        private void TxtCity_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.IsInputKey = true;
        }

        // Fetch weather on Enter key
        private async void TxtCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            e.SuppressKeyPress = true;

            // Get and clear city name
            string city = txtCity.Text.Trim();
            city = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(city.ToLower());

            if (string.IsNullOrWhiteSpace(city))
            {
                lblResult.Text = "Please enter a city name.";
                return;
            }

            // API URLs
            string currentUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
            string forecastUrl = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={apiKey}&units=metric";

            try
            {
                // Get current weather and forecast
                await LoadCurrentWeather(city, currentUrl);
                await LoadForecast(city, forecastUrl);
            }
            catch (Exception ex)
            {
                lblResult.Text = "Error: " + ex.Message;
                picWeather.Image = null;
            }

            // Clear input
            txtCity.Clear();
            txtCity.Focus();
        }

        // Load current weather data
        private async Task LoadCurrentWeather(string city, string url)
        {
            string response = await client.GetStringAsync(url);
            JObject data = JObject.Parse(response);

            // Extract values
            string description = data["weather"][0]["description"].ToString();
            string temp = data["main"]["temp"].ToString();
            string humidity = data["main"]["humidity"].ToString();
            string icon = data["weather"][0]["icon"].ToString();
            string wind = data["wind"]["speed"].ToString();
            double minTemp = (double)data["main"]["temp_min"];
            double maxTemp = (double)data["main"]["temp_max"];
            string timezone = data["timezone"].ToString();

            // Get local time
            DateTime cityTime = DateTime.UtcNow.AddSeconds(double.Parse(timezone));
            bool isDaytime = cityTime.Hour >= 6 && cityTime.Hour < 18;

            // Update icon
            icon = NormalizeIcon(icon, isDaytime);
            string iconUrl = $"https://openweathermap.org/img/wn/{icon}@2x.png";

            // Show current weather
            lblResult.Text = $"Weather in {city} ({DateTime.Today:ddd dd.M.}):\n" +
                             $"{description}\n" +
                             $"Temp: {temp}°C\n" +
                             $"Min: {minTemp:F1}°C / Max: {maxTemp:F1}°C\n" +
                             $"Humidity: {humidity}%\n" +
                             $"Wind: {wind} m/s";

            picWeather.Load(iconUrl);
        }

        // Load 5-day forecast
        private async Task LoadForecast(string city, string url)
        {
            string response = await client.GetStringAsync(url);
            JObject data = JObject.Parse(response);

            forecastPanel.Controls.Clear();
            DateTime today = DateTime.Today;

            // Get timezone again
            string timezoneResponse = await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}");
            DateTime cityTime = DateTime.UtcNow.AddSeconds(double.Parse(JObject.Parse(timezoneResponse)["timezone"].ToString()));

            // Group forecast by date
            var groupedData = data["list"]
                .GroupBy(item => DateTime.Parse(item["dt_txt"].ToString()).Date)
                .Where(g => g.Key > today)
                .Take(5);

            foreach (var group in groupedData)
            {
                AddForecastPanel(group, cityTime);
            }
        }

        // Add forecast UI panel
        private void AddForecastPanel(IGrouping<DateTime, JToken> group, DateTime cityTime)
        {
            DateTime date = group.Key;
            string day = date.ToString("ddd dd.M.");

            // Closest time to current hour
            var closestForecast = group
                .OrderBy(item =>
                {
                    DateTime dt = DateTime.Parse(item["dt_txt"].ToString());
                    TimeSpan diff = (dt - dt.Date).Subtract(cityTime.TimeOfDay);
                    return Math.Abs(diff.TotalHours);
                })
                .First();

            // Calculate averages
            double avgTemp = group.Average(item => (double)item["main"]["temp"]);
            double minTemp = group.Min(item => (double)item["main"]["temp_min"]);
            double maxTemp = group.Max(item => (double)item["main"]["temp_max"]);
            double avgHumidity = group.Average(item => (double)item["main"]["humidity"]);
            double avgWind = group.Average(item => (double)item["wind"]["speed"]);

            // Forecast data
            string description = closestForecast["weather"][0]["description"].ToString();
            string icon = closestForecast["weather"][0]["icon"].ToString();
            DateTime forecastTime = DateTime.Parse(closestForecast["dt_txt"].ToString());
            bool isDaytime = forecastTime.Hour >= 6 && forecastTime.Hour < 18;

            icon = NormalizeIcon(icon, isDaytime);
            string iconUrl = $"https://openweathermap.org/img/wn/{icon}@2x.png";

            // Create panel
            Panel dayPanel = CreateForecastPanel(day, description, iconUrl, avgTemp, minTemp, maxTemp, avgHumidity, avgWind);
            forecastPanel.Controls.Add(dayPanel);
        }

        // Fix icon for day/night
        private string NormalizeIcon(string icon, bool isDaytime)
        {
            if (icon == "01d" || icon == "01n")
                return isDaytime ? "01d" : "01n";
            return icon;
        }

        // Create forecast panel
        private Panel CreateForecastPanel(string day, string description, string iconUrl, double avgTemp, double minTemp, double maxTemp, double humidity, double wind)
        {
            Panel panel = new Panel
            {
                Width = 120,
                Height = 220,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblDay = new Label
            {
                Text = day,
                Dock = DockStyle.Top,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            PictureBox pic = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = 60,
                Height = 60,
                Dock = DockStyle.Top,
                ImageLocation = iconUrl
            };

            Label lblDesc = new Label
            {
                Text = description,
                Dock = DockStyle.Top,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblAvg = new Label
            {
                Text = $"Avg: {avgTemp:F1}°C",
                Dock = DockStyle.Top,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblMinMax = new Label
            {
                Text = $"Min: {minTemp:F1}°C / Max: {maxTemp:F1}°C",
                Dock = DockStyle.Top,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblHumidity = new Label
            {
                Text = $"Humidity: {humidity:F0}%",
                Dock = DockStyle.Top,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblWind = new Label
            {
                Text = $"Wind: {wind:F1} m/s",
                Dock = DockStyle.Top,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Add elements to panel
            panel.Controls.Add(lblWind);
            panel.Controls.Add(lblHumidity);
            panel.Controls.Add(lblMinMax);
            panel.Controls.Add(lblAvg);
            panel.Controls.Add(lblDesc);
            panel.Controls.Add(pic);
            panel.Controls.Add(lblDay);

            return panel;
        }
    }
}