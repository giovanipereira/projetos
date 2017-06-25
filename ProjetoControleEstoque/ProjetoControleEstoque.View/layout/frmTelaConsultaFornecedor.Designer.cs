namespace ProjetoControleEstoque.View.layout
{
    partial class frmTelaConsultaFornecedor
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.cboConsultarPor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvConsultaFornecedores = new System.Windows.Forms.DataGridView();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBuscarTodos = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaFornecedores)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Consulta Fornecedor";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnConsultar);
            this.groupBox.Controls.Add(this.txtValor);
            this.groupBox.Controls.Add(this.cboConsultarPor);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox.Location = new System.Drawing.Point(12, 36);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(798, 94);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Filtragem";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = global::ProjetoControleEstoque.View.Properties.Resources.search;
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.Location = new System.Drawing.Point(672, 32);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(104, 31);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtValor
            // 
            this.txtValor.Enabled = false;
            this.txtValor.Location = new System.Drawing.Point(312, 41);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(215, 22);
            this.txtValor.TabIndex = 2;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // cboConsultarPor
            // 
            this.cboConsultarPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConsultarPor.FormattingEnabled = true;
            this.cboConsultarPor.Items.AddRange(new object[] {
            "Código",
            "Nome",
            "CNPJ"});
            this.cboConsultarPor.Location = new System.Drawing.Point(103, 39);
            this.cboConsultarPor.Name = "cboConsultarPor";
            this.cboConsultarPor.Size = new System.Drawing.Size(158, 24);
            this.cboConsultarPor.TabIndex = 1;
            this.cboConsultarPor.TextChanged += new System.EventHandler(this.cboConsultarPor_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Consultar por:";
            // 
            // dgvConsultaFornecedores
            // 
            this.dgvConsultaFornecedores.AllowUserToAddRows = false;
            this.dgvConsultaFornecedores.AllowUserToDeleteRows = false;
            this.dgvConsultaFornecedores.AllowUserToResizeColumns = false;
            this.dgvConsultaFornecedores.AllowUserToResizeRows = false;
            this.dgvConsultaFornecedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultaFornecedores.Location = new System.Drawing.Point(12, 136);
            this.dgvConsultaFornecedores.MultiSelect = false;
            this.dgvConsultaFornecedores.Name = "dgvConsultaFornecedores";
            this.dgvConsultaFornecedores.ReadOnly = true;
            this.dgvConsultaFornecedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultaFornecedores.Size = new System.Drawing.Size(798, 343);
            this.dgvConsultaFornecedores.TabIndex = 5;
            this.dgvConsultaFornecedores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultaFornecedores_CellDoubleClick);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = global::ProjetoControleEstoque.View.Properties.Resources.Remover;
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExcluir.Location = new System.Drawing.Point(422, 19);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(104, 57);
            this.btnExcluir.TabIndex = 8;
            this.btnExcluir.Text = "Excluír";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Image = global::ProjetoControleEstoque.View.Properties.Resources.Alterar;
            this.btnAtualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAtualizar.Location = new System.Drawing.Point(276, 19);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(104, 57);
            this.btnAtualizar.TabIndex = 7;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btnCancelar);
            this.panel.Controls.Add(this.btnExcluir);
            this.panel.Controls.Add(this.btnBuscarTodos);
            this.panel.Controls.Add(this.btnAtualizar);
            this.panel.Location = new System.Drawing.Point(16, 485);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(794, 86);
            this.panel.TabIndex = 9;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::ProjetoControleEstoque.View.Properties.Resources.No;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(568, 19);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 57);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBuscarTodos
            // 
            this.btnBuscarTodos.Image = global::ProjetoControleEstoque.View.Properties.Resources.search;
            this.btnBuscarTodos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscarTodos.Location = new System.Drawing.Point(130, 19);
            this.btnBuscarTodos.Name = "btnBuscarTodos";
            this.btnBuscarTodos.Size = new System.Drawing.Size(104, 57);
            this.btnBuscarTodos.TabIndex = 5;
            this.btnBuscarTodos.Text = "Buscar Todos";
            this.btnBuscarTodos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarTodos.UseVisualStyleBackColor = true;
            this.btnBuscarTodos.Click += new System.EventHandler(this.btnBuscarTodos_Click);
            // 
            // frmTelaConsultaFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(822, 575);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.dgvConsultaFornecedores);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTelaConsultaFornecedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela Consulta Fornecedor";
            this.Load += new System.EventHandler(this.frmTelaConsultaFornecedor_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaFornecedores)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.ComboBox cboConsultarPor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvConsultaFornecedores;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnBuscarTodos;
        private System.Windows.Forms.Button btnCancelar;
    }
}