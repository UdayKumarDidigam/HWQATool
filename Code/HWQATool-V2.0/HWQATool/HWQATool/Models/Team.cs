using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWQATool.Models
{
    [Table("TBL_TEAM")]
    public class Team : BaseEntity<int>
    {
        [Required]
        [Column("NAME", TypeName = "VARCHAR")]
        [StringLength(50)]        
        [Index("UQ_TBL_TEAM_NAME", IsUnique = true)]
        public string Name { get; set; }

        [Required]
        [Column("QUALITY_BENCHMARK")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Quality Bench Mark")]
        public decimal QualityBenchMark { get; set; }
    }
}
