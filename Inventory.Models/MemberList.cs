﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class MemberList
    {
        [Display(Name = "Member ID")]
        public int  MemberId{ get; set; }

        [Display(Name = "Name")]
        public string MemberName { get; set; }

        [Display(Name = "Registered Date")]
        public DateTimeOffset RegisteredDate { get; set; }
    }
}
