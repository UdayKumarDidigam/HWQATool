using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HWQATool.Models
{
    [Table("TBL_USER_ROLE")]
    public class UserRole
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("USER_ID")]
        [Index("UQ_TBL_USER_ROLE_User_Id", 1, IsUnique = true)]
        [ForeignKey("User")]

        public int UserId { get; set; }

        [Required]
        [Column("ROLE")]
        [Index("UQ_TBL_USER_ROLE_User_Id", 2, IsUnique = true)]        
        public int Role { get; set; }

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

        public virtual User User { get; set; }
    }
}