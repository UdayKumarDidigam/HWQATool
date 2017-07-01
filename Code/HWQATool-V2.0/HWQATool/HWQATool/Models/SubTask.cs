using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWQATool.Models
{
    [Table("TBL_SUB_TASK")]
    public class SubTask : BaseEntity<int>
    {
        [Required]
        [Column("TASK_ID")]
        [Index("UQ_TBL_SUB_TASK_TASK_ID_NAME", 1, IsUnique = true)]
        [ForeignKey("Task")]
        public int TaskId { get; set; }

        [Required]
        [Column("Name", TypeName = "VARCHAR")]
        [Index("UQ_TBL_SUB_TASK_TASK_ID_NAME", 2, IsUnique = true)]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual Task Task { get; set; }
    }
}
