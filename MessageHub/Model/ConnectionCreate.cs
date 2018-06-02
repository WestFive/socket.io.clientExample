using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageHub.Model
{
    public class ConnectionCreate
    {
        public string clientCode;
        public string clientName;


        public ConnectionCreate(string clientCode,string clientName)
        {
            this.clientCode = clientCode;
            this.clientName = clientName;
        }
    }
}
