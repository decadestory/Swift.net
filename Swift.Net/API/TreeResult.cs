using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Swift.Net.API
{
    public class TreeResult
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "children")]
        public IList<TreeResult> Children { get; set; }

        [JsonProperty(PropertyName = "state")]
        public int State { get; set; }

        [JsonProperty(PropertyName = "checked")]
        public bool Checked { get; set; }

        [JsonProperty(PropertyName = "parentId")]
        public int ParentId { get; set; }
    }
}
