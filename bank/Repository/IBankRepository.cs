

using bank.Model;
using System.Collections.Generic;

namespace bank.repository
{
    public interface IBankRepository
    {
        Task<List<Bank>> GetBanksAsync();

        Task<Bank?> getbanksidasync(int id);    
        Task<Bank> createbankasync(Bank bank);

        Task<Bank?> updatebankasync(Bank bank, int id);

        Task<bool> deletebankasync(int id);
    }
}
