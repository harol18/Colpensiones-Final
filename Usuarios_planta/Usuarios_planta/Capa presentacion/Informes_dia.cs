using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Usuarios_planta.Capa_presentacion
{
    public partial class Informes_dia : Form
    {

        dia_dia cmds_dia = new dia_dia();

        public Informes_dia()
        {
            InitializeComponent();
        }

        private void Btn_busqueda_Click(object sender, EventArgs e)
        {
            cmds_dia.Informe_dia(dgv_informes, dtpinicio, dtpfinal, cmbinformes);
        }
    }
}
