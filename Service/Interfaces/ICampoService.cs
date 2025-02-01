using NavegacionDinamica.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NavegacionDinamica.Services.Interfaces
{
    public interface ICampoService
    {
        Task<List<Campo>> ObtenerTodasAsync();
        Task<Campo> ObtenerPorIdAsync(int idCampo);
        Task CrearAsync(Campo campo);
        Task ActualizarAsync(Campo campo);
        Task EliminarAsync(int idCampo);
    }
}
