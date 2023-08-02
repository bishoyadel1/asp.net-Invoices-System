

using Domin.Entity;
using Domin.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infrastructure.Data
{
    public class InvoicesAppDbContext : IdentityDbContext<AppUserModel>
    {
        public InvoicesAppDbContext(DbContextOptions<InvoicesAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        //    modelBuilder.Entity<Invoice>().HasMany(i=>i.InvoiceItems).WithOne(i => i.Invoice);
            //modelBuilder.Entity<LogCategory>().Property(n => n.Id).HasDefaultValueSql("(newid())");

            //modelBuilder.Entity<LogBook>().Property(n => n.Id).HasDefaultValueSql("(newid())");
            //modelBuilder.Entity<UsersView>().HasNoKey().ToView("UsersView");
            ////    modelBuilder.Entity<NewCategory>().Property(i => i.Id).HasDefaultValue("1");
            //modelBuilder.Entity<LogCategory>()
            //  .HasOne(lc => lc.Category)
            //  .WithMany()
            //  .HasForeignKey(lc => lc.CategoryId)
            //  .OnDelete(DeleteBehavior.Restrict);


        }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<InvoiceTemp> InvoiceTemp { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItem { get; set; }
    }


}
