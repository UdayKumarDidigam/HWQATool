using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HWQATool.Models
{
    public class User
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("LOGIN_ID")]
        [Index("UQ_TBL_USER_LOGIN_ID_N", 2, IsUnique = true)]
        [ForeignKey("Grade")]
        public int TeamId { get; set; }


    }
}