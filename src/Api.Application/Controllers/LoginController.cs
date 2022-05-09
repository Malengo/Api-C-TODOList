using System.Net;
using Api.Domain.Dtos;
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
        public async Task<object> Login([FromBody] LoginDto login)
        {
            if (login == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _service.FindByEmail(login);
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
