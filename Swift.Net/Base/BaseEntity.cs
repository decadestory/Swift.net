using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Net.Base
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Enable = true;
            AddTime=DateTime.Now;
            EditTime=DateTime.Now;
        }

        public DateTime? AddTime { get; set; }
        public DateTime? EditTime { get; set; }
        public string Remark { get; set; }
        public bool Enable{get; set; }
    }
}
