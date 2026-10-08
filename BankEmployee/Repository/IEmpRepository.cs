using BankEmployee.Model;

namespace BankEmployee.Repository
{
    public interface IEmpRepository
    {
        Task<List<Employees>> GetAllAsync();

        Task<Employees?> GetByIdAsync(int id);

        Task<Employees> CreateEmpAsync(Employees employee);

        Task<Employees?> UpdateEmployeesAsync(Employees employee,int id);

        Task<bool>DeleteEmployeesAsync(int id);
    }
}
