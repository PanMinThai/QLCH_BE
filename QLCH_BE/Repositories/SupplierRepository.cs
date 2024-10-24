using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLCH_BE.Entities.Objects;
using QLCH_BE.Models;
using System.Diagnostics.Contracts;

namespace QLCH_BE.Repositories
{
    public interface ISupplierRepository
    {
        public Task<List<SupplierModel>> GetAllSuppliers();
        public Task<SupplierModel> GetSuppliersById(Guid id);
        public Task<Guid> CreateSupplier(SupplierModel supplier);
        public Task DeleteSupplier(Guid id);
        public Task UpdateSupplier(SupplierModel model, Guid id);
    }
    public class SupplierRepository : ISupplierRepository
    {
        public readonly StoreManagementDbContext _context;
        public readonly IMapper _mapper;
        public SupplierRepository(StoreManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> CreateSupplier(SupplierModel model)
        {
            var supplier = _mapper.Map<SupplierEntity>(model);
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier.Id;
        }

        public async Task DeleteSupplier(Guid id)
        {
            var supplier = await _context.Suppliers.SingleOrDefaultAsync(x => x.Id == id);
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SupplierModel>> GetAllSuppliers()
        {
            var list = await _context.Suppliers.ToListAsync();
            return _mapper.Map<List<SupplierModel>>(list);
        }

        public async Task<SupplierModel> GetSuppliersById(Guid id)
        {
            var supplier = await _context.Suppliers.SingleOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<SupplierModel>(supplier);
        }

        public async Task UpdateSupplier(SupplierModel model, Guid id)
        {
            var supplier = await _context.Suppliers.SingleOrDefaultAsync(x => x.Id ==  id);
            _mapper.Map(model, supplier);
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
        }
    }
}
