using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EasyModbus;

namespace SensorRead.Services
{
    public class SensorDataRead
    {
        public string retData = "";
        public ModbusClient modbusClient = new ModbusClient();
        public string ip = "172.17.0.100";
        public int port = 502;
        public int startingAddress = 0;
        public int quantity_30000 = 33;
        public int quantity_40000 = 10;
        public bool Connect()
        {
            modbusClient.Connect(ip, port);
            if (modbusClient.Connected)
            {
                retData = "Connected .";
            }
            else
            {
                retData = "Connection Failed .";
            }
            Console.WriteLine(retData);
            return modbusClient.Connected;
        }
        public int[] Read()
        { 

            int[] data = new int[quantity_30000+ quantity_40000];

            int[] data_30000 = new int[quantity_30000];
            int[] data_40000 = new int[quantity_40000];

            data_30000 = modbusClient.ReadInputRegisters(startingAddress, quantity_30000);
            data_40000 = modbusClient.ReadHoldingRegisters(startingAddress, quantity_40000);


            for (int i = 0; i < quantity_30000; i++)
            {
                data[i] = data_30000[i];
            }
            for (int i = 0; i < quantity_40000; i++)
            {
                data[i + quantity_30000] = data_40000[i];
            }

            Console.WriteLine(data.ToList());

            return data;
        }
    }
}
