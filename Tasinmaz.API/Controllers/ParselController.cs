using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using TasinmazProje.API.Business.Abstract;
using System.Linq;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Core.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Tasinmaz.API.Entities.DTOs;

namespace Tasinmaz.API.Controllers
{
    [Route("api/tasinmazlar")]
    [ApiController]
    public class ParselController : ControllerBase
    {
        private readonly IParselService _parselService;

        public ParselController(IParselService productService)
        {
            _parselService = productService;
        }

        [HttpGet("getall")]
        public async Task<IDataResult<List<Parsel>>> GetAll()
        {
           return await _parselService.GetAll();
        }

        [HttpGet("getbyid")]
        public async Task<IDataResult<Parsel>> GetById(int parselId)
        {
            return await _parselService.GetById(parselId);
        }

        [HttpGet("getallasc")]
        public IActionResult GetAllTasinmaz()
        {
            return Ok();
        }
        //[HttpPost("add")]
        //public async Task<IResult> AddParselAsync([FromBody] Parsel parsel)
        //{
        //    return await _parselService.AddParselAsync(parsel);
        //}

        [HttpDelete("delete/{parselId}")]
        public async Task<IResult> DeleteParselAsync(int parselId)
        {
            return await _parselService.DeleteParselAsync(parselId);
        }

        [HttpPut("update")]
        public async Task<IResult> UpdateParselAsync(Parsel parsel)
        {
            return await _parselService.UpdateParselAsync(parsel);
        }

        [HttpGet("getlistbyil")]
        public async Task<IDataResult<List<Parsel>>> GetListByIl(int Sid)
        {
            return await _parselService.GetListByIl(Sid);
        }

        //[HttpGet("getalllog")]
        //public async Task<IDataResult<List<Log>>> GetAllLog()
        //{
        //    return await _parselService.GetAllLog();
        //}

        [HttpGet("getbyuserid")]
        public async Task<IDataResult<List<Parsel>>> GetByUserId(int userId)
        {
            return await _parselService.GetByUserId(userId);
        }

        [HttpGet("gettasinmazdetails")]
        public async Task<IDataResult<List<TasinmazDetailDto>>> GetTasinmazDetails()
        {
            return await _parselService.GetTasinmazDetails();
        }
    }
}
