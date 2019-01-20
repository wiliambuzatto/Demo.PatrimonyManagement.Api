using AutoMapper;
using Demo.GestaoPatrimonio.Api.ViewModels;
using Demo.PatrimonyManagement.Data.Infra.Identity;
using Demo.PatrimonyManagement.Domain;
using Demo.PatrimonyManagement.Domain.Common;
using Demo.PatrimonyManagement.Service.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Demo.GestaoPatrimonio.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllHeaders")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAppSignInManager _signManager;

        public UserController(IUserService userService, IAppSignInManager signManager)
        {
            _userService = userService;
            _signManager = signManager;
        }

        #region GET
        [HttpGet()]
        [Authorize("Bearer")]
        public PagedList<UserViewModel> GetAll() => Paged(1, 50);

        [HttpGet("{page}/{items}")]
        [Authorize("Bearer")]
        public PagedList<UserViewModel> Paged(int page, int items)
        {
            var users = _userService.Get<object>(x => x.Name, page, items);
            var response = Mapper.Map<List<UserViewModel>>(users.Items);
            return new PagedList<UserViewModel>()
            {
                Page = page,
                TotalItems = users.TotalItems,
                ItemsPerPage = items,
                Items = response
            };
        }
        #endregion

        #region POST
        [HttpPost("Register")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(409)]
        public IActionResult Post([FromBody]CreateUserViewModel createUserViewModel,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = Mapper.Map<CreateUserViewModel, User>(createUserViewModel);
            var result = _userService.Insert(user);

            if (result.Success)
                return Ok(_signManager.GenerateToken(result.Value, signingConfigurations, tokenConfigurations));

            return Conflict(result);
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(404)]
        public IActionResult Login([FromBody]LoginUserViewModel loginUserViewModel,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = Mapper.Map<LoginUserViewModel, User>(loginUserViewModel);

            var result = _userService.Authenticate(user);

            if (result.Success)
            {
                var response = new Result
                {
                    Value = _signManager.GenerateToken(result.Value, signingConfigurations, tokenConfigurations)
                };

                return Ok(response);
            }

            return NotFound(result);
        }
        #endregion

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public Result Delete(Guid id) => _userService.Delete(id);

    }
}