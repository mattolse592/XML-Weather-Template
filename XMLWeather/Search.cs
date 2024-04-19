using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class Search : UserControl
    {
        public Search()
        {
            InitializeComponent();
            SetBackgroundColor();
        }

        private void SetBackgroundColor()
        {
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
                    this.BackColor = Color.Yellow;
                    break;
                case "13d":
                    this.BackColor = Color.Gray;
                    break;
                case "50d":
                    this.BackColor = Color.SlateGray;
                    break;
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen fs = new CurrentScreen();
            f.Controls.Add(fs);
        }
        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }
    }
}
