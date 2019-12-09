﻿using System;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    public class DemandController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public DemandController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        [Route("api/Demand/{id}")]

        public JsonResult Get(int id)
        {
            using (var DemandRepository = _factory.GetRepository<Demand>()) {
                return Json(DemandRepository.GetById(7));
            }          
        }

        [HttpGet]
        [Route("api/Demands")]
        public JsonResult GetAll()
        {
            using (var DemandRepository = _factory.GetRepository<Demand>())
            {
                return Json(DemandRepository.GetAll());
            }
        }

        [HttpPost]
        [Route("api/Demand/create")]
        public bool Create([FromForm] Demand Demand)
        {
            using (var DemandRepository = _factory.GetRepository<Demand>())
            {
                if (DemandRepository.Create(Demand))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        [Route("api/Demand/update")]
        public bool Update([FromForm] Demand Demand)
        {
            using (var DemandRepository = _factory.GetRepository<Demand>())
            {
                if (DemandRepository.Update(Demand))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        [Route("api/Demand/delete")]
        public bool Delete([FromForm] Demand Demand)
        {
            using (var DemandRepository = _factory.GetRepository<Demand>())
            {
                if (DemandRepository.Delete(Demand))
                {
                    return true;
                }
                else return false;
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_DemandRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}