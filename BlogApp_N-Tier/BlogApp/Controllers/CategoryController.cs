﻿using BlogApp.Business.DTOs.Category;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Abstraction;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IValidator<CreateCategoryDto> _validator;
        private readonly IValidator<UpdateCategoryDto> _validatorUpdate;


        public CategoryController(ICategoryService service, IValidator<CreateCategoryDto> validator, IValidator<UpdateCategoryDto> validatorUpdate)
        {
            _service = service;
            _validator = validator;
            _validatorUpdate = validatorUpdate;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var brands = await _service.GetAllAsync();
            return StatusCode(StatusCodes.Status200OK, brands);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Category brand = await _service.GetById(id);
            return StatusCode(StatusCodes.Status200OK, brand);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryDto createBrandDto)
        {
            var validationResult = _validator.Validate(createBrandDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _service.Create(createBrandDto);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCategoryDto updateBrandDto)
        {
            var validationResult = _validatorUpdate.Validate(updateBrandDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _service.Update(updateBrandDto);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpDelete("id")]

        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return StatusCode(StatusCodes.Status200OK);

        }
     

        [HttpDelete("DeleteAll")]
        public async Task<IActionResult> DeleteAll()
        {
            await _service.deleteAll();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
