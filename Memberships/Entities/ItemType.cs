using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Memberships.Entities
{
    /// <summary>
    /// Will define which view will be loaded for item types
    /// </summary>
    [Table("ItemType")]
    public class ItemType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }

        [MaxLength(255)]
        [Required]
        public string Title{ get; set; }
    }
}