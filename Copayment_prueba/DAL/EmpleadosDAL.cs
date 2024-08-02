using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using Copayment_prueba.Models;

namespace Copayment_prueba.DAL
{
    public class EmpleadosDAL
    {
        #region Obtener empleado
        public Empleado obtenerEmpleado(int id_empleado)
        {
            DataTable dtEmpleado = new DataTable();                
            Empleado emp = new Empleado();
            using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
            {
                using (MySqlCommand command = new MySqlCommand("obtenerEmpleado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id_empleado);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {                        
                        connection.Open();
                        adapter.Fill(dtEmpleado);
                        connection.Close();                        
                    }
                }
            }
            if (dtEmpleado?.Rows?.Count > 0)
            {
                emp.Id_empleado = Convert.ToInt32(dtEmpleado.Rows[0]["Id_empleado"]);
                emp.Nombre = dtEmpleado.Rows[0]["Nombre"].ToString();
                emp.App = dtEmpleado.Rows[0]["App"].ToString();
                emp.Apm = dtEmpleado.Rows[0]["Apm"].ToString();
                emp.Fecha_nacimiento = Convert.ToDateTime(dtEmpleado.Rows[0]["Fecha_nacimiento"]);
                emp.Sexo = dtEmpleado.Rows[0]["Sexo"].ToString();
                emp.Departamento = Convert.ToInt32(dtEmpleado.Rows[0]["Departamento"]);
                emp.Telefono_contacto = dtEmpleado.Rows[0]["Telefono_contacto"].ToString();
                emp.Correo_contacto = dtEmpleado.Rows[0]["Correo_contacto"].ToString();
                emp.Activo = dtEmpleado.Rows[0]["Activo"].ToString();
                return emp;
            }
            else                    
                return emp;            
        }
        public List<Empleado> obtenerEmpleados()
        {
            DataTable dtEmpleado = new DataTable();
            List<Empleado> empleados = new List<Empleado>();
            using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
            {
                using (MySqlCommand command = new MySqlCommand("obtenerEmpleados", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        connection.Open();
                        adapter.Fill(dtEmpleado);
                        connection.Close();
                    }
                }
            }
            if (dtEmpleado?.Rows?.Count > 0)
            {                
                foreach (DataRow row in dtEmpleado.Rows)
                {
                    Empleado emp = new Empleado();                    
                        
                    emp.Id_empleado = Convert.ToInt32(row["Id_empleado"]);
                    emp.Nombre = row["Nombre"].ToString();
                    emp.App = row["App"].ToString();
                    emp.Apm = row["Apm"].ToString();
                    emp.Fecha_nacimiento = Convert.ToDateTime(dtEmpleado.Rows[0]["Fecha_nacimiento"]);
                    emp.Sexo = row["Sexo"].ToString();
                    emp.Departamento = Convert.ToInt32(dtEmpleado.Rows[0]["Departamento"]);
                    emp.Telefono_contacto = row["Telefono_contacto"].ToString();
                    emp.Correo_contacto = row["Correo_contacto"].ToString();
                    emp.Activo = row["Activo"].ToString();                    

                    empleados.Add(emp);
                }                                
                return empleados;
            }
            else
            {                
                return empleados;
            }
        }
        #endregion
        #region Crear empleado
        public string crearEmpleado(Empleado parametro)
        {
            try { 
            using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
            {
                using (MySqlCommand command = new MySqlCommand("crearEmpleado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    
                    command.Parameters.AddWithValue("@nom", parametro.Nombre);
                    command.Parameters.AddWithValue("@app", parametro.App);
                    command.Parameters.AddWithValue("@apm", parametro.Apm);
                    command.Parameters.AddWithValue("@nacimiento", parametro.Fecha_nacimiento);
                    command.Parameters.AddWithValue("@sex", parametro.Sexo);
                    command.Parameters.AddWithValue("@dep", parametro.Departamento);
                    command.Parameters.AddWithValue("@telefono", parametro.Telefono_contacto);
                    command.Parameters.AddWithValue("@correo", parametro.Correo_contacto);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
                return "Empleado creado correctamente";
            }
            catch (Exception ex) {
                return "Ha ocurrido un error: "+ex.Message.ToString();
            }
        }
        #endregion
        #region Actualizar empleado
        public string actualizarEmpleado(Empleado parametro)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
                {
                    using (MySqlCommand command = new MySqlCommand("actualizarEmpleado", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", parametro.Id_empleado);
                        command.Parameters.AddWithValue("@nom", parametro.Nombre);
                        command.Parameters.AddWithValue("@app", parametro.App);
                        command.Parameters.AddWithValue("@apm", parametro.Apm);
                        command.Parameters.AddWithValue("@nacimiento", parametro.Fecha_nacimiento);
                        command.Parameters.AddWithValue("@sex", parametro.Sexo);
                        command.Parameters.AddWithValue("@dep", parametro.Departamento);
                        command.Parameters.AddWithValue("@telefono", parametro.Telefono_contacto);
                        command.Parameters.AddWithValue("@correo", parametro.Correo_contacto);
                        command.Parameters.AddWithValue("@act", parametro.Activo);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                return "Empleado actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Ha ocurrido un error: " + ex.Message.ToString();
            }
        }
        #endregion
        #region Eliminar empleado
        public string eliminarEmpleado(int id_emp)
        {
            Empleado emp = obtenerEmpleado(id_emp);
            if (emp.Id_empleado>0)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
                    {
                        using (MySqlCommand command = new MySqlCommand("eliminarEmpleado", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@id", id_emp);
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    return "Empleado eliminado correctamente";
                }
                catch (Exception ex)
                {
                    return "Ha ocurrido un error: " + ex.Message.ToString();
                }
            }
            else
                return "El empleado no existe";
            
        }
        #endregion
    }
}

