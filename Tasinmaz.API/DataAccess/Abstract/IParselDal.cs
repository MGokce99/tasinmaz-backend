using Core.DataAccess;
using Core.Utilities;
using Entities.Concrete;
using System.Collections.Generic;
using Tasinmaz.API.Entities.DTOs;

namespace Tasinmaz.API.DataAccess.Abstract
{
    public interface IParselDal : IEntityRepository<Parsel>
    {
        List<TasinmazDetailDto> GetTasinmazDetails();
        List<Parsel> GetAllTasinmaz();
    }
}
