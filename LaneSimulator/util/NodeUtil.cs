using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LaneDataSimulator.util
{
    public class NodeUtil
    {      
        public void AddChildNode(TreeNode node)
        {
            Dictionary<string, dynamic> dic = new Dictionary<string, dynamic>();
            try
            {
                dic = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(JsonConvert.SerializeObject(node.Tag));
            }catch(JsonSerializationException)
            {
                 dic = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>((string)node.Tag);
            }

            foreach (var item in dic)
            {
                TreeNode child = new TreeNode();
                child.Tag = item.Value == null ? "" : item.Value;               
                child.Text = item.Key;
                child.Name = Guid.NewGuid().ToString();


                AddChildArrayNode(child);
                node.Nodes.Add(child);
               

            }
        }

        public void AddChildArrayNode(TreeNode node)
        {
            int i = 0;

            if (null != node.Tag && node.Tag.GetType().FullName == "Newtonsoft.Json.Linq.JArray")
            {
                foreach (var childitem in (JArray)node.Tag)
                {
                    TreeNode child = new TreeNode();
                    child.Text = i++.ToString();
                    child.Tag = childitem;
                    child.Name = Guid.NewGuid().ToString();               
                    AddChildNode(child);
                    node.Nodes.Add(child);
                  

                }
            }
        }



        public dynamic updateChildKeyValueToRoot(string fullpath, string value, dynamic root)
        {
            dynamic temp = root;
            List<string> counts = fullpath.Split("\\".ToArray()).ToList();

            if (counts.Count == 1)
            {
                root = value;
                return root;
            }
            else if (null != root[counts.Last()])
            {
                root[counts.Last()] = value;
                return root;
            }
            else
            {
                counts.Remove(counts.FirstOrDefault());              


            }



            return null;
        }
    }

}
