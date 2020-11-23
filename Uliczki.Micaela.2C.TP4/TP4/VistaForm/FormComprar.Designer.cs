namespace VistaForm
{
    partial class FormComprar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormComprar));
            this.pictureBoxImagenProducto = new System.Windows.Forms.PictureBox();
            this.buttonComprar = new System.Windows.Forms.Button();
            this.listBoxProductos = new System.Windows.Forms.ListBox();
            this.richTextBoxDetalle = new System.Windows.Forms.RichTextBox();
            this.pictureBoxEscudo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagenProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEscudo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxImagenProducto
            // 
            this.pictureBoxImagenProducto.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxImagenProducto.InitialImage = null;
            this.pictureBoxImagenProducto.Location = new System.Drawing.Point(250, 41);
            this.pictureBoxImagenProducto.Name = "pictureBoxImagenProducto";
            this.pictureBoxImagenProducto.Size = new System.Drawing.Size(251, 308);
            this.pictureBoxImagenProducto.TabIndex = 8;
            this.pictureBoxImagenProducto.TabStop = false;
            // 
            // buttonComprar
            // 
            this.buttonComprar.Location = new System.Drawing.Point(42, 353);
            this.buttonComprar.Name = "buttonComprar";
            this.buttonComprar.Size = new System.Drawing.Size(159, 45);
            this.buttonComprar.TabIndex = 13;
            this.buttonComprar.Text = "COMPRAR";
            this.buttonComprar.UseVisualStyleBackColor = true;
            this.buttonComprar.Click += new System.EventHandler(this.buttonComprar_Click);
            // 
            // listBoxProductos
            // 
            this.listBoxProductos.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxProductos.FormattingEnabled = true;
            this.listBoxProductos.ItemHeight = 20;
            this.listBoxProductos.Location = new System.Drawing.Point(28, 41);
            this.listBoxProductos.Name = "listBoxProductos";
            this.listBoxProductos.Size = new System.Drawing.Size(187, 284);
            this.listBoxProductos.TabIndex = 15;
            this.listBoxProductos.SelectedIndexChanged += new System.EventHandler(this.listBoxProductos_SelectedIndexChanged);
            // 
            // richTextBoxDetalle
            // 
            this.richTextBoxDetalle.BackColor = System.Drawing.Color.Black;
            this.richTextBoxDetalle.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxDetalle.ForeColor = System.Drawing.SystemColors.Menu;
            this.richTextBoxDetalle.Location = new System.Drawing.Point(520, 210);
            this.richTextBoxDetalle.Name = "richTextBoxDetalle";
            this.richTextBoxDetalle.Size = new System.Drawing.Size(189, 188);
            this.richTextBoxDetalle.TabIndex = 16;
            this.richTextBoxDetalle.Text = "";
            // 
            // pictureBoxEscudo
            // 
            this.pictureBoxEscudo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEscudo.Location = new System.Drawing.Point(562, 41);
            this.pictureBoxEscudo.Name = "pictureBoxEscudo";
            this.pictureBoxEscudo.Size = new System.Drawing.Size(117, 125);
            this.pictureBoxEscudo.TabIndex = 17;
            this.pictureBoxEscudo.TabStop = false;
            // 
            // FormComprar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(721, 423);
            this.Controls.Add(this.pictureBoxEscudo);
            this.Controls.Add(this.richTextBoxDetalle);
            this.Controls.Add(this.listBoxProductos);
            this.Controls.Add(this.buttonComprar);
            this.Controls.Add(this.pictureBoxImagenProducto);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(737, 462);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(737, 462);
            this.Name = "FormComprar";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tienda TODO ROJO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormComprar_FormClosing);
            this.Load += new System.EventHandler(this.FormComprar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagenProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEscudo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxImagenProducto;
        private System.Windows.Forms.Button buttonComprar;
        private System.Windows.Forms.ListBox listBoxProductos;
        private System.Windows.Forms.RichTextBox richTextBoxDetalle;
        private System.Windows.Forms.PictureBox pictureBoxEscudo;
    }
}