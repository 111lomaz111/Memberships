using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Memberships.Entities
{
    [Table("SubscriptionProduct")]
    public class SubscriptionProduct
    {
        [Required]
        [Key, Column(Order = 1)]
        public int ProductId{ get; set; }
        [Required]
        [Key, Column(Order = 2)]
        public int SubscriptionId { get; set; }
        [NotMapped]//entity will not create this columns in DB
        public int OldProductId { get; set; }
        [NotMapped] 
        public int OldSubscriptionId { get; set; }
    }
}