using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWQATool.Models
{
    [Table("TBL_ERROR")]
    public class Error : BaseEntity<int>
    {
        [Required]
        [Column("TASK_ID")]
        [Index("UQ_TBL_ERROR_TASK_ID_NAME", 1, IsUnique = true)]
        [ForeignKey("Task")]
        public int TaskId { get; set; }

        [Required]
        [Column("NAME", TypeName = "VARCHAR")]
        [StringLength(50)]
        [Index("UQ_TBL_ERROR_TASK_ID_NAME", 2, IsUnique = true)]
        public string Name { get; set; }


        [Column("DESCRIPTION", TypeName = "VARCHAR")]
        public string Description { get; set; }

        [Required]
        [Column("WEIGHTAGE")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Weightage { get; set; }

        public virtual Function Function { get; set; }
    }
}
