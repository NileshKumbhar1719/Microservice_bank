using bank.Model;
using bank.repository;
using bank.Repository;

namespace bank.Service
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _BankRepo;

        public BankService(IBankRepository bankRepository) 
        {
            this._BankRepo = bankRepository;
        
        }

        public  async Task<Bank> create(Bank bank)
        {
            return await _BankRepo.createbankasync(bank);
        }

        public async Task<bool> delete(int id)
        {
            return await _BankRepo.deletebankasync(id);
        }

        public async Task<List<Bank>> GetAll()
        {
            return await _BankRepo.GetBanksAsync();
        }

        public async Task<Bank?> GetById(int id)
        {
            return await _BankRepo.getbanksidasync(id);
        }

        public async Task<Bank?> update(Bank bank, int id)
        {
            return await _BankRepo.updatebankasync(bank, id);
        }
    }
}
