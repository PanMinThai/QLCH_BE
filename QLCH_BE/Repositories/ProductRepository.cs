using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLCH_BE.Entities.Objects;
using QLCH_BE.Models;

namespace QLCH_BE.Repositories
{
    public interface IProductRepository
    {
        public Task<List<ProductModel>> GetAllProducts();
        public Task<ProductModel> GetProductById(Guid id);
        public Task<Guid> CreateProduct(ProductModel model);
        public Task DeleteProduct(Guid id);
        public Task UpdateProduct(ProductModel model, Guid id);
    }
    public class ProductRepository : IProductRepository
    {
        public readonly StoreManagementDbContext _context;
        public readonly IMapper _mapper;
        public ProductRepository(StoreManagementDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> CreateProduct(ProductModel model)
        {
            var newProduct = _mapper.Map<ProductEntity>(model);
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct.Id;
        }

        public async Task DeleteProduct(Guid id)
        {
            var product =  await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            var list = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductModel>>(list);
        }

        public async Task<ProductModel> GetProductById(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            return _mapper.Map<ProductModel>(product);
        }

        public async Task UpdateProduct(ProductModel model, Guid id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id ==id);
            _mapper.Map(model, product);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();  
        }
    }
}
