using Microsoft.EntityFrameworkCore;
using QLCH_BE.Entities.Invoice;
using QLCH_BE.Entities.Objects;

namespace QLCH_BE.Common.Interface
{
    public interface IStoreManagementDbContext
    {
        DbSet<ProductEntity> Products { get; set; } 
        DbSet<BranchEntity> Branches { get; set; }
        DbSet<CardTypeEntity> CardTypes { get; set; }
        DbSet<EmployeeEntity> Employees { get; set; }
        DbSet<ImageEntity> Images { get; set; }
        DbSet<MembershipCardEntity> MembershipCards { get; set; }
        DbSet<SupplierEntity> Suppliers { get; set; }
        DbSet<ExpenseInvoiceEntity> ExpenseInvoices { get; set; }
        DbSet<InvoiceDetailEntity> InvoiceDetails { get; set; }
        DbSet<InvoiceEntity> Invoices { get; set; }
        DbSet<PurchaseInvoiceEntity> PurchaseInvoices { get;set; }
        int SaveChanges();
    }
}
