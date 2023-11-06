using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheLastBugPrueba.Common;
using TheLastBugPrueba.Services;

namespace TheLastBugPrueba.Api.Controllers
{
    [Authorize(Roles = "Administrador")]
    [ApiController]
    [Route("api/[controller]")]
    public class AyudasSocialesController : ControllerBase
    {
        private readonly ServicioAyudaSocial _servicioAyudaSocial;

        public AyudasSocialesController(ServicioAyudaSocial servicioAyudaSocial)
        {
            _servicioAyudaSocial = servicioAyudaSocial;
        }

        [HttpPost("asignar")]
        public async Task<IActionResult> AsignarAyuda([FromBody] AsignacionAyudaSocialDto asignacionDto)
        {
            var resultado = await _servicioAyudaSocial.AsignarAyudaAsync(asignacionDto.UsuarioId, asignacionDto.AyudaSocialId, asignacionDto.Year);
            if (!resultado) return BadRequest("La ayuda social ya fue asignada a este usuario en el año indicado.");
            return Ok();
        }

    }

}
