using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing;
using MySql.Data.MySqlClient;

namespace Usuarios_planta
{
    class dia_dia
    {
        MySqlConnection con = new MySqlConnection("server=82.2.121.99;Uid=userapp;password=userapp;database=dblibranza;port=3306;persistsecurityinfo=True;");


        public void Insertar_colp(TextBox Txtradicado, TextBox Txtcedula, TextBox Txtnombre, TextBox TxtEstado_cliente, TextBox Txtafiliacion1, TextBox Txtafiliacion2,
                                  ComboBox cmbtipo, TextBox Txtscoring, TextBox Txtconsecutivo, ComboBox cmbfuerza, ComboBox cmbdestino, TextBox Txtrtq, TextBox Txtmonto, 
                                  TextBox Txtplazo, TextBox Txtcuota, TextBox Txttotal,TextBox Txtpagare, TextBox Txtnit, TextBox Txtcuota_letras, TextBox Txttotal_letras,
                                  ComboBox cmbestado, ComboBox cmbcargue,DateTimePicker dtpcargue, ComboBox cmbresultado, 
                                  ComboBox cmbrechazo, DateTimePicker dtpfecha_rpta,TextBox Txtplano_dia, TextBox Txtplano_pre, TextBox TxtN_Plano, TextBox Txtcomentarios, Label lblfecha_actual)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("insertar_colp_dia", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente 

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Radicado", Txtradicado.Text);
                cmd.Parameters.AddWithValue("@_Cedula", Txtcedula.Text);
                cmd.Parameters.AddWithValue("@_Nombre_Cliente", Txtnombre.Text);
                cmd.Parameters.AddWithValue("@_Estado_Cliente", TxtEstado_cliente.Text);
                cmd.Parameters.AddWithValue("@_N_Afiliacion1", Txtafiliacion1.Text);
                cmd.Parameters.AddWithValue("@_N_Afiliacion2", Txtafiliacion2.Text);
                cmd.Parameters.AddWithValue("@_Tipo_Documento", cmbtipo.Text);
                cmd.Parameters.AddWithValue("@_Scoring", Txtscoring.Text);
                cmd.Parameters.AddWithValue("@_Consecutivo", Txtconsecutivo.Text);
                cmd.Parameters.AddWithValue("@_Fuerza_Venta", cmbfuerza.Text);
                cmd.Parameters.AddWithValue("@_Destino", cmbdestino.Text);
                cmd.Parameters.AddWithValue("@_Rtq", Txtrtq.Text);
                cmd.Parameters.AddWithValue("@_Monto_Aprobado", Txtmonto.Text);
                cmd.Parameters.AddWithValue("@_Plazo_Aprobado", Txtplazo.Text);
                cmd.Parameters.AddWithValue("@_Cuota", string.Format("{0:#}", double.Parse(Txtcuota.Text)));// se formate el numero para que no vaya con el . de la separacion de miles
                cmd.Parameters.AddWithValue("@_Total", Txttotal.Text);
                cmd.Parameters.AddWithValue("@_Pagare", Txtpagare.Text);
                cmd.Parameters.AddWithValue("@_Nit", Txtnit.Text);
                cmd.Parameters.AddWithValue("@_Cuota_Letras", Txtcuota_letras.Text);
                cmd.Parameters.AddWithValue("@_Total_Letras", Txttotal_letras.Text);
                cmd.Parameters.AddWithValue("@_Estado_operacion", cmbestado.Text);
                cmd.Parameters.AddWithValue("@_Estado_cargue", cmbcargue.Text);
                cmd.Parameters.AddWithValue("@_Fecha_Cargue", dtpcargue.Text);
                cmd.Parameters.AddWithValue("@_Respuesta_Cargue", cmbresultado.Text);
                cmd.Parameters.AddWithValue("@_Causal_Rechazo", cmbrechazo.Text);
                cmd.Parameters.AddWithValue("@_Fecha_respuesta", dtpfecha_rpta.Text);
                cmd.Parameters.AddWithValue("@_Plano_Dia", Txtplano_dia.Text);
                cmd.Parameters.AddWithValue("@_Plano_Pre", Txtplano_pre.Text);
                cmd.Parameters.AddWithValue("@_Plano", TxtN_Plano.Text);
                cmd.Parameters.AddWithValue("@_Comentarios", Txtcomentarios.Text);
                cmd.Parameters.AddWithValue("@_Id_Funcionario", usuario.Identificacion);                
                cmd.Parameters.AddWithValue("@_CE", usuario.CE);
                cmd.Parameters.AddWithValue("@_Fecha_Gestion", lblfecha_actual.Text);
                cmd.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show("Información Almacenada con Éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception e)
            {
                myTrans.Rollback();
                MessageBox.Show(e.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public void buscar_colp(TextBox Txtradicado, TextBox Txtcedula, TextBox Txtnombre, TextBox TxtEstado_cliente, TextBox Txtafiliacion1, TextBox Txtafiliacion2,
                                ComboBox cmbtipo, TextBox Txtscoring, TextBox Txtconsecutivo, ComboBox cmbfuerza, ComboBox cmbdestino, TextBox Txtrtq, TextBox Txtmonto, TextBox Txtplazo, TextBox Txtcuota, TextBox Txttotal,
                                TextBox Txtpagare, TextBox Txtnit, TextBox Txtcuota_letras, TextBox Txttotal_letras, ComboBox cmbestado, ComboBox cmbcargue,
                                DateTimePicker dtpcargue, ComboBox cmbresultado, ComboBox cmbrechazo, DateTimePicker dtpfecha_rpta,
                                TextBox Txtplano_dia, TextBox Txtplano_pre, TextBox TxtN_Plano, TextBox Txtcomentarios)
        {

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("buscar_colp_dia", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Radicado", Txtradicado.Text);
                MySqlDataReader registro;
                registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    Txtcedula.Text = registro["Cedula"].ToString();
                    Txtnombre.Text = registro["Nombre_Cliente"].ToString();
                    TxtEstado_cliente.Text = registro["Estado_Cliente"].ToString();
                    Txtafiliacion1.Text = registro["N_Afiliacion1"].ToString();
                    Txtafiliacion2.Text = registro["N_Afiliacion2"].ToString();
                    cmbtipo.Text = registro["Tipo_Documento"].ToString();
                    Txtscoring.Text = registro["Scoring"].ToString();
                    Txtconsecutivo.Text = registro["Consecutivo"].ToString();
                    cmbfuerza.Text = registro["Fuerza_Venta"].ToString();
                    cmbdestino.Text = registro["Destino"].ToString();
                    Txtrtq.Text = registro["Rtq"].ToString();
                    Txtmonto.Text = registro["Monto_Aprobado"].ToString();
                    Txtplazo.Text = registro["Plazo_Aprobado"].ToString();
                    Txtcuota.Text = registro["Cuota"].ToString();
                    Txttotal.Text = registro["Total"].ToString();
                    Txtpagare.Text = registro["Pagare"].ToString();
                    Txtnit.Text = registro["Nit"].ToString();
                    Txtcuota_letras.Text = registro["Cuota_Letras"].ToString();
                    Txttotal_letras.Text = registro["Total_Letras"].ToString();
                    cmbestado.Text = registro["Estado_operacion"].ToString();
                    cmbcargue.Text = registro["Estado_cargue"].ToString();
                    dtpcargue.Text = registro["Fecha_Cargue"].ToString();
                    cmbresultado.Text = registro["Respuesta_Cargue"].ToString();
                    cmbrechazo.Text = registro["Causal_Rechazo"].ToString();
                    dtpfecha_rpta.Text = registro["Fecha_respuesta"].ToString();
                    Txtplano_dia.Text = registro["Plano_Dia"].ToString();
                    Txtplano_pre.Text = registro["Plano_Pre"].ToString();
                    TxtN_Plano.Text = registro["plano"].ToString();
                    Txtcomentarios.Text = registro["Comentarios"].ToString();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Caso no existe", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpcargue.Text = "01/01/2020";
                    dtpfecha_rpta.Text = "01/01/2020";
                    Txtnit.Text = "860003020";
                    Txtcedula.Text = null;
                    Txtnombre.Text = null;
                    TxtEstado_cliente.Text = null;
                    Txtafiliacion1.Text = null;
                    Txtafiliacion2.Text = null;
                    cmbtipo.Text = null;
                    Txtscoring.Text = null;
                    Txtconsecutivo.Text = null;
                    cmbfuerza.Text = null;
                    cmbdestino.Text = null;
                    Txtrtq.Text = null;
                    Txtmonto.Text = null;
                    Txtplazo.Text = null;
                    Txtcuota.Text = null;
                    Txttotal.Text = null;
                    Txtpagare.Text = null;
                    Txtcuota_letras.Text = null;
                    Txttotal_letras.Text = null;
                    cmbestado.Text = null;
                    cmbcargue.Text = null;
                    cmbresultado.Text = null;
                    cmbrechazo.Text = null;
                    Txtplano_dia.Text = null;
                    Txtplano_pre.Text = null;
                    TxtN_Plano.Text = null;
                    Txtcomentarios.Text = null;                   
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Caso no existe", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada");
            }
        }

        public void pendiente_cargue_dia(DateTimePicker dtp_cargue, DataGridView dgv_altas, TextBox Txtfuncionario)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("pendiente_cargue_dia", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Fecha_Cargue", dtp_cargue.Text);
                cmd.Parameters.AddWithValue("@_Id_Funcionario", Txtfuncionario.Text);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgv_altas.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void pendiente_cargue_dia_bajas(DateTimePicker dtp_cargue, DataGridView dgv_bajas, TextBox Txtfuncionario)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("pendiente_cargue_dia_bajas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Fecha_Cargue", dtp_cargue.Text);
                cmd.Parameters.AddWithValue("@_Id_Funcionario", Txtfuncionario.Text);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgv_bajas.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void busqueda_plano(DataGridView dgv_datos_plano, TextBox Txtbusqueda)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("busqueda_plano", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_plano", Txtbusqueda.Text);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgv_datos_plano.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void buscar_fallecido(TextBox Txtcedula, TextBox TxtEstado_cliente)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("buscar_fallecido", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Cedula", Txtcedula.Text);
                MySqlDataReader registro;
                registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    TxtEstado_cliente.Text = "Fallecido";
                    con.Close();
                }
                else
                {
                    TxtEstado_cliente.Text = "Activo";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void buscar_recaudo(TextBox Txtcedula)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("buscar_recaudo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Cedula", Txtcedula.Text);
                MySqlDataReader registro;
                registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Cliente no registra recaudo para el mes en curso, por favor reportar al area encargada","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void planos_cargue(DataGridView dgv_altas, TextBox Txtplano_alta)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("planos_cargue", con);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (DataGridViewRow row in dgv_altas.Rows)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@_Afiliacion", Convert.ToString(row.Cells[0].Value));
                    cmd.Parameters.AddWithValue("@_plano", Txtplano_alta.Text);
                    cmd.Parameters.AddWithValue("@_Fecha_cargue", fecha.ToString("dd/MM/yyyy"));
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Información Actualizada con Éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        DateTime fecha = DateTime.Now;

        public void actualizar_cargueckl(DataGridView dgv_altas, TextBox Txtplano_alta)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("actualizar_cargueckl", con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (DataGridViewRow row in dgv_altas.Rows)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@_N_Afiliacion2", Convert.ToString(row.Cells[0].Value));
                    cmd.Parameters.AddWithValue("@_Estado_cargue", "Ok Cargue");
                    cmd.Parameters.AddWithValue("@_Fecha_Cargue", fecha.ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("@_Respuesta_Cargue", "Pdte Dictamen");
                    cmd.Parameters.AddWithValue("@_Plano", Txtplano_alta.Text);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Información Actualizada con Éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void actualizar_rta_dia(DataGridView dgv_datos_plano)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("actualizar_rtackl", con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (DataGridViewRow row in dgv_datos_plano.Rows)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@_N_Afiliacion2", Convert.ToString(row.Cells[2].Value));
                    cmd.Parameters.AddWithValue("@_Respuesta_Cargue", Convert.ToString(row.Cells[3].Value));
                    cmd.Parameters.AddWithValue("@_Fecha_respuesta", fecha.ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("@_Causal_Rechazo", Convert.ToString(row.Cells[4].Value));
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Información Actualizada con Éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void rescate_rtq(TextBox Txtafiliacion2, TextBox Txtcedula, TextBox Txtnit, TextBox Txtcuota, TextBox Txtplazo,
                                TextBox Txtpagare, TextBox Txtplano_pre, TextBox Txtplano_dia, DateTimePicker dtpcargue, 
                                TextBox TxtIDfuncionario, TextBox TxtNomFuncionario) 
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("rescate_rtq", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente 

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Afiliacion", Txtafiliacion2.Text);
                cmd.Parameters.AddWithValue("@_Cedula", Txtcedula.Text);
                cmd.Parameters.AddWithValue("@_Nit", Txtnit.Text);
                cmd.Parameters.AddWithValue("@_Cuota", string.Format("{0:#}", double.Parse(Txtcuota.Text)));
                cmd.Parameters.AddWithValue("@_Plazo", Txtplazo.Text);
                cmd.Parameters.AddWithValue("@_Pagare", Txtpagare.Text);
                cmd.Parameters.AddWithValue("@_Plano_pre", Txtplano_pre.Text);
                cmd.Parameters.AddWithValue("@_Plano_dia", Txtplano_dia.Text);
                cmd.Parameters.AddWithValue("@_Fecha_cargue", dtpcargue.Text);
                cmd.Parameters.AddWithValue("@_Id_Funcionario", TxtIDfuncionario.Text);
                cmd.Parameters.AddWithValue("@_Nombre_Funcionario", TxtNomFuncionario.Text);
                cmd.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show("Rescate Registrado","Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception e)
            {
                try
                {
                    myTrans.Rollback();
                }
                catch (MySqlException ex)
                {
                    if (myTrans.Connection != null)
                    {
                        MessageBox.Show("Se encontró una excepción de tipo" + ex.GetType() + " al intentar revertir la transacción..");
                    }
                }
                MessageBox.Show("Se encontró una excepción de tipo " + e.GetType() + " al insertar los datos.");
                MessageBox.Show("Ninguno de los registros se escribió en la base de datos.");
            }
            finally
            {
                con.Close();
            }
        }


        public void Informe_dia(DataGridView dgv_informes, DateTimePicker dtpinicio, DateTimePicker dtpfinal , ComboBox cmbinformes)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("informe_dia", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_fecha_inicio", dtpinicio.Text);
                cmd.Parameters.AddWithValue("@_fecha_final", dtpfinal.Text);
                cmd.Parameters.AddWithValue("@_Estado_Operacion", cmbinformes.Text);
                cmd.Parameters.AddWithValue("@_Id_Funcionario", usuario.Identificacion);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgv_informes.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
