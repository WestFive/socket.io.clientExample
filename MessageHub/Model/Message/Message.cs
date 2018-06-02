using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageHub.Model.Message
{
   public  class Message
    {
        
        public string key { get; set; }

        public string value { get; set; }

        public string createTime { get; set; }

        public string updateTime { get; set; }


        public Message(string key,string value,string createTime,string updateTime)
        {
            this.key = key;
            this.value = value;
            this.updateTime = updateTime;
            this.createTime = createTime;
        }
    }
}
