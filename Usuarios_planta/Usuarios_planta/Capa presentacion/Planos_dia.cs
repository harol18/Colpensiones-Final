using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Usuarios_planta.Capa_presentacion
{
    public partial class Planos_dia : Form
    {
        MySqlConnection con = new MySqlConnection("server=82.2.121.99;Uid=userapp;password=userapp;database=dblibranza;port=3306;persistsecurityinfo=True;");


        dia_dia cmds_dia = new dia_dia();

        public Planos_dia()
        {
            InitializeComponent();
        }

        private void ch_plano_alta_CheckedChanged(object sender, EventArgs e)
        {
            ch_plano_baja.Checked = false;
        }

        private void ch_plano_baja_CheckedChanged(object sender, EventArgs e)
        {
            ch_plano_alta.Checked = false;
        }

        DateTime fecha = DateTime.Now;

        private void Btn_actualizar_cargue_Click(object sender, EventArgs e)
        {
            if (cmb_Gestion2.Text == "Negados")
            {
                cmds_dia.actualizar_cargueckl(dgv_altas, Txtplano_alta);
                cmds_dia.planos_cargue(dgv_altas, Txtplano_alta);                
            }
        }

        private void Planos_dia_Load(object sender, EventArgs e)
        {
            lblfecha_actual.Text = fecha.ToString("dd/MM/yyyy");
            String sCadena = fecha.ToString("dd/MM/yyyy");
            String año = sCadena.Substring(6, 4);
            String mes = sCadena.Substring(3, 2);
            String dia = sCadena.Substring(0, 2);
            Txtplano_alta.Text = "PR_00860003020_" + año + mes + dia + TxtCod_plano.Text;
            Txtplano_baja.Text = "RP_00860003020_" + año + mes + dia + TxtCod_plano.Text;
        }

        private void TxtCod_plano_TextChanged(object sender, EventArgs e)
        {
            String sCadena = fecha.ToString("dd/MM/yyyy");
            String año = sCadena.Substring(6, 4);
            String mes = sCadena.Substring(3, 2);
            String dia = sCadena.Substring(0, 2);
            Txtplano_alta.Text = "PR_00860003020_" + año + mes + dia + TxtCod_plano.Text;
            Txtplano_baja.Text = "RP_00860003020_" + año + mes + dia + TxtCod_plano.Text;
        }

        private void cmb_Gestion2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dgv_altas.DataSource = null;
            dgv_bajas.DataSource = null;
        }

        private void btn_Validar_Click(object sender, EventArgs e)
        {
            if (cmb_Gestion2.Text == "Pendiente Cargue")
            {
                cmds_dia.pendiente_cargue_dia(dtp_cargue, dgv_altas,Txtfuncionario);
                cmds_dia.pendiente_cargue_dia_bajas(dtp_cargue, dgv_bajas,Txtfuncionario);
                lbtotal.Text = dgv_altas.Rows.Count.ToString();
            }
        }

        private void Btn_actualizar_cargue_Click_1(object sender, EventArgs e)
        {
            cmds_dia.actualizar_cargueckl(dgv_altas, Txtplano_alta);
            cmds_dia.planos_cargue(dgv_altas, Txtplano_alta);
            dgv_altas.DataSource = null;
            dgv_bajas.DataSource = null;
        }

        private void Btn_Crear_plano_Click(object sender, EventArgs e)
        {
            if (TxtCod_plano.Text == "")
            {
                MessageBox.Show("Debe digitar el codigo del plano","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                if (ch_plano_alta.Checked)
                {
                    //Esta línea de código crea un archivo de texto para la exportación de datos.
                    //StreamWriter file = new StreamWriter(@"C:\\Users\\BBVA\\Desktop\\Colpensiones\\" + Txtplano_alta.Text + ".txt");
                    StreamWriter file = new StreamWriter(@"D:\\Colpensiones\\" + Txtplano_alta.Text + ".txt");
                    try
                    {
                        string sLine = "";
                        //Este bucle for recorre cada fila de la tabla
                        for (int r = 0; r <= dgv_altas.Rows.Count - 1; r++)
                        {
                            //Este bucle for recorre cada columna y el número de fila
                            //se pasa desde el bucle for arriba.
                            for (int c = 0; c <= dgv_altas.Columns.Count - 1; c++)
                            {
                                sLine = sLine + dgv_altas.Rows[r].Cells[c].Value;
                                if (c != dgv_altas.Columns.Count - 1)
                                {
                                    // Una coma se agrega como delimitador de texto para
                                    //para separar cada campo en el archivo de texto.
                                    //Puede elegir otro carácter como delimitador, para este caso no se pone delimitador dado
                                    //que el plano va toda la informacion pegada sin espacios ni caracteres.
                                    sLine = sLine + "";
                                }
                            }
                            //El texto exportado se escribe en el archivo de texto, una línea a la vez.
                            file.WriteLine(sLine);
                            sLine = "";
                        }
                        file.Close();
                        MessageBox.Show("Ok archivo plano creado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        file.Close();
                    }
                }
                else if (ch_plano_baja.Checked)
                {
                    //Esta línea de código crea un archivo de texto para la exportación de datos.
                    //StreamWriter file = new StreamWriter(@"C:\\Users\\BBVA\\Desktop\\Colpensiones\\" + Txtplano_baja.Text + ".txt");
                    StreamWriter file = new StreamWriter(@"D:\\Colpensiones\\" + Txtplano_baja.Text + ".txt");
                    try
                    {
                        string sLine = "";
                        //Este bucle for recorre cada fila de la tabla
                        for (int r = 0; r <= dgv_bajas.Rows.Count - 1; r++)
                        {
                            //Este bucle for recorre cada columna y el número de fila
                            //se pasa desde el bucle for arriba.
                            for (int c = 0; c <= dgv_bajas.Columns.Count - 1; c++)
                            {
                                sLine = sLine + dgv_bajas.Rows[r].Cells[c].Value;
                                if (c != dgv_bajas.Columns.Count - 1)
                                {
                                    // Una coma se agrega como delimitador de texto para
                                    //para separar cada campo en el archivo de texto.
                                    //Puede elegir otro carácter como delimitador.
                                    sLine = sLine + "";
                                }
                            }
                            //El texto exportado se escribe en el archivo de texto, una línea a la vez.
                            file.WriteLine(sLine);
                            sLine = "";
                        }

                        file.Close();
                        MessageBox.Show("Ok archivo plano creado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        file.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar que plano va a crear","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        }
    }
}
