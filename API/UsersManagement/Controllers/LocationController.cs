// using System.Collections.Generic;
// using PersonalInfoAPI.Models;
// using PersonalInfoAPI.Services;
// using PersonalInfoAPI.Services.Interfaces;
// using Microsoft.AspNetCore.Mvc;

// namespace PersonalInfoAPI.Controllers;



    //http://localhost:5676/api/locations/567456
    [ApiController]
    [Route("/api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _addresssrv;
        public LocationController(ILocationService service)
        {
            _addresssrv = service;
        }


            // HTTP POST: http://localhost:5676/api/locations/567456

//         [HttpPost]
//         public async Task<bool> Insert([FromBody] Location theAddress)
//         {
//             bool status = await _addresssrv.Insert(theAddress);
//             return status;
//         }


// HTTP PUT: http://localhost:5676/api/locations/567456



//         [HttpPut]
//         public async Task<bool> Update(Location theAddress)
//         {
//             bool status = await _addresssrv.Update(theAddress);
//             return status;
//         }
//     }
