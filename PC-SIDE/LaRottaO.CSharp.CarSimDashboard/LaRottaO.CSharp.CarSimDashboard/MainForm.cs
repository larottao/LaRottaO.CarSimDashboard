using LaRottaO.CSharp.CarSimDashboard;
using System;
using System.Globalization;

using System.Windows.Forms;
using System.Timers;
using System.IO.Ports;
using static LaRottaO.CSharp.CarSimDashboard.Variables;

namespace LRottaO.CSharp.SimDashboardCtrl
{
    public partial class MainForm : Form
    {
        private System.Timers.Timer simDataTimer;
        private System.Timers.Timer sendRpmDataTimer;
        private System.Timers.Timer sendSpeedDataTimer;

        private PortIO portIO = new PortIO();

        public MainForm()
        {
            InitializeComponent();

            // Timer for reading sim data
            simDataTimer = new System.Timers.Timer(50);
            simDataTimer.Elapsed += OnSimDataTimerElapsed;
            simDataTimer.AutoReset = true;

            // Timer for sending RPM data
            sendRpmDataTimer = new System.Timers.Timer(50);
            sendRpmDataTimer.Elapsed += OnRpmDataTimerElapsed;
            sendRpmDataTimer.AutoReset = true;

            // Timer for sending speed data
            sendSpeedDataTimer = new System.Timers.Timer(500);
            sendSpeedDataTimer.Elapsed += OnSpeedDataTimerElapsed;
            sendSpeedDataTimer.AutoReset = true;
        }

        public void StopTimers()
        {
            simDataTimer.Stop();
            sendRpmDataTimer.Stop();
            sendSpeedDataTimer.Stop();
        }

        private void OnSimDataTimerElapsed(object sender, ElapsedEventArgs e)
        {
            ReadSimData();
        }

        private void OnRpmDataTimerElapsed(object sender, ElapsedEventArgs e)
        {
            SendRpmData();
        }

        private void OnSpeedDataTimerElapsed(object sender, ElapsedEventArgs e)
        {
            SendSpeedData();
        }

        private void ReadSimData()
        {
            if (Variables.currentDataSource == DATASOURCE.ASSETO &&
                CheckAssetoRunning.isRunning() &&
              AssetoIO.telemetry.telemetryConnectedSuccess)
            {
                Physics physics = AssetoIO.telemetry.ReadPhysics();

                Variables.fuel = Convert.ToInt32(physics.Fuel);
                Variables.gear = physics.Gear - 1;
                Variables.rpms = physics.Rpms;
                Variables.kmh = Math.Round(physics.SpeedKmh, 0);
            }
            else
            {
                Variables.fuel = Convert.ToInt32(textBoxFuel.Text);
                Variables.gear = Convert.ToInt32(textBoxGear.Text);
                Variables.rpms = Convert.ToDouble(textBoxRPM.Text);
                Variables.kmh =  Convert.ToDouble(textBoxKMH.Text);
            }

            convertRpmsAndSpeedIntoFrequencies();
        }

        private void SendRpmData()
        {
            string message = $"#rpm:{Variables.equivRpmFreq}$";

            Tuple<Boolean, String> sendResult = portIO.tryToSendMessage(message);

            if (!sendResult.Item1)
            {
                errorSendingSerialMssage(sendResult.Item2);
            }
        }

        private void SendSpeedData()
        {
            string message = $"#speed:{Variables.equivKmhFreq}$";

            Tuple<Boolean, String> sendResult = portIO.tryToSendMessage(message);

            if (!sendResult.Item1)
            {
                errorSendingSerialMssage(sendResult.Item2);
            }
        }

        private void errorSendingSerialMssage(String reason)
        {
            sendRpmDataTimer.Stop();
            sendSpeedDataTimer.Stop();

            portIO.tryClosePort();

            SetControlEnabled(buttonConnectPort, true);
            SetControlEnabled(buttonDisconnectPort, false);

            MessageBox.Show(reason);

            Console.WriteLine("ERROR WHILE SENDING DATA TROUGH SERIAL: " + reason);
        }

        private void SetControlEnabled(Control control, bool enabled)
        {
            if (control.InvokeRequired)
            {
                // Use Invoke to marshal the call to the UI thread
                control.Invoke(new Action(() => SetControlEnabled(control, enabled)));
            }
            else
            {
                // Set the control's enabled state
                control.Enabled = enabled;
            }
        }

