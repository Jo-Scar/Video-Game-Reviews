using System.ComponentModel.DataAnnotations;

namespace VideoGameReviewSite.Models
{
    public class ReviewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<ProductVideoGameModel>? VideoGame { get; set; }

    }
}
