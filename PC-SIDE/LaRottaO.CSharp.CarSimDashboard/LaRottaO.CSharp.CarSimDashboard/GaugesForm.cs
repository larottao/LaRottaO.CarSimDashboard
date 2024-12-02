using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Awesome BMW Gauges photo by Massimo Z.

namespace LaRottaO.CSharp.CarSimDashboard
{
    public partial class GaugesForm : Form
    {
        public GaugesForm()
        {
            InitializeComponent();
        }

        private GaugeElement speedometer;

        private GaugeElement tachometer;

        private void GaugesForm_Load(object sender, EventArgs e)
        {
            List<Tuple<float, float>> speedometerCorrectionPoints = new List<Tuple<float, float>>

                {
                    new Tuple<float, float>(0, -40),
                    new Tuple<float, float>(10, -27),
                    new Tuple<float, float>(20, -18),
                    new Tuple<float, float>(30, -8),
                    new Tuple<float, float>(40, 2),
                    new Tuple<float, float>(60, 23),
                    new Tuple<float, float>(80, 41),
                    new Tuple<float, float>(100, 63),
                    new Tuple<float, float>(120, 84),
                    new Tuple<float, float>(150, 107),
                    new Tuple<float, float>(180, 130),
                    new Tuple<float, float>(210, 152),
                    new Tuple<float, float>(330, 226)
                };

            speedometer = new GaugeElement(speedometerPictureBox, speedometerCorrectionPoints, 2);

            List<Tuple<float, float>> tachometerCorrectionPoints = new List<Tuple<float, float>>

                {
                    new Tuple<float, float>(0, -40),
                    new Tuple<float, float>(9000, 226)
                };

            tachometer = new GaugeElement(tachometerPictureBox, tachometerCorrectionPoints, 100);
        }

        public void setSpeedOnGauge(double speed)
        {
            speedometer.inputNewValue((float)speed);
        }

        public void setRpmOnGauge(double rpm)
        {
            tachometer.inputNewValue((float)rpm);
        }

        public void setGear(int gearNumber)
        {
            if (gearNumber == -1)
            {
                labelGear.Text = "R";
            }

            else if (gearNumber == 0)
            {
                labelGear.Text = "N";
            }

            else
            {
                labelGear.Text = gearNumber.ToString();
            }
        }
    }
}