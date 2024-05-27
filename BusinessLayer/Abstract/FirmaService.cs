using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public class FirmaService
    {
        private readonly IRepository<Firma> _firmaRepository;

        public FirmaService(IRepository<Firma> firmaRepository)
        {
            _firmaRepository = firmaRepository;
        }

        public async Task<IEnumerable<Firma>> GetAllFirmalarAsync()
        {
            return await _firmaRepository.GetAllAsync();
        }

        public async Task<Firma> GetFirmaByIdAsync(int id)
        {
            return await _firmaRepository.GetByIdAsync(id);
        }

        public async Task AddFirmaAsync(Firma firma)
        {
            await _firmaRepository.AddAsync(firma);
            await _firmaRepository.SaveChangesAsync();
        }

        public async Task UpdateFirmaAsync(Firma firma)
        {
            _firmaRepository.Update(firma);
            await _firmaRepository.SaveChangesAsync();
        }
    }
}
