using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using WebApiKnowlegde.DTO;
using WebApiKnowlegde.Entidades;
using WebApiKnowlegde.Utilities;

namespace WebApiKnowlegde.Controllers
{
    [ApiController]
    [Route("api/employees")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class EmployeesController:ControllerBase
    {
        private readonly AplicationDbContext context;
        private readonly IMapper mapper;
        private readonly GetClaimsToken getClaimsToken;

        public EmployeesController(AplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            getClaimsToken = new GetClaimsToken();

        }


        [HttpGet]
        public async Task<ActionResult> ListEmployees()
        {
            try
            {
                var listemployees = await context.employees.ToListAsync();
                return Ok(new responseDTO(true, "", mapper.Map<List<employeesDTO>>(listemployees), null));
            }
            catch (Exception ex)
            {
                var listErrors = new List<string>() { ex.Message };

                return Ok(new responseDTO(false, "Cannot retrieve the employees list", null, listErrors));
            }


        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee(employeeCreateDTO employeeCreateDTO)
        {
            try
            {
                var departamentsIds = await context.departaments.Where(dep => employeeCreateDTO.DepartamentosIds.Contains(dep.Id))
                    .Select(x => x.Id).ToListAsync();

                if (employeeCreateDTO.DepartamentosIds == null)
                {
                    return Ok(new responseDTO(false, "No Departaments", null, null));

                }

                if (employeeCreateDTO.DepartamentosIds.Count != departamentsIds.Count)
                {
                    return Ok(new responseDTO(false, "Don't exist departaments sended", null, null));

                }

                var authorization = Request.Headers[HeaderNames.Authorization].ToString();

                var employe = mapper.Map<employees>(employeeCreateDTO);
                employe.created_by = getClaimsToken.readClaimsFromToken(authorization);
                context.employees.Add(employe);
                await context.SaveChangesAsync();
                return Ok(new responseDTO(true, "Employee create successfuly", null, null));

            }
            catch (Exception ex)
            {
                var listErrors = new List<string>() { ex.Message };
                return Ok(new responseDTO(false, "Cannot create a new Employee", null, listErrors));

            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditEmployee(employeeUpdateDTO employeeUpdateDTO, int id)
        {
            var authorization = Request.Headers[HeaderNames.Authorization].ToString();


            //var enterpriseExists = await context.entrerprises.AnyAsync(en => en.Id == id);
            //if (!enterpriseExists)
            //{
            //    return Ok(new responseDTO(false, $"Cannot exist a enteprise with {id}", null, null));
            //}

            // using automapper
            var employe = mapper.Map<employees>(employeeUpdateDTO);
            //get user 
            var userCreateBy = await context.employees.FirstOrDefaultAsync(en => en.Id == id);
            employe.created_date = userCreateBy.created_date;
            employe.created_by = userCreateBy.created_by;

            context.ChangeTracker.Clear();
            employe.Id = id;
            employe.modified_by = getClaimsToken.readClaimsFromToken(authorization);


            context.Update(employe);

            await context.SaveChangesAsync();
            return Ok(new responseDTO(true, "Employee update successfuly", null, null));

        }
    }
}
