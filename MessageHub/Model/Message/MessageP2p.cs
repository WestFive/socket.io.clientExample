using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageHub.Model.Message
{
    public class MessageP2p
    {

        /// <summary>
        /// 点对点消息接收者
        /// </summary>
        public string receiver { get; set; }



        /// <summary>
        /// 消息内容
        /// </summary>
        public string msg { get; set; }


        public MessageP2p(string receiver,string msg)
        {
            this.receiver = receiver;
            this.msg = msg;
        }

    }
}
