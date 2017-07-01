using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWQATool.Models
{
    [Table("TBL_EXCEL_RECORD")]
    public class ExcelRecord : BaseEntity<long>
    {
        [Required]
        [Column("TEAM_ID")]
        [ForeignKey("Team")]
        public int TeamId { get; set; }

        [Required]
        [Column("UPLOAD_TRACK_ID")]
        [ForeignKey("UploadTrack")]
        public long UploadTrackId { get; set; }
        
        [Required]
        [Column("IS_ERROR")]
        public bool IsError { get; set; }

        [Column("ERROR_CODE", TypeName = "VARCHAR")]
        public string ErrorCode { get; set; }


        [Column("CLIENT", TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Client { get; set; }

        [Column("TASK", TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Task { get; set; }

        [Column("PLATFORM", TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Platform { get; set; }

        [Column("PROCESSOR", TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Processor { get; set; }

        [Column("PROCESSDATE", TypeName = "VARCHAR")]
        [StringLength(50)]
        public string ProcessDate { get; set; }

        [Column("SERVICE_REQUEST_NO", TypeName = "VARCHAR")]
        [StringLength(50)]
        public string ServiceRequestNo { get; set; }

        [Column("AUDIT_NO", TypeName = "VARCHAR")]
        [StringLength(50)]
        public string AuditNo { get; set; }

        [Column("BATCH_NO", TypeName = "VARCHAR")]
        [StringLength(50)]
        public string BatchNo { get; set; }

        [Column("FILE_NO", TypeName = "VARCHAR")]
        [StringLength(50)]
        public string FileNo { get; set; }

        [Column("NO_OF_RECORDS", TypeName = "VARCHAR")]
        [StringLength(50)]
        public string NoOfRecords { get; set; }

        [Column("AUDITOR", TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Auditor { get; set; }

        public virtual Team Team { get; set; }
        public virtual UploadTrack UploadTrack { get; set; }

    }
}
