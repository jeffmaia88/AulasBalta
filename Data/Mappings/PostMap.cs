using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AulasBalta.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.LastUpdateDate).IsRequired()
                                                   .HasColumnName("LastUpdateDate")
                                                   .HasColumnType("SMALLDATETIME")
                                                   .HasMaxLength(60)
                                                   .HasDefaultValueSql("GETDATE()"); // Horario do Banco


            //Indices
            builder.HasIndex(x => x.Slug, "IX_Post_Slug").IsUnique();


            //Relacionamentos

            // 1 para N
            builder.HasOne(x => x.Author).WithMany(x => x.Posts)
                                         .HasConstraintName("FK_Post_Author")
                                         .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Category);

            // N para N
            builder.HasMany(x => x.Tags).WithMany(x => x.Posts)
                                        .UsingEntity<Dictionary<string, object>>(
                                            "PostTag",
                                            post => post.HasOne<Tag>().WithMany()
                                                        .HasForeignKey("PostId")
                                                        .HasConstraintName("FK_PostTag_PostId")
                                                        .OnDelete(DeleteBehavior.Cascade),
                                            
                                            tag => tag.HasOne<Post>().WithMany()
                                                                     .HasForeignKey("TagId")
                                                                     .HasConstraintName("FK_PostTag_TagId")
                                                                     .OnDelete(DeleteBehavior.Cascade));
                                                        
            

        }
    }
}