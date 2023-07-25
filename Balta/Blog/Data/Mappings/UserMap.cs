using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Tabela
            builder.ToTable("User");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn(); // IDENTITY(1, 1)

            builder.Property(x => x.Name)
            .IsRequired() // not null no banco
            .HasColumnName("Name") // colocar o nome na coluna
            .HasColumnType("Nvarchar") // tipo
            .HasMaxLength(80);

            builder.Property(x => x.Bio);
            builder.Property(x => x.Email);
            builder.Property(x => x.Image);
            builder.Property(x => x.PasswordHash);

            builder.Property(x => x.Slug)
           .IsRequired() // not null no banco
           .HasColumnName("Slug") // colocar o nome na coluna
           .HasColumnType("Varchar") // tipo
           .HasMaxLength(80);

            // Indices
            builder.HasIndex(x => x.Slug, "IX_Category_Slug")
            .IsUnique();

            builder
            .HasMany(x => x.Roles)
            .WithMany(x => x.Users)
            UsingEntity<Dictionary<string, object>>(
                "UserRole",
                Role => role
                    .HasOne<Role>()
                    .WithMany()
                    .HasForeignKey("Roled")
                    .HasConstraintName("FK_User_RoledId")
                    .OnDelete(DeleteBehavior.Cascade),
                User => user
                    .HasOne<Role>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .HasConstraintName("FK_User_RoledId")
                    .OnDelete(DeleteBehavior.Cascade));


        }
    }
}