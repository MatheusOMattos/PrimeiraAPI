using Microsoft.AspNetCore.Mvc;
using PrimeiraApi.Services;
using System.Threading.Tasks;

namespace PrimeiraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly JsonFileService _jsonFileService;

        public WeatherForecastController(JsonFileService jsonFileService)
        {
            _jsonFileService = jsonFileService;
        }

        [HttpGet("json-content")]
        public async Task<IActionResult> GetJsonContent()
        {
            var content = await _jsonFileService.ReadJsonFileAsync<object>();

            if (content == null)
            {
                return NotFound("Arquivo JSON não encontrado ou inválido.");
            }

            return Ok(content);
        }
    }
}

