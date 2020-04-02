using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using helpMeFest.Api.Dtos;
using helpMeFest.Data;
using helpMeFest.Models;
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
            var authResult = await this.userService.ValidateLogin(userLogin.Email, userLogin.Password);

            if (authResult.LoginResult == EnumLoginResult.FAIL)
            {
                return Unauthorized(new { authResult.Message});
            }

            var user = authResult.ReturnedUser;
            var userDto = this.mapper.Map<UserDto>(user);
            var token = this.tokenService.GenerateToken(user);

            userDto.Token = token;

            return Ok(userDto);
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

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                var users = await this.userService.GetAllUsers();
                var usersDto = this.mapper.Map<List<UserDto>>(users);
                return Ok(usersDto);
            }
            catch(Exception ex)
            {
                return BadRequest(new { Message = $"Erro ao buscar usuários: {ex.Message}" });
            }
        }
    }
}
