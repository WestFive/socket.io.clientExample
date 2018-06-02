using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageHub.Model.Message
{
    public class MessageCUR
    {
        public string poolName { get; set; }

        public Message message { get; set; }

        public MessageCUR(string poolName,Message message)
        {
            this.poolName = poolName;
            this.message = message;
        }

    }
}
