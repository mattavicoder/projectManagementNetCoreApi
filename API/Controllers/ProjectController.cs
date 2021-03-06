using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProjectController : BaseApiController
    {
        public ProjectController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            return HandleResult(await Mediator.Send(new Details.Query() { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] Domain.Project project)
        {
            return HandleResult(await Mediator.Send(new Create.Command() { Project = project }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Domain.Project project)
        {
            return HandleResult(await Mediator.Send(new Edit.Command() { Project = project }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command() { Id = id }));
        }
    }
}