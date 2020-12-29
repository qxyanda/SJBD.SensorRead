using SensorRead.Entities;
using SJBD.SensorRead.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SensorRead
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            SensorReadController sensorReadController = new SensorReadController();
            Msg msg = sensorReadController.GetData();
            tb_Msg.Text = msg.ToString();
        }
    }
}
