using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using helpMeFest.Api.Dtos;
using helpMeFest.Models.Contract.Services;
using helpMeFest.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace helpMeFest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEventController : ControllerBase
    {
        private readonly IUserEventService userEventService;
        public UserEventController(IMapper mapper, IUserEventService service)
        {
            this.userEventService = service;
        }

        [HttpPost]
        [Authorize]
        [Route("leaveEvent/{eventId}")]
        public async Task<ActionResult> LeaveEvent([FromRoute] int eventId, [FromQuery] int userId)
        {
            try
            {
                var result = await this.userEventService.LeaveEvent(eventId, userId);
                return Ok("Que pena! Sentiremos sua falta");
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Erro ao sair do evento: {ex.Message}"});
            }
        }
    }
}
