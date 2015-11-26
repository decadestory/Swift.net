using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Swift.Net.Base;

namespace Swift.Demo.Entity.Mapper
{
    public class DemoEnityMapper : BaseMap<DemoEntity>
    {
        public override void Init()
        {
           ToTable("DemoEntity");
           HasKey(m => m.Id);
        }

    }
}
