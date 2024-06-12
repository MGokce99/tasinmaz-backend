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
using Tasinmaz.API.Entities.DTOs;


namespace Business.Concrete
{
    public class IlceManager : IIlceService
    {
        private readonly Context _context;

        public IlceManager(Context context)
        {
            _context = context;
        }

        public async Task<IDataResult<List<Ilce>>> GetAll()
        {
            var result = await this._context.Ilce
           .Include(i => i.Il).ToListAsync();

            return new SuccessDataResult<List<Ilce>>(result, "İlçeler Başarıyla Listelendi...");
        }

        public async Task<IDataResult<Ilce>> GetById(int id)
        {
            var result = await this._context.Ilce
               .Include(i => i.Il)
               .FirstOrDefaultAsync(p => p.IlceId == id);

            return new SuccessDataResult<Ilce>(result, "Başarılı");

            //return new SuccessDataResult<Ilce>(_ilceDal.Get(p => p.IlceId == Iid));
        }

        public async Task<IDataResult<List<Ilce>>> GetByIlID(int id)
        {
            var result = await this._context.Ilce
            .Include(i => i.Il)
            .Where(p => p.IlId == id)
            .ToListAsync();

            return new SuccessDataResult<List<Ilce>>(result, "Başarılı");
            //return new SuccessDataResult<List<Ilce>>(_ilceDal.GetAll(c => c.IlId == id));
        }

        public async Task<IDataResult<List<Ilce>>> GetList()
        {
            var result = await this._context.Ilce
            .Include(i => i.Il)
            .ToListAsync();

            return new SuccessDataResult<List<Ilce>>(result, "Tüm Ilce öğeleri başarıyla listelendi.");
            //return new SuccessDataResult<List<Ilce>>(_ilceDal.GetList().ToList());
        }

        public async Task<IDataResult<List<Ilce>>> GetListByCategory(int categoryId)
        {
            var result = await this._context.Ilce
           .Include(i => i.Il)
           .Where(p => p.IlId == categoryId) // Kategoriye göre filtreleme yapılıyor
           .ToListAsync();

            return new SuccessDataResult<List<Ilce>>(result, "Kategoriye göre Ilce öğeleri başarıyla listelendi.");

            //return new SuccessDataResult<List<Ilce>>(_ilceDal.GetList(p => p.IlId == categoryId).ToList());
        }

        public async Task<IDataResult<List<IlceDetailDto>>> GetIlceDetails()
        {
            try
            {
                // Tüm ilçeleri al
                var ilceListResult = await GetAll();

                // Eğer ilçe listesi başarılı şekilde alındıysa
                if (ilceListResult.Success)
                {
                    // Ilce listesini al
                    var ilceList = ilceListResult.Data;

                    // Ilce detaylarını oluşturmak için döngü
                    var ilceDetailList = ilceList.Select(ilce => new IlceDetailDto
                    {
                        Iid = ilce.IlId,
                        Iname = ilce.IlceName,
                        SId = ilce.IlceId,
                        // Diğer detayları ekleyin
                    }).ToList();

                    // Başarılı sonucu dön
                    return new SuccessDataResult<List<IlceDetailDto>>(ilceDetailList, "Ilçe detayları başarıyla listelendi.");
                }
                else
                {
                    // Hata durumunda hata sonucunu dön
                    return new ErrorDataResult<List<IlceDetailDto>>(null, ilceListResult.Message);
                }
            }
            catch (Exception ex)
            {
                // Hata oluştuğunda hata sonucunu dön
                return new ErrorDataResult<List<IlceDetailDto>>(null, "Ilçe detayları alınırken bir hata oluştu: " + ex.Message);
            }

            //return new SuccessDataResult<List<IlceDetailDto>>(_ilceDal.GetIlceDetails());
        }

    }
}
