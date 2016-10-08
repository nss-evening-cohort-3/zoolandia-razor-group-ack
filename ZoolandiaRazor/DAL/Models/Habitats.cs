using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZoolandiaRazor.DAL.Models;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.DAL.Models
{
    public class Habitat
    {
        [Key]
        public int HabitatId { get; set; }
        [Required]
        public string HabitatName { get; set; }


        public virtual HabitatType HabitatType { get; set; }
        public virtual List<Animal> Animals { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }

    

}