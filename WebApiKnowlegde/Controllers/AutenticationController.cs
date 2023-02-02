using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using WebApiKnowlegde.DTO;
using WebApiKnowlegde.Utilities;

namespace WebApiKnowlegde.Controllers
{
    [ApiController]
    [Route("api/autentication")]
    public class AutenticationController:ControllerBase
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly GetClaimsToken getClaimsToken;

        public TokenGenerate tokenGenerate { get; set; }
        public IConfiguration Configuration { get; }

        public AutenticationController(SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager,IConfiguration configuration)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            Configuration = configuration;
            tokenGenerate = new TokenGenerate(Configuration["JWTKey"]);
            getClaimsToken = new GetClaimsToken();

        }

        [HttpPost("register")]
        public async Task<ActionResult<responseAutentication>> Register(userCredentials credentials)
        {
            var newUser = new IdentityUser { UserName = credentials.Email, Email = credentials.Email };
            var result = await userManager.CreateAsync(newUser, credentials.Password);

            if (result.Succeeded)
            {
               return tokenGenerate.tokenCreate(credentials);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("login")]
        public async Task<ActionResult<responseAutentication>> Login(userCredentials userCredentials)
        {
            var result = await signInManager.PasswordSignInAsync(userCredentials.Email,
                userCredentials.Password,isPersistent:true,lockoutOnFailure:false);
            if (result.Succeeded)
            {
                return tokenGenerate.tokenCreate(userCredentials);
            }
            else
            {
                return BadRequest("Cannot log in");
            }

        }

        [HttpGet("renoveToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<responseAutentication>> RenoveToken()
        {
            var authorization = Request.Headers[HeaderNames.Authorization].ToString();

            var credentials=new userCredentials()
            {
                Email = getClaimsToken.readClaimsFromToken(authorization)
            };

            return tokenGenerate.tokenCreate(credentials);
        }



    }
}
