using System.Threading.Tasks;
using ToDoProject.Models.Enums;
using ToDoProject.Models.RequestModels;
using ToDoProject.Models.ResponseModels;

namespace ToDoProject.Services.Interfaces
{
    public interface ICardService
    {
        /// <summary>
        /// Create card
        /// </summary>
        /// <param name="model">ACard request model</param>
        /// <returns>Card response model</returns>
        Task<CardResponseModel> CreateCard(CardRequestModel model);

        /// <summary>
        /// Edit card
        /// </summary>
        /// <param name="cardId">Card id</param>
        /// <param name="model">Card request model</param>
        /// <returns>Card response model </returns>
        Task<CardResponseModel> EditCard(int cardId, CardRequestModel model);

        /// <summary>
        /// Edit card status
        /// </summary>
        /// <param name="cardId">Card id</param>
        /// <param name="status">Card status</param>
        /// <returns>Card response model </returns>
        Task<CardResponseModel> EditCardStatus(int cardId, CardStatus status);

        /// <summary>
        /// Get list of cards
        /// </summary>
        /// <param name="boardId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PaginationResponseModel<CardResponseModel>> GetCardsList(int boardId, PaginationRequestModel<CardSortingModel> model);

        /// <summary>
        /// Delete card
        /// </summary>
        /// <param name="cardId">Card id</param>
        /// <returns>Card response model </returns>
        Task DeleteCard(int cardId);
    }
}
