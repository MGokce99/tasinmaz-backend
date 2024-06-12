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
    public class IlManager : IIlService
    {
        private readonly Context _context;

        public IlManager(Context context)
        {
            _context = context;
        }
        public async Task<IDataResult<List<Il>>> GetAll()
        {
            var result = await this._context.Il.ToListAsync();
          
            return new SuccessDataResult<List<Il>>(result, "İller Başarıyla Listelendi...");
        }
      
    }
}
