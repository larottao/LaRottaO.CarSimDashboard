using LaRottaO.CSharp.CarSimDashboard;
using System;
using System.Globalization;
using System.IO.Ports;
using System.Windows.Forms;

namespace LRottaO.CSharp.SimDashboardCtrl
{
    public partial class MainForm : Form
    {
        private AsettoCorsaTelemetry telemetry = new AsettoCorsaTelemetry();
        private SerialPort serialPort;

        private readonly ValuePair[] RealRpmTable =
        {
            new ValuePair(0, 0),
            new ValuePair(500, 11),
            new ValuePair(1000, 20),
            new ValuePair(2000, 35),
            new ValuePair(2000, 38),
            new ValuePair(3000, 52),
            new ValuePair(4000, 69),
            new ValuePair(5000, 85),
            new ValuePair(6000, 101),
            new ValuePair(7000, 117),
            new ValuePair(8000, 134),
            new ValuePair(9000, 152),
            new ValuePair(10000, 168),
            new ValuePair(11000, 185),
            new ValuePair(12000, 202),
            new ValuePair(13000, 220),
            new ValuePair(14000, 237),
            new ValuePair(15000, 255)
        };

        private ValuePair[] RpmTable7KRedline =
{
            new ValuePair(0, 0),
            new ValuePair(500, 11),
            new ValuePair(1000, 20),
            new ValuePair(2000, 35),
            new ValuePair(2000, 38),
            new ValuePair(3000, 52),
            new ValuePair(6000, 168),
            new ValuePair(7000, 185)
        };

        private readonly ValuePair[] KphTable =
            {
            new ValuePair(0, 0),
            new ValuePair(5, 1),
            new ValuePair(10, 3),
            new ValuePair(20, 6),
            new ValuePair(30, 9),
            new ValuePair(40, 12),
            new ValuePair(50, 15),
            new ValuePair(60, 18),
            new ValuePair(70, 22),
            new ValuePair(80, 25),
            new ValuePair(90, 29),
            new ValuePair(100, 31),
            new ValuePair(110, 34),
            new ValuePair(120, 37),
            new ValuePair(130, 39),
            new ValuePair(140, 42),
            new ValuePair(150, 45),
            new ValuePair(160, 48),
            new ValuePair(170, 51),
            new ValuePair(180, 54),
            new ValuePair(190, 57),
            new ValuePair(200, 60),
            new ValuePair(210, 63),
            new ValuePair(220, 66),
            new ValuePair(230, 68),
            new ValuePair(240, 71),
            new ValuePair(250, 74),
            new ValuePair(260, 77),
            new ValuePair(270, 80),
            new ValuePair(280, 83),
            new ValuePair(290, 91)
        };

        private const double scalingFactor = 1E47;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            selectGameDataSource();

            SerialPortUtils.populateComPortsWithDeviceNames(comboBoxComPorts);
        }

        private void connectToUc(String portName)
        {
            try
            {
                serialPort = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One)
                {
                    ReadTimeout = 100,
                    WriteTimeout = 100
                };

                serialPort.Open();

                buttonConnectPort.Enabled = false;
                buttonDisconnectPort.Enabled = true;
            }
            catch (Exception ex)
            {
                buttonConnectPort.Enabled = true;
                buttonDisconnectPort.Enabled = false;

                MessageBox.Show(ex.ToString());
                radioTest.Checked = true;
                return;
            }

