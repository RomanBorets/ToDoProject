using System;
using System.Linq;
using ToDoProject.Domain.Entities.Cards;
using ToDoProject.Domain.Entities.Identity;
using ToDoProject.Models.RequestModels;
using ToDoProject.Models.ResponseModels;

namespace ToDoProject.Services.StartApp
{
    public class AutoMapperProfileConfiguration : AutoMapper.Profile
    {
        public AutoMapperProfileConfiguration()
        : this("MyProfile")
        {
        }

        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            #region Cards

            CreateMap<CardRequestModel, Card>();

            CreateMap<Card, CardResponseModel>()
                .ForMember(t => t.Id, opt => opt.MapFrom(x => x.Id));

            #endregion
        }
    }
}
