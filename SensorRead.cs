using System;
using System.Linq;
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
        public int quantity = 45;
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
            int[] data = new int[quantity];
            data = modbusClient.ReadInputRegisters(startingAddress, quantity);
            Console.WriteLine(data.ToList());
            return data;
        }
    }
}
