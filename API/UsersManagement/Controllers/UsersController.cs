    using UsersManagement.Models;
using Microsoft.AspNetCore.Mvc;
using UsersManagement.Services.Interfaces;

namespace UsersManagement.Controller;

[ApiController]
[Route("/api")]
public class UsersController: ControllerBase{

    private readonly IUserService _svc;

    public UsersController(IUserService svc)
    {
       _svc=svc;
    }

    // POST http://localhost:/api/users
    [HttpPost]
    [Route("adduser")]

    public async Task<bool> Add(User user)
    {
        bool status = await _svc.Add(user);
        return status;

    }

    [HttpPut]
    [Route("updateuser/{id}")]

    public async Task<bool> Update(int id,User user)
    {
        bool status = await _svc.Update(id,user);
        return status;

    }


   //GET http://localhost:/api/users
    [HttpGet]
    [Route("getall")]
    public async Task<List<User>> GetAll()
    {
        List<User> peoples = await _svc.GetAll();
        return peoples;
    }



   // GET http://localhost:/api/users/aadhar/76545656


    [HttpGet]
    [Route("getDetails/{aaddharid}")]

    public async Task<User> GetDetails(string aadharid)
    {
        User people = await _svc.GetDetails(aadharid);
        return people;
    }


   // HTTPDELETE  http://localhost:/api/users/aadhar/76545656
    [HttpDelete]
    [Route("DeleteUser/{aadharid}")]

    public async Task<bool> Delete(string aadharid)
    {
        bool status = await _svc.DeleteByAadharId(aadharid);
        return status;
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