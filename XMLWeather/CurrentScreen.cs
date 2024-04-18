using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class CurrentScreen : UserControl
    {
        Pen whitePen = new Pen(Color.White, 2);
        Rectangle sunSetRec = new Rectangle(100, 300, 200, 200);
        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            cityOutput.Text = Form1.days[0].location;

            currentOutput.Text = (Convert.ToDouble(Form1.days[0].currentTemp)).ToString("##") + "°";
            minOutput.Text = (Convert.ToDouble(Form1.days[0].tempLow)).ToString("##");
            maxOutput.Text = (Convert.ToDouble(Form1.days[0].tempHigh)).ToString("##");

            sunRiseLabel.Text = (Convert.ToString(AdjustTimeZone(Form1.days[0].sunRise, Form1.days[0].timezone))).Substring(9, 5) + "am";
            sunSetLabel.Text = (Convert.ToString(AdjustTimeZone(Form1.days[0].sunSet, Form1.days[0].timezone))).Substring(9,5) + "pm";

            lastUpdateLabel.Text = "Last Update: " + Form1.lastUpdate.Substring(0,10) + " " + Form1.lastUpdate.Substring(11,8);

            //change background color and icon
            switch (Form1.days[0].icon)
            {
                case "01d":
                    this.BackColor = Color.Yellow;
                    pictureBox1.Image = Properties.Resources._01d;
                    break;
                case "02d":
                    this.BackColor = Color.Gold;
                    pictureBox1.Image = Properties.Resources._02d;
                    break;
                case "03d":
                    this.BackColor = Color.LightSteelBlue;
                    pictureBox1.Image = Properties.Resources._03d;
                    break;
                case "04d":
                    this.BackColor = Color.Gray;
                    pictureBox1.Image = Properties.Resources._04d;
                    break;
                case "09d":
                    this.BackColor = Color.DarkGray;
                    pictureBox1.Image = Properties.Resources._09d;
                    break;
                case "10d":
                    this.BackColor = Color.DarkKhaki;
                    pictureBox1.Image = Properties.Resources._10d;
                    break;
                case "11d":
                    this.BackColor = Color.Yellow;
                    pictureBox1.Image = Properties.Resources._11d;
                    break;
                case "50d":
                    this.BackColor = Color.SlateGray;
                    pictureBox1.Image = Properties.Resources._50d;
                    break;
            }
        }

        public DateTime AdjustTimeZone(string time, string timezone)
        {
            int hour = Convert.ToInt32(time.Substring(11, 2));
            int minute = Convert.ToInt32(time.Substring(14, 2));
            int second = Convert.ToInt32(time.Substring(17, 2));

            //year, month, day is irrelevent
            DateTime test = new DateTime(2004,12, 8, hour, minute, second);

            test = test.AddSeconds(Convert.ToInt32(timezone));

            return test;
        }
        private void forecastLabel_Click_1(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }

        private void CurrentScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(whitePen, 80, 400, 320, 400);
            e.Graphics.DrawArc(whitePen, sunSetRec, 0, -180);

        }
    }
}
