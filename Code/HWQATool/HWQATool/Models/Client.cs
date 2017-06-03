using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HWQATool.Models
{
    [Table("TBL_CLIENT")]
    public class Client
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("NAME")]
        [Index("UQ_TBL_CLIENT_TEAM_ID_NAME", 1, IsUnique = true)]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [ForeignKey("Team")]
        [Required]
        [Index("UQ_TBL_CLIENT_TEAM_ID_NAME", 2, IsUnique = true)]
        [Column("TEAM_ID")]
        public int TeamId { get; set; }

        [Required]
        [Column("IS_KEY_CLIENT")]
        public Boolean Iskeyclient { get; set; }


        [Required]
        [Column("SAMPLE_PERCENTAGE")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)]
        public decimal SamplePercentage { get; set; }

        [Required]
        [Column("IS_ACTIVE")]
        public Boolean Isactive { get; set; }

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

        public virtual Team Team{ get; set; }
    }
}