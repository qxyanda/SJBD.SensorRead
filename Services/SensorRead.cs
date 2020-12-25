using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyModbus;

namespace DoorControl.Services
{
    public class SensorRead
    {
        string ip = "";
        int port = 502;
        public bool Connect()
        {
            ModbusClient modbusClient = new ModbusClient();
            modbusClient.IPAddress = ip;
            modbusClient.Port = port;
            return modbusClient.Connect();
        }
    }
}
