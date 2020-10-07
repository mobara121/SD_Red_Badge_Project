using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class ItemOutListItem
    {
        [Display(Name = "Takeout No.")]
        public int ItemOutId { get; set; }

        [Display(Name = "Member Name")]
        public string MemberName { get; set; }

        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Display(Name = "Number of Takeout")]
        public int Qty { get; set; }

        [Display(Name = "Record Date")]
        public DateTimeOffset RecordDate { get; set; }
    }
}
