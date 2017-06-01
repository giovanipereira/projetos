namespace ProjetoControleEstoque.View.layout
{
    partial class frmTelaConsultaProduto
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
            this.dgvListaProdutos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFiltro = new System.Windows.Forms.ComboBox();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnBuscarTodos = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaProdutos
            // 
            this.dgvListaProdutos.AllowUserToAddRows = false;
            this.dgvListaProdutos.AllowUserToDeleteRows = false;
            this.dgvListaProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaProdutos.Location = new System.Drawing.Point(8, 93);
            this.dgvListaProdutos.Name = "dgvListaProdutos";
            this.dgvListaProdutos.ReadOnly = true;
            this.dgvListaProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaProdutos.Size = new System.Drawing.Size(739, 318);
            this.dgvListaProdutos.TabIndex = 0;
            this.dgvListaProdutos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListaProdutos_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filtro:";
            // 
            // cboFiltro
            // 
            this.cboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltro.FormattingEnabled = true;
            this.cboFiltro.Location = new System.Drawing.Point(15, 26);
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.Size = new System.Drawing.Size(121, 21);
            this.cboFiltro.TabIndex = 2;
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(164, 27);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(155, 20);
            this.txtBusca.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(462, 27);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(111, 29);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnBuscarTodos
            // 
            this.btnBuscarTodos.Location = new System.Drawing.Point(600, 27);
            this.btnBuscarTodos.Name = "btnBuscarTodos";
            this.btnBuscarTodos.Size = new System.Drawing.Size(131, 29);
            this.btnBuscarTodos.TabIndex = 5;
            this.btnBuscarTodos.Text = "Buscar Todos";
            this.btnBuscarTodos.UseVisualStyleBackColor = true;
            this.btnBuscarTodos.Click += new System.EventHandler(this.btnBuscarTodos_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(35, 441);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(129, 29);
            this.btnAdicionar.TabIndex = 6;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // frmTelaConsultaProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(759, 497);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnBuscarTodos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.cboFiltro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvListaProdutos);
            this.Name = "frmTelaConsultaProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTelaConsultaProduto";
            this.Load += new System.EventHandler(this.frmTelaConsultaProduto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFiltro;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnBuscarTodos;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.DataGridView dgvListaProdutos;
    }
}