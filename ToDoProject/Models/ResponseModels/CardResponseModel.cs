using Newtonsoft.Json;

namespace ToDoProject.Models.ResponseModels
{
    public class CardResponseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
