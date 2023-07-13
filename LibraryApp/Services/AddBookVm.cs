using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Services
{
    public class AddBookVm
    { 
        public string Name { get; set; }
        [Required]
        public int Count { get; set; }
        public string Author { get; set; }
        public int BookCategoryId { get; set; }
        public DateTime AddDate { get; set; }
    }
}
