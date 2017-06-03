using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HWQATool.Models
{
    [Table("TBL_EXCEL_RECORD")]
    public class ExcelRecord
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public long Id { get; set; }

        [Required]
        [Column("TEAM_ID")]
        [ForeignKey("Team")]
        public int TeamId { get; set; }

        [Required]
        [Column("IS_ERROR")]
        public Boolean IsError { get; set; }

       
        [Column("ERROR_CODE")]
        public string ErrorCode { get; set; }

 
        [Column("CLIENT")]
        [StringLength(50)]
        public string Client {get;set;}

        [Column("TASK")]
        [StringLength(50)]
        public string Task {get;set;}

        [Column("PLATFORM")]
        [StringLength(50)]
        public string Platform {get;set;}

        [Column("PROCESSOR")]
        [StringLength(50)]
        public string Processor {get;set;}

        [Column("PROCESSDATE")]
        [StringLength(50)]
        public string ProcessDate {get;set;}

        [Column("SERVICE_REQUEST_NO")]
        [StringLength(50)]
        public string ServiceRequestNo {get;set;}

        [Column("AUDIT_NO")]
        [StringLength(50)]
        public string AuditNo {get;set;}

        [Column("BATCH_NO")]
        [StringLength(50)]
        public string BatchNo {get;set;}

        [Column("FILE_NO")]
        [StringLength(50)]
        public string FileNo {get;set;}

        [Column("NO_OF_RECORDS")]
        [StringLength(50)]
        public string NoOfRecords {get;set;}

        [Column("AUDITOR")]
        [StringLength(50)]
        public string Auditor {get;set;}

        public virtual Team Team { get; set; }
    
    }
}