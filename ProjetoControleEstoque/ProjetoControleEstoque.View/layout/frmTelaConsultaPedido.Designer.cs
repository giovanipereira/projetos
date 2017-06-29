namespace ProjetoControleEstoque.View.layout
{
    partial class frmTelaConsultaPedido
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
            this.dgvConsultaPedidos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.btnDetalhes = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaPedidos)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvConsultaPedidos
            // 
            this.dgvConsultaPedidos.AllowUserToAddRows = false;
            this.dgvConsultaPedidos.AllowUserToDeleteRows = false;
            this.dgvConsultaPedidos.AllowUserToResizeColumns = false;
            this.dgvConsultaPedidos.AllowUserToResizeRows = false;
            this.dgvConsultaPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultaPedidos.Location = new System.Drawing.Point(12, 33);
            this.dgvConsultaPedidos.MultiSelect = false;
            this.dgvConsultaPedidos.Name = "dgvConsultaPedidos";
            this.dgvConsultaPedidos.ReadOnly = true;
            this.dgvConsultaPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultaPedidos.Size = new System.Drawing.Size(798, 443);
            this.dgvConsultaPedidos.TabIndex = 10;
            this.dgvConsultaPedidos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultaPedidos_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Consulta Pedido";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btnDetalhes);
            this.panel.Controls.Add(this.btnCancelar);
            this.panel.Controls.Add(this.btnAtualizar);
            this.panel.Location = new System.Drawing.Point(16, 482);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(794, 86);
            this.panel.TabIndex = 11;
            // 
            // btnDetalhes
            // 
            this.btnDetalhes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalhes.Image = global::ProjetoControleEstoque.View.Properties.Resources.Adicionar;
            this.btnDetalhes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDetalhes.Location = new System.Drawing.Point(183, 20);
            this.btnDetalhes.Name = "btnDetalhes";
            this.btnDetalhes.Size = new System.Drawing.Size(104, 57);
            this.btnDetalhes.TabIndex = 14;
            this.btnDetalhes.Text = "Detalhes";
            this.btnDetalhes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetalhes.UseVisualStyleBackColor = true;
            this.btnDetalhes.Click += new System.EventHandler(this.btnDetalhes_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::ProjetoControleEstoque.View.Properties.Resources.No;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(531, 20);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 57);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Image = global::ProjetoControleEstoque.View.Properties.Resources.Alterar;
            this.btnAtualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAtualizar.Location = new System.Drawing.Point(345, 20);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(104, 57);
            this.btnAtualizar.TabIndex = 3;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // frmTelaConsultaPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(822, 575);
            this.Controls.Add(this.dgvConsultaPedidos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel);
            this.Name = "frmTelaConsultaPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela Consulta Pedido";
            this.Load += new System.EventHandler(this.frmTelaConsultaPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaPedidos)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConsultaPedidos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnDetalhes;
    }
}