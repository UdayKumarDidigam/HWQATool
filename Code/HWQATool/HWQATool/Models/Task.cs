using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWQATool.Models
{
    [Table("TBL_TASK")]
    public class Task : BaseEntity<int>
    {
        [Required]
        [Column("TEAM_ID")]
        [Index("UQ_TBL_TASK_TEAM_ID_NAME", 1, IsUnique = true)]
        [ForeignKey("Team")]
        public int TeamId { get; set; }

        [Required]
        [Column("Name", TypeName = "VARCHAR")]
        [Index("UQ_TBL_TASK_TEAM_ID_NAME", 2, IsUnique = true)]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Column("SAMPLE_PERCENTAGE")]
        [DisplayFormat(DataFormatString = "{0:N2}" ,ApplyFormatInEditMode=true)]
        [Display(Name = "Sample Percentage")]
        public decimal SamplePercentage { get; set; }
        
        public virtual Team Team { get; set; }
    }
}
