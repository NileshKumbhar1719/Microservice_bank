using bank.Model;
using bank.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankservice;

        public BankController(IBankService bankService) 
        {
         _bankservice = bankService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBank()
        {
            var banks = await _bankservice.GetAll();

            return Ok(banks);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyIDbank(int id)
        {
            var banks = await _bankservice.GetById(id);
            if (banks == null)
            {
                return NotFound("Bank is not found");
            }

            return Ok(banks);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBank(Bank bank)
        {
            var createbank = await _bankservice.create(bank);

            return Ok(createbank);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBank(Bank bank, int id )
        {
            var UpdateData = await _bankservice.update(bank,id);
            if (UpdateData == null)
            {
                return NotFound();
            }

            return Ok(UpdateData);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBank(int id)
        {
            var data = await _bankservice.delete(id);
            if(data == false)
            {
                return NotFound("bank not found ");
            }

            return NoContent();
        }
    }
}
