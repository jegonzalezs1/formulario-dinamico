using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NavegacionDinamica.Models;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using NavegacionDinamica.Repository.Interfaces;

namespace NavegacionDinamica.Repository
{
    public class FormularioRepository : IFormularioRepository
    {
        private readonly string _connectionString;

        public FormularioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevConnection");
        }

        public async Task InsertarAsync(Formulario formulario)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_crud_formulario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@accion", "I");
                cmd.Parameters.AddWithValue("@nomb_form", formulario.NombreFormulario);

                conn.Open();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task ActualizarAsync(Formulario formulario)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_crud_formulario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@accion", "U");
                cmd.Parameters.AddWithValue("@id_form", formulario.IdFormulario);
                cmd.Parameters.AddWithValue("@nomb_form", formulario.NombreFormulario);

                conn.Open();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task EliminarAsync(int idFormulario)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_crud_formulario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@accion", "D");
                cmd.Parameters.AddWithValue("@id_form", idFormulario);

                conn.Open();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<Formulario> ObtenerPorIdAsync(int idFormulario)
        {
            Formulario formulario = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_crud_formulario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accion", "C");
                cmd.Parameters.AddWithValue("@id_form", idFormulario);

                conn.Open();
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        formulario = new Formulario
                        {
                            IdFormulario = Convert.ToInt32(reader["IdFormulario"]),
                            NombreFormulario = reader["NombreFormulario"].ToString(), 
                        };
                    }
                }
            }

            return formulario;
        }

        public async Task<List<Formulario>> ObtenerTodasAsync()
        {
            var formularios = new List<Formulario>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_crud_formulario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accion", "G");

                conn.Open();
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var formulario = new Formulario
                        {
                            IdFormulario = Convert.ToInt32(reader["IdFormulario"]),
                            NombreFormulario = reader["NombreFormulario"].ToString(),
                        };
                        formularios.Add(formulario);
                    }
                }
            }

            return formularios;
        }
    }
}
