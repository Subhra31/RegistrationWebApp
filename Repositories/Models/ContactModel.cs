using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    public class ContactModel
    {
        public int ContactId { get; set; }        

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile No")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Please Upload Image")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Please Enter Designation")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        [Required(ErrorMessage = "Please Select Gender")]
        public string Gender { get; set; }
    }
}
