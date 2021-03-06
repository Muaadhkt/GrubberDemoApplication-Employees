using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrubberDemo.Models.EFEntities
{
    public class Employee
    {
        [Key]
        [Column(Order=1)]
        [Required]
        public long PkEmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Gender { get; set; }
        [MaxLength(1000)]
        public string Address { get; set; }
        public string Role { get; set; }
        public string Skills { get; set; }
        [MaxLength(5000)]
        public string About { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime JoinDate { get; set; }
        public string Hobbies { get; set; }
        public int RowStatus { get; set; }
    }
}