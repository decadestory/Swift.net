using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Swift.Net.API
{
    public class ComboResult
    {
        /// <summary>
        /// 值
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        /// <summary>
        /// 显示文字
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        /// <summary>
        /// 拼音
        /// </summary>
        [JsonProperty(PropertyName = "queryText")]
        public string QueryText { get; set; }
        /// <summary>
        /// 简拼
        /// </summary>
        [JsonProperty(PropertyName = "fastQueryText")]
        public string FastQueryText { get; set; }
    }
}
