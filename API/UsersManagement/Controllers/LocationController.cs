// using System.Collections.Generic;
// using PersonalInfoAPI.Models;
// using PersonalInfoAPI.Services;
// using PersonalInfoAPI.Services.Interfaces;
// using Microsoft.AspNetCore.Mvc;

// namespace PersonalInfoAPI.Controllers;

<<<<<<< HEAD:API/UsersManagement/Controllers/LocationController.cs
    [ApiController]
    [Route("/api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _addresssrv;
        public LocationController(ILocationService service)
        {
            _addresssrv = service;
        }
=======
//     [ApiController]
//     [Route("/api/[controller]")]
//     public class AddressesController : ControllerBase
//     {
//         private readonly IAddressService _addresssrv;
//         public AddressesController(IAddressService service)
//         {
//             _addresssrv = service;
//         }
>>>>>>> 7c71f1e3436060ebd0daa35e3252dd9c24f72470:API/UsersManagement/Controllers/AddressesController.cs

//         [HttpPost]
//         public async Task<bool> Insert([FromBody] Location theAddress)
//         {
//             bool status = await _addresssrv.Insert(theAddress);
//             return status;
//         }
//         [HttpPut]
//         public async Task<bool> Update(Location theAddress)
//         {
//             bool status = await _addresssrv.Update(theAddress);
//             return status;
//         }
//     }
