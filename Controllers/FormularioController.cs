using System.Collections.Generic;
using System.Threading.Tasks;
using NavegacionDinamica.Models;
using NavegacionDinamica.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NavegacionDinamica.Controllers
{
    [ApiController]
    [Route("api/formulario")]
    public class FormularioController : ControllerBase
    {
        private readonly IFormularioService _formularioService;

        public FormularioController(IFormularioService formularioService)
        {
            _formularioService = formularioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Formulario>>> ObtenerTodas()
        {
            var formularios = await _formularioService.ObtenerTodasAsync();
            return Ok(formularios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Formulario>> ObtenerPorId(int id)
        {
            var formulario = await _formularioService.ObtenerPorIdAsync(id);
            if (formulario == null)
            {
                return NotFound();
            }
            return Ok(formulario);
        }

        [HttpPost]
        public async Task<ActionResult> Insertar([FromBody] Formulario formulario)
        {
            await _formularioService.CrearAsync(formulario);
            return Ok(new { message = "Los datos del formulario se han guardado correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(int id, [FromBody] Formulario formulario)
        {
            var formularioExistente = await _formularioService.ObtenerPorIdAsync(id);
            if (formularioExistente == null)
            {
                return NotFound();
            }
            formulario.IdFormulario = id;
            await _formularioService.ActualizarAsync(formulario);
            return Ok(new { message = "Los datos del formulario se han actualizado correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            var formulario = await _formularioService.ObtenerPorIdAsync(id);
            if (formulario == null)
            {
                return NotFound();
            }
            await _formularioService.EliminarAsync(id);
            return Ok(new { message = "Los datos del formulario se han eliminado correctamente" });
        }
    }
}
