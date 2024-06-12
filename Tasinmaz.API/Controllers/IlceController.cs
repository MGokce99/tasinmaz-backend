using Business.Abstract;
using Core.Utilities;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasinmaz.API.Controllers { 

    [Route("api/ilceler")]
    [ApiController]

    public class IlceController : ControllerBase
    {
        private IIlceService _ilceService;

        public IlceController(IIlceService sehirService )
        {
            _ilceService = sehirService;
        }

        [HttpGet("getall")]
        public async Task<IDataResult<List<Ilce>>> GetAll()
        {
            return await _ilceService.GetAll();
        }


        [HttpGet("getbyid")]
        public async Task<IDataResult<Ilce>> GetById(int id)
        {
            return await _ilceService.GetById(id);
        }

        [HttpGet("getbyilid")]
        public async Task<IDataResult<List<Ilce>>> GetByIlID(int id)
        {
            return await _ilceService.GetByIlID(id);
        }

        [HttpGet("getlist")]
        public async Task<IDataResult<List<Ilce>>> GetList()
        {
            return await _ilceService.GetList();
        }

        [HttpGet("getlistbycategory")]
        public async Task<IDataResult<List<Ilce>>> GetListByCategory(int categoryId)
        {
            return await _ilceService.GetListByCategory(categoryId);
        }
    }
}
