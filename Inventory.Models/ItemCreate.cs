using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class ItemCreate
    {
        [Required]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please input [Location Name]/[Shelf No.]. (ex. pantory/3)")]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "QTY")]
        public int Qty { get; set; }
    }
}
