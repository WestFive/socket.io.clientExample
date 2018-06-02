using MessageHub.Model.Message;
using MessageHub.util;
using MessageHub.Model;
using Newtonsoft.Json;
using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageHub
{
    public class MessageHubClient:IDisposable
    {
        public string HubAddress { get; set; }
        #region HubReciveMessageCallBack
        public delegate void ReciveMessage(string str);
        /// <summary>
        /// 接收消息的回调
        /// </summary>
        public event ReciveMessage reciveMessage;
        #endregion
        #region HubStatusCallBack
        /// <summary>
        /// 接收状态的回调：例如连接成功
        /// </summary>
        /// <param name="str"></param>
        public delegate void ReciveStatus(string str);
        public event ReciveStatus reciveStatus;
        #endregion
        #region HubErrorCallBack
        /// <summary>
        /// 接收hub错误。
        /// </summary>
        public delegate void HubError(string str);
        public event HubError reciveHubError;
        #endregion

        public string laneCode;

        public string apiAddress { get; set; }




        /// <summary>
        /// CreateHub
        /// </summary>
        /// <param name="HubAddress">地址</param>
        /// <param name="HubMethod">名称</param>
        /// <param name="HubParams">参数例如：传入一个Dictionary dic = {{"Name","xiamenxxxxx"},{"Type","client"}}</param>
        public MessageHubClient(string HubAddress, string apiAddress, string laneCode)
        {


            this.HubAddress = HubAddress;
            this.laneCode = laneCode;

            RedisManager.url = HubAddress;

            this.apiAddress = apiAddress;

        }
        Socket socket;
        public void HubInit()
        {
            try
            {
                socket = IO.Socket(HubAddress);

                socket.On(Socket.EVENT_CONNECT, (data) =>
                {
                    socket.Emit("authentication", (data1) =>
                    {


                        reciveStatus?.Invoke(convertData(data1));
                    }, JsonConvert.SerializeObject(new ConnectionCreate(laneCode, laneCode)));

                });

                socket.On(laneCode, (data) =>
                {
                    
                    reciveMessage?.Invoke(convertData(data));
                });

                //var redis = RedisManager.Instance.GetSubscriber();
                //redis.SubscribeAsync(laneCode, (chanel, message) =>
                //{
                //    reciveMessage?.Invoke(message);
                //});

                //var db = RedisManager.Instance.GetDatabase();
                //db.PublishAsync(laneCode, "监听注册登陆成功");
            }
            catch (Exception ex)
            {
                reciveStatus?.Invoke("消息客户端出现错误" + ex.ToString());
            }
        }


        /// <summary>
        /// SimulatorLaneSendMes
        /// </summary>
        public void AddMessage(MessageCUR messagecreate)
        {


            try
            {
                socket.Emit("createMessage", (data) =>
                {
                    reciveStatus?.Invoke(convertData(data));
                }, JsonConvert.SerializeObject(messagecreate));
            }
            catch (Exception ex)//尝试用API的方式发送
            {
                string url = apiAddress + "/addMessage";
                dynamic str = WebApi.Post(url, JsonConvert.SerializeObject(messagecreate));
                reciveStatus?.Invoke(convertData(str));

            }

        }






        private string convertData(object obj)
        {
            if (obj.GetType().FullName == "Newtonsoft.Json.Linq.JObject")
            {
                string strobj = JsonConvert.SerializeObject(obj);
                return strobj;
            }
            return (string)obj;
        }


        public void deleteMessage(MessageD messageDel)
        {
            try
            {
                socket.Emit("deleteMessage", (data) =>
                {
                    reciveStatus?.Invoke(JsonConvert.SerializeObject(data));
                }, JsonConvert.SerializeObject(messageDel));
            }
            catch (Exception ex)
            {
                string url = apiAddress + "/deleteMessage";
                dynamic str = WebApi.Post(url, JsonConvert.SerializeObject(messageDel));
                reciveStatus?.Invoke(convertData(str));
            }

        }

        public void sendP2pMessge(MessageP2p message)
        {
            string url = apiAddress + "/p2pMessage";
            Console.WriteLine(message.receiver);
            dynamic str = WebApi.Post(url, JsonConvert.SerializeObject(message));
            reciveStatus?.Invoke(convertData(str));
        }



        public void Dispose()
        {
            socket.Close();
            socket.Disconnect();            
        }
    }
}

