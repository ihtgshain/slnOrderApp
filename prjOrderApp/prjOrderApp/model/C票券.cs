using System;
using System.Collections.Generic;
using System.Text;

namespace prjOrderApp.model
{
    public class C票券
    {
        public int 票券編號 { get; set; }
        public string 座位 { get; set; }
        public string 日期 { get; set; }
        public string 場次 { get; set; }
        public string 票種 { get; set; }
        public string urlIma { get; set; }
        public string 概要 { get; set; } 
        public bool 尚未訂票 { get; set; }
    }
}
