using Business.Abstract;
using Core.Utilities;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasinmaz.API.Controllers
{
    [Route("api/mahalleler")]
    [ApiController]
    public class MahalleController : ControllerBase
    {
        private IMahalleService _mahalleService;

        public MahalleController(IMahalleService sehirService)
        {
            _mahalleService = sehirService;

        }

        [HttpGet("getall")]
        public async Task<IDataResult<List<Mahalle>>> GetAll()
        {
           return await _mahalleService.GetAll();
        }

        [HttpGet("getbyid")]
        public async Task<IDataResult<Mahalle>> GetById(int Iid)
        {
            return await _mahalleService.GetById(Iid);
        }

        [HttpGet("getlist")]
        public async Task<IDataResult<List<Mahalle>>> GetList()
        {
            return await _mahalleService.GetList();
        }

        [HttpGet("getlistbycategory")]
        public async Task<IDataResult<List<Mahalle>>> GetListByCategory(int categoryId)
        {
            return await _mahalleService.GetListByCategory(categoryId);
        }
    }
}
