namespace Usuarios_planta.Formularios
{
    partial class Informes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.dtpinicio = new System.Windows.Forms.DateTimePicker();
            this.lbinicial = new System.Windows.Forms.Label();
            this.dtpfinal = new System.Windows.Forms.DateTimePicker();
            this.lbfinal = new System.Windows.Forms.Label();
            this.dgv_informes = new System.Windows.Forms.DataGridView();
            this.cmbinformes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Crear_plano = new FontAwesome.Sharp.IconButton();
            this.Btn_busqueda = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_informes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_busqueda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Emoji", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(157)))));
            this.label3.Location = new System.Drawing.Point(425, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 43);
            this.label3.TabIndex = 46;
            this.label3.Text = "Informes";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(9, 89);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(142, 17);
            this.label36.TabIndex = 80;
            this.label36.Text = "Seleccionar Informe";
            // 
            // dtpinicio
            // 
            this.dtpinicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpinicio.CustomFormat = "dd/MM/yyyy";
            this.dtpinicio.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpinicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpinicio.Location = new System.Drawing.Point(16, 196);
            this.dtpinicio.Name = "dtpinicio";
            this.dtpinicio.Size = new System.Drawing.Size(111, 25);
            this.dtpinicio.TabIndex = 84;
            // 
            // lbinicial
            // 
            this.lbinicial.AutoSize = true;
            this.lbinicial.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbinicial.Location = new System.Drawing.Point(13, 174);
            this.lbinicial.Name = "lbinicial";
            this.lbinicial.Size = new System.Drawing.Size(90, 17);
            this.lbinicial.TabIndex = 83;
            this.lbinicial.Text = "Fecha Inicial";
            // 
            // dtpfinal
            // 
            this.dtpfinal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpfinal.CustomFormat = "dd/MM/yyyy";
            this.dtpfinal.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfinal.Location = new System.Drawing.Point(155, 196);
            this.dtpfinal.Name = "dtpfinal";
            this.dtpfinal.Size = new System.Drawing.Size(111, 25);
            this.dtpfinal.TabIndex = 86;
            // 
            // lbfinal
            // 
            this.lbfinal.AutoSize = true;
            this.lbfinal.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbfinal.Location = new System.Drawing.Point(152, 174);
            this.lbfinal.Name = "lbfinal";
            this.lbfinal.Size = new System.Drawing.Size(82, 17);
            this.lbfinal.TabIndex = 85;
            this.lbfinal.Text = "Fecha Final";
            // 
            // dgv_informes
            // 
            this.dgv_informes.AllowUserToAddRows = false;
            this.dgv_informes.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_informes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_informes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_informes.Location = new System.Drawing.Point(411, 128);
            this.dgv_informes.Name = "dgv_informes";
            this.dgv_informes.Size = new System.Drawing.Size(691, 484);
            this.dgv_informes.TabIndex = 87;
            // 
            // cmbinformes
            // 
            this.cmbinformes.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbinformes.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbinformes.FormattingEnabled = true;
            this.cmbinformes.Items.AddRange(new object[] {
            "Informe Jueves Cpk Libranza"});
            this.cmbinformes.Location = new System.Drawing.Point(16, 129);
            this.cmbinformes.Name = "cmbinformes";
            this.cmbinformes.Size = new System.Drawing.Size(228, 25);
            this.cmbinformes.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(157)))));
            this.label1.Location = new System.Drawing.Point(724, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 32);
            this.label1.TabIndex = 89;
            this.label1.Text = "Datos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_Crear_plano
            // 
            this.Btn_Crear_plano.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.Btn_Crear_plano.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Crear_plano.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Crear_plano.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.Btn_Crear_plano.Font = new System.Drawing.Font("SF Pro Display", 9.75F);
            this.Btn_Crear_plano.ForeColor = System.Drawing.Color.White;
            this.Btn_Crear_plano.IconChar = FontAwesome.Sharp.IconChar.FileAlt;
            this.Btn_Crear_plano.IconColor = System.Drawing.Color.Gainsboro;
            this.Btn_Crear_plano.IconSize = 18;
            this.Btn_Crear_plano.Location = new System.Drawing.Point(991, 618);
            this.Btn_Crear_plano.Name = "Btn_Crear_plano";
            this.Btn_Crear_plano.Rotation = 0D;
            this.Btn_Crear_plano.Size = new System.Drawing.Size(111, 30);
            this.Btn_Crear_plano.TabIndex = 90;
            this.Btn_Crear_plano.Text = "Descargar";
            this.Btn_Crear_plano.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Crear_plano.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Crear_plano.UseVisualStyleBackColor = false;
            this.Btn_Crear_plano.Click += new System.EventHandler(this.Btn_Crear_plano_Click);
            // 
            // Btn_busqueda
            // 
            this.Btn_busqueda.BackColor = System.Drawing.Color.White;
            this.Btn_busqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_busqueda.Image = global::Usuarios_planta.Properties.Resources.search_26px;
            this.Btn_busqueda.Location = new System.Drawing.Point(294, 195);
            this.Btn_busqueda.Name = "Btn_busqueda";
            this.Btn_busqueda.Size = new System.Drawing.Size(24, 26);
            this.Btn_busqueda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Btn_busqueda.TabIndex = 82;
            this.Btn_busqueda.TabStop = false;
            this.Btn_busqueda.Click += new System.EventHandler(this.Btn_busqueda_Click);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::Usuarios_planta.Properties.Resources.índice1;
            this.pictureBox8.Location = new System.Drawing.Point(6, 2);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(120, 77);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 42;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Usuarios_planta.Properties.Resources.colpensiones;
            this.pictureBox6.Location = new System.Drawing.Point(966, 2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(136, 56);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 41;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(187)))), ((int)(((byte)(33)))));
            this.pictureBox3.Location = new System.Drawing.Point(1044, 793);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(269, 18);
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(101)))), ((int)(((byte)(124)))));
            this.pictureBox2.Location = new System.Drawing.Point(536, 793);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(512, 18);
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 793);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(540, 18);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // Informes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1149, 689);
            this.Controls.Add(this.Btn_Crear_plano);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbinformes);
            this.Controls.Add(this.dgv_informes);
            this.Controls.Add(this.dtpfinal);
            this.Controls.Add(this.lbfinal);
            this.Controls.Add(this.dtpinicio);
            this.Controls.Add(this.lbinicial);
            this.Controls.Add(this.Btn_busqueda);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Informes";
            this.Text = "Informes";            
            ((System.ComponentModel.ISupportInitialize)(this.dgv_informes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_busqueda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.PictureBox Btn_busqueda;
        private System.Windows.Forms.DateTimePicker dtpinicio;
        private System.Windows.Forms.Label lbinicial;
        private System.Windows.Forms.DateTimePicker dtpfinal;
        private System.Windows.Forms.Label lbfinal;
        private System.Windows.Forms.DataGridView dgv_informes;
        private System.Windows.Forms.ComboBox cmbinformes;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton Btn_Crear_plano;
    }
}