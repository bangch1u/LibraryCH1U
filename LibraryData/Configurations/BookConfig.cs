using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Configurations
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(e => e.BookId);

            builder.HasMany(s => s.Genres)
                .WithMany(s => s.Books)
                .UsingEntity(tb => tb.ToTable("Book_Genre"));
                //.HasMany(s => s.Authors)
                //.WithMany(s => s.Books)
                //.UsingEntity(a => a.ToTable("bookAuthor"));
        }
    }
}
