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
using System.Linq;

namespace SensorRead
{
    public partial class FormMain : Form
    {
        public string connectStr = "server=49.232.51.71;port=8400;user=root;password=root; database=cam;";
        
        public FormMain()
        {
            InitializeComponent();
            Log.Info("启动成功");
            Log.Error("启动成功","ww");
            //MessageBox.Show("qi");
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            connectStr = cbConnect.SelectedItem.ToString();
            btn_Read.Enabled = false;
            btn_Stop.Enabled = true;
            Thread th = new Thread(new ThreadStart(Read));
            th.Start();

        }
        public void Read()
        {
        ReRead:

                MySqlConnection conn = new MySqlConnection(connectStr);
                string sql = "";
                string dataCombine = "";

                SensorReadController sensorReadController = new SensorReadController();
                int q = sensorReadController.sensorDataRead.quantity_30000 + sensorReadController.sensorDataRead.quantity_40000;
                int[] data = new int[q];
                string[] dataDouble = new string[q];
            try
            {
                data = sensorReadController.GetData();
                DataHandle(dataDouble, data, q);
                sql = SqlMake(dataCombine, dataDouble, conn, q);

                tb_Msg.Clear();
                tb_Msg.AppendText("Retrying...");
                TbShow(sql, data);
            }
            catch(Exception e)
            {
                Log.Info($"{e}");
                goto ReRead;
            }

            while (btn_Stop.Enabled)//
            {
                if (btn_Stop.Enabled == false) break;
                Thread.Sleep(500);
                try
                {
                    data = sensorReadController.GetData(btn_Stop.Enabled);
                    DataHandle(dataDouble,data,q);
                    sql = SqlMake(dataCombine, dataDouble, conn, q);

                    tb_Msg.Clear();
                    tb_Msg.AppendText("Continue...");
                    TbShow(sql, data);

                }
                catch (Exception e)
                {
                    Log.Info($"{e}");
                    goto ReRead; 
                }
                
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
            MySqlConnection conn = new MySqlConnection(connectStr);
            string sql = "";
            sql = "UPDATE t_monitor_probe SET register_data = (CASE data_address WHEN 3 THEN '2' WHEN 2 THEN '3' END )";
            SqlEx(conn, sql);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            cbConnect.SelectedIndex = 0;
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
        private void DataHandle(string[] dataDouble,int[] data,int q)
        {
            for (int i = 0; i < q; i++)
            {
                if (i == 0 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 1 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 2 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 3 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 4 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 5 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 6 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 7) dataDouble[i] = ((double)data[i] / 13107 - 1).ToString("F4");
                if (i == 8) dataDouble[i] = ((double)data[i] / 13107 - 1).ToString("F4");
                if (i == 9) dataDouble[i] = (((double)data[i] / 524.28 - 25) * 0.771).ToString("F4");
                if (i == 10 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 11 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 12 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 13 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 14 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 15 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 16 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 17 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 18 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 19 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 20 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 21) dataDouble[i] = ((double)data[i] / 13107 - 1).ToString("F4");
                if (i == 22) dataDouble[i] = ((double)data[i] / 13107 - 1).ToString("F4");
                if (i == 23 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 24 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 25 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 26 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 27 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 28 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 29 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 30 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 31 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 32 && data[i] != 0) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 33) dataDouble[i] = ((double)data[i]).ToString("F0");
                if (i == 34) dataDouble[i] = ((double)data[i]).ToString("F0");
                if (i == 35) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 36) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 37) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 38) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 39) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 40) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 41) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 42) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 43) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 44) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 45) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 46) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 47) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 48) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 49) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
                if (i == 50) dataDouble[i] = ((double)data[i] / 10).ToString("F1");
            }
        }
        string lastSql = "";
        string sql = "";
        private string SqlMake(string dataCombine,string[] dataDouble, MySqlConnection conn,int q)
        {
            if(!string.IsNullOrEmpty(sql))
            lastSql = sql;
            sql = "UPDATE t_monitor_probe SET register_data = (CASE data_address";
            dataCombine = "";
            for (int i = 0; i < q; i++)
            {
                dataCombine += " WHEN ";
                dataCombine += i;
                dataCombine += " THEN ";
                dataCombine += dataDouble[i];
                if (double.Parse(dataDouble[i]) == 0)
                {
                    if (i != 2 && i != 7 && i != 8 && i != 9 && i != 10 && i != 11 && i != 12 && i != 21 && i != 22 && i < 33)
                        textBoxError.AppendText(DateTime.Now.ToString()+":["+i.ToString()+"]:"+ dataDouble[i]+"\r\n");
                }
            }

            sql += dataCombine;
            sql += " END )";

            bool isNotNull = false;
            for(int i = 0; i < q; i++)
            {
                if(double.Parse(dataDouble[i]) == 0)
                {
                    if (i != 2 && i != 7 && i != 8 && i != 9 && i != 10 && i != 11 && i != 12 && i != 21 && i != 22 && i < 33)
                        isNotNull = true;
                    break;
                }
            }
            //test
            //SqlEx(conn, sql);
            if (!isNotNull)
            {
                SqlEx(conn, sql);
            }
            else
            {
                SqlEx(conn, lastSql);
            }
            
            return sql;
        }

        private void TbShow(string sql, int[] data)
        {
            tb_Msg.AppendText("\r\n");
            tb_Msg.AppendText(sql);
            tb_Msg.AppendText("\r\n");
            tb_Msg.AppendText("\r\n");
            DataShow(data);
        }
    }
}
