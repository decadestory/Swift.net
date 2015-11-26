using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Demo.Entity;
using Swift.Net.API;
using Swift.Net.Base;

namespace Swift.Demo.Resp
{
    public class DemoResp : BaseRep<DemoEntity>
    {
        public PaginationResult<DemoEntity> PageList()
        {
            var sql = "select * from DemoEntity";
            var sqlCount = "select count(1) from DemoEntity";
            var list = ExecuteQuery(sql).ToList();
            var count = ExecuteCount(sqlCount);

            return new PaginationResult<DemoEntity> { Total = count, Rows = list };
        }


        public int HandlerBus()
        {
            int result;
            using (var tran = this.EfContext.Database.BeginTransaction())
            {
                try
                {
                    result = ExecuteSql("delete DemoEntity where id='5465'");
                    result = ExecuteSql(@"INSERT INTO [dbo].[DemoEntity] ([Id] ,[Name] ,[Phone] ,[Nric] ,[Age] ,
                        [Height] ,[AddTime] ,[EditTime] ,[Remark] ,[Enable]) VALUES ('0006dc19-5214-4aad-9569-f874c43b7d04' ,
                        'tooo' ,'18961516' ,'316513165651' ,23 ,43 ,getdate() ,getdate() ,'remarkkkk' ,1)"); 
                    tran.Commit();
                }
                catch (Exception)
                {
                    result = 0;
                }
            }
            return result;
        }


    }
}
