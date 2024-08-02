using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using Copayment_prueba.Models;
using Copayment_prueba.Dtos;

namespace Copayment_prueba.DAL
{
    public class DepartamentoDAL
    {
        #region Obtener Departamento
        public Departamento obtenerDepartamento(int id)
        {
            DataTable dtDepartamentos = new DataTable();
            Departamento departamento = new Departamento();
            using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
            {
                using (MySqlCommand command = new MySqlCommand("obtenerDepartamento", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        connection.Open();
                        adapter.Fill(dtDepartamentos);
                        connection.Close();
                    }
                }
            }
            if (dtDepartamentos?.Rows?.Count > 0)
            {
                departamento.Id_departamento = Convert.ToInt32(dtDepartamentos.Rows[0]["Id_departamento"]);
                departamento.Nombre = dtDepartamentos.Rows[0]["Nombre"].ToString();
                departamento.Pago_hora = Convert.ToDouble(dtDepartamentos.Rows[0]["Pago_hora"].ToString());
                return departamento;
            }
            else
                return departamento;
        }
        public List<Departamento> obtenerDepartamentos()
        {
            DataTable dtDepartamentos = new DataTable();
            List<Departamento> departamentos = new List<Departamento>();
            using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
            {
                using (MySqlCommand command = new MySqlCommand("obtenerDepartamentos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        connection.Open();
                        adapter.Fill(dtDepartamentos);
                        connection.Close();
                    }
                }
            }
            if (dtDepartamentos?.Rows?.Count > 0)
            {
                foreach (DataRow row in dtDepartamentos.Rows)
                {
                    Departamento departamento = new Departamento();

                    departamento.Id_departamento = Convert.ToInt32(row["Id_departamento"]);
                    departamento.Nombre = row["Nombre"].ToString();
                    departamento.Pago_hora = Convert.ToDouble(row["Pago_hora"].ToString());

                    departamentos.Add(departamento);
                }                
                return departamentos;
            }
            else
                return departamentos;
        }
        #endregion
        #region Crear Departamento
        public string crearDepartamento(Departamento parametro)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
                {
                    using (MySqlCommand command = new MySqlCommand("crearDepartamento", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;                        
                        command.Parameters.AddWithValue("@nom", parametro.Nombre);
                        command.Parameters.AddWithValue("@pago", parametro.Pago_hora);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                return "Departamento creado correctamente";
            }
            catch (Exception ex)
            {
                return "Ha ocurrido un error: " + ex.Message.ToString();
            }
        }
        #endregion
        #region Actualizar Departamento
        public string actualizarDepartamento(Departamento parametro)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
                {
                    using (MySqlCommand command = new MySqlCommand("actualizarDepartamento", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", parametro.Id_departamento);
                        command.Parameters.AddWithValue("@nom", parametro.Nombre);
                        command.Parameters.AddWithValue("@pago", parametro.Pago_hora);                        
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                return "Departamento actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Ha ocurrido un error: " + ex.Message.ToString();
            }
        }
        public string actualizarPagoHora(Departamento parametro)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
                {
                    using (MySqlCommand command = new MySqlCommand("actualizarPagoHora", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", parametro.Id_departamento);                        
                        command.Parameters.AddWithValue("@pago", parametro.Pago_hora);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                return "Pago por hora actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Ha ocurrido un error: " + ex.Message.ToString();
            }
        }
        #endregion
        #region Eliminar departamento
        public string eliminarDepartamento(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
                {
                    using (MySqlCommand command = new MySqlCommand("eliminarDepartamento", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", id);                        
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                return "Departamento eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Ha ocurrido un error: " + ex.Message.ToString();
            }
        }
        #endregion
    }
}