            connectToAsseto();
        }

        private void connectToAsseto()
        {
            if (radioAssetoData.Checked && telemetry.telemetryConnectedSuccess)
            {
                StaticInfo staticInfo = telemetry.ReadStaticInfo();
                int maxPower = Convert.ToInt32(staticInfo.MaxPower * scalingFactor);

                RpmTable7KRedline = new ValuePair[]
               {
                new ValuePair(0, 0),
                new ValuePair(500, 11),
                new ValuePair(1000, 20),
                new ValuePair(2000, 35),
                new ValuePair(2000, 38),
                new ValuePair(3000, 52),
                new ValuePair(maxPower - 1000, 168),
                new ValuePair(maxPower, 185)
               };

                setTextBoxesEnabled(false);            
            }
        }

        public void tryToClosePort()
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
                buttonConnectPort.Enabled = true;
                buttonDisconnectPort.Enabled = false;
            }
        }

        private String lastSentMessage = "";

        private void SerialSend(int rpm, int speed, int gas, int gear)
        {
            if (serialPort ==null) {

                return;
            }
            string message = $"#{rpm:D3},{speed:D3},{gas:D3},{gear:D1}$";

            if (!message.Equals(lastSentMessage))
            {
                lastSentMessage = message;

                try
                {
                    serialPort.Write(message + "\n");
                }
                catch (Exception ex)
                {
                    tryToClosePort();
                    MessageBox.Show(ex.ToString());
                }

                // For debug purposes read the response from the serial port and print it
                //string response = serialPort.ReadLine(); // This will block until a newline character is received
                //Console.WriteLine("Received: " + response);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int equivRpmFreq = 0;
            int equivKmhFreq = 0;
            double rpms = 0;
            float kmh = 0;
            int gear = 0;
            int fuel = 0;

            if (radioAssetoData.Checked &&  telemetry.telemetryConnectedSuccess)
            {
                setTextBoxesEnabled(false);

                Physics physics = telemetry.ReadPhysics();

                fuel = Convert.ToInt32(physics.Fuel);
                gear = physics.Gear - 1;
                textBoxFuel.Text = Convert.ToString(fuel);
                textBoxGear.Text = Convert.ToString(gear);

                rpms = physics.Rpms;
                kmh = physics.SpeedKmh;

                textBoxRPM.Text = Convert.ToString(rpms);
                textBoxKMH.Text = Convert.ToString(kmh);
            }
            else
            {
                setTextBoxesEnabled(true);

                fuel = Convert.ToInt32(textBoxFuel.Text);
                gear = Convert.ToInt32(textBoxGear.Text);

                rpms = Convert.ToDouble(textBoxRPM.Text);
                kmh = float.Parse(textBoxKMH.Text, CultureInfo.InvariantCulture.NumberFormat);
            }

            if (checkBoxUseFreqTable.Checked)
            {
                if (radioMatchRealScale.Checked)
                {
                    equivRpmFreq = (int)Math.Round(Interpolation.interpolate(rpms, RealRpmTable));
                }

                if (radio10KRedLineMatchMaxPw.Checked)
                {
                    equivRpmFreq = (int)Math.Round(Interpolation.interpolate(rpms, RpmTable7KRedline));
                }

                equivKmhFreq = (int)Math.Round(Interpolation.interpolate(kmh, KphTable));

                if (equivRpmFreq<0)
                {
                    equivRpmFreq = 0;
                }

                if (equivKmhFreq<0)
                {
                    equivKmhFreq = 0;
                }

                textBoxRpmFreq.Text = equivRpmFreq.ToString();
                textBoxKmhFreq.Text = equivKmhFreq.ToString();
            }
            else
            {
                equivRpmFreq = Convert.ToInt32(textBoxRpmFreq.Text);
                equivKmhFreq = Convert.ToInt32(textBoxKmhFreq.Text);
            }

            if (equivRpmFreq < 0)
            {
                equivRpmFreq = 0;
            }

            if (equivKmhFreq < 0)
            {
                equivKmhFreq = 0;
            }

            SerialSend(equivRpmFreq, equivKmhFreq, fuel, gear);
        }

        private void setTextBoxesEnabled(Boolean value)
        {
            textBoxRPM.Enabled = value;
            textBoxKMH.Enabled = value;
            textBoxFuel.Enabled = value;
            textBoxGear.Enabled = value;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            tryToClosePort();
        }

        private void buttonConnectPort_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBoxComPorts.Text))
            {
                return;
            }

            String portName = comboBoxComPorts.Text.Substring(0, comboBoxComPorts.Text.IndexOf("|")).Trim();
            connectToUc(portName);
        }

        private void radioAssetoData_CheckedChanged(object sender, EventArgs e)
        {
            selectGameDataSource();
        }

        private void selectGameDataSource()
        {
            if (radioAssetoData.Checked && CheckAssetoRunning.isRunning())
            {
                connectToAsseto();
            }

            else {

                radioAssetoData.Checked = false;
                radioTest.Checked = true;
                setTextBoxesEnabled(true);
            }
        }

        private void radioTest_CheckedChanged(object sender, EventArgs e)
        {
            selectGameDataSource();
        }

        private void buttonDisconnectPort_Click(object sender, EventArgs e)
        {
            tryToClosePort();
        }
    }
}