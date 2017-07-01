using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWQATool.Models
{

    [Table("TBL_UPLOAD_TRACK")]
    public class UploadTrack : BaseEntity<long>
    {
        [Required]
        [Column("ORIGINAL_FILE_NAME", TypeName = "VARCHAR")]
        [StringLength(500)]
        public string OriginalFileName { get; set; }

        [Required]
        [Column("FILE_NAME", TypeName = "VARCHAR")]
        [StringLength(500)]
        [Index(IsUnique = true)]
        public string FileName { get; set; }

        [Required]
        [Column("STATUS")]
        public TrackStatus Status { get; set; }

        [Required]
        [Column("TEAM_ID")]
        [ForeignKey("Team")]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
    }

    public enum TrackStatus
    {
        Submitted = 1,
        Queued = 2,
        Proccessing = 3,
        Completed = 4,
        Error = 5
    }
}
