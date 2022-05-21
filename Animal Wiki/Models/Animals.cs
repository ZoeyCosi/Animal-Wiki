using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_Wiki.Models
{
    public class Kingdom
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string photopath { get; set; }
        public Phylium Phylium { get; set; }
    }
    public class Phylium
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string photopath { get; set; }
        public Kingdom Kingdom { get; set; }
        [ForeignKey("Kingdom")]
        public int KingdomID { get; set; }
    }
    public class AnimalClass
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string photopath { get; set; }
        public Phylium Phylium { get; set; }
        [ForeignKey("Phylium")]
        public int PhyliumID { get; set; }
    }
    public class Order
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string photopath { get; set; }
        public AnimalClass AnimalClass { get; set; }
        [ForeignKey("AnimalClass")]
        public int AnimalClassID { get; set; }
    }
    public class Family
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string photopath { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public int OrderID { get; set; }
    }
    public class Genius
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string photopath { get; set; }
        public Family Family { get; set; }
        [ForeignKey("Family")]
        public int FamilyID { get; set; }

    }
    public class Species
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string photopath { get; set; }
        public string scientificname { get; set; }
        public Genius Genius { get; set; }
        [ForeignKey("Genius")]
        public int GeniusID { get; set; }
    }
    public class AnimalContext : DbContext
    {
        public AnimalContext(DbContextOptions<AnimalContext> options)
            : base(options)
        {
        }

        public DbSet<Species> species { get; set; }
        public DbSet<Genius> genius { get; set; }
        public DbSet<Family> families { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<AnimalClass> classes { get; set; }
        public DbSet<Phylium> phylia { get; set; }
        public DbSet<Kingdom> kingdoms { get; set; }
    }
}
