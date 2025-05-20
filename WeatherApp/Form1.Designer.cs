namespace WeatherApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.picWeather = new System.Windows.Forms.PictureBox();
            this.forecastPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picWeather)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.Location = new System.Drawing.Point(12, 221);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(143, 20);
            this.txtCity.TabIndex = 0;
            this.txtCity.Text = "Enter a city name";
            this.txtCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResult.Location = new System.Drawing.Point(12, 9);
            this.lblResult.Name = "lblResult";
            this.lblResult.Padding = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.lblResult.Size = new System.Drawing.Size(143, 232);
            this.lblResult.TabIndex = 2;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picWeather
            // 
            this.picWeather.BackColor = System.Drawing.SystemColors.ControlLight;
            this.picWeather.Location = new System.Drawing.Point(34, 152);
            this.picWeather.Name = "picWeather";
            this.picWeather.Size = new System.Drawing.Size(99, 63);
            this.picWeather.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWeather.TabIndex = 3;
            this.picWeather.TabStop = false;
            // 
            // forecastPanel
            // 
            this.forecastPanel.AutoScroll = true;
            this.forecastPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.forecastPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.forecastPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.forecastPanel.Location = new System.Drawing.Point(161, 9);
            this.forecastPanel.Name = "forecastPanel";
            this.forecastPanel.Size = new System.Drawing.Size(652, 232);
            this.forecastPanel.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 251);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.picWeather);
            this.Controls.Add(this.forecastPanel);
            this.Controls.Add(this.lblResult);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picWeather)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.PictureBox picWeather;
        private System.Windows.Forms.FlowLayoutPanel forecastPanel;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

