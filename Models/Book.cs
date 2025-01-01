using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }

        [Column(TypeName = "bit")]
        public bool IsAvailable { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
