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
    public class EventController : ControllerBase
    {
        private readonly IEventService eventService;
        private readonly IMapper mapper;

        public EventController(IEventService eventService, IMapper mapper)
        {
            this.eventService = eventService;
            this.mapper = mapper;
        }
       
        [HttpGet]
        [Authorize]
        [Route ("allbyuser/{userId}")]
        public async Task<ActionResult> GetAllByUserId([FromRoute] int userId)
        {
            try
            {
                return Ok(await this.eventService.FindAllByUser(userId));
            }
            catch (Exception  ex)
            {
                return BadRequest(new { Message = $"Erro ao obter evento:\n{ex.Message}" });
            }
        }

        [HttpGet("{enventId}")]
        [Authorize]
        public async Task<ActionResult> GetEvent([FromRoute] int enventId, [FromQuery] int userId)
        {
            var eve = await this.eventService.GetEventById(enventId, userId);
            return Ok(eve);
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public async Task<ActionResult> CreateEvent([FromBody] EventDto ev)
        {
            var eventModel = this.mapper.Map<EventDto, Event>(ev);
            var createdEvent = await this.eventService.CreateEvent(eventModel);
            return Created($"/event/{ createdEvent.Id }", new { Message = "Evento Criado com sucesso!"});
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateEvent([FromBody] Event ev)
        {
            //var eventModel = this.mapper.Map<EventDto, Event>(ev);
            var updatedEvent = await this.eventService.UpdateEvent(ev);
            return Ok(updatedEvent);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteEvent([FromRoute] int Id)
        {
            var deletedEvent = await this.eventService.DeleteEvent(Id);
            return Ok(deletedEvent);
        }
        
    }
}
