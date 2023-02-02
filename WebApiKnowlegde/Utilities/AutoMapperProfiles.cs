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
                
            CreateMap<employeeCreateDTO, employees>()
                .ForMember(depa => depa.departaments_employees,
                options => options.MapFrom(MapDepartamentsEmployees));


            //Listing
            CreateMap<entrerprises, enterpriesesDTO>();
            CreateMap<departaments, departamentsDTO>();
            CreateMap<employees, employeesDTO>();


            //Update
            CreateMap<enterpriesesUpdateDTO, entrerprises>();
            CreateMap<departamentUpdateDTO, departaments>();
            CreateMap<employeeUpdateDTO, employees>();  

        }
        private List<departaments_employees> MapDepartamentsEmployees(employeeCreateDTO employeeCreateDTO,employees employees)
        {
            var response = new List<departaments_employees>();

            if (employeeCreateDTO.DepartamentosIds == null)
            {
                return response;

            }
            foreach (var departamentId in employeeCreateDTO.DepartamentosIds)
            {
                response.Add(new departaments_employees() { departamentsId = departamentId });
            }
            return response;
        }
    }
}
