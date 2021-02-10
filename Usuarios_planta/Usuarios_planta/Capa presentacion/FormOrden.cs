using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Drawing.Printing;


namespace Usuarios_planta.Formularios
{
    public partial class FormOrden : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Uid=root;password=Indr42020$;database=dblibranza;port=3306;persistsecurityinfo=True;");
        Comandos cmds = new Comandos();
        MySqlDataReader dr;

        public FormOrden()
        {
            InitializeComponent();

        }

        private int v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, vSuma =0 , vResta=0;

        private void TxtValor8_TextChanged(object sender, EventArgs e)
        {
           
            if (Convert.ToInt32(TxtSaldo.Text) <= 2000000)
                BtnSimulador.Visible = true;

            else
                BtnSimulador.Visible = false;
        }

        private void TxtValor_aprobado_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(TxtValor_aprobado.Text, out v10))
                Restar();
            else
                TxtValor_aprobado.Text = v10.ToString();

            if (Convert.ToInt32(TxtSaldo.Text) <= 2000000)
                BtnSimulador.Visible = true;

            else            
                BtnSimulador.Visible = false;           
        }

        private void TxtTotal_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(TxtTotal.Text, out v9))
                Restar();
            else
                TxtTotal.Text = v9.ToString();
        }
        private void TxtValor2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;// bloquea el ingreso de letras y el 8 corresponde a la barra espaciador
        }

        private void TxtValor3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;// bloquea el ingreso de letras y el 8 corresponde a la barra espaciador
        }

        private void TxtValor4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;// bloquea el ingreso de letras y el 8 corresponde a la barra espaciador
        }

        private void TxtValor5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;// bloquea el ingreso de letras y el 8 corresponde a la barra espaciador
        }

        private void TxtValor6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;// bloquea el ingreso de letras y el 8 corresponde a la barra espaciador
        }

        private void TxtValor7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;// bloquea el ingreso de letras y el 8 corresponde a la barra espaciador
        }

        private void TxtValor8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;// bloquea el ingreso de letras y el 8 corresponde a la barra espaciador
        }

        private void TxtRadicado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;// bloquea el ingreso de letras y el 8 corresponde a la barra espaciador
        }

        private void TxtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;// bloquea el ingreso de letras y el 8 corresponde a la barra espaciador
        }

        private void TxtScoring_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;// bloquea el ingreso de letras y el 8 corresponde a la barra espaciador
        }

        private void TxtValor_aprobado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;// bloquea el ingreso de letras y el 8 corresponde a la barra espaciador
        }

        private void TxtPlazo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;// bloquea el ingreso de letras y el 8 corresponde a la barra espaciador
        }

        private void TxtCod_oficina_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;// bloquea el ingreso de letras y el 8 corresponde a la barra espaciador
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void TxtRauto_TextChanged(object sender, EventArgs e)
        {

        }

        //private void BtnBuscar_Click(object sender, EventArgs e)
        //{
        //    cmds.buscar_orden(TxtRadicado, TxtCedula, TxtNombre, TxtEstatura, TxtPeso, TxtCuenta, TxtScoring, TxtValor_aprobado,
        //    TxtPlazo, cmbDestino, TxtRauto, TxtConvenio, TxtCod_oficina, TxtNom_oficina, TxtCiudad, TxtId_gestor, TxtNom_gestor,
        //    cmbCoordinador, cmbDactiloscopia, cmbG_telefonica, Txtobligacion1, TxtNom_entidad1, TxtNit1, TxtValor1,
        //    Txtobligacion2, TxtNom_entidad2, TxtNit2, TxtValor2, Txtobligacion3, TxtNom_entidad3, TxtNit3, TxtValor3,
        //    Txtobligacion4, TxtNom_entidad4, TxtNit4, TxtValor4, Txtobligacion5, TxtNom_entidad5, TxtNit5, TxtValor5,
        //    Txtobligacion6, TxtNom_entidad6, TxtNit6, TxtValor6, Txtobligacion7, TxtNom_entidad7, TxtNit7, TxtValor7,
        //    Txtobligacion8, TxtNom_entidad8, TxtNit8, TxtValor8, TxtTotal, TxtSaldo, cmbestado, TxtIDfuncionario, TxtNomFuncionario);

        //    if (TxtCedula.Text == "")
        //    {
        //        BtnActualizar.Enabled = false;
        //        BtnGuardar.Enabled = true;
        //    }        
        //    else
        //    {
        //        BtnActualizar.Enabled = true;
        //        BtnGuardar.Enabled = false;
        //    }
                
        //}

        private void TxtCod_oficina_TextChanged(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM tf_oficinas WHERE codigo_oficina = @codigo ", con);
            comando.Parameters.AddWithValue("@codigo", TxtCod_oficina.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                TxtNom_oficina.Text = registro["sucursal"].ToString();
                TxtCiudad.Text = registro["ciudad"].ToString();
                
            }
            con.Close();
        }

        private void TxtNom_entidad1_TextChanged(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM tf_entidades WHERE nombre_entidad = @nombre_entidad ", con);
            comando.Parameters.AddWithValue("@nombre_entidad", TxtNom_entidad1.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                TxtNit1.Text = registro["nit_entidad"].ToString();
            }
            con.Close();
        }

        private void cmbCoordinador_MouseClick(object sender, MouseEventArgs e)
        {
            string query = "SELECT id_tfcoordinador, nombre_coordinador from tf_coordinador";
            MySqlCommand comando = new MySqlCommand(query, con);
            MySqlDataAdapter da1 = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            cmbCoordinador.ValueMember = "id";
            cmbCoordinador.DisplayMember = "nombre_coordinador";
            cmbCoordinador.DataSource = dt;
        }

        private void TxtId_gestor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;// bloquea el ingreso de letras y el 8 corresponde a la barra espaciador
        }

        private void TxtValor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;// bloquea el ingreso de letras y el 8 corresponde a la barra espaciador
        }

        private void TxtIDfuncionario_TextChanged(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM tf_usuarios WHERE Identificacion = @Identificacion ", con);
            comando.Parameters.AddWithValue("@Identificacion", TxtIDfuncionario.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                TxtNomFuncionario.Text = registro["Nombre"].ToString();
            }
            con.Close();
        }

        private void cmbCoordinador_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar limpiar = new limpiar(); //llamo la clase para limpiar todos los textbox que se encuentran en el groupbox1
            limpiar.BorrarCampos(groupBox1); 
            limpiar.BorrarCampos(groupBox2); 
            limpiar.BorrarCampos(groupBox3);
            limpiar.BorrarCampos(groupBox4);
            limpiar.BorrarCampos(groupBox6);
            cmbDestino.Text = "";
            cmbDactiloscopia.Text = "";
            cmbG_telefonica.Text = "";
            cmbestado.Text = "";
            TxtValor1.Text = "";
            TxtValor2.Text = "";
            TxtValor3.Text = "";
            TxtValor4.Text = "";
            TxtValor5.Text = "";
            TxtValor6.Text = "";
            TxtValor7.Text = "";
            TxtValor8.Text = "";
        }
     
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TxtValor7_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(TxtValor7.Text, out v7))
                Sumar();
            else
                TxtValor7.Text = v7.ToString();

            if (Convert.ToInt32(TxtSaldo.Text) <= 2000000)
                BtnSimulador.Visible = true;

            else
                BtnSimulador.Visible = false;
        }

        private void TxtValor6_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(TxtValor6.Text, out v6))
                Sumar();
            else
                TxtValor6.Text = v6.ToString();

            if (Convert.ToInt32(TxtSaldo.Text) <= 2000000)
                BtnSimulador.Visible = true;

            else
                BtnSimulador.Visible = false;
        }

        private void TxtValor5_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(TxtValor5.Text, out v5))
                Sumar();
            else
                TxtValor5.Text = v5.ToString();

            if (Convert.ToInt32(TxtSaldo.Text) <= 2000000)
                BtnSimulador.Visible = true;

            else
                BtnSimulador.Visible = false;
        }

        private void TxtValor4_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(TxtValor4.Text, out v4))
                Sumar();
            else
                TxtValor4.Text = v4.ToString();

            if (Convert.ToInt32(TxtSaldo.Text) <= 2000000)
                BtnSimulador.Visible = true;

            else
                BtnSimulador.Visible = false;
        }

        private void TxtValor3_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(TxtValor3.Text, out v3))
                Sumar();
            else
                TxtValor3.Text = v3.ToString();

            if (Convert.ToInt32(TxtSaldo.Text) <= 2000000)
                BtnSimulador.Visible = true;

            else
                BtnSimulador.Visible = false;
        }

        private void TxtValor2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(TxtValor2.Text, out v2))
                Sumar();
            else
                TxtValor2.Text = v2.ToString();

            if (Convert.ToInt32(TxtSaldo.Text) <= 2000000)
                BtnSimulador.Visible = true;

            else
                BtnSimulador.Visible = false;
        }

        private void TxtValor1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(TxtValor1.Text, out v1))
                Sumar();
            else
               
                TxtValor1.Text = v1.ToString();

            if (Convert.ToInt32(TxtSaldo.Text) <= 2000000)
                BtnSimulador.Visible = true;

            else
                BtnSimulador.Visible = false;

        }

        private void Sumar()
        {
            vSuma = v1 + v2 + v3 + v4 + v5 + v6 + v7 + v8 ;
            TxtTotal.Text = vSuma.ToString();
        }

        private void Restar()
        {
            vResta = v10 - v9;
            TxtSaldo.Text = vResta.ToString();

            if (Convert.ToInt32(TxtSaldo.Text) <= 2000000)
                BtnSimulador.Visible = true;

            else
                BtnSimulador.Visible = false;
        }
    }
}
                        