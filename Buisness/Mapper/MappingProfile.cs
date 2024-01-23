using AutoMapper;
using DataAccess.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContactsDTO, Contacts>();
            CreateMap<Contacts, ContactsDTO>();

            CreateMap<CoursesDTO, Courses>();
            CreateMap<Courses, CoursesDTO>();

            CreateMap<StudentsDTO, Courses>();
            CreateMap<Courses, StudentsDTO>();

            CreateMap<Contacts, CountriesDTO>();
            CreateMap<CountriesDTO, Contacts>();

            CreateMap<FeesDTO, Fees>().ReverseMap();

            CreateMap<ReceiptImageDTO, ReceiptImage>().ReverseMap();

            CreateMap<AllContactsListDTO, AllContactsList>().ReverseMap();


        }
    }
}
