using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        protected readonly IMapper _mapper;
        public MappingProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {

                //Domain to Dto
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<Movie, MovieDto>();
                cfg.CreateMap<MembershipType, MembershipTypeDto>();
                cfg.CreateMap<GenreType, GenreTypeDto>();

                //Dto to Domain
                cfg.CreateMap<CustomerDto, Customer>()
                    .ForMember(c => c.Id, opt => opt.Ignore());
                cfg.CreateMap<MovieDto, Movie>()
                    .ForMember(c => c.Id, opt => opt.Ignore());

            });

            _mapper = config.CreateMapper();

        }
    }
}