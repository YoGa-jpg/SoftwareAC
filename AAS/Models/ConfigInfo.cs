using System.IO;
using Newtonsoft.Json;

namespace AAS.Models
{
    public class ConfigInfo
    {
        public string uri { get; set; }

        public int computer { get; set; }

        public string path { get; set; }

        public ConfigInfo(bool arg)
        {
            ConfigInfo info = JsonConvert.DeserializeObject<ConfigInfo>(File.ReadAllText(@"config.json"));

            uri = info.uri;
            computer = info.computer;
            path = info.path;
        }

        public ConfigInfo() { }
    }
}