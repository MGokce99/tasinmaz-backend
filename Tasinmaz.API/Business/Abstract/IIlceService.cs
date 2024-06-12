using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tasinmaz.API.Entities.DTOs;

namespace Business.Abstract
{
    public interface IIlceService
    {
        Task<IDataResult<List<Ilce>>> GetAll();

        Task<IDataResult<Ilce>> GetById(int Iid);
        Task<IDataResult<List<Ilce>>> GetList();
        Task<IDataResult<List<IlceDetailDto>>> GetIlceDetails();

        Task<IDataResult<List<Ilce>>> GetListByCategory(int categoryId);

        Task<IDataResult<List<Ilce>>> GetByIlID(int id);

    }
}
