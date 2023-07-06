using System.Collections.Generic;
using PersonalInfoAPI.Models;
using PersonalInfoAPI.Services;
using PersonalInfoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PersonalInfoAPI.Controllers;

    [ApiController]
    [Route("/api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _addresssrv;
        public LocationController(ILocationService service)
        {
            _addresssrv = service;
        }

        [HttpPost]
        public async Task<bool> Insert([FromBody] Location theAddress)
        {
            bool status = await _addresssrv.Insert(theAddress);
            return status;
        }
        [HttpPut]
        public async Task<bool> Update(Location theAddress)
        {
            bool status = await _addresssrv.Update(theAddress);
            return status;
        }
    }