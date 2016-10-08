using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZoolandiaRazor.DAL.Models;

namespace ZoolandiaRazor.DAL.Models
{
    public class Animal
    {
       [Key]
       public int AnimalId { get; set; }
       [Required]
       public string AnimalName { get; set; }
       [Required]
       public int AnimalAge { get; set; }

       public string SpeciesCommonName { get; set; }
       [Required]
       public string SpeciesScientificName { get; set; }

       public virtual Habitat Habitat { get; set; }
    }

}