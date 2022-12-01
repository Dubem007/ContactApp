using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Web
{
    public class Serialize
    {
        public T DeserializeJson<T>(string JsonString) {
            return JsonConvert.DeserializeObject<T>(JsonString);
        }

        public string SerializeJson<T>(T value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
