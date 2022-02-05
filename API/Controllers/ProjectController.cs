using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Project;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProjectController : BaseApiController 
    {
        public ProjectController()
        {

        }

        [HttpGet]
        public async Task<ActionResult<List<Domain.Project>>> GetProjects()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Project>> GetProject(int id)
        {
            return await Mediator.Send(new Details.Query(){Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] Domain.Project project)
        {
            return Ok(await Mediator.Send(new Create.Command(){Project = project}));
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Domain.Project project)
        {
            return Ok(await Mediator.Send(new Edit.Command(){Project = project}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new Delete.Command(){Id = id}));
        }
    }
}