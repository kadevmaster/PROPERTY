using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Property.Core.Models;
using Property.Core.IServices;
using AutoMapper;
using Property.Api.Resources;
using Property.Api.Validators;

namespace Property.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        private readonly ICityService _cityService;
        private readonly IMapper _mapper;
        public CityController(ICityService cityService, IMapper mapper)
        {
            this._cityService = cityService;
            this._mapper = mapper;
        }

        //get all cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetAllCities()
        {
            var city = await _cityService.GetAllCities();
            return Ok(city);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<City>>> GetCityById(int id)
        {
            var city = await _cityService.GetCityById(id);
            var musicResource = _mapper.Map<City, CityResource>(city);
            return Ok(city);
        }

        //insere um objeto do tipo City
        [HttpPost]
        public async Task<ActionResult<CityResource>> Add([FromBody] SaveCityResource saveCityResource)
        {
            var validator = new SaveCityResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCityResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var cityToCreate = _mapper.Map<SaveCityResource, City>(saveCityResource);

            var newCity = await _cityService.CreateCity(cityToCreate);

            var city = await _cityService.GetCityById(newCity.Id);

            var cityResource = _mapper.Map<City, CityResource>(city);

            return Ok(cityResource);
        }

        //atualiza um objeto do tipo City pelo id
        [HttpPut("{id}")]
        public async Task<ActionResult<CityResource>> UpdateCity(int id, [FromBody] SaveCityResource saveCityResource)
        {
            var validator = new SaveCityResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCityResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok
            var cityToBeUpdate = await _cityService.GetCityById(id);

            if (cityToBeUpdate == null)
                return NotFound();

            var city = _mapper.Map<SaveCityResource, City>(saveCityResource);

            await _cityService.UpdateCity(cityToBeUpdate, city);

            var updated = await _cityService.GetCityById(id);
            var updatedResource = _mapper.Map<City, CityResource>(updated);

            return Ok(updatedResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            if (id == 0)
                return BadRequest();

            var city = await _cityService.GetCityById(id);

            if (city == null)
                return NotFound();

            await _cityService.DeleteCity(city);

            return NoContent();
        }
    }
}