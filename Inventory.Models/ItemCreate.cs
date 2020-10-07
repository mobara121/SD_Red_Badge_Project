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
        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage="Item Name is required")]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Shelf No. is required")]
        [Display(Name = "Shelf No.")]
        public int Shelf { get; set; }

        [Required(ErrorMessage = "Item number is required")]
        [Display(Name = "QTY")]
        public int Qty { get; set; }
    }
}
