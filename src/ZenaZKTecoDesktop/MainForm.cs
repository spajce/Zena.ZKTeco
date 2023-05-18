using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zena.ZKTeco.Forms;
using Zena.ZKTeco;

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

        private void DonwloadLogsButton_Click(object sender, EventArgs e)
        {
            using (var form = new ZKTecoDeviceConnectForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var logs = ZkemHelpers.ReadAllGLogData(ZKTecoGlobal.Zkem);
                    //var users = ZkemHelpers.GetAllUserInfo(ZKTecoGlobal.Zkem);

                    dataGridView1.DataSource = logs;
                }
            }
        }
    }
}
