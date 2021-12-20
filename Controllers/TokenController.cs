using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreWebStore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebStore.Auth;
using WebStore.Models;

namespace WebStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IWebStoreRepository _repository;
        //private readonly LinkGenerator _linkGenerator;
        private readonly ITokenService _tokenService;

        public TokenController(IWebStoreRepository repository, ITokenService tokenService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<ActionResult> Refresh(TokenApiModel tokenApiModel)
        {
            if (tokenApiModel is null)
            {
                return BadRequest("Invalid client request");
            }
            string accessToken = tokenApiModel.AccessToken;
            string refreshToken = tokenApiModel.RefreshToken;
            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name; //this is mapped to the Name claim by default
            var user = await _repository.GetUserByLoginAsync(username);
            
            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Invalid client request");
            }

            var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            _repository.SaveChangesAsync();

            return new ObjectResult(new
            {
                accessToken = newAccessToken,
                refreshToken = newRefreshToken
            });
        }

        [HttpPost, Authorize]
        [Route("revoke")]
        public async Task<ActionResult> Revoke()
        {
            var username = User.Identity.Name;
            var user = await _repository.GetUserByLoginAsync(username);
            if (user == null) 
                return BadRequest();
            user.RefreshToken = null;
            _repository.SaveChangesAsync();
            return NoContent();
        }
    }

}
