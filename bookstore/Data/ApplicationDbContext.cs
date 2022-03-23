using Microsoft.EntityFrameworkCore;
using bookstore.Models;
namespace bookstore.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            // create tb_bookcategory, m-2-m between book and category
            modelBuider.Entity<BookCategory>().HasKey(bc => new
            {
                bc.category_id,
                bc.book_id
            });

            modelBuider.Entity<BookCategory>().HasOne(b => b.Book)
                .WithMany(bc => bc.BookCategories)
                .HasForeignKey(b => b.book_id);
            modelBuider.Entity<BookCategory>().HasOne(c => c.Category)
                .WithMany(cb => cb.CategoryBooks)
                .HasForeignKey(c => c.category_id);

            // create tb_authorbook, m2m between author and book
            modelBuider.Entity<AuthorBook>().HasKey(ab => new
            {
                ab.author_id,
                ab.book_id
            });

            modelBuider.Entity<AuthorBook>().HasOne(a => a.author)
                .WithMany(ab => ab.AuthorBooks)
                .HasForeignKey(a => a.author_id);
            modelBuider.Entity<AuthorBook>().HasOne(b => b.book)
                .WithMany(ba => ba.BookAuthors)
                .HasForeignKey(b => b.book_id);

            // create tb_rentorder, m2m between renter and book
            modelBuider.Entity<RentOrder>().HasKey(ro => new
            {
                ro.order_id
            });

            modelBuider.Entity<RentOrder>().HasOne(r => r.renter)
                .WithMany(ro => ro.RenterOrders)
                .HasForeignKey(r => r.renter_id);

            modelBuider.Entity<RentOrder>().HasOne(b => b.book)
                .WithMany(bo => bo.BookOrders)
                .HasForeignKey(b => b.book_id);

            base.OnModelCreating(modelBuider);

        }

        public DbSet<Category> category { get; set; }
        public DbSet<Book> book { get; set; }
        public DbSet<BookCategory> category_book { get; set; }

        public DbSet<Author> author { get; set; }
        public DbSet<AuthorBook> author_book { get; set; }
        public DbSet<Renter> renter { get; set; }
        public DbSet<RentOrder> rentorder { get; set; }
    }
}
