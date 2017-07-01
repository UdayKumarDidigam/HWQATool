using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWQATool.Models
{
    [Table("TBL_USER_ROLE")]
    public class UserRole : BaseEntity<int>
    {
        [Required]
        [Column("USER_ID")]
        [Index("UQ_TBL_USER_ROLE_USER_ID_ROLE", 1, IsUnique = true)]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [Column("ROLE")]
        [Index("UQ_TBL_USER_ROLE_USER_ID_ROLE", 2, IsUnique = true)]
        public Role Role { get; set; }

        public virtual User User { get; set; }
    }

    public enum Role
    {
        Administrator = 1,
        Supervisor = 2,
        Auditor = 3,
        Processor = 4,
        Reporter = 5
    }
}
