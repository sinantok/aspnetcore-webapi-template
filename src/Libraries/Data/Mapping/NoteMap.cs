using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.DbEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public class NoteMap : MappingEntityTypeConfiguration<Note>
    {
        public override void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Notes");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).HasMaxLength(255);
            builder.Property(p => p.Category).HasMaxLength(255);
            builder.Property(p => p.Description).HasMaxLength(255);
            builder.Property(p => p.Owner).HasMaxLength(255);
            builder.Property(p => p.CreateUTC).HasColumnType("DateTime").HasDefaultValueSql("GetUtcDate()");
            base.Configure(builder);

        }
    }
}
