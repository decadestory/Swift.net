using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Swift.Net.API
{
    /// <summary>
    /// 返回消息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [JsonObject(MemberSerialization.OptIn)]
    public class DataResult<T>
    {
        /// <summary>
        /// 返回标志代码：0为成功
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }

        /// <summary>
        /// 错误提示
        /// </summary>
        [JsonProperty(PropertyName = "errMsg")]
        public string ErrMsg { get; set; }

        /// <summary>
        /// 扩展数据
        /// </summary>
        [JsonProperty(PropertyName = "extData")]
        public object ExtData { get; set; }
    }
}
