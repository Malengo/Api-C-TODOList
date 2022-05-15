using System.Net;
using Api.Domain.Interfaces.Service.List;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImplementaionListController : ControllerBase
    {
        private IImplementionList _service;

        public ImplementaionListController(IImplementionList service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetListById(Guid id)
        {
            try
            {
                return Ok(await _service.FindByCategory(id));
            }
            catch (Exception e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("name/{name}")]
        public async Task<ActionResult> GetListByName(string name)
        {
            try
            {
                return Ok(await _service.FindByName(name));
            }
            catch (Exception e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
