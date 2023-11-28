using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ToDoProject.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CardSortingModel
    {
        CreatedAt,
        Title
    }
}
