using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoGameReviewSite.Models
{
    public class ProductVideoGameModel
    {
        [Key]
        public int Id { get; set; }        
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public virtual ReviewModel? Publishers { get; set; }
        [NotMapped]
        public string? NewPublisher { get; set; }
        [ForeignKey("ReviewModel")]
        public int PublishersId { get; set; }
        [NotMapped]  
        public string Publisher
        {
            get
            {
                if(Publishers is not null)
                {
                    return Publishers.Name;
                }
                else
                {
                    return "";
                }
            }
        }
        public string Reviews { get; set; }
        public string ReleaseDate { get; set; }
        public double Cost { get; set; }
    }
}
