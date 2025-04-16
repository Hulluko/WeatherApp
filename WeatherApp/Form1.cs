using System;
using System.Net.Http;
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

            txtCity.KeyDown += TxtCity_KeyDown;
            txtCity.PreviewKeyDown += TxtCity_PreviewKeyDown;
        }

        private void TxtCity_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.IsInputKey = true;
        }

        private async void TxtCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                string city = txtCity.Text.Trim();
                city = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(city.ToLower());

                if (string.IsNullOrWhiteSpace(city))
                {
                    lblResult.Text = "Please enter a city name.";
                    return;
                }

                string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

                try
                {
                    string response = await client.GetStringAsync(url);
                    JObject data = JObject.Parse(response);

                    string description = data["weather"][0]["description"].ToString();
                    string temp = data["main"]["temp"].ToString();
                    string humidity = data["main"]["humidity"].ToString();
                    string icon = data["weather"][0]["icon"].ToString();
                    string wind = data["wind"]["speed"].ToString();

                    lblResult.Text =
                        $"Weather in {city}:\n" +
                        $"{description}\n" +
                        $"Temp: {temp}°C\n" +
                        $"Humidity: {humidity}%\n" +
                        $"Wind: {wind} m/s";

                    string iconUrl = $"https://openweathermap.org/img/wn/{icon}@2x.png";
                    picWeather.Load(iconUrl);
                }
                catch (Exception ex)
                {
                    lblResult.Text = "Error: " + ex.Message;
                    picWeather.Image = null;
                }

                txtCity.Clear();
                txtCity.Focus();
            }
        }

        private void lblResult_Click(object sender, EventArgs e)
        {

        }
    }
}