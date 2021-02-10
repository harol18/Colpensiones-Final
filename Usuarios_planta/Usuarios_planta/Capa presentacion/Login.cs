using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;



namespace Usuarios_planta.Capa_presentacion
{
    public partial class Login : Form
    {
        MySqlConnection con = new MySqlConnection("server=82.2.121.99;Uid=userapp;password=userapp;database=dblibranza;port=3306;persistsecurityinfo=True;");


        public Login()
        {
            InitializeComponent();
        }

        public void loguear(string user, string pass)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Select Identificacion,nombre, CE from tf_usuarios where Identificacion=@Identificacion and Contraseña=@Contraseña", con);
                cmd.Parameters.AddWithValue("@Identificacion", user);
                cmd.Parameters.AddWithValue("@Contraseña", pass);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    MessageBox.Show("Bienvenido !! " + dt.Rows[0][1].ToString());
                    usuario.Identificacion = dt.Rows[0][0].ToString();
                    usuario.Nombre = dt.Rows[0][1].ToString();
                    usuario.CE= dt.Rows[0][2].ToString();
                    Form formulario = new VoBo();
                    formulario.Show();
                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña incorrectos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void Txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;// bloquea el ingreso de letras y el 8 corresponde a la barra espaciador
        }

        private void Salir(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Ingresar(object sender, EventArgs e)
        {
            loguear(Txtusuario.Text, Txtcontraseña.Text);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            //Como ocultar el contenido de un textbox como si fuera una contraseña
            if (Txtcontraseña.UseSystemPasswordChar == false)
                Txtcontraseña.UseSystemPasswordChar = true;
            else
                Txtcontraseña.UseSystemPasswordChar = false;
        }
    }
}
