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
    [Route("api/iller")]
    [ApiController]
    public class IlController : ControllerBase
    {
        private IIlService _ilService;

        public IlController(IIlService ilService )
        {
            _ilService = ilService;
        }

        [HttpGet("getall")]
        public async Task<IDataResult<List<Il>>> GetAll()
        {
            return await _ilService.GetAll();
        }
    }
}
