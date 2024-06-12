using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tasinmaz.API.Entities.DTOs
{
    public class TasinmazDetailDto : IDto
    {
        public int TasinmazId { get; set; }
        public int Il { get; set; }
        public int Ilce { get; set; }


        public int UserId { get; set; }
        public string CoorX { get; set; }

        public string CoorY { get; set; }

    }
}
