using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTOs;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly TokenService tokenService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }


        [HttpPost]
        public async Task<ActionResult<UserDTO>> Login([FromBody] Login loginDetails)
        {
            var user = await this.userManager.FindByEmailAsync(loginDetails.Email);

            if (user == null) return NotFound();

            var authentication = await this.signInManager.CheckPasswordSignInAsync(user, loginDetails.Password, false);

            if (!authentication.Succeeded)
            {
                return Unauthorized();
            }
            else
            {
                return new UserDTO()
                {
                    DisplayName = user.DisplayName,
                    Email = user.Email,
                    Token = this.tokenService.CreateToken(user),
                    UserName = user.UserName
                };
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(Register register)
        {
            var emailUser = await this.userManager.FindByEmailAsync(register.Email);

            if (emailUser != null) return BadRequest("Email Already Exists");

            var nameUser = await this.userManager.FindByNameAsync(register.UserName);

            if (nameUser != null) return BadRequest("UserName already Exists");

            var userApp = new AppUser
            {
                UserName = register.UserName,
                DisplayName = register.DisplayName,
                Email = register.Email,
                Bio = string.Empty
            };

            var registration = await userManager.CreateAsync(userApp, register.Password);

            if (registration.Succeeded)
            {
                return CreateUserObject(userApp);
            }

            return BadRequest();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var user = await this.userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return CreateUserObject(user);
        }

        private UserDTO CreateUserObject(AppUser user)
        {
            return new UserDTO
            {
                DisplayName = user.DisplayName,
                UserName = user.UserName,
                Email = user.Email,
                Token = tokenService.CreateToken(user)
            };
        }
    }


}