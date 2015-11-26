using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Core;

namespace Swift.Core
{
    public partial class SContext
    {

        public DbSet<object> Admins { set; get; }
    }
}
