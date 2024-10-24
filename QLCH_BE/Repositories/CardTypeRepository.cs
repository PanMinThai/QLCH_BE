using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLCH_BE.Entities.Objects;
using QLCH_BE.Models;

namespace QLCH_BE.Repositories
{
    public interface ICardTypeRepository
    {
        public Task<List<CardTypeModel>> GetAllCardTypeAsync();
        public Task<CardTypeModel> GetCardTypeByIdAsync(Guid id);
        public Task<Guid> CreateCardTypeAsync(CardTypeModel model);
        public Task UpdateCardTypeAsync(CardTypeModel model, Guid id);
        public Task DeleteCardTypeAsync(Guid id);

    }
    public class CardTypeRepository : ICardTypeRepository
    {
        public readonly StoreManagementDbContext _context;
        public readonly IMapper _mapper;
        public CardTypeRepository(StoreManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateCardTypeAsync(CardTypeModel model)
        {
            var newCardType = _mapper.Map<CardTypeEntity>(model);
            _context.CardTypes.Add(newCardType);
            await _context.SaveChangesAsync();
            return newCardType.Id;
        }

        public async Task DeleteCardTypeAsync(Guid id)
        {
            var cardtype = await _context.CardTypes.FindAsync(id);
            if (cardtype != null)
            {
                _context.CardTypes.Remove(cardtype);
                await _context.SaveChangesAsync();
            }          
        }

        public async Task<List<CardTypeModel>> GetAllCardTypeAsync()
        {
            var list = await _context.CardTypes.ToListAsync();
            return _mapper.Map<List<CardTypeModel>>(list);
        }

        public async Task<CardTypeModel> GetCardTypeByIdAsync(Guid id)
        {
            var cardtype = await _context.CardTypes.FindAsync(id);
            return _mapper.Map<CardTypeModel>(cardtype);
        }

        public async Task UpdateCardTypeAsync(CardTypeModel model, Guid id)
        {
            var cardtype = await _context.CardTypes.SingleOrDefaultAsync(x => x.Id == id);
            _mapper.Map(model, cardtype);
            _context.CardTypes.Update(cardtype);
            await _context.SaveChangesAsync();
        }
    }
}
