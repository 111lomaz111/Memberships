using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Memberships.Entities
{
    /// <summary>
    /// Will define which view will be loaded for item types
    /// </summary>
    [Table("Item")]
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }

        /// <summary>
        /// Item title
        /// </summary>
        [MaxLength(255)]
        [Required]
        public string Title{ get; set; }

        /// <summary>
        /// Description of item
        /// </summary>
        [MaxLength(2048)]
        public string Description { get; set; }
        
        /// <summary>
        /// Path to item video 
        /// </summary>
        [MaxLength(1024)]
        public string Url { get; set; }

        /// <summary>
        /// Path to item image
        /// </summary>
        [MaxLength(1024)]
        [DisplayName("Image URL")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Formatting 
        /// </summary>
        [AllowHtml]
        public string HTML { get; set; }

        /// <summary>
        /// Number of days to wait for item (smth like annoucement for premiere)
        /// </summary>
        [DefaultValue(0)]
        [DisplayName("Wait days")]
        public int WaitDays { get; set; }

        /// <summary>
        /// Display first 50char`s from html
        /// </summary>
        public string HTMLShort{
            get
            {
                return (string.IsNullOrEmpty(HTML) || HTML.Length < 50) ? HTML : HTML.Substring(0, 50);
            }
        }

        public int ProductId { get; set; }
        public int ItemTypeId { get; set; }
        public int SectionId { get; set; }
        public int PartId { get; set; }

        /// <summary>
        /// Specify if item is free or user need to pay for it. // I`ve send question to author of course why it isn`t bool instead of int // Repaired
        /// </summary>
        [DisplayName("Is free")]
        public bool IsFree{ get; set; }

        /// <summary>
        /// Props. for lazy loading. // loading just when it`s necessary
        /// </summary>
        [DisplayName("Item Type")]
        public ICollection<ItemType> ItemTypes{ get; set; }
        [DisplayName("Sections")]
        public ICollection<Section> Sections{ get; set; }
        [DisplayName("Parts")]
        public ICollection<Part> Parts{ get; set; }
    }
}