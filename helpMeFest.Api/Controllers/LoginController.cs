using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using helpMeFest.Data;
using helpMeFest.Models.Contract;
using helpMeFest.Models.Contract.Repositories;
using helpMeFest.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace helpMeFest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService tokenService;
        private readonly IUserRepository userRepo;

        public LoginController(ITokenService tokenService, IUserRepository repository)
        {
            this.tokenService = tokenService;
            this.userRepo = repository;
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] User model)
        {
            var user = this.userRepo.GetUser(model.Email, model.Password);

            if (model == null)
            {
                return NotFound(new { Message = "Not found sorry about it"});
            }
    
            //var token = this.tokenService.GenerateToken(user);
            //user.Password = string.Empty; // TODO: Implement auto mapper here

            return new
            {
                //user,
                //token
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "1,2")]
        public string Employee() => "Funcionário";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "1")]
        public string Manager() => "Gerente";
    }
}
