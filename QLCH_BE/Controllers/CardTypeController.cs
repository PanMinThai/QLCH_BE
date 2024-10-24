using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLCH_BE.Models;
using QLCH_BE.Repositories;
using System.Reflection.Metadata.Ecma335;
using System.Security.Permissions;

namespace QLCH_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardTypeController : ControllerBase
    {
        private readonly ICardTypeRepository _repository;
        public CardTypeController(ICardTypeRepository cardTypeRepository)
        {
            _repository = cardTypeRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<CardTypeModel>>> Index()
        {
            var list = await _repository.GetAllCardTypeAsync();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CardTypeModel>> Detail(Guid id)
        {
            var cardtype = await _repository.GetCardTypeByIdAsync(id);
            return Ok(cardtype);
        }
        [HttpPost]
        public async Task<ActionResult> Create(CardTypeModel model)
        {
            await _repository.CreateCardTypeAsync(model);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _repository.DeleteCardTypeAsync(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(CardTypeModel model,Guid id)
        {
            await _repository.UpdateCardTypeAsync(model, id);
            return Ok();
        }
    }
}
