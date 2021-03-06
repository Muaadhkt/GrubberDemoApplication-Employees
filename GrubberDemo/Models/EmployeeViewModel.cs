using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrubberDemo.Models
{
    public class EmployeeViewModel
    {
        public long PkEmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public string Skills { get; set; }
        public string Hobbies { get; set; }
        public string About { get; set; }
        public DateTime JoinDate { get; set; } = DateTime.Now;
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public List<SelectListItem> GenderList { get; set; }
        public List<SelectListItem> SkillsList { get; set; }
        public List<SelectListItem> HobbiesList { get; set; }
    }
}