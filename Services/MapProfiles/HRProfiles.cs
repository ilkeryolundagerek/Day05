using AutoMapper;
using Core.DTOs;
using Core.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MapProfiles
{
    public class HRProfiles : Profile
    {
        public HRProfiles()
        {
            CreateMap<Person, PersonListItemDTO>()
                .ForMember(
                    o => o.DepartmentName,
                    s => s.MapFrom(p => p.Department.Name));

            //Person koleksiyonu dönüşüm hatası için yazılan profil.
            CreateMap<Department, DepartmentDTO>().ForMember(d => d.People, s => s.Ignore());
        }
    }
}
