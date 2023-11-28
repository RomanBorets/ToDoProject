using Newtonsoft.Json;
using ToDoProject.Models.Enums;

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

        [JsonProperty("status")]
        public CardStatus Status { get; set; }
    }
}
