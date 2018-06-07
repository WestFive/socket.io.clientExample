using LaneSimulator.Model.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LaneDataSimulator.util
{
    public class JsonUtil
    {

        public Lane LoadLaneFromLocalJson()
        {

            string jsonstr = File.ReadAllText(Application.StartupPath + "/conf/lane.json");

            return JsonConvert.DeserializeObject<Lane>(jsonstr);
        }
        public JobQueue LoadJobQueueFromLocalJson()
        {
            string jsonstr = File.ReadAllText(Application.StartupPath + "/conf/queue.json");

            return JsonConvert.DeserializeObject<JobQueue>(jsonstr);
        }
        public string LoadCommandFromLocalJson()
        {
            string jsonstr = File.ReadAllText(Application.StartupPath + "/conf/command.json");

            return jsonstr;
        }
        public static string ConvertJsonString(string str)
        {
            //格式化json字符串  
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(str);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return str;
            }
        }
    }
}
