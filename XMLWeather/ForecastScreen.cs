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
    public partial class ForecastScreen : UserControl
    {
        List<Label> dateLabels = new List<Label>();
        List<Label> maxLabels = new List<Label>();
        List<Label> minLabels = new List<Label>();
        List<PictureBox> icons = new List<PictureBox>();
        public ForecastScreen()
        {
            InitializeComponent();
            addComponentsToList();
            displayForecast();
        }

        //add all labels and icons to a list for use in a for loop
        public void addComponentsToList()
        {
            dateLabels.Add(date1Label);
            dateLabels.Add(date2Label);
            dateLabels.Add(date3Label);
            dateLabels.Add(date4Label);
            dateLabels.Add(date5Label);
            dateLabels.Add(date6Label);

            maxLabels.Add(max1Label);
            maxLabels.Add(max2Label);
            maxLabels.Add(max3Label);
            maxLabels.Add(max4Label);
            maxLabels.Add(max5Label);
            maxLabels.Add(max6Label);

            minLabels.Add(min1Label);
            minLabels.Add(min2Label);
            minLabels.Add(min3Label);
            minLabels.Add(min4Label);
            minLabels.Add(min5Label);
            minLabels.Add(min6Label);

            icons.Add(icon1);
            icons.Add(icon2);
            icons.Add(icon3);
            icons.Add(icon4);
            icons.Add(icon5);
            icons.Add(icon6);
        }
        public void displayForecast()
        {
            for (int i = 0; i < Form1.days.Count; i++)
            {
                dateLabels[i].Text = Form1.days[i].date;
                maxLabels[i].Text = (Convert.ToDouble(Form1.days[i].tempHigh)).ToString("##");
                minLabels[i].Text = (Convert.ToDouble(Form1.days[i].tempLow)).ToString("##");

                //fill the temperature with zero if zero.
                if (Math.Abs(Convert.ToDouble(Form1.days[i].tempHigh)) < 1)
                {
                    maxLabels[i].Text = "0";
                }
                if (Math.Abs(Convert.ToDouble(Form1.days[i].tempLow)) < 1)
                {
                    minLabels[i].Text = "0";
                }

                //display icon for each day
                switch (Form1.days[i].icon)
                {
                    case "01d":
                        icons[i].Image = Properties.Resources._01d;
                        break;
                    case "02d":
                        icons[i].Image = Properties.Resources._02d;
                        break;
                    case "03d":
                        icons[i].Image = Properties.Resources._03d;
                        break;
                    case "04d":
                        icons[i].Image = Properties.Resources._04d;
                        break;
                    case "04n":
                        icons[i].Image = Properties.Resources._04d;
                        break;
                    case "09d":
                        icons[i].Image = Properties.Resources._09d;
                        break;
                    case "10d":
                        icons[i].Image = Properties.Resources._10d;
                        break;
                    case "11d":
                        icons[i].Image = Properties.Resources._11d;
                        break;
                    case "13d":
                        icons[i].Image = Properties.Resources._13d;
                        break;
                    case "50d":
                        icons[i].Image = Properties.Resources._50d;
                        break;
                }
            }

            //change backcolor based on icon
            switch (Form1.days[0].icon)
            {
                case "01d":
                    this.BackColor = Color.Goldenrod;
                    break;
                case "02d":
                    this.BackColor = Color.Gold;
                    break;
                case "03d":
                    this.BackColor = Color.LightSteelBlue;
                    break;
                case "04d":
                    this.BackColor = Color.Gray;
                    break;
                case "04n":
                    this.BackColor = Color.Gray;
                    break;
                case "09d":
                    this.BackColor = Color.DarkGray;
                    break;
                case "10d":
                    this.BackColor = Color.DarkCyan;
                    break;
                case "11d":
                    this.BackColor = Color.Goldenrod;
                    break;
                case "13d":
                    this.BackColor = Color.Gray;
                    break;
                case "50d":
                    this.BackColor = Color.SlateGray;
                    break;
            }

            lastUpdateLabel.Text = "Last Update: " + CurrentScreen.realLastUpdate.Substring(0, 10) + " " + CurrentScreen.realLastUpdate.Substring(10, 8);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }

        private void searchLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            Search fs = new Search();
            f.Controls.Add(fs);
        }
    }
}
