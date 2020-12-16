using HomeWork.Helpers;
using HomeWork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> logger;
        private readonly JwtHelpers jwt;
        public AccountController(ILogger<AccountController> logger, JwtHelpers jwt)
        {
            this.jwt = jwt;
            this.logger = logger;
        }

        [HttpPost("~/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public ActionResult<LoginResult> Login(LoginModel model)
        {
            logger.LogTrace(model.Username);
            logger.LogDebug(model.Username);
            logger.LogInformation(model.Username);
            logger.LogWarning(model.Username);
            logger.LogError(model.Username);
            logger.LogCritical(model.Username);

            if (ValidateUser(model))
            {
                return new LoginResult()
                {
                    Token = jwt.GenerateToken(model.Username, 10)
                };
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet("~/claims")]
        public IActionResult GetClaims()
        {
            return Ok(User.Claims.Select(p => new { p.Type, p.Value }));
        }

        [Authorize]
        [HttpGet("~/username")]
        public IActionResult GetUserName()
        {
            return Ok(User.Identity.Name);
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("~/RefreshToken")]
        public ActionResult<LoginResult> RefreshToken()
        {
            return new LoginResult()
            {
                Token = jwt.GenerateToken(User.Identity.Name, 10)
            };
        }

        private bool ValidateUser(LoginModel model)
        {
            return true;
        }
    }
}
