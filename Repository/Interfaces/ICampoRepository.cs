using NavegacionDinamica.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NavegacionDinamica.Repository.Interfaces
{
    public interface ICampoRepository
    {
        Task InsertarAsync(Campo campo);
        Task ActualizarAsync(Campo campo);
        Task EliminarAsync(int idCampo);
        Task<Campo> ObtenerPorIdAsync(int idCampo);
        Task<List<Campo>> ObtenerTodasAsync();
    }
}
