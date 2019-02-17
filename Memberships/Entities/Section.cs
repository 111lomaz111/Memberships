using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Memberships.Entities
{
    [Table("Section")]
    public class Section
    {
        /// <summary>
        /// Generating auto incresing value in DB 
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Setting max length for this prop
        /// Setting something like not null in sql(?) for this prop
        /// </summary>
        [MaxLength(255)]
        [Required]
        public string Title { get; set; }
    }
}