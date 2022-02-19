using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.User;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        public UserController()
        {
        }

        // [HttpGet]
        // public async Task<ActionResult<List<Domain.User>>> GetUsers()
        // {
        //     return await Mediator.Send(new List.Query());
        // }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<Domain.User>> GetUser(int id)
        // {
        //     return await Mediator.Send(new Details.Query(){Id = id});
        // }

        // [HttpPut]
        // public async Task<IActionResult> EditUser([FromBody] Domain.User user)
        // {
        //     return Ok(await Mediator.Send(new Edit.Command(){User = user}));
        // }

        // [HttpPost]
        // public async Task<IActionResult> SaveUser([FromBody] Domain.User user)
        // {
        //     return Ok(await Mediator.Send(new Create.Command(){User = user}));
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteUser(int id)
        // {
        //     return Ok(await Mediator.Send(new Delete.Command(){Id = id}));
        // }


    }
}