using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWQATool.Models
{
    [Table("TBL_AUDIT")]
    public class Audit : BaseEntity<long>
    {
        [Column("AUDIT_NO")]
        [StringLength(50)]
        [Display(Name = "Audit Number")]
        public string AuditNumber { get; set; }

        [Column("BATCH_NO")]
        [StringLength(50)]
        [Display(Name = "Batch Number")]
        public string BatchNumber { get; set; }

        [Column("FILE_NO")]
        [StringLength(50)]
        [Display(Name = "File Number")]
        public string FileNumber { get; set; }

        [Column("SERVICE_REQUEST_NO")]
        [StringLength(50)]
        [Display(Name = "Service Request Number")]
        public string ServiceRequestNumber { get; set; }

        [Required]
        [Column("PROCESSED_DATE")]
        [Display(Name = "Processed Date")]
        public DateTime ProcessedDate { get; set; }

        [Column("PROCESSOR")]
        public int? Processor { get; set; }

        [Column("CLIENT_ID")]
        public int? ClientId { get; set; }
        
        [Column("TASK_ID")]
        public int? TaskId { get; set; }
        
        [Column("SUB_TASK_ID")]
        public int? SubTaskId { get; set; }

        [Column("AUDITOR")]        
        public int? Auditor { get; set; }

        [Column("AUDIT_DATE")]
        [Display(Name = "Audit Date")]
        public DateTime? AuditDate { get; set; }

        [Column("PLATFORM_ID")]
        public int? PlatformId { get; set; }

        [Column("COMMENTS")]
        [StringLength(500)]
        public string Comments { get; set; }

        [Column("IS_DEFECT")]
        [Display(Name = "Defect")]
        public bool IsDefect { get; set; }

        [Column("IS_LEARNING")]
        [Display(Name = "Learning")]
        public bool IsLearning { get; set; }

        [Column("IS_ESCALATION")]
        [Display(Name = "Escalation")]
        public bool IsEscalation { get; set; }

        [Column("IS_CLIENT_FOCUS")]
        [Display(Name = "Client Focus")]
        public bool IsClientFocus { get; set; }

        [Column("IS_DUPLICATE")]
        [Display(Name = "Duplicate")]
        public bool IsDuplicate { get; set; }

        [Column("IS_SAMPLED")]
        [Display(Name = "Sampled")]
        public bool IsSampled { get; set; }

        [Required]
        [Column("NO_OF_RECORDS")]
        [Display(Name = "No Of Records")]
        public int NoOfRecords { get; set; }

        [Column("Total_Defects")]
        [Display(Name = "Total Defects")]
        public int? TotalDefects { get; set; }

        [Required]
        [Column("STATUS")]
        public AuditStatus Status { get; set; }

        public virtual User P { get; set; }
    }

    public enum AuditStatus
    {
        NotAssigned,
        Assigned,
        InProgress,
        Hold,
        Reject,
        Completed
    }
}
