namespace VistaForm
{
    partial class FormInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonIngresar = new System.Windows.Forms.Button();
            this.buttonComprar = new System.Windows.Forms.Button();
            this.labelTiendaOficial = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonIngresar
            // 
            this.buttonIngresar.BackColor = System.Drawing.Color.Black;
            this.buttonIngresar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonIngresar.FlatAppearance.BorderSize = 2;
            this.buttonIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIngresar.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIngresar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonIngresar.Location = new System.Drawing.Point(47, 428);
            this.buttonIngresar.Name = "buttonIngresar";
            this.buttonIngresar.Size = new System.Drawing.Size(121, 47);
            this.buttonIngresar.TabIndex = 1;
            this.buttonIngresar.Text = "INGRESAR";
            this.buttonIngresar.UseVisualStyleBackColor = false;
            this.buttonIngresar.Click += new System.EventHandler(this.buttonIngresar_Click);
            // 
            // buttonComprar
            // 
            this.buttonComprar.BackColor = System.Drawing.Color.Black;
            this.buttonComprar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonComprar.FlatAppearance.BorderSize = 2;
            this.buttonComprar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonComprar.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonComprar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonComprar.Location = new System.Drawing.Point(212, 428);
            this.buttonComprar.Name = "buttonComprar";
            this.buttonComprar.Size = new System.Drawing.Size(121, 47);
            this.buttonComprar.TabIndex = 2;
            this.buttonComprar.Text = "COMPRAR";
            this.buttonComprar.UseVisualStyleBackColor = false;
            this.buttonComprar.Click += new System.EventHandler(this.buttonComprar_Click);
            // 
            // labelTiendaOficial
            // 
            this.labelTiendaOficial.AutoSize = true;
            this.labelTiendaOficial.BackColor = System.Drawing.Color.Transparent;
            this.labelTiendaOficial.Font = new System.Drawing.Font("Mistral", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTiendaOficial.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelTiendaOficial.Location = new System.Drawing.Point(239, 372);
            this.labelTiendaOficial.Name = "labelTiendaOficial";
            this.labelTiendaOficial.Size = new System.Drawing.Size(112, 27);
            this.labelTiendaOficial.TabIndex = 3;
            this.labelTiendaOficial.Text = "Tienda Oficial";
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.BackgroundImage = global::VistaForm.Properties.Resources.todorojo;
            this.ClientSize = new System.Drawing.Size(389, 505);
            this.Controls.Add(this.labelTiendaOficial);
            this.Controls.Add(this.buttonComprar);
            this.Controls.Add(this.buttonIngresar);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(405, 544);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(405, 544);
            this.Name = "FormInicio";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "🔴 - TODO ROJO - 🔴";
            this.Load += new System.EventHandler(this.FormInicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonIngresar;
        private System.Windows.Forms.Button buttonComprar;
        private System.Windows.Forms.Label labelTiendaOficial;
    }
}