        private void updateFormTextboxes()
        {
            if (Variables.currentDataSource == DATASOURCE.ASSETO)
            {
                textBoxRPM.Text = Convert.ToString(Variables.rpms);
                textBoxKMH.Text = Convert.ToString(Variables.kmh);
                textBoxFuel.Text = Convert.ToString(Variables.fuel);
                textBoxGear.Text = Convert.ToString(Variables.gear);

                textBoxRpmFreq.Text = Variables.equivRpmFreq.ToString();
                textBoxKmhFreq.Text = Variables.equivKmhFreq.ToString();
            }
        }

        private void convertRpmsAndSpeedIntoFrequencies()
        {
            if (checkBoxUseFreqTable.Checked)
            {
                if (radioMatchRealScale.Checked)
                {
                    Variables.equivRpmFreq = (int)Math.Round(Interpolation.interpolate(Variables.rpms, Variables.RealRpmTable));
                }

                if (radio10KRedLineMatchMaxPw.Checked)
                {
                    Variables.equivRpmFreq = (int)Math.Round(Interpolation.interpolate(Variables.rpms, Variables.RpmTable10KRedline));
                }

                Variables.equivKmhFreq = (int)Math.Round(Interpolation.interpolate(Variables.kmh, Variables.KphTable));

                if (Variables.equivRpmFreq < 0)
                {
                    Variables.equivRpmFreq = 0;
                }

                if (Variables.equivKmhFreq < 0)
                {
                    Variables.equivKmhFreq = 0;
                }
            }
            else
            {
                Variables.equivRpmFreq = Convert.ToInt32(textBoxRpmFreq.Text);
                Variables.equivKmhFreq = Convert.ToInt32(textBoxKmhFreq.Text);
            }

            if (Variables.equivRpmFreq < 0)
            {
                Variables.equivRpmFreq = 0;
            }

            if (Variables.equivKmhFreq < 0)
            {
                Variables.equivKmhFreq = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAvailPorts.populateComboBoxWithPortsAndDeviceNames(comboBoxComPorts);
            simDataTimer.Start();
            dataSourceRadioButtonLogic();
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
            StopTimers();
        }

        private void buttonConnectPort_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBoxComPorts.Text))
            {
                return;
            }

            String portName = comboBoxComPorts.Text.Substring(0, comboBoxComPorts.Text.IndexOf("|")).Trim();

            Boolean connSuccess = portIO.tryPortInit(portName);

            SetControlEnabled(buttonConnectPort, false);
            SetControlEnabled(buttonDisconnectPort, true);

            if (connSuccess)
            {
                dataSourceRadioButtonLogic();

                sendRpmDataTimer.Start();
                sendSpeedDataTimer.Start();
            }
        }

        private void dataSourceRadioButtonLogic()
        {
            if (Variables.currentDataSource == DATASOURCE.ASSETO)
            {
                Tuple<Boolean, String> assetoConnResult = AssetoIO.tryInitAssetoConnection();

                if (assetoConnResult.Item1)
                {
                    setTextBoxesEnabled(false);
                    radioAssetoData.Checked = true;
                    radioManualInput.Checked = false;
                }
                else
                {
                    radioAssetoData.Checked = false;
                    radioManualInput.Checked = true;
                    MessageBox.Show(assetoConnResult.Item2);
                }
            }

            if (Variables.currentDataSource == DATASOURCE.MANUAL_INPUT)
            {
                setTextBoxesEnabled(true);
            }
        }

        private void buttonDisconnectPort_Click(object sender, EventArgs e)
        {
            sendRpmDataTimer.Stop();
            sendSpeedDataTimer.Stop();
            portIO.tryClosePort();

            SetControlEnabled(buttonConnectPort, true);
            SetControlEnabled(buttonDisconnectPort, false);
        }

        private void FormTimer_Tick(object sender, EventArgs e)
        {
            updateFormTextboxes();
        }

        private void radioAssetoData_Click(object sender, EventArgs e)
        {
            Variables.currentDataSource = Variables.DATASOURCE.ASSETO;
            dataSourceRadioButtonLogic();
        }

        private void radioManualInput_Click(object sender, EventArgs e)
        {
            Variables.currentDataSource = Variables.DATASOURCE.MANUAL_INPUT;
            dataSourceRadioButtonLogic();
        }
    }
}