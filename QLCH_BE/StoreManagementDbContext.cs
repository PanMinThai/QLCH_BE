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
    public class StoreManagementDbContext :IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>,IStoreManagementDbContext
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
                entity.UpdatedTime = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    entity.CreatedTime = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
          
            // ApplicationUser
            builder.Entity<ApplicationUser>()
                .HasOne(a => a.Employee)
                .WithOne(b => b.ApplicationUser)
                .HasForeignKey<EmployeeEntity>(x => x.AppUserId);

            // Product - Image
            builder.Entity<ProductEntity>()
                   .HasOne(a => a.Image)
                   .WithOne(b => b.Product)
                   .HasForeignKey<ImageEntity>(c => c.Id);

            // Membership Card  - Card Type
            builder.Entity<MembershipCardEntity>()
                .HasOne(a => a.CardType)
                .WithMany(b => b.Membershipcard)
                .HasForeignKey(x => x.CardTypeId);

            // Branch
            builder.Entity<EmployeeEntity>()
                .HasOne(a => a.Branch)
                .WithMany(b => b.Employees)
                .HasForeignKey(x => x.BranchId);

            // Purchase Invoice
            builder.Entity<PurchaseInvoiceEntity>()
                .HasOne(a => a.Supplier)
                .WithMany(b => b.PurchaseInvoices)
                .HasForeignKey(x => x.SupplierId);
            builder.Entity<PurchaseInvoiceEntity>()
                .HasOne(a => a.Employee)
                .WithMany(b => b.PurchaseInvoices)
                .HasForeignKey (x => x.EmployeeId);

            // Expense Invoice
            builder.Entity<ExpenseInvoiceEntity>()
                .HasOne(a => a.Employee)
                .WithMany(b => b.ExpenseInvoices)
                .HasForeignKey (x => x.EmployeeId);

            // Invoice 
            builder.Entity<InvoiceEntity>()
                .HasOne(a => a.Employee)
                .WithMany(b => b.Invoices)
                .HasForeignKey (x => x.EmployeeId);
            builder.Entity<InvoiceEntity>()
                .HasOne(a => a.MembershipCard)
                .WithMany(b => b.Invoices)
                .HasForeignKey (x => x.MembershipCardId);

            // Invoice Detail
            builder.Entity<InvoiceDetailEntity>()
                .HasOne(a => a.Invoice)
                .WithMany(b => b.InvoiceDetails)
                .HasForeignKey(x => x.InvoiceId);
            builder.Entity<InvoiceDetailEntity>()
                .HasOne(a => a.PurchaseInvoice)
                .WithMany(b => b.InvoiceDetails)
                .HasForeignKey(x => x.PurchaseInvoiceId);
            builder.Entity<InvoiceDetailEntity>()
                .HasOne(a => a.Product)
                .WithMany(b => b.InvoiceDetails)
                .HasForeignKey(x => x.ProductId);

        }
    }
}
