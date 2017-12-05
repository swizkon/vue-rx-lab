using System;
using Newtonsoft.Json;

namespace AccountHistory.Models
{
    public class AccountEvent
    {
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; }
        
        [JsonProperty(PropertyName = "eventType")]
        public string EventType { get; set; }
        
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }

        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}