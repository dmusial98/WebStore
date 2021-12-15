﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreWebStore.Data;
using Microsoft.AspNetCore.Routing;
using WebStore.Data.Entities;
using WebStore.Models;

namespace WebStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IWebStoreRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public UsersController(IWebStoreRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }


        [HttpGet]
        public async Task<ActionResult<UserModel[]>> Get()
        {
            try
            {
                var result = await _repository.GetAllUsersAsync();
                return _mapper.Map<UserModel[]>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserModel>> Get(int id)
        {
            try
            {
                var result = await _repository.GetUserByIdAsync(id);
                return _mapper.Map<UserModel>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Post(UserModel model)
        {
            try
            {
                var user = _mapper.Map<User>(model);
                _repository.Add(user);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/users/{user.Id}", _mapper.Map<UserModel>(user));
                }
            }
            catch (Exception exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"{exception.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserModel>> Put(int id, UserModel model)
        {
            try
            {
                var oldUser = await _repository.GetUserByIdAsync(id);
                if (oldUser == null) return NotFound($"Could not find user with id equal {id}");

                _mapper.Map(model, oldUser);

                if (await _repository.SaveChangesAsync())
                    return _mapper.Map<UserModel>(oldUser);
            }
            catch (Exception exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"{exception.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var oldUser = await _repository.GetUserByIdAsync(id);
                if (oldUser == null) return NotFound($"Could not find user with id equal {id}");

                _repository.Delete(oldUser);

                if (await _repository.SaveChangesAsync())
                    return Ok();
            }
            catch (Exception exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"{exception.Message}");
            }

            return BadRequest();
        }
    }
}
