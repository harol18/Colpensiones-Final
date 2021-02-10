using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Usuarios_planta.Formularios;
using Usuarios_planta.Capa_presentacion;
using FontAwesome.Sharp; // libreria para utilizar los iconbutton y los iconos

namespace Usuarios_planta
{
    public partial class VoBo : Form
    {
        
        private IconButton currentBtn;
        private Panel leftBorderBtn;

        public VoBo()
        {           
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelSideMenu.Controls.Add(leftBorderBtn);
            hideSubMenu();

            this.Text = string.Empty;
            this.ControlBox = false; //quitar caja de control
            this.DoubleBuffered = true; // activar el buffer para reducri el parpadeo en los graficos del formulario
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea; // establecer limites para dejar el formulario como el area del escritorio
        }

        bool move = false;

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(251, 187, 33);
            public static Color color2 = Color.FromArgb(52, 179, 29);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(53, 41, 237);
            public static Color color5 = Color.FromArgb(56, 171, 179);
            public static Color color6 = Color.FromArgb(255, 69, 0);
            public static Color color7 = Color.FromArgb(75, 0, 130);

        }
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = Color.FromArgb(215, 219, 222);
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(0, 66, 84);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        public void hideSubMenu()
        {
            panelCheques.Visible = false;
            panelinformes.Visible = false;
            panel_planos.Visible = false;
            
        }

        public void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que deseas salir?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }

        private void BtnOrden_MouseHover(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);          
        }

         private void BtnGiros_MouseHover_1(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);            
        }

        private void BtnChequesCF_MouseHover(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);            
        }

        private void BtnSalir_MouseHover(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
        }

        private void AbrirFormHijo(object formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formhijo as Form;
            fh.TopLevel = false; // decimos que es un formulario secundario
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void BtnInformes_Click(object sender, EventArgs e)
        {
            showSubMenu(panelinformes);
        }

        private void BtnInformes_MouseHover(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);            
        }

        private void BtnColpensiones_Click(object sender, EventArgs e)
        {
            showSubMenu(panelCheques);
        }

        private void BtnColpensiones_MouseHover(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);            
        }

        private void Btncklb_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form formulario = new FormGiros();
            formulario.Show();
        }

        private void Btndia_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form formulario = new Formdia();
            formulario.Show();
        }

        private void BtnInformes_colp_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Informes());
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            panelSideMenu.Visible = false;
        }

        private void BtnCargue_archivos_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Cargue_archivos());
        }

        private void BtnCargue_archivos_MouseHover(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
        }

        private void BtnCrear_planos_Click(object sender, EventArgs e)
        {            
            showSubMenu(panel_planos);
        }

        private void BtnCrear_planos_MouseHover(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
        }

        private void Btnplanos_ckl_MouseHover(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
        }

        private void Btnplanos_dia_MouseHover(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color7);
        }

        private void Btnplanos_ckl_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Planos());
        }

        private void panelTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                this.Location = Cursor.Position;
            }
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
        }

        private void panelTitulo_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Btnplanos_dia_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Planos_dia());
        }

        private void BtnInformes_dia_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Informes_dia());
        }
    }
}
