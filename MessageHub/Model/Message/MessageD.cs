using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageHub.Model.Message
{
    public class MessageD
    {
        public string poolName { get; set; }

        public string messageKey { get; set; }


       public MessageD(string poolName,string messageKey)
        {
            this.poolName = poolName;
            this.messageKey = messageKey;
        }

    }
}
