using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Swift.Demo.Entity;
using Swift.Demo.Entity.DTO;

namespace Swift.Test.Bootstrapper
{
    public class AutoMapperInstaller
    {
        public static void Install()
        {
            Mapper.CreateMap<DemoEntity, DemoEntityDTO>().ReverseMap();
        }
    }
}
