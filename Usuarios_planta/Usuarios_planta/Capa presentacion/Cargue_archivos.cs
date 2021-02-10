using MySql.Data.MySqlClient;
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
using System.Runtime.InteropServices;   
using Excel = Microsoft.Office.Interop.Excel;


namespace Usuarios_planta.Capa_presentacion
{
    public partial class Cargue_archivos : Form
    {
        MySqlConnection con = new MySqlConnection("server=;Uid=;password=;database=dblibranza;port=3306;persistsecurityinfo=True;");

        public Cargue_archivos()
        {
            InitializeComponent();
        }
         
        private void BtnCargar_fallecidos_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Title = "Importar archivo (.txt, .txt)";
            d.Filter = "txt|*.txt";
            if (d.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    using (StreamReader reader = new StreamReader(d.FileName))
                    {   
                        string line;  //Variable para almacenarm
                        while ((line = reader.ReadLine()) != null)
                        {   //Mientras haya mas archivo, leemos mas

                            string[] fields = line.Split('|'); // Dividimos la linea por el caracter
                            con.Open();
                            MySqlCommand cmd = con.CreateCommand();
                            cmd.CommandText = "INSERT INTO FALLECIDOS_COLP (Afiliacion,Cedula,Nombre,Mes,Cuota,Nit,Entidad,Estado_cliente) value ";
                            cmd.CommandText += "(\"" + fields[0] + "\",\"" + fields[2] + "\",\"" + fields[3] + "\",\"" + fields[4] + "\",\"" + fields[8] + "\",\"" + fields[9] + "\"," +
                                                "\"" + fields[10] + "\", \"" + "Fallecido" + "\")";
                            cmd.ExecuteNonQuery();
                            con.Close();
                            
                        }
                        
                        reader.Close();                        
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    con.Close();
                }
                MessageBox.Show("Ok archivo cargado");
            }
        }

        private void BtnCargar_contabilizados_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Title = "Importar archivo (.xlsx, .xlsx)";
            d.Filter = "xlsx|*.xlsx";
            if (d.ShowDialog() == DialogResult.OK)
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO contabilizados_colp(Fecha_corte,Convenio,Nombre_Convenio,Consecutivo,Scoring,Nombre,Cedula_cliente,Fecha_desembolso,Importe," +
                    "Plazo,TasaE_A,TasaN_M,Valor_cuota,Estado,Marcacion_retanqueo) values (@Fecha_corte,@Convenio,@Nombre_Convenio,@Consecutivo,@Scoring,@Nombre,@Cedula_cliente,@Fecha_desembolso,@Importe," +
                    "@Plazo,@TasaE_A,@TasaN_M,@Valor_cuota,@Estado,@Marcacion_retanqueo)";
                
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(d.FileName);
                Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range range = xlWorksheet.UsedRange;
                int rows = range.Rows.Count;
                int cols = range.Columns.Count;
                for (int i = 2; i <=rows; i++)
                {
                    
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Fecha_corte", Convert.ToDateTime(range.Cells[i, 1].Value2).ToString("dd/MM/yyyy")); //convertir formato fecha dado que viene 2020-07-29 y se formatea a 29/07/2020
                    cmd.Parameters.AddWithValue("@Convenio", range.Cells[i, 2].Value2.ToString());
                    cmd.Parameters.AddWithValue("@Nombre_Convenio", range.Cells[i, 3].Value2);
                    cmd.Parameters.AddWithValue("@Consecutivo", range.Cells[i, 4].Value2.ToString());
                    cmd.Parameters.AddWithValue("@Scoring", range.Cells[i, 10].Value2.ToString());
                    cmd.Parameters.AddWithValue("@Nombre", range.Cells[i, 11].Value2.ToString());
                    cmd.Parameters.AddWithValue("@Cedula_cliente", range.Cells[i, 12].Value2.ToString());
                    cmd.Parameters.AddWithValue("@Fecha_desembolso", Convert.ToDateTime(range.Cells[i, 13].Value2).ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("@Importe", range.Cells[i, 14].Value2.ToString());
                    cmd.Parameters.AddWithValue("@Plazo", range.Cells[i, 15].Value2.ToString());
                    cmd.Parameters.AddWithValue("@TasaE_A", range.Cells[i, 16].Value2.ToString());
                    cmd.Parameters.AddWithValue("@TasaN_M", range.Cells[i, 17].Value2.ToString());
                    cmd.Parameters.AddWithValue("@Valor_cuota", range.Cells[i, 18].Value2.ToString());
                    cmd.Parameters.AddWithValue("@Estado", range.Cells[i, 38].Value2.ToString());
                    cmd.Parameters.AddWithValue("@Marcacion_retanqueo", range.Cells[i, 39].value2);
                    cmd.ExecuteNonQuery();
                }
                ///cerrar excel///
                Marshal.ReleaseComObject(range);
                Marshal.ReleaseComObject(xlWorksheet);
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                con.Close();
                MessageBox.Show("Ok cargue Archivo en la base de datos");
            }
        }
    }
}
