using LaRottaO.CSharp.CarSimDashboard;
using System;
using System.Globalization;

using System.Windows.Forms;
using System.Timers;
using System.IO.Ports;
using static LaRottaO.CSharp.CarSimDashboard.Variables;
using LaRottaO.CSharp.CarSimDashboard.Services;
using System.Threading.Tasks;

namespace LRottaO.CSharp.SimDashboardCtrl
{
    public partial class MainForm : Form
    {
        private System.Timers.Timer readDataTimer;
        private System.Timers.Timer sendRpmDataTimer;
        private System.Timers.Timer sendSpeedDataTimer;
        private System.Timers.Timer sendFuelDataTimer;
        private System.Timers.Timer sendGearDataTimer;

        private readonly IUsb _usb = new UsbService();

        public MainForm()
        {
            InitializeComponent();

            // Timer for reading sim data
            readDataTimer = new System.Timers.Timer(50);
            readDataTimer.Elapsed += OnReadDataTimerElapsed;
            readDataTimer.AutoReset = true;

            // Timer for sending RPM data
            sendRpmDataTimer = new System.Timers.Timer(100);
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
            sendGearDataTimer = new System.Timers.Timer(200);
            sendGearDataTimer.Elapsed += OnGearDataTimerElapsed;
            sendGearDataTimer.AutoReset = true;
        }

        public void StopTimers()
        {
            readDataTimer.Stop();
            sendRpmDataTimer.Stop();
            sendSpeedDataTimer.Stop();
            sendFuelDataTimer?.Stop();
            sendGearDataTimer?.Stop();
        }

        private void OnReadDataTimerElapsed(object sender, ElapsedEventArgs e)
        {
            readDataForUIAndBoard();
        }

        private void OnRpmDataTimerElapsed(object sender, ElapsedEventArgs e)
        {
            SendDataToBoard($"#rpm:{Variables.equivRpmFreq}$");
        }

        private void OnSpeedDataTimerElapsed(object sender, ElapsedEventArgs e)
        {
            SendDataToBoard($"#speed:{Variables.equivKmhFreq}$");
        }

        private void OnFuelDataTimerElapsed(object sender, ElapsedEventArgs e)
        {
            double fuelInterpolationResult = Interpolation.interpolate(Variables.fuel, Variables.FuelTable);
            SendDataToBoard($"#fuel:{Math.Round(fuelInterpolationResult, 1)}$");
        }

        private void OnGearDataTimerElapsed(object sender, ElapsedEventArgs e)
        {
            SendDataToBoard($"#gear:{Variables.gear}$");
        }

        private void readDataForUIAndBoard()
        {
            if (Variables.currentDataSource == DATASOURCE.ASSETO &&
                CheckAssetoRunning.isRunning())
            {
                AssetoIO.tryInitAssetoConnection();

                if (AssetoIO.telemetry.telemetryConnectedSuccess)
                {
                    Physics physics = AssetoIO.telemetry.ReadPhysics();

                    Variables.fuel = Convert.ToInt32(physics.Fuel);
                    Variables.gear = physics.Gear - 1;
                    Variables.rpms = physics.Rpms;
                    Variables.kmh = Math.Round(physics.SpeedKmh, 0);
                }
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

        private void SendDataToBoard(String data)
        {
            var result = _usb.sendDataToBoard(data);

            if (!result.success)
            {
                errorSendingSerialMssage();
            }
        }

        private void errorSendingSerialMssage()
        {
            sendRpmDataTimer.Stop();
            sendSpeedDataTimer.Stop();
            sendFuelDataTimer.Stop();
            sendGearDataTimer.Stop();

            CrossThreadOps.setControlEnabled(buttonConnectPort, true);
            CrossThreadOps.setControlEnabled(buttonDisconnectPort, false);

            //CrossThreadOps.SetControlText(labelInfo, reason);

            Console.WriteLine("ERROR WHILE SENDING DATA TROUGH SERIAL: ");
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
            BoardInitialization();
            AssetoInitialization();

            readDataTimer.Start();
        }

        private void BoardInitialization()
        {
            Console.WriteLine(_usb.connectToBoard());

            if (_usb.isBoardConnected())
            {
                labelBoardStatus.Text = "Board: Connected";

                CrossThreadOps.setControlEnabled(buttonConnectPort, false);
                CrossThreadOps.setControlEnabled(buttonDisconnectPort, true);

                sendRpmDataTimer.Start();
                sendSpeedDataTimer.Start();
                sendFuelDataTimer.Start();
                sendGearDataTimer.Start();
            }
        }

        private void AssetoInitialization()
        {
            if (CheckAssetoRunning.isRunning())
            {
                dataSourceRadioButtonLogic(DATASOURCE.ASSETO);
            }
            else
            {
                dataSourceRadioButtonLogic(DATASOURCE.MANUAL_INPUT);
            }
        }

        private void setUserTextBoxesEnabled(Boolean value)
        {
            textBoxRPM.Enabled = value;
            textBoxKMH.Enabled = value;
            textBoxFuel.Enabled = value;
            textBoxGear.Enabled = value;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopTimers();
            _usb.disconnectBoard();
        }

        private void buttonConnectPort_Click(object sender, EventArgs e)
        {
            BoardInitialization();
        }

        private void dataSourceRadioButtonLogic(DATASOURCE newDataSource)
        {
            Variables.currentDataSource = newDataSource;

            if (Variables.currentDataSource == DATASOURCE.ASSETO)
            {
                setUserTextBoxesEnabled(false);
                radioAssetoData.Checked = true;
                radioManualInput.Checked = false;
            }
            else if (Variables.currentDataSource == DATASOURCE.MANUAL_INPUT)
            {
                setUserTextBoxesEnabled(true);
                radioAssetoData.Checked = false;
                radioManualInput.Checked = true;
            }
        }

        private void buttonDisconnectPort_Click(object sender, EventArgs e)
        {
            sendRpmDataTimer.Stop();
            sendSpeedDataTimer.Stop();
            sendFuelDataTimer.Stop();
            sendGearDataTimer.Stop();

            _usb.disconnectBoard();

            labelBoardStatus.Text = "Board: Disconnected";

            CrossThreadOps.setControlEnabled(buttonConnectPort, true);
            CrossThreadOps.setControlEnabled(buttonDisconnectPort, false);
        }

        private void FormTimer_Tick(object sender, EventArgs e)
        {
            updateFormTextboxes();
        }

        private void radioAssetoData_Click(object sender, EventArgs e)
        {
            AssetoInitialization();
        }

        private void radioManualInput_Click(object sender, EventArgs e)
        {
            dataSourceRadioButtonLogic(DATASOURCE.MANUAL_INPUT);
        }

        private void radio10KRedLineMatchMaxPw_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}