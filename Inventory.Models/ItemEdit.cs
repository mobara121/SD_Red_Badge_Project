using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class ItemEdit
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Location { get; set; }
        public int Qty { get; set; }
    }
}
