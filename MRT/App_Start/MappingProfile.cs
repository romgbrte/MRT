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
                .ForMember(sc => sc.Id, opt => opt.Ignore());

            CreateMap<State, StateDto>();

            CreateMap<Policy, PolicyDto>()
                .ReverseMap()
                .ForMember(p => p.Id, opt => opt.Ignore());

            CreateMap<PolicyType, PolicyTypeDto>();

            CreateMap<PolicyAssignment, PolicyAssignmentDto>()
                .ReverseMap()
                .ForMember(sc => sc.Id, opt => opt.Ignore());

            CreateMap<WCRate, WCRateDto>()
                .ForMember(dest => dest.CarrierName, opt => opt.MapFrom(src => src.Carrier.Name))
                .ForMember(dest => dest.StateName, opt => opt.MapFrom(src => src.State.Abbreviation))
                .ForMember(dest => dest.CodeNumber, opt => opt.MapFrom(src => src.Code.Number));
        }
    }
}