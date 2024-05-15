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

        public static string realLastUpdate;
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
            sunSetLabel.Text = (Convert.ToString(AdjustTimeZone(Form1.days[0].sunSet, Form1.days[0].timezone))).Substring(9, 5) + "pm";

            conditionLabel.Text = (Convert.ToString(Form1.days[0].condition));

            //14400 is the time conversion for Stratford
            realLastUpdate = Convert.ToString(AdjustTimeZone(Form1.lastUpdate, "-14400"));
            lastUpdateLabel.Text = "Last Update: " + realLastUpdate.Substring(0, 10) + " " + realLastUpdate.Substring(10, 8);

            //change background color and icon
            switch (Form1.days[0].icon)
            {
                case "01d":
                    this.BackgroundImage = Properties.Resources._01db;
                    this.BackColor = Color.Goldenrod;
                    pictureBox1.Image = Properties.Resources._01d;
                    break;
                case "02d":
                    this.BackgroundImage = Properties.Resources._02db;
                    this.BackColor = Color.Gold;
                    pictureBox1.Image = Properties.Resources._02d;
                    break;
                case "03d":
                    this.BackgroundImage = Properties.Resources._03db;
                    this.BackColor = Color.LightSteelBlue;
                    pictureBox1.Image = Properties.Resources._03db;
                    break;
                case "04d":
                    this.BackgroundImage = Properties.Resources._03db;
                    this.BackColor = Color.Gray;
                    pictureBox1.Image = Properties.Resources._04d;
                    break;
                case "04n":
                    this.BackgroundImage = Properties.Resources._03db;
                    this.BackColor = Color.Gray;
                    pictureBox1.Image = Properties.Resources._04d;
                    break;
                case "09d":
                    this.BackgroundImage = Properties.Resources._09db;
                    this.BackColor = Color.DarkGray;
                    pictureBox1.Image = Properties.Resources._09d;
                    break;
                case "10d":
                    this.BackgroundImage = Properties.Resources._10db;
                    this.BackColor = Color.DarkCyan;
                    pictureBox1.Image = Properties.Resources._10d;
                    break;
                case "11d":
                    this.BackColor = Color.Goldenrod;
                    pictureBox1.Image = Properties.Resources._11d;
                    break;
                case "13d":
                    this.BackgroundImage = Properties.Resources._13db;
                    this.BackColor = Color.Gray;
                    pictureBox1.Image = Properties.Resources._13d;
                    break;
                case "50d":
                    this.BackColor = Color.SlateGray;
                    pictureBox1.Image = Properties.Resources._50d;
                    break;
            }
        }

        //adjust for timezones
        //used for sunset, sunrise, and last update functions
        public DateTime AdjustTimeZone(string time, string timezone)
        {
            int year = Convert.ToInt32(time.Substring(0, 4));
            int month = Convert.ToInt32(time.Substring(5, 2));
            int day = Convert.ToInt32(time.Substring(8, 2));
            int hour = Convert.ToInt32(time.Substring(11, 2));
            int minute = Convert.ToInt32(time.Substring(14, 2));
            int second = Convert.ToInt32(time.Substring(17, 2));

            DateTime test = new DateTime(year, month, day, hour, minute, second);

            test = test.AddSeconds(Convert.ToInt32(timezone));

            return test;
        }

        //change the screen to the forecast screen
        private void forecastLabel_Click_1(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }
        private void searchLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            Search fs = new Search();
            f.Controls.Add(fs);
        }

        //draw the sunrise and sunset lines
        private void CurrentScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(whitePen, 80, 400, 320, 400);
            e.Graphics.DrawArc(whitePen, sunSetRec, 0, -180);

        }

        private void CurrentScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
