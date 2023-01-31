using AutoMapper;
using WebApiKnowlegde.DTO;
using WebApiKnowlegde.Entidades;

namespace WebApiKnowlegde.Utilidades
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            //Creations
            CreateMap<enterpriesesCreateDTO, entrerprises>();
            CreateMap<departamentsCreateDTO, departaments>();
            CreateMap<employeeCreateDTO, employees>();


            //Listing
            CreateMap<entrerprises, enterpriesesDTO>();
            CreateMap<departaments, departamentsDTO>();
            CreateMap<employees, employeesDTO>();


            //Update
            CreateMap<enterpriesesUpdateDTO, entrerprises>();
            CreateMap<departamentUpdateDTO, departaments>();
            CreateMap<employeeUpdateDTO, employees>();  


        }
    }
}
