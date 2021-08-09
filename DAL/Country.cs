using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string CountryName { get; set; }
    }
}
