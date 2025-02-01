using NavegacionDinamica.Models;
using NavegacionDinamica.Repository.Interfaces;
using NavegacionDinamica.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NavegacionDinamica.Services
{
    public class CampoService : ICampoService
    {
        private readonly ICampoRepository _campoRepository;

        public CampoService(ICampoRepository campoRepository)
        {
            _campoRepository = campoRepository;
        }

        public async Task<List<Campo>> ObtenerTodasAsync()
        {
            return await _campoRepository.ObtenerTodasAsync();
        }

        public async Task<Campo> ObtenerPorIdAsync(int idCampo)
        {
            return await _campoRepository.ObtenerPorIdAsync(idCampo);
        }

        public async Task CrearAsync(Campo campo)
        {
            await _campoRepository.InsertarAsync(campo);
        }

        public async Task ActualizarAsync(Campo campo)
        {
            await _campoRepository.ActualizarAsync(campo);
        }

        public async Task EliminarAsync(int idCampo)
        {
            await _campoRepository.EliminarAsync(idCampo);
        }
    }
}
