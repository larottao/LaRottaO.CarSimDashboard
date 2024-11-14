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
        private System.Timers.Timer sendFuelDataTimer;
        private System.Timers.Timer sendGearDataTimer;

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

            // Timer for sending fuel data
            sendFuelDataTimer = new System.Timers.Timer(1000);
            sendFuelDataTimer.Elapsed += OnFuelDataTimerElapsed;
            sendFuelDataTimer.AutoReset = true;

            // Timer for sending gear data
            sendGearDataTimer = new System.Timers.Timer(500);
            sendGearDataTimer.Elapsed += OnGearDataTimerElapsed;
            sendGearDataTimer.AutoReset = true;
        }

        public void StopTimers()
        {
            simDataTimer.Stop();
            sendRpmDataTimer.Stop();
            sendSpeedDataTimer.Stop();
            sendFuelDataTimer?.Stop();
            sendGearDataTimer?.Stop();
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

        private void OnFuelDataTimerElapsed(object sender, ElapsedEventArgs e)
        {
            SendFuelData();
        }

        private void OnGearDataTimerElapsed(object sender, ElapsedEventArgs e)
        {
            SendGearData();
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
                try
                {
                    Variables.fuel = Convert.ToInt32(textBoxFuel.Text);
                }
                catch
                {
                    Variables.fuel = 0;
                }

                try
                {
                    Variables.gear = Convert.ToInt32(textBoxGear.Text);
                }
                catch
                {
                    Variables.gear = 0;
                }
                try
                {
                    Variables.rpms = Convert.ToDouble(textBoxRPM.Text);
                }
                catch
                {
                    Variables.rpms = 0;
                }
                try
                {
                    Variables.kmh =  Convert.ToDouble(textBoxKMH.Text);
                }
                catch
                {
                    Variables.kmh = 0;
                }
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

        private void SendFuelData()
        {
            String message = $"#fuel:{Variables.fuel}$";

            Tuple<Boolean, String> sendResult = portIO.tryToSendMessage(message);

            if (!sendResult.Item1)
            {
                errorSendingSerialMssage(sendResult.Item2);
            }
        }

        private void SendGearData()
        {
            String message = $"#gear:{Variables.gear}$";

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
            sendFuelDataTimer.Stop();
            sendGearDataTimer.Stop();

            portIO.tryClosePort();

            CrossThreadOps.setControlEnabled(buttonConnectPort, true);
            CrossThreadOps.setControlEnabled(buttonDisconnectPort, false);

            CrossThreadOps.SetControlText(labelInfo, reason);

            Console.WriteLine("ERROR WHILE SENDING DATA TROUGH SERIAL: " + reason);
        }

        private void updateFormTextboxes()
        {
            textBoxRPM.Text = Convert.ToString(Variables.rpms);
            textBoxKMH.Text = Convert.ToString(Variables.kmh);
            textBoxFuel.Text = Convert.ToString(Variables.fuel);
            textBoxGear.Text = Convert.ToString(Variables.gear);

            textBoxRpmFreq.Text = Variables.equivRpmFreq.ToString();
            textBoxKmhFreq.Text = Variables.equivKmhFreq.ToString();
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
            Variables.currentDataSource = Variables.DATASOURCE.MANUAL_INPUT;
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

            Tuple<Boolean, String> connSuccess = portIO.tryPortInit(portName);

            CrossThreadOps.setControlEnabled(buttonConnectPort, false);
            CrossThreadOps.setControlEnabled(buttonDisconnectPort, true);

            if (connSuccess.Item1)
            {
                dataSourceRadioButtonLogic();

                sendRpmDataTimer.Start();
                sendSpeedDataTimer.Start();
                sendFuelDataTimer.Start();
                sendGearDataTimer.Start();
            }
            else
            {
                labelInfo.Text = connSuccess.Item2;
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
                    labelInfo.Text = assetoConnResult.Item2;
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
            sendFuelDataTimer.Stop();
            sendGearDataTimer.Stop();

            portIO.tryClosePort();

            CrossThreadOps.setControlEnabled(buttonConnectPort, true);
            CrossThreadOps.setControlEnabled(buttonDisconnectPort, false);
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