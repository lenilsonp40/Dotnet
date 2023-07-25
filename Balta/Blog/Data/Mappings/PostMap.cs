using System;
using System.Collections.Generic;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Blog.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public bool Configure(EntityTypeBuilder<Post> builder)
        {
            //Tabela
            builder.ToTable("Post");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn(); // IDENTITY(1, 1)

            builder.Property(x => x.LastUpdateDate)
            .IsRequired() // not null no banco
            .HasColumnName("LastUpdateDate") // colocar o nome na coluna
            .HasColumnType("SmallDATETIME") // tipo
            .HasMaxLength(60)
            .HasDefaultValueSql("GETDATE()"); // esse método usar função do sql
            //.HasDefaultValue(DateTime.Now.ToUniversalTime()); // dessa forma usa funçao do .Net em vez do sql

            // Indices
            builder.HasIndex(x => x.Slug, "IX_Post_Slug")
            .IsUnique();

            // Relacionamentos
            builder.HasOne(x => x.Author)
            .WithMany(x => x.Posts)
            .HasConstraintName("FH_Post_Author")
            .OnDelete(DeleteBehavior.Cascade);

            builder
            .HasOne(x => x.Category)
            .WithMany(x => x.Posts)
            .HasConstraintName("FH_Post_Category")
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Tags)
                .WithMany(x => x.Posts)
                .UsingEntity<Dictionary<string, object>>(
                    "PostTag",
                    post => post.HasOne<Tag>()
                        .WithMany()
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostTag_PostId")
                        .OnDelete(DeleteBehavior.Cascade),
                    tag => tag.HasOne<Post>()
                        .WithMany()
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK_PostTag_TagId")
                        .OnDelete(DeleteBehavior.Cascade));

        }
    }
}