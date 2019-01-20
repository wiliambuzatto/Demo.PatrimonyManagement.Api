using Demo.PatrimonyManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.PatrimonyManagement.Data.Mapping
{
    public class BrandMap
    {
        public BrandMap(EntityTypeBuilder<Brand> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);

            entityBuilder.Property(t => t.Name)
                .HasColumnType("varchar(200)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
