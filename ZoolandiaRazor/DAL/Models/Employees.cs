using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZoolandiaRazor.DAL.Models;

namespace ZoolandiaRazor.DAL.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public int EmployeeAge { get; set; }
        [Required]
        public string EmployeeName { get; set; }

        public virtual List<Habitat> Habitats { get; set; }
    }
}