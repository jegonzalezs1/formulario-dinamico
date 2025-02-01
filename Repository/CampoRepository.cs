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
    public class CampoRepository : ICampoRepository
    {
        private readonly string _connectionString;

        public CampoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevConnection");
        }

        public async Task InsertarAsync(Campo campo)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_crud_campo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@accion", "I");
                cmd.Parameters.AddWithValue("@nomb_campo", campo.NombreCampo);
                cmd.Parameters.AddWithValue("@tipo_campo", campo.TipoCampo);
                cmd.Parameters.AddWithValue("@id_form", campo.IdFormulario);

                conn.Open();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task ActualizarAsync(Campo campo)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_crud_campo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@accion", "U");
                cmd.Parameters.AddWithValue("@id_campo", campo.IdCampo);
                cmd.Parameters.AddWithValue("@nomb_campo", campo.NombreCampo);
                cmd.Parameters.AddWithValue("@tipo_campo", campo.TipoCampo);
                cmd.Parameters.AddWithValue("@id_form", campo.IdFormulario);

                conn.Open();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task EliminarAsync(int idCampo)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_crud_campo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@accion", "D");
                cmd.Parameters.AddWithValue("@id_campo", idCampo);
                conn.Open();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<Campo> ObtenerPorIdAsync(int idCampo)
        {
            Campo campo = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_crud_campo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accion", "C");
                cmd.Parameters.AddWithValue("@id_campo", idCampo);

                conn.Open();
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        campo = new Campo
                        {
                            IdCampo = Convert.ToInt32(reader["IdCampo"]),
                            NombreCampo = reader["NombreCampo"].ToString(),
                            TipoCampo = reader["TipoCampo"].ToString(),
                            IdFormulario = Convert.ToInt32(reader["IdFormulario"]),
                            Formulario = new Formulario
                            {
                                IdFormulario = Convert.ToInt32(reader["IdFormulario"]),
                                NombreFormulario = reader["NombreFormulario"].ToString(),
                            }
                        };
                    }
                }
            }

            return campo;
        }

        public async Task<List<Campo>> ObtenerTodasAsync()
        {
            var campos = new List<Campo>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_crud_campo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accion", "G");

                conn.Open();
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var campo = new Campo
                        {
                            IdCampo = Convert.ToInt32(reader["IdCampo"]),
                            NombreCampo = reader["NombreCampo"].ToString(),
                            TipoCampo = reader["TipoCampo"].ToString(),
                            IdFormulario = Convert.ToInt32(reader["IdFormulario"]),
                            Formulario = new Formulario
                            {
                                IdFormulario = Convert.ToInt32(reader["IdFormulario"]),
                                NombreFormulario = reader["NombreFormulario"].ToString(),
                            }
                        };
                        campos.Add(campo);
                    }
                }
            }

            return campos;
        }
    }
}
