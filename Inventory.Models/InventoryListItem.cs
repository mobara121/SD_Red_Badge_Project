﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class InventoryListItem
    {
        [Display(Name = "Item ID")]
        public int ItemId { get; set; }

        public Guid OwnerId { get; set; }

        public string Category { get; set; }

        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Shelf No.")]
        public int Shelf { get; set; }

        [Display(Name = "Current QTY")]
        public int Qty { get; set; }

        [Display(Name = "Stocked Date")]
        public DateTimeOffset StockedDate { get; set; }

        [Display(Name = "Modified Date")]
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
