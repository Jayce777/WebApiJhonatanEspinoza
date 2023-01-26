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


            //Listing
            CreateMap<entrerprises, enterpriesesDTO>();

            //Update
            CreateMap<enterpriesesUpdateDTO, entrerprises>();

            
        }
    }
}
