using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWQATool.Models
{
    [Table("TBL_USER")]
    public class User : BaseEntity<int>
    {
        [Required]
        [Column("LOGIN_ID", TypeName = "VARCHAR")]
        [Index("UQ_TBL_USER_LOGIN_ID", IsUnique = true)]
        [StringLength(20)]

        public string LoginId { get; set; }

        [Required]
        [Column("ASSOCIATE_ID", TypeName = "VARCHAR")]
        [Index("UQ_TBL_USER_ASSOCIATE_ID", IsUnique = true)]
        [StringLength(10)]
        public string AssociateId { get; set; }

        [Required]
        [Column("EMAIL", TypeName = "VARCHAR")]
        [Index("UQ_TBL_USER_EMAIL", IsUnique = true)]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [Column("FIRSTNAME", TypeName = "VARCHAR")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Column("LASTNAME", TypeName = "VARCHAR")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Column("LOCATION", TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Location { get; set; }

        [Column("SUPERVOISER_EMAIL", TypeName = "VARCHAR")]
        [StringLength(200)]
        [Display(Name = "Supervoiser Email")]
        public string Supervoiser_Email { get; set; }

        [Required]
        [Column("GRADE_ID")]
        [ForeignKey("Grade")]
        public int GradeId { get; set; }

        [Required]
        [Column("SAMPLE_PERCENTAGE")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Sample Percentage")]
        public decimal SamplePercentage { get; set; }

        [Column("COMMENTS", TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Comments { get; set; }

        public virtual Grade Grade { get; set; }
    }
}
