using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using Copayment_prueba.Models;

namespace Copayment_prueba.DAL
{
    public class UsuarioDAL
    {
        #region Crear usuario
        public string crearUsuario(Usuario parametro)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
                {
                    using (MySqlCommand command = new MySqlCommand("crearUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        //Password hash
                        parametro.Password = Utils.Utils.passwordHash(parametro.Password);
                        command.Parameters.AddWithValue("@nom", parametro.Nombre_usuario);
                        command.Parameters.AddWithValue("@pass", parametro.Password);                        
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                return "Usuario creado correctamente";
            }
            catch (Exception ex)
            {
                return "Ha ocurrido un error: " + ex.Message.ToString();
            }
        }
        #endregion
        #region Obtener usuario
        public Usuario obtenerUsuario(string nombre_usuario)
        {
            DataTable dtUsuario = new DataTable();
            Usuario us = new Usuario();
            using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
            {
                using (MySqlCommand command = new MySqlCommand("obtenerUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombre", nombre_usuario);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        connection.Open();
                        adapter.Fill(dtUsuario);
                        connection.Close();
                    }
                }
            }
            if (dtUsuario?.Rows?.Count > 0)
            {
                us.Id_usuario = Convert.ToInt32(dtUsuario.Rows[0]["Id_usuario"]);
                us.Nombre_usuario = dtUsuario.Rows[0]["Nombre_usuario"].ToString();
                us.Password = dtUsuario.Rows[0]["Password"].ToString();
                us.Activo = dtUsuario.Rows[0]["Activo"].ToString();
                return us;
            }
            else
                return us;
        }
        #endregion
        #region Eliminar usuario
        public string eliminarUsuario(string nombre_usuario)
        {
            Usuario us = obtenerUsuario(nombre_usuario);
            if (us.Id_usuario > 0)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
                    {
                        using (MySqlCommand command = new MySqlCommand("eliminarUsuario", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@nombre", nombre_usuario);
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    return "Usuario eliminado correctamente";
                }
                catch (Exception ex)
                {
                    return "Ha ocurrido un error: " + ex.Message.ToString();
                }
            }
            else
                return "El usuario no existe";

        }
        #endregion
    }
}