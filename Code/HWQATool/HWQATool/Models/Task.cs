using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HWQATool.Models
{
    [Table("TBL_TASK")]
    public class Function
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("Name", TypeName = "VARCHAR")]
        [Index("UQ_TBL_TASK_TEAM_ID_NAME", 1, IsUnique = true)]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Column("SAMPLE_PERCENTAGE")]
        [DisplayFormat(DataFormatString = "{0:P2}" ,ApplyFormatInEditMode=true)]
        public decimal SamplePercentage { get; set; }

        [Required]
        [Column("TEAM_ID")]
        [Index("UQ_TBL_TASK_TEAM_ID_NAME", 2, IsUnique = true)]
        [ForeignKey("Team")]
        public int TeamId { get; set; }

        [Required]
        [Column("VERSION")]
        public int Version { get; set; }

        [Required]
        [Column("LAST_MODIFIED_AT")]
        public DateTime LastModifiedAt { get; set; }

        [Required]
        [Column("LAST_MODIFIED_BY",TypeName="VARCHAR")]
        [StringLength(50)]
        public string LastModifiedBy { get; set; }

        public virtual Team Team { get; set; }

    }
}