using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLCH_BE.Entities.Objects;
using QLCH_BE.Models;

namespace QLCH_BE.Repositories
{
    public interface IBranchRepository
    {
        public Task<BranchModel> GetBranchByIdAsync(Guid id);
        public Task<List<BranchModel>> GetAllBranchesAsync();
        public Task<Guid> CreateBranchAsync(BranchModel branch);
        public Task DeleteBranchAsync(Guid id);
        public Task UpdateBranchAsync(BranchModel branch, Guid id);
    }
    public class BranchRepository : IBranchRepository
    {
        public readonly StoreManagementDbContext _context;
        public readonly IMapper _mapper;
        public BranchRepository(StoreManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> CreateBranchAsync(BranchModel model)
        {
            var newBranch = _mapper.Map<BranchEntity>(model);
            _context.Branches.Add(newBranch);
            await _context.SaveChangesAsync();
            return newBranch.Id;

        }

        public async Task DeleteBranchAsync(Guid id)
        {
            var branch = await _context.Branches.FindAsync(id);
            if (branch != null)
            {
                _context.Branches.Remove(branch);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<BranchModel>> GetAllBranchesAsync()
        {
            var list = await _context.Branches.ToListAsync();
            return _mapper.Map<List<BranchModel>>(list);
        }

        public async Task<BranchModel> GetBranchByIdAsync(Guid id)
        {
            var branch = await _context.Branches.SingleOrDefaultAsync(x=>x.Id == id);
            return _mapper.Map<BranchModel>(branch);
        }

        public async Task UpdateBranchAsync(BranchModel model, Guid id)
        {
            var branch = await _context.Branches.SingleOrDefaultAsync(x=>x.Id == id);
            if(branch != null)
            {
                _mapper.Map(model, branch);
                _context.Branches.Update(branch);
                await _context.SaveChangesAsync();
            }
        }
    }
}
