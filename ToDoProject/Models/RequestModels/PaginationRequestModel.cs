using Newtonsoft.Json;
using ToDoProject.Models.Enums;

namespace ToDoProject.Models.RequestModels
{
    public class PaginationRequestModel<T> : PaginationBaseRequestModel where T : struct
    {
        [JsonProperty("search")]
        public string Search { get; set; }

        [JsonProperty("order")]
        public OrderingRequestModel<T, SortingDirection> Order { get; set; }
    }
}
