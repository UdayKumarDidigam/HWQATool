using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWQATool.Models
{
    [Table("TBL_PLATFORM")]
    public class Platform : BaseEntity<int>
    {
        [Required]
        [Column("TEAM_ID")]
        [Index("UQ_TBL_PLATFORM_TEAM_ID_NAME", 1, IsUnique = true)]
        [ForeignKey("Team")]
        public int TeamId { get; set; }

        [Required]
        [Column("Name", TypeName = "VARCHAR")]
        [StringLength(50)]
        [Index("UQ_TBL_PLATFORM_TEAM_ID_NAME", 2, IsUnique = true)]
        public string Name { get; set; }

        public virtual Team Team { get; set; }
    }
}
