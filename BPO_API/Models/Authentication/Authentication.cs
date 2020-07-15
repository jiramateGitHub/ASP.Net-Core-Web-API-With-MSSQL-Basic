using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPO_API.Models
{
    public class Authentication
    {
        [Key]
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
