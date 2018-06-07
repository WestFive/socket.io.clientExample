using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MessageHub.util
{

    public class WebApi
    {
        public static dynamic Get(string url, Dictionary<string, string> dic = null)
        {
            

            var client = new RestSharp.RestClient(url);
            var request = new RestSharp.RestRequest(RestSharp.Method.GET);
            try
            {

                if (dic != null)
                {
                    foreach (var item in dic)
                    {
                        request.AddQueryParameter(item.Key, item.Value);
                    }
                }

                request.AddHeader("header", "Accept: application/json");
                RestResponse response = (RestResponse)client.Execute(request);
                var content = response.Content;
                return content;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                client.ClearHandlers();
            }


        }
        public enum PostType
        {
            File,
            Body,
            QueryString,
            Parms,
            Picture
        }

        //Post method parms可选
        //
        public static dynamic Post(string url, dynamic parms, PostType type)
        {
            Dictionary<string, dynamic> dic = null;
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                switch (type)
                {
                    case PostType.Picture:
                        if (parms.GetType() == typeof(Dictionary<string, dynamic>))
                        {
                            dic = parms;
                        }
                        else
                        {
                            dic = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(parms);
                        }
                        foreach (var item in dic)
                        {
                            if (item.Key == "file")
                            {
                                request.AddFile(item.Key, item.Value);
                            }
                            else
                            {
                                request.AddParameter(item.Key, item.Value);
                            }
                        }
                        break;
                    case PostType.QueryString:
                        break;
                    case PostType.Body:
                        request.AddHeader("Content-Type", "application/json");
                        request.AddHeader("charset", "UTF-8");
                        //request.AddQueryParameter("message", parms);
                        request.AddBody(parms);
                        break;
                    case PostType.Parms:
                        dic = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(parms);
                        foreach (var item in dic)
                        {
                            request.AddParameter(item.Key, item.Value);
                        }
                        break;
                }
                RestResponse res = (RestResponse)client.Execute(request);
                return res.Content;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }



        public static string Post(string url, string param,string method="POST")
        {
            string strURL = url;
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            request.Method = method;
            request.ContentType = "application/json";
            string paraUrlCoded = param;
            byte[] payload;
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            request.ContentLength = payload.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(payload, 0, payload.Length);
            writer.Close();
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            string StrDate = "";
            string strValue = "";
            StreamReader Reader = new StreamReader(s, Encoding.UTF8);
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate + "\r\n";
            }
            return strValue;

        }



    }
}

