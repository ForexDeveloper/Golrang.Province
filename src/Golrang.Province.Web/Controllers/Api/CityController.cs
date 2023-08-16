using System.Collections.Generic;
using Golrang.Province.Core;
using System.Threading.Tasks;
using Golrang.Province.Core.Models;
using Golrang.Province.Core.Services;
using Golrang.Province.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtoCommerce.Platform.Core.Common;
using System;

namespace Golrang.Province.Web.Controllers.Api
{
    [Authorize]
    [Route("api/city")]
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IProvinceService _provinceService;

        public CityController(ICityService cityService, IProvinceService provinceService)
        {
            _cityService = cityService;
            _provinceService = provinceService;
        }

        [HttpGet(nameof(GetCity))]
        [Authorize(ModuleConstants.Security.Permissions.Read)]
        public async Task<IActionResult> GetCity(string id)
        {
            var city = await _cityService.GetByIdAsync(id);
            return Ok(city);
        }


        [HttpGet(nameof(GetAllCityByIds))]
        [Authorize(ModuleConstants.Security.Permissions.Read)]
        public async Task<IActionResult> GetAllCityByIds(List<string> ids)
        {
            var cities = await _cityService.GetAsync(ids);
            return Ok(cities);
        }


        [HttpGet(nameof(GetCityByProvinceId))]
        [Authorize(ModuleConstants.Security.Permissions.Read)]
        public async Task<IActionResult> GetCityByProvinceId(string provinceId)
        {
            var city = await _cityService.GetCityByProvinceId(provinceId);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }


        [HttpPost(nameof(CreateOrUpdateCity))]
        [Authorize(ModuleConstants.Security.Permissions.Create)]
        public async Task<IActionResult> CreateOrUpdateCity([FromBody] CityModel city)
        {
            var province = _provinceService.GetByIdAsync(city.ProvinceId);

            if (province == null)
            {
                return BadRequest();
            }

            if (!Guid.TryParse(city.Id, out _))
            {
                city.SetIdentifier();
            }

            await _cityService.SaveChangesAsync(new[] { city });

            return Ok(city);
        }
    }
}
