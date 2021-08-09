using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class ContactModel
    {
        [Key]
        public int ContactId { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required]
        public string MobileNo { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        public string Image { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Designation { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        [Column(TypeName = "varchar(10)")]
        [Required]
        public string Gender { get; set; }

    }
}
