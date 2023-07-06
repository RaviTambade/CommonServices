using UsersManagement.Models;
using Microsoft.AspNetCore.Mvc;
using UsersManagement.Services.Interfaces;

namespace UsersManagement.Controller;

[ApiController]
[Route("/api/[Controller]")]
public class UsersController: ControllerBase{

    private readonly IUserService _svc;

    public UsersController(IUserService svc)
    {
       _svc=svc;
    }

    [HttpPost]
    [Route("adduser")]

    public async Task<bool> AddUser(User user)
    {
        bool status = await _svc.AddUser(user);
        return status;

    }

    [HttpPut]
    [Route("updateuser/{id}")]

    public async Task<bool> UpdateUser(int id,User user)
    {
        bool status = await _svc.UpdateUser(id,user);
        return status;

    }

    [HttpGet]
    [Route("getall")]

    public async Task<List<User>> GetAllUsers()
    {
        List<User> peoples = await _svc.GetAllUsers();
        return peoples;
    }



    [HttpGet]
    [Route("getDetails/{aaddharid}")]

    public async Task<User> GetDetails(string aaddharid)
    {
        User people = await _svc.GetDetails(aaddharid);
        return people;
    }


    [HttpDelete]
    [Route("DeleteUser/{aaddharid}")]

    public async Task<bool> DeleteUser(string aaddharid)
    {
        bool status = await _svc.DeleteUser(aaddharid);
        return status;
    }

    [HttpGet]
    [Route("{userId}")]
    public async Task<User> GetUser(int userId){
        return await _svc.GetUser(userId);
    }


    [HttpDelete]
    [Route("{userId}")]
   public async Task<bool> DeleteUserbyId(int userId){
         return await _svc.DeleteUserbyId(userId);
   } 


}