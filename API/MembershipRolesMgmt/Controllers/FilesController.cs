using Microsoft.AspNetCore.Mvc;
using Transflower.MembershipRolesMgmt.Services.Interfaces;

namespace Transflower.MembershipRolesMgmt.Controllers;
[ApiController]
[Route("/api/files")]
public class FilesController : ControllerBase
{
    private readonly IUserService _svc;

    public FilesController(IUserService svc)
    {
        _svc = svc;
    }

    [HttpPost, DisableRequestSizeLimit]
    [Route("fileupload/{fileName}")]
    public IActionResult Upload(string fileName)
    {
        try
        {
            var file = Request.Form.Files[0];
            if (file.Length <= 0)
            {
                return BadRequest();
            }
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var filePath = Path.Combine(pathToSave, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return Ok(new { filePath });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex}");
        }
    }

    [HttpPost, DisableRequestSizeLimit]
    [Route("filedownload/{fileName}")]
    public IActionResult DownLoad(string fileName)
    {
        try
        {
            var file = Request.Form.Files[0];
            if (file.Length <= 0)
            {
                return BadRequest();
            }
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var filePath = Path.Combine(pathToSave, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                //code to read file and send file through body
               // file.CopyTo(stream);
            }
            return Ok(new { filePath });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex}");
        }
    }

}
