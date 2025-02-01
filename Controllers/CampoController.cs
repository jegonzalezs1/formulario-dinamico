using System.Collections.Generic;
using System.Threading.Tasks; // Asegúrate de incluir esto
using NavegacionDinamica.Models;
using NavegacionDinamica.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NavegacionDinamica.Controllers
{
    [ApiController]
    [Route("api/campo")]
    public class CampoController : ControllerBase
    {
        private readonly ICampoService _campoService;

        public CampoController(ICampoService campoService)
        {
            _campoService = campoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Campo>>> ObtenerTodas()
        {
            var campos = await _campoService.ObtenerTodasAsync();
            return Ok(campos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Campo>> ObtenerPorId(int id)
        {
            var campo = await _campoService.ObtenerPorIdAsync(id);
            if (campo == null)
            {
                return NotFound();
            }
            return Ok(campo);
        }

        [HttpPost]
        public async Task<ActionResult> Insertar([FromBody] Campo campo)
        {
            await _campoService.CrearAsync(campo);
            return Ok(new { message = "Los datos del campo se han guardado correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(int id, [FromBody] Campo campo)
        {
            var campoExistente = await _campoService.ObtenerPorIdAsync(id);
            if (campoExistente == null)
            {
                return NotFound();
            }
            campo.IdCampo = id;
            await _campoService.ActualizarAsync(campo);
            return Ok(new { message = "Los datos del campo se han actualizado correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            var campo = await _campoService.ObtenerPorIdAsync(id);
            if (campo == null)
            {
                return NotFound();
            }
            await _campoService.EliminarAsync(id);
            return Ok(new { message = "Los datos del campo se han eliminado correctamente" });
        }
    }
}
