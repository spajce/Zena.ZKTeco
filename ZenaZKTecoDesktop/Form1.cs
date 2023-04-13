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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var form = new ZKTecoDeviceConnectForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var logs = ZkemHelpers.ReadAllGLogData(ZKTecoGlobal.Zkem);
                    //var users = ZkemHelpers.GetAllUserInfo(ZKTecoGlobal.Zkem);

                  
                }
            }
        }
    }
}
