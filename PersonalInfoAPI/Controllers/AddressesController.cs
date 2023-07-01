using System.Collections.Generic;
using PersonalInfoAPI.Models;
using PersonalInfoAPI.Services;
using PersonalInfoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PersonalInfoAPI.Controllers;

    [ApiController]
    [Route("/api/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addresssrv;
        public AddressesController(IAddressService service)
        {
            _addresssrv = service;
        }

        [HttpPost]
        public bool Insert([FromBody] Address theAddress)
        {
            bool status = _addresssrv.Insert(theAddress);
            return status;
        }
        [HttpPut]
        public bool Update(Address theAddress)
        {
            bool status = _addresssrv.Update(theAddress);
            return status;
        }
    }