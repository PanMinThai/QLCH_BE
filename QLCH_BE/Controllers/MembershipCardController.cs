using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLCH_BE.Models;
using QLCH_BE.Repositories;

namespace QLCH_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipCardController : ControllerBase
    {
        private readonly IMembershipCardRepository _repository;
        public MembershipCardController(IMembershipCardRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<MembershipCardModel>>> Index()
        {
            var list = await _repository.GetAllMembershipCard();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MembershipCardModel>> Detail(Guid id)
        {
            var membershipcard = await _repository.GetMembershipCardById(id);
            return Ok(membershipcard);
        }
        [HttpPost]
        public async Task<ActionResult> Create(MembershipCardModel model)
        {
            var id = await _repository.CreateMembershipCard(model);
            var membershipcard = _repository.GetMembershipCardById(id);
            return Ok(membershipcard);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _repository.DeleteMembershipCard(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(MembershipCardModel model, Guid id)
        {
            await _repository.UpdateMembershipCard(model, id);
            return Ok();
        }
            
    }
}
