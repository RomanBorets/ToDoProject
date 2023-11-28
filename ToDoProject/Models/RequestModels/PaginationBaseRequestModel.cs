using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ToDoProject.Models.RequestModels
{
    public class PaginationBaseRequestModel
    {
        [JsonProperty("limit")]
        [Range(1, int.MaxValue, ErrorMessage = "Limit must be graster than 0")]
        public int Limit { get; set; } = 10;

        [JsonProperty("offset")]
        [Range(0, int.MaxValue, ErrorMessage = "Offset must be equal or graster than 0")]
        public int Offset { get; set; } = 0;
    }
}
