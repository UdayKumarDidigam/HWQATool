using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWQATool.Models
{
    public class AuditTimeSlot : BaseEntity<long>
    {
        [Required]
        [Column("AUDIT_ID")]
        [ForeignKey("Audit")]
        public long AuditId { get; set; }

        [Required]
        [Column("AUDITOR")]
        [ForeignKey("User")]
        public int Auditor { get; set; }

        [Required]
        [Column("START_DATE")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Column("END_DATE")]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Column("TOTAL_TIME")]
        [Display(Name = "Total Time")]
        public int TotalTime { get; set; }

        [Required]
        [Column("STATUS")]
        public AuditStatus Status { get; set; }

        public virtual Audit Audit { get; set; }
        public virtual User User { get; set; }
    }
}
