using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unicron.DtoModels;
using Unicron.Publish;
using Environment = Unicron.Models.Environment;

namespace Unicron.Controllers
{
    [Route("environment")]
    internal class EnvironmentController : Controller
    {
        public EnvironmentController(Publisher publisher)
        {
            this.publisher = publisher;
        }

        [HttpGet("all")]
        public IEnumerable<EnvironmentDto> GetAll()
        {
            return publisher.GetAllDto();
        }

        [HttpGet("{id}")]
        public ActionResult<EnvironmentDto> Get([FromHeader]Guid apiKey, Guid id)
        {
            var env = publisher.GetDto(id);
            return env is null ?  NotFound() : (ActionResult)Ok(env);
        }

        [HttpPost("{id}/set_remote")]
        public ActionResult Post(Guid id, [FromHeader]Guid apiKey, [FromBody]Uri remote)
        {
            if (remote == default)
                return BadRequest();

            var env = publisher.Get(id);

            if (env is null)
                return NotFound();

            env.RemoteUrl = remote;
            return Ok();
        }

        [HttpPost("{id}/deploy")]
        public ActionResult Deploy([FromHeader]Guid apiKey, [FromBody]string value)
        {
            return Ok();
        }

        [HttpPost("create")]
        public ActionResult Create([FromHeader] Guid apiKey, [FromBody] EnvironmentDto environment)
        {
            var id = Guid.NewGuid();
            if (environment is null)
                return BadRequest();
            var env = Environment.FromDto(environment);
            env.Id = id;
            publisher.Add(env);
            return Created($"/environment/{id}", env.ToDto());
        }

        
        private Publisher publisher;
    }
}
