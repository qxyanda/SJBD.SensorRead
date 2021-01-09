using System;
using System.Windows.Forms;
using SensorRead.Entities;
using SensorRead.Services;

namespace SJBD.SensorRead.Controllers
{

    public class SensorReadController
    {
        public SensorDataRead sensorDataRead = new SensorDataRead();
        Msg msg = new Msg();
        public int[] GetData()
        {
            int[] sensorData = new int[sensorDataRead.quantity_30000 + sensorDataRead.quantity_40000];

            if (sensorDataRead.Connect())
            {
                msg.code = 200;
                msg.msg = "成功";
                sensorData = sensorDataRead.Read();
                msg.data = sensorData.ToString();
            }
            else
            {
                msg.code = 400;
                msg.msg = "失败";
                msg.data = sensorDataRead.retData;
            }

            Console.WriteLine(msg.data);
            return sensorData;
        }

        public int[] GetData(bool isConnected)
        {
            int[] sensorData = new int[sensorDataRead.quantity_30000 + sensorDataRead.quantity_40000];

            if (isConnected)
            {
                msg.code = 200;
                msg.msg = "成功";
                sensorData = sensorDataRead.Read();
                msg.data = sensorData.ToString();
            }

            Console.WriteLine(msg.data);
            return sensorData;
        }


    }
}