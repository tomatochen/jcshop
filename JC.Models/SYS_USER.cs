//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace JC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SYS_USER
    {
        public System.Guid USERID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string FULLNAME { get; set; }
        public string SHORTNAME { get; set; }
        public Nullable<int> DEPTID { get; set; }
        public string DEPTNAME { get; set; }
        public string ALLOWLOGIN { get; set; }
        public Nullable<int> SEQUENCE { get; set; }
        public Nullable<System.DateTime> LASTTIME { get; set; }
        public Nullable<int> ROLEID { get; set; }
        public string ROLENAME { get; set; }
        public string QQ { get; set; }
        public string EMAIL { get; set; }
        public Nullable<int> POSITIONID { get; set; }
        public string POSITIONNAME { get; set; }
        public string MOBILE { get; set; }
        public string REMARK { get; set; }
        public string IP { get; set; }
        public Nullable<int> OPERATORID { get; set; }
        public string OPERATORNAME { get; set; }
        public Nullable<System.DateTime> OPERATEDATE { get; set; }
        public int ISDELETED { get; set; }
        public string DELETEUSER { get; set; }
        public Nullable<System.DateTime> DELETEDATE { get; set; }
        public string HEADLOG { get; set; }
        public string AREANAME { get; set; }
        public Nullable<System.Guid> AREAID { get; set; }
    }
}
