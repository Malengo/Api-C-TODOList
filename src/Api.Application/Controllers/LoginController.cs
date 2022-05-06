using System.Net;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Service.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserLogon _service;

        public LoginController(IUserLogon service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<object> Login([FromBody] UserEntity user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _service.FindByEmail(user);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }
    }
}
