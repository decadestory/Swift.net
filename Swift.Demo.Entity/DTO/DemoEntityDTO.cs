using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Net.Base;

namespace Swift.Demo.Entity.DTO
{
    [NotMapped]
    public class DemoEntityDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
