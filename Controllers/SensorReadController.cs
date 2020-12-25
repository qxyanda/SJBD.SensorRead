using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using SensorRead.Entities;
using SensorRead.Services;

namespace SJBD.SensorRead.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorReadController : ControllerBase
    {
        private readonly ILogger<SensorReadController> _logger;

        public SensorReadController(ILogger<SensorReadController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Msg GetData()
        {
            SensorDataRead sensorDataRead = new SensorDataRead();
            Msg msg = new Msg();
            int[] sensorData = new int[sensorDataRead.quantity];

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
            return msg;
        }

    }
}