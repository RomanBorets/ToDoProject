using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoProject.Domain.Entities.Identity;
using ToDoProject.Models.Enums;

namespace ToDoProject.Domain.Entities.Cards
{
    public class Card : IEntity
    {
        #region Properties

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [DataType("DateTime")]
        public DateTime CreatedAt { get; set; }

        public int? CreatorId { get; set; }

        public int BoardId { get; set; }

        public CardStatus Status { get; set; }

        #endregion

        #region Navigation properties

        [ForeignKey("CreatorId")]
        public virtual ApplicationUser Creator { get; set; }

        #endregion
    }
}
