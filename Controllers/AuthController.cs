using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreWebStore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Routing;
using Microsoft.IdentityModel.Tokens;
using WebStore.Auth;
using WebStore.Models;

namespace WebStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IWebStoreRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly ITokenService _tokenService;

        public AuthController(IWebStoreRepository repository, IMapper mapper, ITokenService tokenService, LinkGenerator linkGenerator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
            _linkGenerator = linkGenerator ?? throw new ArgumentException(nameof(linkGenerator));
        }

        [HttpPost, Route("login")]
        public async Task<ActionResult> Login([FromBody] UserModel loginModel)
        {
            try
            {
                if (loginModel == null)
                {
                    return BadRequest("Invalid client request");
                }

                var user = await _repository.GetUserByLoginAndPasswordAsync(
                    loginModel.Login, loginModel.Password);

                if (user == null)
                    return Unauthorized();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginModel.Login),
                    new Claim(ClaimTypes.Role, user.IsAdmin ? "admin" : "user")
                };

                var accessToken = _tokenService.GenerateAccessToken(claims);
                var refreshToken = _tokenService.GenerateRefreshToken();
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

                _repository.SaveChangesAsync();

                return Ok(new
                {
                    Token = accessToken,
                    RefreshToken = refreshToken
                });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [HttpPost, Authorize]
        [Route("revoke")]
        public async Task<ActionResult> Revoke(UserModel model)
        {
            var username = model.Login;
            var user = await _repository.GetUserByLoginAsync(username);
            if (user == null) return BadRequest();
            user.RefreshToken = null;
            _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}
