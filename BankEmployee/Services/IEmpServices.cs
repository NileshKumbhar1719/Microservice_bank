using BankEmployee.Model;

namespace BankEmployee.Services
{
    public interface IEmpServices
    {
        Task<List<Employees>> GetAll();

        Task<Employees?> GetById(int id);

        Task<Employees> CreateEmp(Employees employee);

        Task<Employees?> UpdateEmployees(Employees employee, int id);

        Task<bool> DeleteEmployees(int id);
    }
}
