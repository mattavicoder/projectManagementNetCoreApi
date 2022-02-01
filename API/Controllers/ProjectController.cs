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

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] Domain.Project project)
        {
            return Ok(await Mediator.Send(new Create.Command(){Project = project}));
        }
    }
}