using Newtonsoft.Json;

namespace ToDoProject.Models.RequestModels
{
    public class OrderingRequestModel<KeyType, DirectionType>
    {
        [JsonProperty("key")]
        public KeyType Key { get; set; }

        [JsonProperty("direction")]
        public DirectionType Direction { get; set; }
    }
}
