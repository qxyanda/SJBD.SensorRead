using SensorRead.Entities;
using SJBD.SensorRead.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SensorRead
{
    public partial class FormMain : Form
    {
        string connetStr = "server=49.232.51.71;port=8400;user=root;password=root; database=cam;";
        public FormMain()
        {
            InitializeComponent();
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            btn_Read.Enabled = false;
            btn_Stop.Enabled = true;
            Thread th = new Thread(new ThreadStart(Read));
            th.Start();

        }
        public void Read()
        {
        ReRead:
            
            MySqlConnection conn = new MySqlConnection(connetStr);
            string sql = "";
            string dataCombine = "";

            SensorReadController sensorReadController = new SensorReadController();
            int q = sensorReadController.sensorDataRead.quantity_30000 + sensorReadController.sensorDataRead.quantity_40000;
            int[] data = new int[q];
            double[] dataDouble = new double[q];

            data = sensorReadController.GetData();

            for (int i = 0; i < q; i++)
            {
                if (i == 0) dataDouble[i] = (double)data[i] / 1;
                if (i == 1) dataDouble[i] = (double)data[i] / 10;
                if (i == 2) dataDouble[i] = (double)data[i] / 10;
                if (i == 3) dataDouble[i] = (double)data[i] / 10;
                if (i == 4) dataDouble[i] = (double)data[i] / 10;
                if (i == 5) dataDouble[i] = (double)data[i] / 10;
                if (i == 6) dataDouble[i] = (double)data[i] / 10;
                if (i == 7) dataDouble[i] = (double)data[i] / 10;
                if (i == 8) dataDouble[i] = (double)data[i] / 13107 - 1;
                if (i == 9) dataDouble[i] = (double)data[i] / 13107 - 1;
                if (i == 10) dataDouble[i] = (double)data[i] / 524.28 - 25;
                if (i == 11) dataDouble[i] = (double)data[i] / 10;
                if (i == 12) dataDouble[i] = (double)data[i] / 10;
                if (i == 13) dataDouble[i] = (double)data[i] / 10;
                if (i == 14) dataDouble[i] = (double)data[i] / 10;
                if (i == 15) dataDouble[i] = (double)data[i] / 10;
                if (i == 16) dataDouble[i] = (double)data[i] / 10;
                if (i == 17) dataDouble[i] = (double)data[i] / 10;
                if (i == 18) dataDouble[i] = (double)data[i] / 10;
                if (i == 19) dataDouble[i] = (double)data[i] / 10;
                if (i == 20) dataDouble[i] = (double)data[i] / 10;
                if (i == 21) dataDouble[i] = (double)data[i] / 10;
                if (i == 22) dataDouble[i] = (double)data[i] / 10;
                if (i == 23) dataDouble[i] = (double)data[i] / 13107 - 1;
                if (i == 24) dataDouble[i] = (double)data[i] / 13107 - 1;
                if (i == 25) dataDouble[i] = (double)data[i] / 10;
                if (i == 26) dataDouble[i] = (double)data[i] / 10;
                if (i == 27) dataDouble[i] = (double)data[i] / 1;
                if (i == 28) dataDouble[i] = (double)data[i] / 1;
                if (i == 29) dataDouble[i] = (double)data[i] / 1;
                if (i == 30) dataDouble[i] = (double)data[i] / 1;
                if (i == 31) dataDouble[i] = (double)data[i] / 1;
                if (i == 32) dataDouble[i] = (double)data[i] / 1;
                if (i == 33) dataDouble[i] = (double)data[i] / 1;
                if (i == 34) dataDouble[i] = (double)data[i] / 1;
                if (i == 35) dataDouble[i] = (double)data[i] / 10;
                if (i == 36) dataDouble[i] = (double)data[i] / 10;
                if (i == 37) dataDouble[i] = (double)data[i] / 10;
                if (i == 38) dataDouble[i] = (double)data[i] / 10;
                if (i == 39) dataDouble[i] = (double)data[i] / 10;
                if (i == 40) dataDouble[i] = (double)data[i] / 10;
                if (i == 41) dataDouble[i] = (double)data[i] / 10;
                if (i == 42) dataDouble[i] = (double)data[i] / 10;
            }

            DataShow(data);

            while (btn_Stop.Enabled)//
            {
                
                try
                {
                    sql = "UPDATE t_monitor_probe_gai SET register_data = (CASE data_address";
                    dataCombine = "";
                    for (int i = 0; i < q; i++)
                    {
                        dataCombine += " WHEN ";
                        dataCombine += i;
                        dataCombine += " THEN ";
                        dataCombine += dataDouble[i].ToString("F4");
                    }

                    sql += dataCombine;
                    sql += " END )";

                    SqlEx(conn, sql);

                    Thread.Sleep(500);
                    tb_Msg.Clear();
                    
                    if (btn_Stop.Enabled == false) break;
                    data = sensorReadController.GetData(btn_Stop.Enabled);

                    DataShow(data);

                    //tb_Msg.Text = sql;
                }
                catch { goto ReRead; }
                
            }
            sensorReadController.sensorDataRead.modbusClient.Disconnect();
            btn_Stop.Enabled = false;
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            btn_Read.Enabled = true;
            btn_Stop.Enabled = false;
        }

        private void SqlEx(MySqlConnection conn, string sql)
        {
            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
                Console.WriteLine("已经建立连接");
                //在这里使用代码对数据库进行增删查改
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connetStr);
            string sql = "";
            sql = "UPDATE t_monitor_probe_gai SET register_data = (CASE data_address WHEN 3 THEN '2' WHEN 2 THEN '3' END )";
            SqlEx(conn, sql);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            btn_test.Visible = false;
            btn_Stop.Enabled = false;
        }
        private void DataShow(int[] data)
        {
            tb_Msg.AppendText("data:" + data.Length + ":");
            foreach (int sensor in data)
            {
                tb_Msg.AppendText(sensor + ",");
            }
            tb_Msg.AppendText("\r\n");
        }
    }
}
