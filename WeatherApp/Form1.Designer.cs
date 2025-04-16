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
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.picWeather = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picWeather)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.Location = new System.Drawing.Point(62, 239);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(206, 20);
            this.txtCity.TabIndex = 0;
            this.txtCity.Text = "Enter City";
            this.txtCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResult.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblResult.Location = new System.Drawing.Point(62, 153);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(120, 80);
            this.lblResult.TabIndex = 2;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblResult.Click += new System.EventHandler(this.lblResult_Click);
            // 
            // picWeather
            // 
            this.picWeather.BackColor = System.Drawing.SystemColors.ControlLight;
            this.picWeather.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picWeather.Location = new System.Drawing.Point(188, 153);
            this.picWeather.Name = "picWeather";
            this.picWeather.Size = new System.Drawing.Size(80, 80);
            this.picWeather.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWeather.TabIndex = 3;
            this.picWeather.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 425);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.picWeather);
            this.Controls.Add(this.txtCity);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picWeather)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.PictureBox picWeather;
    }
}

