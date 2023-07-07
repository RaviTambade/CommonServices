using Microsoft.AspNetCore.Mvc;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace AuthenticationAPI.Controllers;

[ApiController]
[Route("/api")]
public class CredentialController : ControllerBase
{
    private readonly ICredentialService _service;

    public CredentialController(ICredentialService service)
    {
        _service = service;
    }

//http://localhost:5664/api/authentication/login
//http://localhost:56455/authentication/signin
 //http:localhost:56455/membership/signin
    [Route]
    [HttpPost("authenticate")]
    public async Task<AuthenticateResponse> Authenticate([FromBody] AuthenticateRequest request)
    {
        var token = await _service.Authenticate(request);
        return token;
    }

 //http:localhost:56455/authentication/register
    [HttpPost("register")]
    public async Task<bool> Register(Credential credential)
    {
        return await _service.Register(credential);
    }

     //http:localhost:56455/authentication/update/contactnumber
    [HttpPut("updatecontactnumber")]
     public async Task<bool> UpdateContactNumber(ChangeContactNumber credential)
    {
        //retrive existing authorized users contact numbers from token
        // return await _service.UpdateContactNumber( oldContactNumber, newContactNumber)
        return await _service.UpdateContactNumber(credential);
    }



       //http:localhost:56455/authentication/contactnumber/9881735801/resetpassword/
    [Authorize]
    [HttpPut("updatepassword")]
    
    public async Task<bool> Update(string contactNumber,PasswordDetails passwordDetails)
    {
        return await _service.UpdatePassword(passwordDetails);
    }

    [HttpDelete("{id}")]
    public async Task<bool> Delete(int id)
    {
        return await _service.Delete(id);
    }
}
