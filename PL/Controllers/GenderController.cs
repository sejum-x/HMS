using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    [ApiController]
    [Route("api/genders")]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _genderService;

        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenders()
        {
            var genders = await _genderService.GetAllGendersAsync();
            return Ok(genders);
        }

        [HttpPost]
        public async Task<IActionResult> AddGender([FromBody] GenderModel genderModel)
        {
            await _genderService.AddGenderAsync(genderModel);
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateGender(Guid id, [FromBody] string newName)
        {
            await _genderService.UpdateGenderAsync(id, newName);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteGender(Guid id)
        {
            await _genderService.DeleteGenderAsync(id);
            return Ok();
        }
    }
}
