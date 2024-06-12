using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tasinmaz.API.Entities.DTOs
{
    public class SehirDetailDto : IDto
    {
        public int Sid { get; set; }
        public string Sname { get; set; }

    }

}
