﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Tasinmaz.API.Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
