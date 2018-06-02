using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHub.util
{
    public class RedisManager
    {
        private RedisManager() { }

        private static ConnectionMultiplexer instance;
        private static readonly object locker = new object();

        public static string url;

        public static ConnectionMultiplexer Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                        if (instance == null)
                        {
                            instance = ConnectionMultiplexer.Connect(url);
                        }
                }
                return instance;
            }
        }

    }
}
