using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class ItemEdit
    {
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Item Name is required")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Please input[Location Name] /[Shelf No.]. (ex.pantory / 3)")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Item Number is required")]
        public int Qty { get; set; }
    }
}
