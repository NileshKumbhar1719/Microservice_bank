using bank.Model;
using bank.repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace bank.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly DBContext _context;

        public BankRepository(DBContext dbcontext)
        { 
            this._context = dbcontext;
        
        }

        public async Task<Bank> createbankasync(Bank bank)
        {
             await _context.bank.AddAsync(bank);
             await _context.SaveChangesAsync();
             return bank;
                     
        }

        public async Task<bool> deletebankasync(int id)
        {
           var bank = await _context.bank.FindAsync(id);
            if(bank == null)
            {
                return false;

            }
              _context.bank.Remove(bank);
             await _context.SaveChangesAsync();
             return true;
        }

        public async Task<List<Bank>> GetBanksAsync()
        { 
           return await _context.bank.ToListAsync();
            
        }

       
        public async Task<Bank?> getbanksidasync(int id)
        {
            var banks = await _context.bank.FindAsync(id);

            return banks;
        }

        public async Task<Bank?> updatebankasync(Bank bank, int id)
        {
            var banks = await _context.bank.FindAsync(id);
            if (banks == null)
            {
                return null;
            }
          
            banks.bankname = bank.bankname;
            banks.bankbranch = bank.bankbranch;
            banks.banktype = bank.banktype;

            await _context.SaveChangesAsync();
            return banks;
                
        }
    }

    
}
