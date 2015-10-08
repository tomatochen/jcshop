using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JC.Models
{
    public class Menu
    {
        public string ID { get; set; }
        public string PID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        public string Url { get; set; }

        public bool IsParent { 
            get {
                if (ChildMenu.Count > 0)
                {
                    return true;
                }else
                { 
                    return false; 
                }
            } 
        }
        public bool isChild { get; set; }
        public List<Menu> ChildMenu;
        public Menu()
        {
            ChildMenu = new List<Menu>();
            this.isChild = false;
        }

        public Menu(string id,string pid,string name,string icon,string url):this()
        {
            this.ID = id;
            this.PID = pid;
            this.Name = name;
            this.Icon = icon;
            this.Url = url;
        }

        public void AddChild(string id,string name,string icon,string url)
        {
            Menu model = new Menu();
            model.ID = id;
            model.PID = this.PID;
            model.Name = name;
            model.Icon = icon;
            model.Url = url;
            model.isChild = true;
            ChildMenu.Add(model);
        }
    }
}