using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWQATool.Models
{
    public class BaseEntity<T>
    {
        public BaseEntity()
        {
            this.Version = 1;
            this.LastModifiedAt = DateTime.Now;
            this.LastModifiedBy = "Admin";
        }

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
        [ScaffoldColumn(false)]        
        public int Version { get; set; }

        [Required]
        [Column("LAST_MODIFIED_AT")]
        [Display(Name = "Last Modified At")]
        [ScaffoldColumn(false)]
        public DateTime LastModifiedAt { get; set; }

        [Required]
        [Column("LAST_MODIFIED_BY", TypeName = "VARCHAR")]
        [StringLength(50)]
        [Display(Name = "Last Modified By")]
        [ScaffoldColumn(false)]
        public string LastModifiedBy { get; set; }
    }
}
