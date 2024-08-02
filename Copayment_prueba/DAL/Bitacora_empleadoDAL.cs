using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using Copayment_prueba.Models;
using Copayment_prueba.Dtos;

namespace Copayment_prueba.DAL
{
    public class Bitacora_empleadoDAL
    {
        #region Obtener Bitacora empleados
        public List<Bitacora_empleado> obtenerBitacoraEmpleado(Bitacora_empleadoDTO parametro)
        {
            DataTable dtBitacoraEmpleado = new DataTable();
            List<Bitacora_empleado> bt_empleados = new List<Bitacora_empleado>();
            using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
            {
                using (MySqlCommand command = new MySqlCommand("obtenerBitacoraEmpleado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_emp", parametro.Id_empleado);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        connection.Open();
                        adapter.Fill(dtBitacoraEmpleado);
                        connection.Close();
                    }
                }
            }
            if (dtBitacoraEmpleado?.Rows?.Count > 0)
            {
                foreach (DataRow row in dtBitacoraEmpleado.Rows)
                {
                    Bitacora_empleado bt_empleado = new Bitacora_empleado();

                    bt_empleado.Id_registro = Convert.ToInt32(row["Id_registro"]);
                    bt_empleado.Id_empleado = Convert.ToInt32(row["Id_empleado"]);
                    bt_empleado.Entrada = Convert.ToDateTime(row["Entrada"]);
                    bt_empleado.Salida = !string.IsNullOrEmpty(row["Salida"]?.ToString()) ? Convert.ToDateTime(row["Salida"]) : Convert.ToDateTime("1000-01-01");
                    bt_empleados.Add(bt_empleado);
                }
                
                return bt_empleados;
            }
            else            
                return bt_empleados;            
        }
        public List<Bitacora_empleado> obtenerBitacorasEmpleados(Bitacora_empleadoDTO parametro)
        {
            DataTable dtBitacoraEmpleado = new DataTable();
            List<Bitacora_empleado> bt_empleados = new List<Bitacora_empleado>();
            using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
            {
                using (MySqlCommand command = new MySqlCommand("obtenerBitacorasEmpleados", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fecha", parametro.Fecha);                    

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        connection.Open();
                        adapter.Fill(dtBitacoraEmpleado);
                        connection.Close();
                    }
                }
            }
            if (dtBitacoraEmpleado?.Rows?.Count > 0)
            {
                foreach (DataRow row in dtBitacoraEmpleado.Rows)
                {
                    Bitacora_empleado bt_empleado = new Bitacora_empleado();

                    bt_empleado.Id_registro = Convert.ToInt32(row["Id_registro"]);
                    bt_empleado.Id_empleado = Convert.ToInt32(row["Id_empleado"]);
                    bt_empleado.Entrada = Convert.ToDateTime(row["Entrada"]);
                    bt_empleado.Salida = !string.IsNullOrEmpty(row["Salida"]?.ToString()) ? Convert.ToDateTime(row["Salida"]) : Convert.ToDateTime("1000-01-01");
                    bt_empleados.Add(bt_empleado);
                }

                return bt_empleados;
            }
            else
                return bt_empleados;
        }
        #endregion
        #region Registrar Entrada/Salida
        public string registrarEntrada(Bitacora_empleadoDTO bt_empleadoDTO)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
                {
                    using (MySqlCommand command = new MySqlCommand("registrarEntrada", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id_emp", bt_empleadoDTO.Id_empleado);
                        command.Parameters.AddWithValue("@fecha_entrada", bt_empleadoDTO.Fecha_entrada);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                return "Entrada registrada correctamente";
            }
            catch (Exception ex)
            {
                return "Ha ocurrido un error: " + ex.Message.ToString();
            }
        }
        public string registrarSalida(Bitacora_empleadoDTO bt_empleadoDTO)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
                {
                    using (MySqlCommand command = new MySqlCommand("registrarSalida", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id_emp", bt_empleadoDTO.Id_empleado);
                        command.Parameters.AddWithValue("@fecha", bt_empleadoDTO.Fecha_entrada);
                        command.Parameters.AddWithValue("@fecha_salida", bt_empleadoDTO.Fecha_salida);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                return "Salida registrada correctamente";
            }
            catch (Exception ex)
            {
                return "Ha ocurrido un error: " + ex.Message.ToString();
            }
        }
        #endregion
        #region Calcular salario diario
        public List<CalculoSalario> calcularSalarioDiarioIndividual(Bitacora_empleadoDTO parametro)
        {
            DataTable dtCalculoSalario = new DataTable();
            List<CalculoSalario> calculo_salarios = new List<CalculoSalario>();
            using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
            {
                using (MySqlCommand command = new MySqlCommand("calcularSalarioDiarioIndividual", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_emp", parametro.Id_empleado);
                    command.Parameters.AddWithValue("@fecha", parametro.Fecha);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        connection.Open();
                        adapter.Fill(dtCalculoSalario);
                        connection.Close();
                    }
                }
            }
            if (dtCalculoSalario?.Rows?.Count > 0)
            {
                foreach (DataRow row in dtCalculoSalario.Rows)
                {
                    CalculoSalario cs = new CalculoSalario();
                    
                    cs.Id_empleado = Convert.ToInt32(row["Id_empleado"]);
                    cs.Nombre = row["Nombre"].ToString();
                    cs.App = row["App"].ToString();
                    cs.Apm = row["Apm"].ToString();
                    cs.Entrada = Convert.ToDateTime(row["Entrada"]);
                    cs.Salida = !string.IsNullOrEmpty(row["Salida"]?.ToString()) ? Convert.ToDateTime(row["Salida"]) : Convert.ToDateTime("1000-01-01");
                    cs.Salario_diario = !string.IsNullOrEmpty(row["Salario_diario"]?.ToString()) ? Convert.ToDouble(row["Salario_diario"].ToString()) : 0.00;
                    cs.Horas_trabajadas = !string.IsNullOrEmpty(row["Horas_trabajadas"]?.ToString()) ? Convert.ToDouble(row["Horas_trabajadas"].ToString()) : 0.00;
                    calculo_salarios.Add(cs);
                }
                return calculo_salarios;
            }
            else
                return calculo_salarios;
        }
        public List<CalculoSalario> calcularTodoSalarioDiario(Bitacora_empleadoDTO parametro)
        {
            DataTable dtCalculoSalario = new DataTable();
            List<CalculoSalario> calculo_salarios = new List<CalculoSalario>();
            using (MySqlConnection connection = new MySqlConnection(Utils.Utils.cadenaConexion()))
            {
                using (MySqlCommand command = new MySqlCommand("calcularTodoSalarioDiario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;                    
                    command.Parameters.AddWithValue("@fecha", parametro.Fecha);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        connection.Open();
                        adapter.Fill(dtCalculoSalario);
                        connection.Close();
                    }
                }
            }
            if (dtCalculoSalario?.Rows?.Count > 0)
            {
                foreach (DataRow row in dtCalculoSalario.Rows)
                {
                    CalculoSalario cs = new CalculoSalario();

                    cs.Id_empleado = Convert.ToInt32(row["Id_empleado"]);
                    cs.Nombre = row["Nombre"].ToString();
                    cs.App = row["App"].ToString();
                    cs.Apm = row["Apm"].ToString();
                    cs.Entrada = Convert.ToDateTime(row["Entrada"]);
                    cs.Salida = !string.IsNullOrEmpty(row["Salida"]?.ToString()) ? Convert.ToDateTime(row["Salida"]) : Convert.ToDateTime("1000-01-01");
                    cs.Salario_diario = !string.IsNullOrEmpty(row["Salario_diario"]?.ToString()) ? Convert.ToDouble(row["Salario_diario"].ToString()) : 0.00;
                    cs.Horas_trabajadas = !string.IsNullOrEmpty(row["Horas_trabajadas"]?.ToString()) ?  Convert.ToDouble(row["Horas_trabajadas"].ToString()) : 0.00;
                    calculo_salarios.Add(cs);
                }
                return calculo_salarios;
            }
            else
                return calculo_salarios;
        }
        #endregion
    }
}