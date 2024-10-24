using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLCH_BE.Entities.Objects;
using QLCH_BE.Models;

namespace QLCH_BE.Repositories
{
    public interface IMembershipCardRepository
    {
        public Task<List<MembershipCardModel>> GetAllMembershipCard();
        public Task<MembershipCardModel> GetMembershipCardById(Guid id);
        public Task<Guid> CreateMembershipCard(MembershipCardModel model);
        public Task DeleteMembershipCard(Guid id);
        public Task UpdateMembershipCard(MembershipCardModel model, Guid id);
    }
    public class MembershipCardRepository : IMembershipCardRepository
    {
        public readonly StoreManagementDbContext _context;
        public readonly IMapper _mapper;
        public MembershipCardRepository(StoreManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateMembershipCard(MembershipCardModel model)
        {
            var card = _mapper.Map<MembershipCardEntity>(model); 
            _context.MembershipCards.Add(card);
            await _context.SaveChangesAsync();
            return card.Id;
        }

        public async Task DeleteMembershipCard(Guid id)
        {
            var card = await _context.MembershipCards.SingleOrDefaultAsync(x => x.Id == id);
            _context.MembershipCards.Remove(card);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MembershipCardModel>> GetAllMembershipCard()
        {
            var list = await _context.MembershipCards.ToListAsync();
            return _mapper.Map<List<MembershipCardModel>>(list);
        }

        public async Task<MembershipCardModel> GetMembershipCardById(Guid id)
        {
            var card = await _context.MembershipCards.FindAsync(id);
            return _mapper.Map<MembershipCardModel>(card);
        }

        public async Task UpdateMembershipCard(MembershipCardModel model, Guid id)
        {
            var card = await _context.MembershipCards.FindAsync(id);
            _mapper.Map(model, card);
            _context.MembershipCards.Update(card);
            await _context.SaveChangesAsync();
        }
    }
}
