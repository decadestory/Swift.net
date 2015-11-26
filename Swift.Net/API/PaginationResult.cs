using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Swift.Net.API
{
    public class PaginationResult<TData>
    {
        /// <summary>
        /// 数据总条数
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        [JsonProperty(PropertyName = "rows")]
        public IList<TData> Rows { get; set; }

    }
}
