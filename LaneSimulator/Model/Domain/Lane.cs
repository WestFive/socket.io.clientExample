using LaneSimulator.Model.Msg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneSimulator.Model.Domain
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
}
