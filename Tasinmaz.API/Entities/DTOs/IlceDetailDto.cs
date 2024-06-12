using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tasinmaz.API.Entities.DTOs
{
    public class IlceDetailDto : IDto
    {
        public int Iid { get; set; }
        public string Iname { get; set; }
        public int SId { get; set; }
    }
}
