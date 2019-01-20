﻿using Demo.PatrimonyManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.PatrimonyManagement.Data.Mapping
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);

            entityBuilder.Property(t => t.Name)
                .HasColumnType("varchar(200)")
                .HasMaxLength(100)
                .IsRequired();

            entityBuilder.Property(t => t.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            entityBuilder.Property(t => t.Password)
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50)
                    .IsRequired();

            entityBuilder.Property(t => t.PasswordSalt)
                   .HasColumnType("varchar(50)")
                   .HasMaxLength(50)
                   .IsRequired();
        }
    }
}
