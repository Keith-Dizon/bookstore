namespace bookstore.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, ErrorMessage = "Title can't be longer than 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author is required")]
        [StringLength(50, ErrorMessage = "Author can't be longer than 100 characters.")]
        public string Author { get; set; } = string.Empty;

        [Range(0, 1000, ErrorMessage = "Price must be between 0 and 1000.")]
        public decimal Price { get; set; }

        [Range(1000, 2100, ErrorMessage = "Publication year must be between 1000 and 2100.")]
        public int PublicationYear { get; set; }
    }
}
