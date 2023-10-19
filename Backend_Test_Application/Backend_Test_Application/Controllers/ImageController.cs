using Backend_Test_Application.Entities;
using Backend_Test_Application.Enums;
using Backend_Test_Application.Helpers;
using Backend_Test_Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Backend_Test_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly PluginManager _pluginManager;

        public ImageController(PluginManager pluginManager)
        {
            _pluginManager = pluginManager;
        }

        [HttpPost("add-effect")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> ApplyEffects([FromForm] ImageRequest imageModel)
        {
            try
            {
                ExtendedImage image = new();
                image.OriginalImage = imageModel.OriginalImage;
                image.Effects = JsonConvert.DeserializeObject<List<ImageEffect>>(imageModel.EffectsJson);
                var result = _pluginManager.ApplyEffects(image);

                return File(result.ToArray(), "image/png");

            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("effects")]
        public async Task<IActionResult> GetAllEffectNames()
        {
            string[] enumFields = Enum.GetNames(typeof(EffectEnum));
            return Ok(enumFields);
        }







    }
}

