using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace _2312805_TranNgocNhuY_lab07.Models
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Table01> Tables { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Bills> Bills { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleAccount> RoleAccounts { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Account>()
                .HasKey(a => a.AccountName);

            modelBuilder.Entity<RoleAccount>()
                .HasKey(ra => new { ra.RoleId, ra.AccountName });

            modelBuilder.Entity<Food>()
                .HasRequired(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.FoodCategoryId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Bills>()
                .HasRequired(x => x.Table01)
                .WithMany(t => t.Bills)
                .HasForeignKey(x => x.TableId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BillDetail>()
                .HasRequired(bd => bd.Bill)
                .WithMany(b => b.BillDetails)
                .HasForeignKey(bd => bd.InvoiceId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<BillDetail>()
                .HasRequired(bd => bd.Food)
                .WithMany()
                .HasForeignKey(bd => bd.FoodId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoleAccount>()
                .HasRequired(ra => ra.Role)
                .WithMany(r => r.RoleAccounts)
                .HasForeignKey(ra => ra.RoleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoleAccount>()
                .HasRequired(ra => ra.Account)
                .WithMany(a => a.RoleAccounts)
                .HasForeignKey(ra => ra.AccountName)
                .WillCascadeOnDelete(false);
        }
    }
}
