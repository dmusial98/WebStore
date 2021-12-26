using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreWebStore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Routing;
using WebStore.Data.Entities;
using WebStore.Models;

namespace WebStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IWebStoreRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public ProductsController(IWebStoreRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet/*, Authorize*/]
        public async Task<ActionResult<ProductModel[]>> Get()
        {
            try
            {
                var result = await _repository.GetAllProductsAsync();
                return _mapper.Map<ProductModel[]>(result);
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductModel>> Get(int id)
        {
            try
            {
                var product = await _repository.GetProductByIdAsync(id);

                if (product == null) return NotFound();

                return _mapper.Map<ProductModel>(product);
                
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"{e.Message}");
            }
        }

        
        [HttpGet("byCategory")]
        public async Task<ActionResult<ProductModel[]>> GetByCategory(int categoryId)
        {
            try
            {
                var products = await _repository.GetProductsByCategoryAsync(categoryId);

                if (products == null)
                    return NotFound();

                return _mapper.Map<ProductModel[]>(products);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"{e.Message}");
            }
        }

        [HttpPost/*, Authorize*/]
        public async Task<ActionResult<ProductModel>> Post(ProductModel model)
        {
            try
            {
                var product = _mapper.Map<Product>(model);
                _repository.Add(product);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/products/{product.Id}", _mapper.Map<ProductModel>(product));
                }
            }
            catch (Exception exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"{exception.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{id:int}")]
        //[Authorize]
        public async Task<ActionResult<ProductModel>> Put(int id, ProductModel model)
        {
            try
            {
                var oldProduct = await _repository.GetProductByIdAsync(id);
                if (oldProduct == null) return NotFound($"Could not find product with id equal {id}");

                _mapper.Map(model, oldProduct);

                if (await _repository.SaveChangesAsync())
                    return _mapper.Map<ProductModel>(oldProduct);
            }
            catch (Exception exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"{exception.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var oldProduct = await _repository.GetProductByIdAsync(id);
                if (oldProduct == null) return NotFound($"Could not find product with id equal {id}");

                _repository.Delete(oldProduct);

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
