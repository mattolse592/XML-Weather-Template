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
        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
        }

        public void displayForecast()
        {
            for (int i = 0; i < Form1.days.Count; i++)
            {
                //TODO: add all of the labels, pictureboxes, and min max labels in lists.
                //TODO: make the for loop show the values
                //TODO: win
            }

            //change backcolor
            switch (Form1.days[0].icon)
            {
                case "01d":
                    this.BackColor = Color.Yellow;
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
                case "09d":
                    this.BackColor = Color.DarkGray;
                    break;
                case "10d":
                    this.BackColor = Color.DarkKhaki;
                    break;
                case "11d":
                    this.BackColor = Color.Yellow;
                    break;
                case "50d":
                    this.BackColor = Color.SlateGray;
                    break;
            }

            lastUpdateLabel.Text = "Last Update: " + Form1.lastUpdate.Substring(0, 10) + " " + Form1.lastUpdate.Substring(11, 8);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }

    }
}
