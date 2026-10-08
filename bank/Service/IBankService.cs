using bank.Model;

namespace bank.Service
{
    public interface IBankService
    {
        Task<List<Bank>> GetAll();

        Task<Bank?> GetById(int id);

        Task<Bank> create(Bank bank);
        Task<Bank?> update(Bank bank,int id);
        Task<bool> delete(int id);
    }
}
