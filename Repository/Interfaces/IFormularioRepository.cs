using NavegacionDinamica.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NavegacionDinamica.Repository.Interfaces
{
    public interface IFormularioRepository
    {
        Task InsertarAsync(Formulario formulario);
        Task ActualizarAsync(Formulario formulario);
        Task EliminarAsync(int idFormulario);
        Task<Formulario> ObtenerPorIdAsync(int idFormulario);
        Task<List<Formulario>> ObtenerTodasAsync();
    }
}
