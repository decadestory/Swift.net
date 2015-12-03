using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Swift.Demo.Entity;
using Swift.Demo.Entity.DTO;
using Swift.Demo.Resp;
using Swift.Net.API;
using Swift.Net.Base;

namespace Swift.Demo.Svc
{
    public class DemoSvc : BaseSvc<DemoEntity>
    {
        DemoResp dr = new DemoResp();
        public int AddEntity(DemoEntity obj)
        {
            return Add(obj,false);
        }

        public DataResult<List<DemoEntityDTO>> GetAllEntities()
        {
            var list =  GetAll().ToList();
            var datalist = Mapper.Map<List<DemoEntity>, List<DemoEntityDTO>>(list);
            return new DataResult<List<DemoEntityDTO>> {Code = 0, Data = datalist};
        }

        public DataResult<DemoEntity> GetFirstOne()
        {
            var s = GetFirst(t=>t.Age==1);
            return new DataResult<DemoEntity>{Code = 0,Data = s};
        }

        public PaginationResult<DemoEntity> PageList()
        {
            return dr.PageList();
        }

        public DataResult<int> HandlerBus()
        {
            var result = dr.HandlerBus();
            return new DataResult<int>{Code = 0,Data = result};
        }


    }
}
