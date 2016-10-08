using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ZoolandiaRazor.DAL.Models;

namespace ZoolandiaRazor.DAL
{
    public class AnimalContext : DbContext
    {
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Habitat> Habitats { get; set; }
        public virtual DbSet<HabitatType> HabitatTypes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

    }
}