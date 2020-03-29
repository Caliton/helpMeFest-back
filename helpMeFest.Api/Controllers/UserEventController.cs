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
        private readonly IMapper mapper;
        private readonly IUserEventService userEventService;
        public UserEventController(IMapper mapper, IUserEventService service)
        {
            this.mapper = mapper;
            this.userEventService = service;
        }

        //[HttpPost]
        //[Authorize]
        //public ActionResult ConfirmPresence ([FromBody] SaveUserEvent saveResource)
        //{
        //    var userEvents = saveResource.Persons.Select(x=> new  UserEvent() { IdEvent = saveResource.IdEvent, IdUser = x });

        //}
        //}
    }
}