using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Tasinmaz.API.Core.Entities.Concrete;

namespace Core.Utilities
{
    public class SuccessDataResult<T> : DataResult<T>
    {


        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }
        public SuccessDataResult(T data) : base(data, true)
        {

        }

        public SuccessDataResult(string message) : base(default, true, message)
        {

        }
    
        public SuccessDataResult(IDataResult<List<Parsel>> dataResult) : base(default, true)
        {

        }
    }
}


