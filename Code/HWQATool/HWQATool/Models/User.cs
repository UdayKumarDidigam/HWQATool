using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HWQATool.Models
{
    [Table("TBL_USER")]
    public class User
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("EMAIL",TypeName = "VARCHAR")]
        [Index("UQ_TBL_USER_EMAIL", 1, IsUnique = true)]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [Column("LOGIN_ID")]
        [Index("UQ_TBL_USER_Login_Id", 1, IsUnique = true)]
        
        public int LoginId { get; set; }

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
        public string Supervoiser_Email { get; set; }

        [Required]
        [Column("GRADE_ID")]
        [ForeignKey("Grade")]
        public int GradeId{ get; set; }

        [Required]
        [Column("SAMPLE_PERCENTAGE")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Sample Percentage")]
        public decimal SamplePercentage { get; set; }

        [Column("COMMENTS", TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Comments { get; set; }

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

        public virtual  Grade Grade { get; set; }
    }
}