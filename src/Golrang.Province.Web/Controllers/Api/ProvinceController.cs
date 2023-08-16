using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Golrang.Province.Core;
using Golrang.Province.Core.Models;
using Golrang.Province.Core.Models.Search;
using Golrang.Province.Core.Services;
using Golrang.Province.Core.Services.Search;
using VirtoCommerce.Platform.Core.Common;

namespace Golrang.Province.Web.Controllers.Api
{
    [Route("api/province")]
    [Authorize]
    public class ProvinceController : Controller
    {
        private readonly IProvinceService _provinceService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IProvinceSearchService _provinceSearchService;

        public ProvinceController(IProvinceService provinceService, IAuthorizationService authorizationService, IProvinceSearchService provinceSearchService)
        {
            _provinceService = provinceService;
            _authorizationService = authorizationService;
            _provinceSearchService = provinceSearchService;
        }


        [HttpGet(nameof(GetProvince))]
        [Authorize(ModuleConstants.Security.Permissions.Read)]
        public async Task<IActionResult> GetProvince(string id)
        {
            var province = await _provinceService.GetNoCloneAsync(id);

            if (province == null)
            {
                return NotFound();
            }

            return Ok(province);
        }


        [HttpGet(nameof(GetAllProvinces))]
        [Authorize(ModuleConstants.Security.Permissions.Read)]
        public async Task<IActionResult> GetAllProvinces([FromQuery] List<string> ids)
        {
            var provinces = await _provinceService.GetAllProvinces(ids);
            return Ok(provinces);
        }


        [HttpPost(nameof(SearchProvince))]
        [Authorize(ModuleConstants.Security.Permissions.Access)]
        public async Task<IActionResult> SearchProvince([FromBody] ProvinceSearchCriteria criteria)
        {
            var result = await _provinceSearchService.SearchAsync(criteria);
            return Ok(result);
        }


        [HttpPost(nameof(CreateOrUpdateProvince))]
        [Authorize(ModuleConstants.Security.Permissions.Create)]
        public async Task<IActionResult> CreateOrUpdateProvince([FromBody] ProvinceModel province)
        {
            if (!Guid.TryParse(province.Id, out _))
            {
                province.SetIdentifier();
            }
            await _provinceService.SaveChangesAsync(new[] { province });
            return Ok(province);
        }


        [HttpDelete(nameof(DeleteProvince))]
        [Authorize(ModuleConstants.Security.Permissions.Delete)]
        public async Task<IActionResult> DeleteProvince(string[] ids)
        {
            await _provinceService.DeleteAsync(ids);
            return Ok("Deleted successfully");
        }
    }
}
