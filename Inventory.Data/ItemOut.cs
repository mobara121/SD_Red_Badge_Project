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

        [Required]
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(Member))]
        public int MemberName { get; set; }
        public virtual Member Member { get; set; }

        [ForeignKey(nameof(Item))]
        public int ItemName { get; set; }
        public virtual Item Item { get; set; }



    }
}
