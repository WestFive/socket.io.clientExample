using MessageHub.Model.Message;
using MessageHub.util;
using MessageHub.Model;
using Newtonsoft.Json;
using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageHub.Model.Pool;

namespace MessageHub
{
    public class MessageHubClient : IDisposable
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
        #region 接收点对点消息
        public delegate void P2pMessage(string str);
        public event P2pMessage reciveP2pMessage;
        #endregion
        public delegate void ServerInfo(string str);
        public event ServerInfo receiveServerInfo;
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
       public  Socket socket;
        public void HubInit()
        {
            try
            {
                socket = IO.Socket(HubAddress);

                socket.On(Socket.EVENT_CONNECT, (data) =>
                {
                    socket.Emit("authentication", (data1) =>
                    {
                        Response res = JsonConvert.DeserializeObject<Response>(data1.ToString());
                        reciveMessage.Invoke(res.message);
                    }, JsonConvert.SerializeObject(new ConnectionCreate(laneCode, laneCode)));

                });

                socket.On(laneCode, (data) =>
                {
                    
                    reciveP2pMessage?.Invoke(data.ToString());
                });

                socket.On(Socket.EVENT_ERROR, (data) =>
                {
                    reciveHubError?.Invoke(convertData(data));
                });
                socket.On(Socket.EVENT_CONNECT_ERROR, (data) =>
                {
                    reciveHubError?.Invoke(data.ToString());
                });
                socket.On("receivePoolInfo", (data) =>
                {
                    receiveServerInfo?.Invoke(data.ToString());

                });

                socket.Emit("listenPool", "laneServer");
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
                    reciveStatus?.Invoke("推送消息服务成功");
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
            Response res = JsonConvert.DeserializeObject<Response>(str);
            reciveMessage?.Invoke(res.message);
        }



        public void Dispose()
        {
            socket.Close();
            socket.Disconnect();
        }
    }
}

