using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QLCH_BE.Common.Interface;
using QLCH_BE.Entities.Common;
using QLCH_BE.Entities.Invoice;
using QLCH_BE.Entities.Objects;
using QLCH_BE.Models;

namespace QLCH_BE
{
    public class StoreManagementDbContext :IdentityDbContext<AppUser>,IStoreManagementDbContext
    {
        
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<BranchEntity> Branches { get; set; }
        public DbSet<CardTypeEntity> CardTypes { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<ImageEntity> Images { get; set; }
        public DbSet<MembershipCardEntity> MembershipCards { get; set; }
        public DbSet<SupplierEntity> Suppliers { get; set; }
        public DbSet<ExpenseInvoiceEntity> ExpenseInvoices { get; set; }
        public DbSet<InvoiceDetailEntity> InvoiceDetails { get; set; }
        public DbSet<InvoiceEntity> Invoices { get; set; }
        public DbSet<PurchaseInvoiceEntity> PurchaseInvoices { get;set; }
        public StoreManagementDbContext(DbContextOptions<StoreManagementDbContext> options) : base(options) { }
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                var entity = (BaseEntity)entityEntry.Entity;
                entity.UpdateTime = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    entity.CreateTime = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
          
            builder.Entity<ProductEntity>()
                   .HasOne(a => a.Image)
                   .WithOne(b => b.Product)
                   .HasForeignKey<ImageEntity>(c => c.Id);
            builder.Entity<MembershipCardEntity>()
                .HasOne(a => a.CardType)
                .WithMany(b => b.membershipcard)
                .HasForeignKey(x => x.CardTypeId);
        }
    }
}
