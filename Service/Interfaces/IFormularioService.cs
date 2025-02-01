using NavegacionDinamica.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NavegacionDinamica.Services.Interfaces
{
    public interface IFormularioService
    {
        Task<List<Formulario>> ObtenerTodasAsync();
        Task<Formulario> ObtenerPorIdAsync(int idFormulario);
        Task CrearAsync(Formulario formulario);
        Task ActualizarAsync(Formulario formulario);
        Task EliminarAsync(int idFormulario);
    }
}
