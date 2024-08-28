using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PT.DAL.Model;

namespace PT.DAL.Context;

public partial class MarketPartiesContext : DbContext
{
    public MarketPartiesContext(DbContextOptions<MarketPartiesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BalanceResponsibleParties> BalanceResponsibleParties { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BalanceResponsibleParties>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BusinessId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CodingScheme)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ValidityEnd).HasColumnType("datetime");
            entity.Property(e => e.ValidityStart).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
