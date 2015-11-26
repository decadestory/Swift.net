using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Net.Base;

namespace Swift.Demo.Entity
{
    public class DemoEntity : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Nric { get; set; }
        public int Age { get; set; }
        public float Height { get; set; }
        public int Sex { get; set; }
    }
}
