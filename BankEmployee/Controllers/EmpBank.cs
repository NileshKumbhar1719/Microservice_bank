using BankEmployee.Model;
using BankEmployee.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;

namespace BankEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpBank : ControllerBase
    {
        private readonly IEmpServices _Empservice;

        public EmpBank(IEmpServices empServices)
        {
            this._Empservice = empServices;
             
        }

        [HttpGet]
        public async Task<IActionResult> GetEmp()
        {
            var emp = await _Empservice.GetAll();
            return Ok(emp);
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyEmp(int id )
        {
            var emp = await _Empservice.GetById(id);
            if (emp == null)
            {
                return NotFound(new {messages = "Emp not found"});
            }
            return Ok(emp);
        }
        [HttpPost]
        public async Task<IActionResult> CreEmp(Employees employees)
        {
            var emp = await _Empservice.CreateEmp(employees);
            return Ok(new { messages = " Emp Create Succefully", data = emp });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmp(Employees employees, int id)
        {
            var emp = await _Empservice.UpdateEmployees(employees, id);
            if (emp == null)
            {
                return NotFound(new {messages= "emp not found"});
            }
            return Ok(emp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EmpDelete(int id )
        {
             var emp = await _Empservice.DeleteEmployees(id);
             if(emp == false)
            {
                return NotFound(new {messages =" Emp not Found"});
            }
            return NoContent();
        }
    }
}
