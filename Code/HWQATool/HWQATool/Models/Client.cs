using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWQATool.Models
{
    [Table("TBL_CLIENT")]
    public class Client : BaseEntity<int>
    {
        [ForeignKey("Team")]
        [Required]
        [Index("UQ_TBL_CLIENT_TEAM_ID_NAME", 1, IsUnique = true)]
        [Column("TEAM_ID")]
        public int TeamId { get; set; }

        [Required]
        [Column("NAME")]
        [Index("UQ_TBL_CLIENT_TEAM_ID_NAME", 2, IsUnique = true)]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        [Column("IS_KEY_CLIENT")]
        [Display(Name = "Key Client")]
        public bool IsKeyClient { get; set; }

        [Required]
        [Column("SAMPLE_PERCENTAGE")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Sample Percentage")]
        public decimal SamplePercentage { get; set; }

        public virtual Team Team{ get; set; }
    }
}
