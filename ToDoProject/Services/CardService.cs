using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoProject.Common.Extensions;
using ToDoProject.Domain;
using ToDoProject.Domain.Entities.Cards;
using ToDoProject.Models.Enums;
using ToDoProject.Models.RequestModels;
using ToDoProject.Models.ResponseModels;
using ToDoProject.Services.Interfaces;

namespace ToDoProject.Services.Services
{
    public class CardService : ICardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly int? _userId = null;

        public CardService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            var context = httpContextAccessor.HttpContext;

            if (context?.User != null)
            {
                try
                {
                    _userId = context.User.GetUserId();
                }
                catch
                {
                    _userId = null;
                }
            }
        }

        public async Task<CardResponseModel> CreateCard(CardRequestModel model)
        {
            var card = _mapper.Map<Card>(model);

            //Not assigning creator because there is no users in database
            //card.CreatorId = _userId;

            card.CreatedAt = DateTime.UtcNow;
            card.Status = CardStatus.ToDo;

            _unitOfWork.Repository<Card>().Insert(card);
            _unitOfWork.SaveChanges();

            return _mapper.Map<CardResponseModel>(card); ;
        }

        public async Task<CardResponseModel> EditCard(int cardId, CardRequestModel model)
        {
            var card = _unitOfWork.Repository<Card>().Get(x => x.Id == cardId)
               .FirstOrDefault();

            if (card == null)
                throw new Exception("Card with given id is not found");

            card = _mapper.Map(model, card);

            _unitOfWork.Repository<Card>().Update(card);
            _unitOfWork.SaveChanges();

            return _mapper.Map<CardResponseModel>(card);
        }

        public async Task<CardResponseModel> EditCardStatus(int cardId, CardStatus status)
        {
            var card = _unitOfWork.Repository<Card>().Get(x => x.Id == cardId)
               .FirstOrDefault();

            if (card == null)
                throw new Exception("Card with given id is not found");

            card.Status = status;

            _unitOfWork.Repository<Card>().Update(card);
            _unitOfWork.SaveChanges();

            return _mapper.Map<CardResponseModel>(card);
        }

        public async Task<PaginationResponseModel<CardResponseModel>> GetCardsList(int boardId, PaginationRequestModel<CardSortingModel> model)
        {
            var cards = _unitOfWork.Repository<Card>()
                .Get(x => x.BoardId == boardId);

            var count = cards.Count();

            List<Card> result;

            switch (model.Order.Key)
            {
                case CardSortingModel.Title:
                    cards = (model.Order.Direction == SortingDirection.Desc)
                        ? cards.OrderByDescending(x => x.Title)
                        : cards.OrderBy(x => x.Title);
                    break;

                case CardSortingModel.CreatedAt:
                    cards = (model.Order.Direction == SortingDirection.Desc)
                        ? cards.OrderByDescending(x => x.CreatedAt)
                        : cards.OrderBy(x => x.CreatedAt);
                    break;

                default:
                    cards = cards.OrderBy(x => x.Title);
                    break;
            }

            result = cards
                .AsNoTracking()
                .Skip(model.Offset)
                .Take(model.Limit)
                .ToList();

            return new PaginationResponseModel<CardResponseModel>(_mapper.Map<List<CardResponseModel>>(result), count);
        }

        public async Task DeleteCard(int cardId)
        {
            var card = _unitOfWork.Repository<Card>().Get(x => x.Id == cardId)
                .FirstOrDefault();

            if (card == null)
                throw new Exception("Card with given id is not found");

            _unitOfWork.Repository<Card>().Delete(card);
            _unitOfWork.SaveChanges();
        }
    }
}
