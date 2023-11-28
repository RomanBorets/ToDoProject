using Newtonsoft.Json;

namespace ToDoProject.Models.ResponseModels
{
    public class MessageResponseModel
    {
        public MessageResponseModel(string message)
        {
            Message = message;
        }

        [JsonRequired]
        public string Message { get; set; }
    }
}