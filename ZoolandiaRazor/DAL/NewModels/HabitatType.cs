using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZoolandiaRazor.DAL.NewModels
{
    public class HabitatType
    {
        [Key]
        public int HabitatTypeId { get; set; }

        [Required]
        public string HabitatTypeName { get; set; }

        public virtual List<Habitat> Habitats { get; set; }
    }
}