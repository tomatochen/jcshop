using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JC.Models
{

    public class TModel
    { 
        public string name { get; set; }
        public int nan { get; set; }
        public int nv { get; set; }
        public int Sum
        {
            get
            {
                return nan + nv;
            }
        }
        public TModel()
        {
            nan = 0;
            nv = 0;
        }
        public TModel(string n)
            : this()
        {
            name = n;
        }
    }

}