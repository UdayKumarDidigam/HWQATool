using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HWQATool.Models
{
    [Table("TBL_TEAM")]
    public class Team : BaseEntity <int>
    {
        [Required]
        [Column("NAME", TypeName = "VARCHAR")]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        [Column("QUALITY_BENCHMARK")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Quality Bench Mark")]
        public decimal QualityBenchMark { get; set; }
    }
}
