using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;
using WebApiKnowlegde.DTO;
using WebApiKnowlegde.Entidades;
using WebApiKnowlegde.Utilities;

namespace WebApiKnowlegde.Controllers
{
    [ApiController]
    [Route("api/departaments")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class DepartamentsController:ControllerBase
    {
        private readonly AplicationDbContext context;
        private readonly IMapper mapper;
        private readonly GetClaimsToken getClaimsToken;
        public DepartamentsController(AplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            getClaimsToken = new GetClaimsToken();  
        }

       [HttpPost]
       public async Task<ActionResult> CreateDepartament(departamentsCreateDTO departamentsCreateDTO)
        {
            try
            {
                var foundEnterprises =await context.entrerprises.AnyAsync(e => e.Id == departamentsCreateDTO.entrerprisesId);

                if (!foundEnterprises)
                {
                    return Ok(new responseDTO(false, $"Cannot exist a Departaments with {departamentsCreateDTO.entrerprisesId}", null, null));

                }
                var authorization = Request.Headers[HeaderNames.Authorization].ToString();

                var departament = mapper.Map<departaments>(departamentsCreateDTO);
                departament.created_by = getClaimsToken.readClaimsFromToken(authorization);
                context.departaments.Add(departament);
                await context.SaveChangesAsync();
                return Ok(new responseDTO(true, "Departaments create successfuly", null, null));

            }
            catch (Exception ex)
            {
                var listErrors = new List<string>() { ex.Message };
                return Ok(new responseDTO(false, "Cannot create a new Departaments", null, listErrors));

            }
       }

        [HttpGet]
        public async Task<ActionResult> ListDepartaments0()
        {
            try
            {
                var listdepartaments = await context.departaments.Include(d => d.entrerprises).ToListAsync();
                return Ok(new responseDTO(true, "", mapper.Map<List<departamentsDTO>>(listdepartaments), null));
            }
            catch (Exception ex)
            {
                var listErrors = new List<string>() { ex.Message };

                return Ok(new responseDTO(false, "Cannot retrieve the departaments list", null, listErrors));
            }


        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditDepartaments(departamentUpdateDTO departamentUpdateDTO, int id)
        {
            var authorization = Request.Headers[HeaderNames.Authorization].ToString();


            var departmentsExist=await context.departaments.AnyAsync(en => en.Id == id);

            if (!departmentsExist)
            {
                return Ok(new responseDTO(false, $"Cannot exist a departament with {id}", null, null));

            }

            var enterpriseExists = await context.entrerprises
                .AnyAsync(en => en.Id == departamentUpdateDTO.entrerprisesId);
            if (!enterpriseExists)
            {
                return Ok(new responseDTO(false, $"Cannot exist a enteprise with {id}", null, null));
            }

            // using automapper
            var departament = mapper.Map<departaments>(departamentUpdateDTO);
            //get user 
            var userCreateBy = await context.entrerprises
                .FirstOrDefaultAsync(en => en.Id == departamentUpdateDTO.entrerprisesId);
            departament.Id = id;
            departament.modified_by = getClaimsToken.readClaimsFromToken(authorization);
            departament.created_date = userCreateBy.created_date;
            departament.created_by = userCreateBy.created_by;

            context.ChangeTracker.Clear();

            context.Update(departament);

            await context.SaveChangesAsync();
            return Ok(new responseDTO(true, "Departament update successfuly", null, null));

        }

    }
}
