using NavegacionDinamica.Models;
using NavegacionDinamica.Repository.Interfaces;
using NavegacionDinamica.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NavegacionDinamica.Services
{
    public class FormularioService : IFormularioService
    {
        private readonly IFormularioRepository _formularioRepository;

        public FormularioService(IFormularioRepository formularioRepository)
        {
            _formularioRepository = formularioRepository;
        }

        public async Task<List<Formulario>> ObtenerTodasAsync()
        {
            return await _formularioRepository.ObtenerTodasAsync();
        }

        public async Task<Formulario> ObtenerPorIdAsync(int idFormulario)
        {
            return await _formularioRepository.ObtenerPorIdAsync(idFormulario);
        }

        public async Task CrearAsync(Formulario formulario)
        {
            await _formularioRepository.InsertarAsync(formulario);
        }

        public async Task ActualizarAsync(Formulario formulario)
        {
            await _formularioRepository.ActualizarAsync(formulario);
        }

        public async Task EliminarAsync(int idFormulario)
        {
            await _formularioRepository.EliminarAsync(idFormulario);
        }
    }
}
