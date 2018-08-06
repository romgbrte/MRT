using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MRT.Models;
using MRT.Dtos;

namespace MRT.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Code, CodeDto>() // Creates the initial Code => CodeDto mapping
                .ReverseMap() // Creates the reverse mapping, CodeDto => Code
                .ForMember(c => c.Id, opt => opt.Ignore()); // Omits Id from the reverse mapping

            CreateMap<Carrier, CarrierDto>()
                .ReverseMap()
                .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<StateCoverage, StateCoverageDto>()
                .ReverseMap()
                .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<State, StateDto>()
                .ReverseMap()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}