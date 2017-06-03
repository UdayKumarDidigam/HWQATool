using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace HWQATool.Models
{
    [Table("TBL_AUDIT_FINDING")]
    public class AuditFinding
    {
        
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [ForeignKey("Error")]
        [Required]
        [Index("UQ_TBL_AUDIT_FINDING_AUDIT_ID_ERROR_ID", 1, IsUnique = true)]
        [Column("AUDIT_ID")]
        public int Auditid { get; set; }

        [ForeignKey("Error")]
        [Required]
        [Index("UQ_TBL_AUDIT_FINDING_AUDIT_ID_ERROR_ID", 2, IsUnique = true)]
        [Column("ERROR_ID")]
        public int Errorid { get; set; }

        [Required]
        [Column("VERSION")]
        public int Version { get; set; }

        [Required]
        [Column("LAST_MODIFIED_AT")]
        public DateTime LastModifiedAt { get; set; }

        [Required]
        [Column("LAST_MODIFIED_BY")]
        [StringLength(50)]
        public string LastModifiedBy { get; set; }

        public virtual Error error { get; set; }

    }
}