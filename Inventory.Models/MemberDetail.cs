using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class MemberDetail
    {
        [Required]
        [Display(Name = "Member ID")]
        public int MemberId { get; set; }

        [Required]
        [Display(Name = "Member Name")]

        public string MemberName { get; set; }

        [Required]
        [Display(Name = "Registered Date")]
        public DateTimeOffset RegisteredDate { get; set; }
    }
}
