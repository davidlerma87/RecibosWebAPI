using AutoMapper;
using Recibos.Core.DTOs;
using Recibos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recibos.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() 
        {
            CreateMap<Receipt, ReceiptDto>();
            CreateMap<ReceiptDto, Receipt>();
        }
    }
}
