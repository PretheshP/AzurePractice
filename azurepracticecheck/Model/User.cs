using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace azurepracticecheck.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string password { get; set; }
    }
}
