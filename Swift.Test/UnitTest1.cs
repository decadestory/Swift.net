using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Swift.Demo.Entity;
using Swift.Demo.Resp;
using Swift.Demo.Svc;
using Swift.Net.Base;
using Swift.Net.Share;
using Swift.Test.Bootstrapper;

namespace Swift.Test
{
    [TestClass]
    public class UnitTest1: BaseSvc<DemoEntity>
    {
        [TestMethod]
        public void TestMethod1()
        {
            AutoMapperInstaller.Install();
            var svc = new DemoSvc();
            var obj = new DemoEntity
            {
                Name = "jerry",
                Nric = "32148461641649616",
                Phone = "189615645",
                Age = 1111,
                Height = 234,
                Sex = 1,
                Remark = "这是一个备注",
            };
            var res = svc.AddEntity(obj);

            //var en = svc.GetFirstOne();

            //var res = svc.Add(obj);
            //var result = svc.Get(206);

           // var result = svc.HandlerBus();


            //for (int i = 0; i < 10; i++)
            //{
            //    Stopwatch timer = new Stopwatch();
            //    timer.Start();
            //    var listres = svc.GetPageListOrderDesc(1, 20, (t => t.Age), (t => t.Age <= 10 && t.Height <= 100));
            //    timer.Stop();
            //    Logger.Info("执行时间：" + timer.ElapsedMilliseconds);
            //}
           


            //var result = svc.GetAllEntities();

            //for (int i = 1; i <= 100; i++)
            //{
            //    var obj = new DemoEntity
            //    {
            //        //Id = Guid.NewGuid().ToString(),
            //        Name = "jerry" + i,
            //        Nric = "32148461641649616" + i,
            //        Phone = "189615645" + i,
            //        Age = i % 23,
            //        Height = i % 234,
            //        Sex=1%i,
            //        Remark = "这是一个备注" + i,
            //        AddTime = DateTime.Now
            //    };

            //    svc.AddEntity(obj);
            //}
            //svc.Commit();

            //var exist = svc.Get("0006dc19-5214-4aad-9569-f874c43b7d04");
            //exist.Name = "tom";
            //svc.Update(exist);
            ////svc.Delete("707d9d32-e02c-4414-8399-66ac8e799cc4");
            //svc.Commit();
            Assert.IsFalse(1 == 2);


        }
    }

}
