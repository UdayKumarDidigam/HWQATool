using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HWQATool.Models
{
    [Table("TBL_PLATFORM")]
    public class Platform
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("NAME")]
        [StringLength(50)]
        [Index("", 1, IsUnique = true)]
        public string Name { get; set; }

        [Required]
        [Column("TEAM_ID")]
        [Index("", 2, IsUnique = true)]
        public int TEAM_ID { get; set; }

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


    }
}
