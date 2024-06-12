using Core.Utilities;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Tasinmaz.API.Entities.DTOs;
using TasinmazProje.API.Business.Abstract;


namespace Tasinmaz.API.Business.Concrete
{
    public class ParselManager : IParselService
    {
        private readonly Context _context;

        public ParselManager(Context context)
        {

            _context = context;

        }
        //[ValidationAspect(typeof(TasinmazValidator))]

        public async Task<IResult> AddParselAsync(Parsel parsel)
        {
            try
            {
                await _context.Tasinmazlar.AddAsync(parsel);
                await _context.SaveChangesAsync();

                return new SuccessResult("Taşınmaz Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ErrorResult("Taşınmaz Ekleme Başarısız! : " + e.Message);
            }
        }
        public async Task<IResult> UpdateParselAsync(Parsel parsel)
        {
            var tempData = await _context.Tasinmazlar.FirstOrDefaultAsync(x => x.ParselId == parsel.ParselId);

            tempData.ParselId = parsel.ParselId;
            tempData.ParselNo = parsel.ParselNo;
            tempData.AdaNo = parsel.AdaNo;
            tempData.Il = parsel.Il;
            tempData.Ilce = parsel.Ilce;
            tempData.MahalleId = parsel.MahalleId;
            tempData.Mahalle = parsel.Mahalle;
            tempData.Adres = parsel.Adres;
            tempData.coorX = parsel.coorX;
            tempData.coorY = parsel.coorY;
            _context.Update(tempData);
            await _context.SaveChangesAsync();

            return new SuccessResult("Taşınmaz Başarıyla Güncellendi");
        }
        public async Task<IResult> DeleteParselAsync(int parselId)
        {
            var tempData = await _context.Tasinmazlar.FirstOrDefaultAsync(x => x.ParselId == parselId);
            _context.Remove(tempData);
            await _context.SaveChangesAsync();

            return new SuccessResult("Taşınmaz Başarıyla Silindi");
        }
        //public async Task<IResult> AddLog(Log log)
        //{
        //    await _context.AddAsync(log);
        //    await _context.SaveChangesAsync();

        //    return new SuccessResult("Log Başarıyla Eklendi");
        //}



        public async Task<IDataResult<List<Parsel>>> GetAll()
        {
            var result = await this._context.Tasinmazlar
           .Include(i => i.Mahalle)
           .ThenInclude(i => i.Ilce)
           .ThenInclude(i => i.Il).ToListAsync();

            return new SuccessDataResult<List<Parsel>>(result, "Taşınmazlar Başarıyla Listelendi...");
        }

        public async Task<IDataResult<List<Parsel>>> GetByUserId(int userId)
        {
            var result = await this._context.Tasinmazlar
           .Include(i => i.Mahalle)
           .ThenInclude(i => i.Ilce)
           .ThenInclude(i => i.Il)
           .Where(p => p.UserId == userId).OrderBy(x => x.ParselId).ToListAsync();

            return new SuccessDataResult<List<Parsel>>(result, "Başarılı");
            //return new SuccessDataResult<List<Parsel>>(_parselDal.GetList(p => p.UserId == userId).ToList());
        }
        public async Task<IDataResult<List<TasinmazDetailDto>>> GetTasinmazDetails()
        {
            var tasinmazListResult = await GetAll();
            if (tasinmazListResult.Success)
            {
                var tasinmazList = tasinmazListResult.Data;

                // Ilce detaylarını oluşturmak için döngü
                var tasinmazDetailList = tasinmazList.Select(tasinmaz => new TasinmazDetailDto
                {
                    TasinmazId = tasinmaz.ParselId,
                    Il = tasinmaz.Il,
                    Ilce = tasinmaz.Ilce,
                    UserId = tasinmaz.ParselId,
                    CoorX = tasinmaz.coorX,
                    CoorY = tasinmaz.coorY,
                    // Diğer detayları ekleyin
                }).ToList();

                // Başarılı sonucu dön
                return new SuccessDataResult<List<TasinmazDetailDto>>(tasinmazDetailList, "Taşınmaz detayları başarıyla listelendi.");
            }
            else
            {
                // Hata durumunda bir hata mesajı döndürmek istiyorsanız:
                return new ErrorDataResult<List<TasinmazDetailDto>>(null, "Taşınmaz detayları listelenirken bir hata oluştu.");
            }
        }

        //public async Task<IDataResult<List<Log>>> GetAllLog()
        //{
        //    var result = await this._context.Log
        //       .ToListAsync();

        //    return new SuccessDataResult<List<Log>>(result, "Bütün taşınmaz logları listelendi");
        //    //return new SuccessDataResult<List<Log>>(_logDal.GetAll(), "Bütün Taşınmaz Logları Listelendi");
        //}
        public async Task<IDataResult<Parsel>> GetById(int parselId)
        {
            var result = await this._context.Tasinmazlar
            .Include(i => i.Mahalle)
            .ThenInclude(i => i.Ilce)
            .ThenInclude(i => i.Il)
            .FirstOrDefaultAsync(p => p.ParselId == parselId);

            return new SuccessDataResult<Parsel>(result, "Başarılı");
            //return new SuccessDataResult<Parsel>(_parselDal.Get(p => p.ParselId == tasinmazId));
        }


        public async Task<IDataResult<List<Parsel>>> GetListByIl(int Sid)
        {
            var result = await this._context.Tasinmazlar
           .Include(i => i.Mahalle)
            .ThenInclude(i => i.Ilce)
            .ThenInclude(i => i.Il)
            .Where(p => p.ParselId == Sid) // Kategoriye göre filtreleme yapılıyor
            .ToListAsync();

            return new SuccessDataResult<List<Parsel>>(result, "Kategoriye göre Parsel öğeleri başarıyla listelendi.");
        }
    }
}
