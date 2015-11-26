using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Swift.Net.Core
{
    public class SDbSession
    {
        public static SContext Current()
        {
            var db = (SContext)CallContext.GetData("Dbcontext");
            if (db == null)
            {
                db = new SContext();
                CallContext.SetData("Dbcontext", db);
            }

            return db;  
        }
    }
}
