using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MessageHub.util
{
   public static class JsonHelperUtil
    {
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

        /// <summary>
        /// JsonEncodeTo Dictionary
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static Dictionary<string, string> JsonStringToDic(string json)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

        }
        /// <summary>
        /// Dictionary DecodeToJson
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static  string DicToJsonStr(IEnumerable<KeyValuePair<string, string>> dic)
        {
            return JsonConvert.SerializeObject(dic);
        }

        

    }
}
