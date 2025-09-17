using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AuthUser
    {
        [Key]
        public Guid AuthUserId { get; set; }  

        [Required]
        [MaxLength(255)]
        public string Password{ get; set; }


        // Navigation property for foreign key relationship
        [ForeignKey("Id")]
        public virtual SystemUser SystemUser { get; set; }
    }
}
