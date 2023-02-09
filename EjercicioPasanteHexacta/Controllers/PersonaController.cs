using EjercicioPasanteHexacta.DTOS;
using EjercicioPasanteHexacta.Models;
using EjercicioPasanteHexacta.Services;
using EjercicioPasanteHexacta.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioPasanteHexacta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        IPersonaService personaService;

        private readonly ILogger<PersonaController> _logger;

        public PersonaController(ILogger<PersonaController> logger, IPersonaService service) {

            _logger = logger;
            personaService = service;

        }

        [HttpGet]
        public IActionResult Get([FromQuery] string? nombre = "", [FromQuery] string? apellido = "")
        {

            try
            {
                IEnumerable<PersonaView> personasViews = personaService.Get(nombre, apellido).Select(persona => (PersonaView)persona);

                return Ok(personasViews);
            }
            catch (Exception ex)
            {
                return BadRequest("Datos obtenidos inválidos");
            }

        }

        [HttpPost]

        public IActionResult Post(PersonaDTO dto)
        {

            if(dto.Edad < 0 || dto.Edad > 200)
            {
                return BadRequest("Edad fuera de rango, debe estar entre 0 y 200");
            }

            try
            {
                personaService.Save((Persona)dto);
            }
            catch(Exception ex)
            {
                return BadRequest("Datos inválidos");
            }

            return Ok();
        }
    }
}
