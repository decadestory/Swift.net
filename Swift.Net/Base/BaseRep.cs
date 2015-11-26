using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Net.Core;

namespace Swift.Net.Base
{
    public class BaseRep<TEntity> where TEntity : BaseEntity
    {
        protected SContext EfContext
        {
            get
            {
                return SDbSession.Current();
            }
        }

        protected int Commit()
        {
            return EfContext.SaveChanges();
        }

        protected IEnumerable<TEntity> ExecuteQuery(string sql)
        {
            return EfContext.Database.SqlQuery<TEntity>(sql).ToList();
        }

        protected int ExecuteSql(string sql)
        {
            return EfContext.Database.ExecuteSqlCommand(sql);
        }

        protected int ExecuteCount(string sql)
        {
            var source = EfContext.Database.SqlQuery<int>(sql);
            return source.FirstOrDefault();
        }
    }
}
