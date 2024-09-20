using LaRottaO.CSharp.CarSimDashboard;
using System;
using System.Globalization;
using System.IO.Ports;
using System.Windows.Forms;

namespace LRottaO.CSharp.SimDashboardCtrl
{
    public partial class MainForm : Form
    {
        
   
        public MainForm()
        {
            InitializeComponent();
        }

     

        PortIO portIO = new PortIO();     

        private void Form1_Load(object sender, EventArgs e)
        {
            selectDataSource();
            GetAvailPorts.populateComboBoxWithPortsAndDeviceNames(comboBoxComPorts);
        }




        //I definetly should refactor this to another class, and avoid using timer
        private void timer_Tick(object sender, EventArgs e)
        {
            
            try
            {               

                int equivRpmFreq = 0;
                int equivKmhFreq = 0;
                double rpms = 0;
                float kmh = 0;
                int gear = 0;
                int fuel = 0;

                if (CheckAssetoRunning.isRunning() && 
                    radioAssetoData.Checked && 
                    AssetoIO.telemetry.telemetryConnectedSuccess)
                {
                    setTextBoxesEnabled(false);

                    Physics physics = AssetoIO.telemetry.ReadPhysics();

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
                        equivRpmFreq = (int)Math.Round(Interpolation.interpolate(rpms, Variables.RealRpmTable));
                    }

                    if (radio10KRedLineMatchMaxPw.Checked)
                    {
                        equivRpmFreq = (int)Math.Round(Interpolation.interpolate(rpms, Variables.RpmTable10KRedline));
                    }

                    equivKmhFreq = (int)Math.Round(Interpolation.interpolate(kmh, Variables.KphTable));

                    if (equivRpmFreq < 0)
                    {
                        equivRpmFreq = 0;
                    }

                    if (equivKmhFreq < 0)
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

                if (!portIO.isPortCurrentlyOpen()) {

                    return;

                }
                Tuple<Boolean,String> sendResult = portIO.serialSendSuccess(equivRpmFreq, equivKmhFreq, fuel, gear);

                if (!sendResult.Item1)
                {

                    buttonConnectPort.Enabled = true;
                    buttonDisconnectPort.Enabled = false;
                    MessageBox.Show(sendResult.Item2);

                }
            }
            catch (Exception ex) {

                Console.WriteLine("ERROR WHILE SENDING DATA TROUGH SERIAL: " + ex.ToString());
            }
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
            portIO.tryClosePort();
        }

        private void buttonConnectPort_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBoxComPorts.Text))
            {
                return;
            }

            String portName = comboBoxComPorts.Text.Substring(0, comboBoxComPorts.Text.IndexOf("|")).Trim();

            Boolean connSuccess = portIO.tryPortInit(portName);

                buttonConnectPort.Enabled = !connSuccess;
                buttonDisconnectPort.Enabled = connSuccess;

            if (connSuccess)
            {
                selectDataSource();
            }
        
        }

        private void radioAssetoData_CheckedChanged(object sender, EventArgs e)
        {
            selectDataSource();
        }

        private void selectDataSource()
        {
            if (radioAssetoData.Checked)
            {
               Tuple<Boolean,String> assetoConnResult = AssetoIO.tryInitAssetoConnection();

                if (assetoConnResult.Item1)
                {
                    setTextBoxesEnabled(false);
                }
                else {

                    radioAssetoData.Checked = false;
                    radioManualInput.Checked = true;
                    MessageBox.Show(assetoConnResult.Item2);
                }

            }         

            else {
                
                setTextBoxesEnabled(true);
            }
        }

        private void radioManualInput_CheckedChanged(object sender, EventArgs e)
        {
            selectDataSource();
        }

        private void buttonDisconnectPort_Click(object sender, EventArgs e)
        {
            portIO.tryClosePort();
        }
    }
}