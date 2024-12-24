using System.ComponentModel.DataAnnotations;

namespace GamesReview.Data
{
    public class ReviewClass
    {

        [Key]
        public string ReviewID { get; set; }
        public string UserID { get; set; }

        public string Review {  get; set; }

        public short Rate { get; set; }

       
    }
}