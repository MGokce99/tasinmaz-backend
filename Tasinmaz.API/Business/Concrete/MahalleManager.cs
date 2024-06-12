using Business.Abstract;
using Core.Utilities;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{

    public class MahalleManager : IMahalleService
    {
        private readonly Context _context;

        public MahalleManager(Context context)
        {
            _context = context;
        }

        public async Task<IDataResult<List<Mahalle>>> GetAll()
        {
            var result = await this._context.Mahalle
           .Include(i => i.Ilce)
           .ThenInclude(i => i.Il).ToListAsync();

            return new SuccessDataResult<List<Mahalle>>(result, "Mahalleler Başarıyla Listelendi");
        }


        public async Task<IDataResult<Mahalle>> GetById(int Iid)
        {
            var result = await this._context.Mahalle
               .Include(i => i.Ilce)
               .ThenInclude(i => i.Il)
               .FirstOrDefaultAsync(p => p.MahalleId == Iid);

            return new SuccessDataResult<Mahalle>(result, "Başarılı");
        }

        public async Task<IDataResult<List<Mahalle>>> GetList()
        {
            var result = await this._context.Mahalle
            .Include(i => i.Ilce)
               .ThenInclude(i => i.Il).ToListAsync();

            return new SuccessDataResult<List<Mahalle>>(result, "Tüm Mahalle öğeleri başarıyla listelendi.");
        }

        public async Task<IDataResult<List<Mahalle>>> GetListByCategory(int categoryId)
        {
            var result = await this._context.Mahalle
            .Include(i => i.Ilce)
            .ThenInclude(i => i.Il)
            .Where(p => p.IlceId == categoryId) // Kategoriye göre filtreleme yapılıyor
            .ToListAsync();

            return new SuccessDataResult<List<Mahalle>>(result, "Kategoriye göre Mahalle öğeleri başarıyla listelendi.");
            //return new SuccessDataResult<List<Mahalle>>(_mahalleDal.GetList(p => p.IlceId == categoryId).ToList());
        }
    }
}
