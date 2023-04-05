using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string? Genre { get; set; }
        public decimal price { get; set; }
    }
}
