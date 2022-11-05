#pragma warning disable CS8618

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCoreMVCBoilerPlate.Data.DataModels;

namespace NetCoreMVCBoilerPlate.Data;

public class ApplicationDbContext : IdentityDbContext
{
   public virtual DbSet<DummyEntity> DummyEntities { get; set; }


   public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
   {
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<DummyEntity>(entity =>
      {
         entity.HasKey(e => e.DummyId);

         entity.Property(e => e.DummyId)
            .HasColumnName("DummyId");
         entity.Property(e => e.DummyFirstName)
            .HasMaxLength(50)
            .IsUnicode(false);
         entity.Property(e => e.DummyLastName)
            .HasMaxLength(50)
            .IsUnicode(false);
      });
   }
}

#pragma warning restore CS8618