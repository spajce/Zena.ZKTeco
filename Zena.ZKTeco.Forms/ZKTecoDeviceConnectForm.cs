using System;
using System.Windows.Forms;

namespace Zena.ZKTeco.Forms
{
    public partial class ZKTecoDeviceConnectForm : Form
    {
        private bool cancel;

        public ZKTecoDeviceConnectForm()
        {
            InitializeComponent();

            IPAddressTextEdit.Font = this.Font;
        }

        private void ZKTecoDeviceConnectForm_Load(object sender, EventArgs e)
        {
#if DEBUG
            IPAddressTextEdit.Text = "192.168.88.22";
            PasswordTextEdit.Text = "1234";
#else
            IPAddressTextEdit.Text = Properties.Settings.Default.IPAddress;
            PortTextBox.Text = Properties.Settings.Default.Port.ToString();
            MachineNumTextBox.Text = Properties.Settings.Default.MachineNum.ToString();
            PasswordTextEdit.Text = Properties.Settings.Default.Password.ToString();
#endif

        }

        private void ZKTecoDeviceConnectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = cancel;
            cancel = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                // Search device
                //ZkemHelpers.SearchDevice(new Zkem());
                //string ipAddress = string.Empty;
                //new Zkem().GetDeviceIP(1, ref ipAddress);


                // Try Ping first
                var isPinged = ZkemHelpers.PingIpAddress(IPAddressTextEdit.Text);

                if (!isPinged)
                {
                    MessageBox.Show("Cannot connect to device. Please make sure the device is connected on the network.");
                    cancel = true;
                    return;
                }

                // Note: Using the default Machine Number and Port of the device.
                // Port: 4370
                // Machine Number: 1
                var zkem = new Zkem()
                {
                    CommPassword = int.Parse(PasswordTextEdit.Text),
                    CommPort = int.Parse(PortTextBox.Text),
                };

                ZKTecoGlobal.Connected = zkem.Connect_Net(IPAddressTextEdit.Text);
                ZKTecoGlobal.Zkem = zkem;

                if (ZKTecoGlobal.Connected)
                {
                    int machineNum = int.Parse(MachineNumTextBox.Text);

                    var deviceInfo = ZkemHelpers.GetDeviceInfo(ZKTecoGlobal.Zkem, machineNum);

                    zkem.MachineNumber = machineNum;

                    MessageBox.Show("Sucessfully connected:\n\n" +
                        $"IP Address: {IPAddressTextEdit.Text}\n" +
                        $"Users: {deviceInfo.Users}\n" +
                        $"Attendance Logs: {deviceInfo.AttendanceLogs}\n" +
                        $"Platform: {deviceInfo.Platform}\n" +
                        $"Serial: {deviceInfo.SerialNumber}");

                    Properties.Settings.Default.IPAddress = IPAddressTextEdit.Text;
                    Properties.Settings.Default.Port = int.Parse(PortTextBox.Text);
                    Properties.Settings.Default.MachineNum = machineNum;
                    Properties.Settings.Default.Save();

                    cancel = false;
                }
                else
                {
                    MessageBox.Show("Invalid credentials. Please check the IP Address, Password (Comm Key), Machine Number (Device ID) and Port of the device.\n" +
                        "The device default value:\n" +
                        "Machine Number (Device ID): 1\n" +
                        "Port: 4370");
                    cancel = true;
                }
            }
            catch (Exception ex)
            {
                cancel = true;
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
