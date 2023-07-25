
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Tabela
            builder.ToTable("Category");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn(); // IDENTITY(1, 1)
            

            // Propriedades
            builder.Property(x => x.Name)
            .IsRequired() // not null no banco
            .HasColumnName("Name") // colocar o nome na coluna
            .HasColumnType("Nvarchar") // tipo
            .HasMaxLength(80);


            builder.Property(x => x.Slug)
           .IsRequired() // not null no banco
           .HasColumnName("Slug") // colocar o nome na coluna
           .HasColumnType("Varchar") // tipo
           .HasMaxLength(80);

            // Indices
            builder.HasIndex(x => x.Slug, "IX_Category_Slug")
            .IsUnique();

        }
    }
}