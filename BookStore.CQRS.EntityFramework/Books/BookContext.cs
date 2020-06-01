using BookStore.CQRS.Books;
using BookStore.CQRS.EntityFramework.Config;
using Microsoft.EntityFrameworkCore;

namespace BookStore.CQRS.EntityFramework.Books
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        /// <summary>
        /// 数据聚合。
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// 作者聚合。
        /// </summary>
        public DbSet<Author> Authors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());

            modelBuilder.ApplyConfiguration(new AuthorConfig());
        }
    }
}
