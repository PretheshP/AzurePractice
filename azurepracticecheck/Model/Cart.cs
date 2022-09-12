
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace azurepracticecheck.Models
{
    public class Cart
    {
        [Key]
        public int id { get; set; }
        public int userId { get; set; }
        public int menuitemId { get; set; }
                
    }
}
