using BankEmployee.Model;
using Microsoft.EntityFrameworkCore;

namespace BankEmployee.Repository
{
    public class EmpRepository : IEmpRepository
    {
        private readonly DbContextbank _ContextEmp;

        public EmpRepository(DbContextbank dbContextbank)
        {
             this._ContextEmp = dbContextbank;
        }

        public async Task<Employees> CreateEmpAsync(Employees employee)
        {
               await _ContextEmp.employees.AddAsync(employee);
               await _ContextEmp.SaveChangesAsync();
            return employee;
             
        }

        public async Task<bool> DeleteEmployeesAsync(int id)
        {
            var emp = await _ContextEmp.employees.FindAsync(id);
            if (emp == null)
            {
                return false;

            }
             _ContextEmp.employees.Remove(emp);
            await _ContextEmp.SaveChangesAsync();
            return true;
        }

        public async Task<List<Employees>> GetAllAsync()
        {
            var emp = await _ContextEmp.employees.ToListAsync();
            return emp;
        }

        public async Task<Employees?> GetByIdAsync(int id)
        {
            var emp = await _ContextEmp.employees.FindAsync(id);
            if (emp == null)
            {
                return null;


            }
            return emp;
        }

        public async Task<Employees?> UpdateEmployeesAsync(Employees employee, int id)
        {
            var emp = await _ContextEmp.employees.FindAsync(id);
            if(emp == null)
            {
                return null;

            }
            emp.EmpName = employee.EmpName;
            emp.Salary = employee.Salary;
            emp.EmpPhone = employee.EmpPhone;
            emp.EmpStatus = employee.EmpStatus;
            emp.EmpDepartment = employee.EmpDepartment;
            emp.EmpDesc = employee.EmpDesc;

            await _ContextEmp.SaveChangesAsync();
            return emp;
        }
    }
}
