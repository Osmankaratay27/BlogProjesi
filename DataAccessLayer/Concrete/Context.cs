using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-56OJ44O; database=CoreBlogDb; integrated security=true;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(x => x.WrtierSender)
                .WithMany(y => y.MessageSender)
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
            .HasOne(x => x.WriterReceiver)
            .WithMany(y => y.MessageReceiver)
            .HasForeignKey(z => z.ReceiverID)
            .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRating> BlogRatings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Admin> Admins { get; set; }
     
    }
}
