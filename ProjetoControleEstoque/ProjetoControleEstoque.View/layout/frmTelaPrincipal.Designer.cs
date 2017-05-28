namespace ProjetoControleEstoque.View.layout
{
    partial class frmTelaPrincipal
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
            this.btnCadastroCardapio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCadastroCardapio
            // 
            this.btnCadastroCardapio.Location = new System.Drawing.Point(82, 109);
            this.btnCadastroCardapio.Name = "btnCadastroCardapio";
            this.btnCadastroCardapio.Size = new System.Drawing.Size(75, 23);
            this.btnCadastroCardapio.TabIndex = 0;
            this.btnCadastroCardapio.Text = "button1";
            this.btnCadastroCardapio.UseVisualStyleBackColor = true;
            this.btnCadastroCardapio.Click += new System.EventHandler(this.btnCadastroCardapio_Click);
            // 
            // frmTelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnCadastroCardapio);
            this.Name = "frmTelaPrincipal";
            this.Text = "frmTelaPrincipal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCadastroCardapio;
    }
}