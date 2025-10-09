using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("AuthUser")]
    public class AuthUser : SystemUser
    {
        [Required]
        [MaxLength(255)]
        public string Password { get; set; } = null!;
    }

}

