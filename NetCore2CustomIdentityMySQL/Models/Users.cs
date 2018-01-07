using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2CustomIdentityMySQL.Models
{
    public class Users
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string email { get; set; }

        [Required]
        public bool emailconfirmed { get; set; }

        [Required]
        [MaxLength(100)]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(100)]
        public string password { get; set; }

        [MaxLength(50)]
        public string firstname { get; set; }

        [MaxLength(50)]
        public string lastname { get; set; }
    }
}
