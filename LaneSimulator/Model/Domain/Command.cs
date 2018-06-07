using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneSimulator.Model.Domain
{
   public  class Command
    {

        public string commandCode { get; set; }

        public string commandName { get; set; }
        
        public string senderCode { get; set; }

        public string senderName { get; set; }

        public string recipientType { get; set; }

        public string recipientCode { get; set; }

        public object parameter { get; set; }

        public string sendTime { get; set; }


    }

}
