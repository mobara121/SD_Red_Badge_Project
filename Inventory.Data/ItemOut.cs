using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data
{
    public class ItemOut
    {
        [Key]
        public int Id { get; set; }

        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(Member))]
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }

        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        [Required]
        [Display(Name = "# to be taken")]
        public int Qty { get; set; }

        [Display(Name = "Record Date")]
        public DateTimeOffset RecordDate { get; set; }

    }
}
