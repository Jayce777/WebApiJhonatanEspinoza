using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApiKnowlegde.DTO;
using WebApiKnowlegde.Entidades;
using WebApiKnowlegde.Utilities;

namespace WebApiKnowlegde.Controllers
{
    [ApiController]
    [Route("api/enterprises")]

    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]

    public class EnterprisesController:ControllerBase
    {
        private readonly AplicationDbContext context;
        private readonly IMapper mapper;
        private readonly GetClaimsToken getClaimsToken;

        private string email { get; set; }
        public EnterprisesController(AplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            getClaimsToken = new GetClaimsToken();
        }

        
        [HttpPost]
        public async Task<ActionResult> CreateEnterprises(enterpriesesCreateDTO enterpriesesCreateDTO)
        {
            try
            {
                var authorization = Request.Headers[HeaderNames.Authorization].ToString();

                var enterprises = mapper.Map<entrerprises>(enterpriesesCreateDTO);
                enterprises.created_by = getClaimsToken.readClaimsFromToken(authorization);
                context.entrerprises.Add(enterprises);
                await context.SaveChangesAsync();
                return Ok(new responseDTO(true,"Enterprise create successfuly",null,null));

            }
            catch (Exception ex)
            {
                var listErrors = new List<string>() {ex.Message};
                return Ok(new responseDTO(false, "Cannot create a new enterprise", null, listErrors));

            }

        }  
        
        [HttpGet]
        public async Task<ActionResult> ListEnterprises()
        {
            try
            {


                var listenterprises = await context.entrerprises.Include(d => d.departaments).ToListAsync();

                return Ok(new responseDTO(true, "", mapper.Map<List<enterpriesesDTO>>(listenterprises), null));
            }
            catch (Exception ex)
            {
                var listErrors = new List<string>() { ex.Message };

                return Ok(new responseDTO(false, "Cannot retrieve the enterprise list",null, listErrors));
            }


        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditEnterprises(enterpriesesUpdateDTO enterpriesesUpdateDTO,int id)
        {
            var authorization = Request.Headers[HeaderNames.Authorization].ToString();


            var enterpriseExists = await context.entrerprises.AnyAsync(en => en.Id == id);
            if (!enterpriseExists)
            {
                return Ok(new responseDTO(false,$"Cannot exist a enteprise with {id}",null,null));
            }

            // using automapper
            var enterprise = mapper.Map<entrerprises>(enterpriesesUpdateDTO);
            //get user 
            var userCreateBy= await context.entrerprises.FirstOrDefaultAsync(en => en.Id == id);
            enterprise.created_date = userCreateBy.created_date;
            enterprise.created_by = userCreateBy.created_by;

            context.ChangeTracker.Clear();
            enterprise.Id = id;
            enterprise.modified_by = getClaimsToken.readClaimsFromToken(authorization);
            
           
            context.Update(enterprise);

            await context.SaveChangesAsync();
            return Ok(new responseDTO(true, "Enterprse update successfuly", null, null));

        }

        
    }
}
