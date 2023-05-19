using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Zena.ZKTeco;
using Zena.ZKTeco.Forms;

namespace ZenaZKTecoDesktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
        Random rnd = new Random();
        private void DonwloadLogsButton_Click(object sender, EventArgs e)
        {
            if (!Connected())
                return;
            try
            {
                Cursor = Cursors.WaitCursor;

                var logs = ZkemHelpers.ReadAllGLogData(ZKTecoGlobal.Zkem);
                if (!logs.Any())
                    return;

                using (var dialog = new SaveFileDialog
                {
                    Filter = "DAT File |*.dat"
                })
                {
                    dialog.FileName = $"{logs.FirstOrDefault().DeviceName}_{DateTime.Now:MMddyyyHHmmss}.dat";

                    if (dialog.ShowDialog() != DialogResult.OK)
                        return;

                    using (StreamWriter writer = new StreamWriter(dialog.FileName))
                    {
                        foreach (var item in logs)
                        {
                            int userIdNum = item.UserIdNum;
                            string logDateTime = $"{item.LogDateTime:yyyy-MM-dd HH:mm:ss}";
                            const int value3 = 1;
                            const int value4 = 255;
                            const int value5 = 1;
                            const int value6 = 0;

                            string line = $"{userIdNum,2}\t{logDateTime.PadRight(19)}\t{value3}\t{value4}\t{value5}\t{value6}";
                            writer.WriteLine(line);
                        }
                    }
                    MessageBox.Show($"Successfully downloaded at {dialog.FileName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show($"Something went wrong!\n\n{ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ClearAdministratorsButton_Click(object sender, EventArgs e)
        {
            if (!Connected())
                return;

            var result = ZKTecoGlobal.Zkem.ClearAdministrators();

            if (result)
            {
                MessageBox.Show("done");
            }
        }

        private bool Connected()
        {
            if (!ZKTecoGlobal.Connected)
            {
                using (var form = new ZKTecoDeviceConnectForm())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        return ZKTecoGlobal.Connected;
                    }
                }
            }
            return ZKTecoGlobal.Connected;
        }

        }
    }
}
