﻿using System;
using System.Linq;
using Mentorship.CleaningService.BusinessLogic;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    //[Authorize]
    public class ClientsDemandController : Controller
    {
        private readonly ClientsDemandService _service;

        public ClientsDemandController(ClientsDemandService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/clientsDemand/{id}")]
        public JsonResult Get(int id)
        {
            return Json(_service.GetById(id));
        }
        [HttpGet]
        [Route("api/clientsDemands")]
        public JsonResult GetAll()
        {
            return Json(_service.GetAll());
        }

    }
}
