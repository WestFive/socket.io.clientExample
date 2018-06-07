using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneSimulator.Model.Msg
{
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
