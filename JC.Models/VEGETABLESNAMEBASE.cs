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
    
    public partial class VEGETABLESNAMEBASE
    {
        public System.Guid GUID { get; set; }
        public string VEGETABLESNAME { get; set; }
        public string VEGETABLESDES { get; set; }
        public string BIGUNIT { get; set; }
        public string SMALLUNIT { get; set; }
        public Nullable<System.Guid> TYPEID { get; set; }
        public string TYPENAME { get; set; }
        public string BIGIMAGEURL { get; set; }
        public string SMALLIMAGEURL { get; set; }
        public Nullable<int> PACKRULE { get; set; }
        public string REMARK { get; set; }
        public string CREATEUSERNAME { get; set; }
        public Nullable<System.DateTime> CREATEDATETIME { get; set; }
        public Nullable<System.Guid> CREATEUSERID { get; set; }
        public int ISDELETED { get; set; }
        public string DELETEUSER { get; set; }
        public Nullable<System.DateTime> DELETEDATE { get; set; }
        public Nullable<decimal> SEQUENCE { get; set; }
        public string BUSINESSAREANAMES { get; set; }
        public string BUSINESSAREAIDS { get; set; }
    }
}
