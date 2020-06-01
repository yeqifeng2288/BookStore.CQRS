using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BookStore.CQRS.Books;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.CQRS.EntityFramework.Config
{
    internal class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasOne(a => a.Author).WithOne().HasForeignKey<Author>(o => o.Id);

            builder.OwnsOne(o => o.BookInfo);
        }
    }
}
