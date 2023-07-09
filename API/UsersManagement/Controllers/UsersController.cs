using UsersManagement.Models;
using Microsoft.AspNetCore.Mvc;
using UsersManagement.Services.Interfaces;
using UsersManagement.Helpers;

namespace UsersManagement.Controller;

[ApiController]
[Route("/api")]
public class UsersController : ControllerBase
{
    private readonly IUserService _svc;

    public UsersController(IUserService svc)
    {
        _svc = svc;
    }

    // POST http://localhost:/api/users
    [HttpPost]
    [Route("users")]
    public async Task<bool> Add(User user)
    {
        bool status = await _svc.Add(user);
        return status;
    }

    [Authorize]
    [HttpPut]
    [Route("users/{id}")]
    public async Task<bool> Update(int id, User user)
    {
        bool status = await _svc.Update(id, user);
        return status;
    }

    //GET http://localhost:/api/users
    [HttpGet]
    [Route("users")]
    public async Task<List<User>> GetAll()
    {
        List<User> peoples = await _svc.GetAll();
        return peoples;
    }

    // GET http://localhost:/api/users/aadhar/76545656


    [HttpGet]
    [Route("users/aadhar/{aadharid}")]
    public async Task<User> GetDetails(string aadharid)
    {
        User people = await _svc.GetDetails(aadharid);
        return people;
    }

    // HTTPDELETE  http://localhost:/api/users/aadhar/76545656
    [HttpDelete]
    [Route("users/aadhar/{aadharid}")]
    public async Task<bool> Delete(string aadharid)
    {
        bool status = await _svc.DeleteByAadharId(aadharid);
        return status;
    }

    [HttpGet]
    [Route("users/contact/{contactNumber}")]
    public async Task<User> GetUserByContact(string contactNumber)
    {
        User user = await _svc.GetUserByContact(contactNumber);
        return user;
    }

    //These two REST API action methods are not required
    /*
        [HttpGet]
        [Route("{userId}")]
        public async Task<User> GetbyId(int userId){
            return await _svc.GetById(userId);
        }
    
    
        [HttpDelete]
        [Route("{userId}")]
       public async Task<bool> DeletebyId(int userId){
             return await _svc.DeletebyId(userId);
       }
    
    */
}
