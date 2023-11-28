using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using ToDoProject.Common;
using ToDoProject.Common.Attributes;
using ToDoProject.Models.Enums;
using ToDoProject.Models.RequestModels;
using ToDoProject.Models.ResponseModels;
using ToDoProject.Services.Interfaces;

namespace ToDoProject.Controllers.API
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
            : base()
        {
            _cardService = cardService;
        }


        // POST api/v1/card
        /// <summary>
        /// Create card
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/v1/card
        ///     {
        ///            "title": "string",
        ///            "description": "string"
        ///     }
        ///     
        /// </remarks>
        /// <returns>Card, or error with HTTP 40x or 500 status code</returns> 
        [HttpPost]
        public async Task<IActionResult> AddCard([FromBody][Required] CardRequestModel model)
        {
            return Ok(new JsonResponse<CardResponseModel>(await _cardService.CreateCard(model)));
        }

        // PUT api/v1/card/{id}
        /// <summary>
        /// Edit card
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/v1/card/1
        ///     {
        ///            "title": "string",
        ///            "description": "string"
        ///     }
        ///     
        /// </remarks>
        /// <returns>User card, or error with HTTP 40x or 500 status code</returns> 
        [SwaggerResponse(200, ResponseMessages.RequestSuccessful, typeof(MessageResponseModel))]
        [SwaggerResponse(404, ResponseMessages.NotFound, typeof(NotFoundObjectResult))]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCard([ValidateId][FromRoute] int id, [FromBody][Required] CardRequestModel model)
        {
            try
            {
                return Ok(new JsonResponse<CardResponseModel>(await _cardService.EditCard(id, model)));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PATCH api/v1/card/{id}
        /// <summary>
        /// Edit card status
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/v1/card/1
        ///     {
        ///            "title": "string",
        ///            "description": "string"
        ///     }
        ///     
        /// </remarks>
        /// <returns>User card, or error with HTTP 40x or 500 status code</returns> 
        [HttpPatch("{id}")]
        public async Task<IActionResult> EditCardStatus([ValidateId][FromRoute] int id, [FromBody][Required] CardStatus status)
        {
            try
            {
                return Ok(new JsonResponse<CardResponseModel>(await _cardService.EditCardStatus(id, status)));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        // GET api/v1/card/{id}
        /// <summary>
        /// Get cards list.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/v1/card/1?Limit=10&amp;Offset=0
        ///     
        /// </remarks>
        /// <returns>Cards list, or error with HTTP 40x or 500 status code</returns> 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardsList([FromRoute] int id, [FromQuery] PaginationRequestModel<CardSortingModel> model)
        {
            var data = await _cardService.GetCardsList(id, model);
            return Ok(new JsonPaginationResponse<List<CardResponseModel>>(data.Data, model.Offset + model.Limit, data.TotalCount));
        }

        // DELETE api/v1/card/{id}
        /// <summary>
        /// Delete card
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE api/v1/card/{id}
        ///
        /// </remarks>
        /// <returns>Message about deleting, or error with HTTP 40x or 500 status code</returns>
        [SwaggerResponse(200, ResponseMessages.RequestSuccessful, typeof(MessageResponseModel))]
        [SwaggerResponse(404, ResponseMessages.NotFound, typeof(NotFoundObjectResult))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard([ValidateId][FromRoute] int id)
        {
            try
            {
                await _cardService.DeleteCard(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(new JsonResponse<MessageResponseModel>(new MessageResponseModel("Card deleted successfully.")));
        }
    }
}
