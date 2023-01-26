using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiKnowlegde.DTO;
using WebApiKnowlegde.Entidades;

namespace WebApiKnowlegde.Controllers
{
    [ApiController]
    [Route("api/enterprises")]

    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]

    public class EnterprisesController:ControllerBase
    {
        private readonly AplicationDbContext context;
        private readonly IMapper mapper;

        public EnterprisesController(AplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        
        [HttpPost]
        public async Task<ActionResult> CreateEnterprises(enterpriesesCreateDTO enterpriesesCreateDTO)
        {
            try
            {
                var enterprises = mapper.Map<entrerprises>(enterpriesesCreateDTO);

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

                return Ok(new responseDTO(false, "",null, listErrors));
            }


        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditEnterprises(enterpriesesUpdateDTO enterpriesesUpdateDTO,int id)
        {

            
            var enterpriseExists = await context.entrerprises.AnyAsync(en => en.Id == id);
            if (!enterpriseExists)
            {
                return Ok(new responseDTO(false,$"Cannot exist a enteprise with {id}",null,null));
            }

            var enterprise = mapper.Map<entrerprises>(enterpriesesUpdateDTO);
            enterprise.Id = id;
            context.Update(enterprise);

            await context.SaveChangesAsync();
            return Ok(new responseDTO(true, "Enterprse update successfuly", null, null));

        }
    }
}
