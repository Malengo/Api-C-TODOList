using System.Net;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Service.List;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListsController : ControllerBase
    {
        private IListService _service;

        public ListsController(IListService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (Exception e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetListById")]
        public async Task<ActionResult> GetListById(Guid id)
        {
            try
            {
                return Ok(await _service.Get(id));
            }
            catch (Exception e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> AddList([FromBody] ListEntity list)
        {
            try
            {
                var result = await _service.Post(list);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetListById", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteList(Guid id)
        {
            try
            {
                if (id != null)
                {
                    return Ok(await _service.Delete(id));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> UpdateList([FromBody] ListEntity list)
        {
            try
            {
                var result = await _service.Put(list);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}

