using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class MemberCreate
    {
        [Required(ErrorMessage = "Member Name is required.")]
        [Display(Name = "Member Name")]
        public string  MemberName { get; set; }
    }
}
