using LibraryApp.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Models
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Book ID is required")]
        [Column(TypeName = "int")]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        [Column(TypeName = "nvarchar(450)")]
        public string UserId { get; set; }
        public LibraryAppUser User { get; set; }

        [Required(ErrorMessage = "Loan date is required")]
        [Column(TypeName = "DateTime")]
        public DateTime LoanDate { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime? ReturnDate { get; set; }
    }
}
