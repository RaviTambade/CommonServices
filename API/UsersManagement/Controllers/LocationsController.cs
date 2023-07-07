using System.Collections.Generic;
using UsersManagement.Models;
using UsersManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PersonalInfoAPI.Controllers;
    //http://localhost:5676/api/locations/567456
    [ApiController]
    [Route("/api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _addresssrv;
        public LocationsController(ILocationService service)
        {
            _addresssrv = service;
        }

        // HTTP POST: http://localhost:5676/api/locations
        [HttpPost]
        public async Task<bool> Insert([FromBody] Location theAddress)
        {
            bool status = await _addresssrv.Insert(theAddress);
            return status;
        }

        // HTTP PUT: http://localhost:5676/api/locations/567456
        [HttpPut("{id}")]
        public async Task<bool> Update(int id, Location theAddress)
        {
            bool status = await _addresssrv.Update(id, theAddress);
            return status;
        }
    }
