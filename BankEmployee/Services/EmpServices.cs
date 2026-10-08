using BankEmployee.Model;
using BankEmployee.Repository;

namespace BankEmployee.Services
{
    public class EmpServices : IEmpServices
    {
        private readonly IEmpRepository _empRepo;

        public EmpServices(IEmpRepository empRepository)
        {
            this._empRepo = empRepository;
             
        }

        public async Task<Employees> CreateEmp(Employees employee)
        {
            return await _empRepo.CreateEmpAsync(employee);
        }

        public async Task<bool> DeleteEmployees(int id)
        {
           return await _empRepo.DeleteEmployeesAsync(id);
        }

        public async Task<List<Employees>> GetAll()
        {
            return await _empRepo.GetAllAsync();
        }

        public Task<Employees?> GetById(int id)
        {
           return _empRepo.GetByIdAsync(id);
        }

        public async Task<Employees?> UpdateEmployees(Employees employee, int id)
        {
            return await _empRepo.UpdateEmployeesAsync(employee, id);
        }
    }
}
