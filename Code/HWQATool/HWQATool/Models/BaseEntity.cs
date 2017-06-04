using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HWQATool.Models
{
    public class BaseEntity<T>
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public T Id { get; set; }

        [Required]
        [Column("IS_ACTIVE")]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Required]
        [Column("VERSION")]
        public int Version { get; set; }

        [Required]
        [Column("LAST_MODIFIED_AT")]
        [Display(Name = "Last Modified At")]
        public DateTime LastModifiedAt { get; set; }

        [Required]
        [Column("LAST_MODIFIED_BY", TypeName = "VARCHAR")]
        [StringLength(50)]
        [Display(Name = "Last Modified By")]
        public string LastModifiedBy { get; set; }
    }
}