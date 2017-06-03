using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HWQATool.Models
{
    [Table("TBL_AUDIT")]
    public class Audit
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("AUDIT_NO")]
        [StringLength(50)]
        public string AuditNumber { get; set; }

        [Required]
        [Column("BATCH_NO")]
        [StringLength(50)]
        public string BatchNumber { get; set; }


        [Required]
        [Column("FILE_NO")]
        [StringLength(50)]
        public string FileNumber { get; set; }

        [Required]
        [Column("SERVICE_REQUEST_NO")]
        [StringLength(50)]
        public string ServiceRequestNumber { get; set; }

        [Required]
        [Column("PROCESSED_DATE")]
        public DateTime ProcessedDate { get; set; }

        [Required]
        [Column("PROCESSOR")]
        public int Processor { get; set; }

        [Required]
        [Column("PLATFORM_ID")]
        [ForeignKey("Platform")]
        public int PlatformId { get; set; }

        [Required]
        [Column("SUB_TASK_ID")]
        [ForeignKey("SubTask")]
        public int SubTaskId { get; set; }

        [Required]
        [Column("CLIENT_ID")]
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        [Required]
        [Column("AUDITOR")]
        public int Auditor { get; set; }

        [Required]
        [Column("AUDIT_DATE")]
        [StringLength(50)]
        public string AuditDate { get; set; }

        [Required]
        [Column("AUDITOR_COMMENTS")]
        [StringLength(50)]
        public string AuditorComments { get; set; }

        [Required]
        [Column("IS_DEFECT")]
        public Boolean ISDefect { get; set; }

        [Required]
        [Column("IS_LEARNING")]
        public Boolean IsLearning { get; set; }


        [Required]
        [Column("IS_ESCALATION")]
        public Boolean IsEscalation { get; set; }

        [Required]
        [Column("IS_CLIENTFOCUS")]
        public Boolean IsClientFocus { get; set; }

        [Required]
        [Column("IS_DUPLICATE")]
        public Boolean IsDuplicate { get; set; }

        [Required]
        [Column("IS_SAMPLED")]
        public Boolean IsSampled { get; set; }

        [Required]
        [Column("NO_OF_RECORDS")]
        public int NoOfRecords { get; set; }

        [Required]
        [Column("STATUS")]
        public int Status { get; set; }

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

        public virtual Platform Platform { get; set; }
        public virtual SubTask SubTask { get; set; }
        public virtual Client Client { get; set; }
        public virtual User User { get; set; }
    }
}