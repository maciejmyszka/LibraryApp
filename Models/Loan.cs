using LibraryApp.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Models
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string UserId { get; set; }
        public LibraryAppUser User { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime LoanDate { get; set; }


        [Column(TypeName = "DateTime")]
        public DateTime? ReturnDate { get; set; }
    }
}
