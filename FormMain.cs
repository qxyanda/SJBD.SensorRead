﻿using SensorRead.Entities;
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
            MySqlConnection conn = new MySqlConnection(connetStr);
            string sql = "";
            string dataCombine = "";

            SensorReadController sensorReadController = new SensorReadController();
            int[] data = sensorReadController.GetData();
            double[] dataDouble = new double[45];
            for(int i=0;i<45;i++)
            {
                if (i == 0) dataDouble[i] = data[i] / 160 - 25;
                if (i == 1) dataDouble[i] = data[i] / 160 - 25;
                if (i == 2) dataDouble[i] = data[i] / 4000 - 1;
                if (i == 3) dataDouble[i] = data[i] / 4000 - 1;
                if (i == 4) dataDouble[i] = data[i] / 10;
                if (i == 5) dataDouble[i] = data[i] / 10;
                if (i == 6) dataDouble[i] = data[i] / 10;
                if (i == 7) dataDouble[i] = data[i] / 10;
                if (i == 8) dataDouble[i] = data[i] / 10;
                if (i == 9) dataDouble[i] = data[i] / 10;
                if (i == 10) dataDouble[i] = data[i] / 160 - 25;
                if (i == 11) dataDouble[i] = data[i] / 1;
                if (i == 12) dataDouble[i] = data[i] / 10;
                if (i == 13) dataDouble[i] = data[i] / 10;
                if (i == 14) dataDouble[i] = data[i] / 4000 - 1;
                if (i == 15) dataDouble[i] = data[i] / 4000 - 1;
                if (i == 16) dataDouble[i] = data[i] / 10;
                if (i == 17) dataDouble[i] = data[i] / 10;
                if (i == 18) dataDouble[i] = data[i] / 10;
                if (i == 19) dataDouble[i] = data[i] / 10; 
                if (i == 20) dataDouble[i] = data[i] / 10;
                if (i == 21) dataDouble[i] = data[i] / 10;
                if (i == 22) dataDouble[i] = data[i] / 1;
                if (i == 23) dataDouble[i] = data[i] / 10;
                if (i == 24) dataDouble[i] = data[i] / 10;
                if (i == 25) dataDouble[i] = data[i] / 10;
                if (i == 26) dataDouble[i] = data[i] / 10;
                if (i == 27) dataDouble[i] = data[i] / 1;
                if (i == 28) dataDouble[i] = data[i] / 1;
                if (i == 29) dataDouble[i] = data[i] / 1;
                if (i == 30) dataDouble[i] = data[i] / 1;
                if (i == 31) dataDouble[i] = data[i] / 1;
                if (i == 32) dataDouble[i] = data[i] / 1;
                if (i == 33) dataDouble[i] = data[i] / 1;
                if (i == 34) dataDouble[i] = data[i] / 1;
                if (i == 35) dataDouble[i] = data[i] / 10;
                if (i == 36) dataDouble[i] = data[i] / 10;
                if (i == 37) dataDouble[i] = data[i] / 10;
                if (i == 38) dataDouble[i] = data[i] / 10;
                if (i == 39) dataDouble[i] = data[i] / 10;
                if (i == 40) dataDouble[i] = data[i] / 10;
                if (i == 41) dataDouble[i] = data[i] / 10;
                if (i == 42) dataDouble[i] = data[i] / 10;
                if (i == 43) dataDouble[i] = data[i] / 10;
                if (i == 44) dataDouble[i] = data[i] / 10;
            }

            DataShow(data);

            while (btn_Stop.Enabled)
            {
                sql = "UPDATE t_monitor_probe_gai SET register_data = (CASE data_address";
                dataCombine = "";
                for (int i =0; i<45; i++)
                {
                    dataCombine += " WHEN ";
                    dataCombine += i;
                    dataCombine += " THEN ";
                    dataCombine += dataDouble[i].ToString("F2");
                }

                sql += dataCombine;
                sql += " END )";
                SqlEx(conn,sql);

                Thread.Sleep(500);
                tb_Msg.Clear();
                if (btn_Stop.Enabled == false) break;
                data = sensorReadController.GetData(btn_Stop.Enabled);

                DataShow(data);

                //tb_Msg.Text = sql;
            }
            sensorReadController.sensorDataRead.modbusClient.Disconnect();
            btn_Stop.Enabled = false;
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            btn_Read.Enabled = true;
            btn_Stop.Enabled = false;
        }

        private void SqlEx(MySqlConnection conn,string sql)
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
