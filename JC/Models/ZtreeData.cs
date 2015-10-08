using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JC.Models
{
    /// <summary>
    /// 用途
    /// </summary>
    public class ZtreeData
    {
        public string id { get; set; }

        // 父节点编号 
        public string parentId { get; set; }
        public string name { get; set; }
        public string name2 { get; set; }
        //属性值
        public string attributes { get; set; }
        public bool open { get; set; }
        public bool? isParent { get; set; }
        public bool @checked{ get;set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sequence { get; set; }
        public string data { get; set; }
        public string data2 { get; set; }
        //子节点列表 
        public List<ZtreeData> children { get; set; }


        // 添加子节点  
        public void addChild(ZtreeData node)
        {
            if (children == null)
            {
                children = new List<ZtreeData>();
            }
            children.Add(node);
        }
        public void addChild(string name)
        {
            addChild(null, name);
        }
        public void addChild(string id, string name)
        {
            ZtreeData c = new ZtreeData();
            c.id = id;
            c.name = name;
            children.Add(c);
        }
    }

    /// <summary>
    /// add by陈国亮 2014年10月22日 09:25:31
    /// </summary>
    public class ZtreeSimpleData
    {
        public string id { get; set; }
        public string pId { get; set; }
        public string name { get; set; }

        public bool? open { get; set; }


        public bool? isParent { get; set; }

        // 任意辅助变量
        public string data { get; set; }
        public string data2 { get; set; }
    }
}
