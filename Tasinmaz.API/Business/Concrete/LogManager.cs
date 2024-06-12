using Business.Abstract;
using Core.Utilities;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LogManager : ILogService
    {
        private readonly Context _context;

        public LogManager(Context context)
        {
            _context = context;
        }
        public async Task<IResult> AddLog(Log log)
        {
            await _context.AddAsync(log);
            await _context.SaveChangesAsync();

            return new SuccessResult("Log Başarıyla Eklendi");
        }
        public async Task<IDataResult<List<Log>>> GetAll()
        {
            var result = await this._context.Log
               .ToListAsync();

            return new SuccessDataResult<List<Log>>(result, "Bütün taşınmaz logları listelendi");

        }
    }
}
