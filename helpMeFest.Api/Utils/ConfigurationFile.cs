using Newtonsoft.Json;
namespace QuhelpMeFest.Api.Utils.ConfigurationFiles
{
    public class ConfigurationFile
    {
        [JsonProperty("key")]
        public string Key { get; set; }
    }
}
