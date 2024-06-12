using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tasinmaz.API.Entities.DTOs
{
    public class MahalleDetailDto : IDto
    {
        public int Kid { get; set; }

        public int Iid { get; set; }

        public string Kname { get; set; }
    }
}
