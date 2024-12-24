using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesReview.Data
{
    public class Game
    {

        [Key]
        public string ID { get; set; }
        public string Name { get; set; }

        public short Rate { get; set; }

        public string[] ReviewsID { get; set; }
        public string[] Genres { get; set; }

        public DateTime ReleaseDate { get; set; }

        [NotMapped]
        public int ReviewsCount => ReviewsID.Length;

        /// <summary>
        /// Dynamically calculating field in page load
        /// </summary>
        [NotMapped]
        public short CalculatedRate { get; set; }
    }
}