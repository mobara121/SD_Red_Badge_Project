using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Shelf No.")]
        public int Shelf { get; set; }

        [Required]
        [Display(Name = "Current QTY")]
        public int Qty { get; set; }

        [Required]
        public bool IsInStock
        {
            get
            {
                if (Qty > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        [Required]
        [Display(Name = "Stocked Date")]
        public DateTimeOffset StockedDate { get; set; }
        
        [Display(Name = "Modified Date")]
        public DateTimeOffset? ModifiedDate { get; set; }

        public virtual ICollection<ItemOut> ItemOut { get; set; } = new List<ItemOut>();
    }
}
