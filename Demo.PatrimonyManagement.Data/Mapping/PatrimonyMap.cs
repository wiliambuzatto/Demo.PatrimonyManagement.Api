using Demo.PatrimonyManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.PatrimonyManagement.Data.Mapping
{
    public class PatrimonyMap
    {
        public PatrimonyMap(EntityTypeBuilder<Patrimony> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);

            entityBuilder.Property(t => t.Name)
                .HasColumnType("varchar(200)")
                .HasMaxLength(100)
                .IsRequired();

            entityBuilder.Property(t => t.Description)
                .HasColumnType("varchar(500)")
                .HasMaxLength(100);

            entityBuilder.Property(t => t.TippingNumber)
                    .HasColumnType("uniqueIdentifier")
                    .HasMaxLength(50);

            entityBuilder
              .HasOne(t => t.Brand)
              .WithMany(p => p.Patrimonies)
              .HasForeignKey(x => x.BrandId);
        }
    }
}
