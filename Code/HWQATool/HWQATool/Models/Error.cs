using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HWQATool.Models
{
    [Table("TBL_ERROR")]
    public class Error
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("NAME", TypeName = "VARCHAR")]
        [StringLength(50)]
        [Index("UQ_TBL_ERROR_TASK_ID_NAME", 1, IsUnique = true)]
        public string Name { get; set; }


        [Column("DESCRIPTION", TypeName = "VARCHAR")]
        public string DESCRIPTION { get; set; }

        [Required]
        [Column("WEIGHTAGE")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)]
        public decimal WEIGHTAGE { get; set; }

        [Required]
        [Column("TASK_ID")]
        [Index("UQ_TBL_ERROR_TASK_ID_NAME", 2, IsUnique = true)]
        [ForeignKey("Task")]
        public int TaskId { get; set; }

        [Required]
        [Column("VERSION")]
        public int Version { get; set; }

        [Required]
        [Column("LAST_MODIFIED_AT")]
        public DateTime LastModifiedAt { get; set; }

        [Required]
        [Column("LAST_MODIFIED_BY", TypeName = "VARCHAR")]
        [StringLength(50)]
        public string LastModifiedBy { get; set; }

        public virtual Function Task { get; set; }
    }
}