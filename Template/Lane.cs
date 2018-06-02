using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TempLate
{
    public class Lane
    {

        public string laneCode { get; set; }

        public string laneName { get; set; }

        public string laneType { get; set; }

        public bool laneStatus { get; set; }
        
        public string direction { get; set; }

        public bool hasVehicle { get; set; }

        public string kioskLedDisplay { get; set; }

        public string topLedDisplay { get; set; }

        public string barrierStatus { get; set; }

        public List<Device> devices { get; set; }

        public string updateTime { get; set; }
    }

    public class Device
    {
        public string deviceCode { get; set; }

        public string deviceNameg { get; set; }

        public string deviceType { get; set; }

        public string connectionType { get; set; }

        /// <summary>
        /// Ip或者端口号
        /// </summary>
        public string occupiedResource { get; set; }

        public bool isActivated { get; set; }

        /// <summary>
        /// 状态 ： 正常|异常
        /// </summary>
        public string deviceStatus { get; set; }

        public string updateTime { get; set; }
    }


}
