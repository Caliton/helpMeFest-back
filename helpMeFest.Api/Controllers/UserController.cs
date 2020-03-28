using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using helpMeFest.Api.Dtos;
using helpMeFest.Data;
using helpMeFest.Models.Contract;
using helpMeFest.Models.Contract.Repositories;
using helpMeFest.Models.Contract.Services;
using helpMeFest.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace helpMeFest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ITokenService tokenService;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(ITokenService tokenService, IUserService userService, IMapper mapper)
        {
            this.tokenService = tokenService;
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<ActionResult<UserDto>> Authenticate([FromBody] Login userLogin)
        {
            var user = await this.userService.ValidateLogin(userLogin.Email, userLogin.Password);

            // TODO: Maybe this piece can be replaced by AuthenticationResult
            if (user == null)
            {
                return NotFound(new { Message = "Email or Password Incorrect!"});
            }
    
            var userDto = this.mapper.Map<UserDto>(user);
            var token = this.tokenService.GenerateToken(user);

            userDto.Token = token;

            return userDto;
        }
         

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Createuser([FromBody] SaveUserDto saveUser)
        {
            var mappedUser = this.mapper.Map<SaveUserDto, User>(saveUser);
            var createdUser = await this.userService.CreateUser(mappedUser);
            var userMapped = this.mapper.Map<UserDto>(createdUser);
            return Created($"user/{userMapped.Id}", userMapped);

        }

        //[HttpGet]
        //[Route("anonymous")]
        //[AllowAnonymous]
        //public string Anonymous() => "Anônimo";

        //[HttpGet]
        //[Route("authenticated")]
        //[Authorize]
        //public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        //[HttpGet]
        //[Route("employee")]
        //[Authorize(Roles = "1,2")]
        //public string Employee() => "Funcionário";

        //[HttpGet]
        //[Route("manager")]
        //[Authorize(Roles = "1")]
        //public string Manager() => "Gerente";
    }
}
