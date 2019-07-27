using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WanStap.Models
{
    public class WanStapContext : DbContext
    {
        public WanStapContext() : base("DefaultConnection")
        {
        }

        public static WanStapContext Create()
        {
            return new WanStapContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Member> Member { get; set; }
        public DbSet<MemberType> MemberType { get; set; }
        public DbSet<Establishment> Establishment { get; set; }
        public DbSet<EstablishmentType> EstablishmentType { get; set; }
        public DbSet<Ride> Ride { get; set; }
        public DbSet<RideType> RideType { get; set; }
    }
}