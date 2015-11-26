using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using Swift.Net.Share;

namespace Swift.Net.Core
{

    public class SContext : DbContext
    {
        public SContext()
            : base("DbConnection")
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            //Database.SetInitializer(new CreateDatabaseIfNotExists<SContext>());
            Database.SetInitializer<SContext>(null);
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            try
            {
                foreach (var type in GetTypes())
                {
                    dynamic configurationInstance = Activator.CreateInstance(type);
                    modelBuilder.Configurations.Add(configurationInstance);
                }
                base.OnModelCreating(modelBuilder);
                Logger.Info("DbContext初始化成功！");
            }
            catch (Exception ex)
            {
                Logger.Error("DbContext初始化失败:" + ex.Message);
            }
        }

        private IEnumerable<Type> GetTypes()
        {
            if (CallContext.GetData("CacheTypes") != null) CallContext.GetData("CacheTypes");

            var entityAssembly = ConfigurationManager.AppSettings["SwiftEntityAssembly"];
            var ts = Assembly.Load(entityAssembly).GetTypes();
            var types = ts.Where(t => t.FullName.EndsWith("Mapper"));
            CallContext.SetData("CacheTypes", types);
            return types;
        }

    }
}
