using Core.Utilities;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasinmaz.API.Core.Entities.Concrete;
using Tasinmaz.API.Entities.DTOs;

namespace TasinmazProje.API.Business.Abstract
{
    public interface IParselService
    {
        Task<IDataResult<List<Parsel>>> GetAll();

        //Task<IDataResult<List<Log>>> GetAllLog();

        Task<IDataResult<List<Parsel>>> GetListByIl(int Sid);
        Task<IDataResult<List<TasinmazDetailDto>>> GetTasinmazDetails();

        Task<IDataResult<Parsel>> GetById(int parselId);

        Task<IDataResult<List<Parsel>>> GetByUserId(int userId);


        Task<IResult> AddParselAsync(Parsel parsel);
        Task<IResult> UpdateParselAsync(Parsel parsel);
        Task<IResult> DeleteParselAsync(int parselId);

        //Task<IResult> AddLog(Log log);


    }
}
