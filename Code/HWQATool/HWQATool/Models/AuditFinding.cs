using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWQATool.Models
{
    [Table("TBL_AUDIT_FINDING")]
    public class AuditFinding : BaseEntity<long>
    {
        [Required]
        [Index("UQ_TBL_AUDIT_FINDING_AUDIT_ID_ERROR_ID", 1, IsUnique = true)]
        [Column("AUDIT_ID")]
        [ForeignKey("Audit")]
        public long AuditId { get; set; }
        
        [Required]
        [Index("UQ_TBL_AUDIT_FINDING_AUDIT_ID_ERROR_ID", 2, IsUnique = true)]
        [Column("ERROR_ID")]
        [ForeignKey("Error")]
        public int Errorid { get; set; }

        public virtual Audit Audit { get; set; }
        public virtual Error Error { get; set; }

    }
}
