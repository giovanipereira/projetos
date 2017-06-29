namespace ProjetoControleEstoque.View.layout
{
    partial class frmTelaRelatorioEntradaProduto
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetControleEstoque = new ProjetoControleEstoque.View.relatorios.DataSetControleEstoque();
            this.dataSetControleEstoqueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.historicoprodutoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.historico_produtoTableAdapter = new ProjetoControleEstoque.View.relatorios.DataSetControleEstoqueTableAdapters.historico_produtoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetControleEstoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetControleEstoqueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.historicoprodutoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetEstoque";
            reportDataSource1.Value = this.historicoprodutoBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "ProjetoControleEstoque.View.relatorios.ReportHistoricoProdutos.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(822, 575);
            this.reportViewer.TabIndex = 0;
            // 
            // dataSetControleEstoque
            // 
            this.dataSetControleEstoque.DataSetName = "DataSetControleEstoque";
            this.dataSetControleEstoque.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetControleEstoqueBindingSource
            // 
            this.dataSetControleEstoqueBindingSource.DataSource = this.dataSetControleEstoque;
            this.dataSetControleEstoqueBindingSource.Position = 0;
            // 
            // historicoprodutoBindingSource
            // 
            this.historicoprodutoBindingSource.DataMember = "historico_produto";
            this.historicoprodutoBindingSource.DataSource = this.dataSetControleEstoqueBindingSource;
            // 
            // historico_produtoTableAdapter
            // 
            this.historico_produtoTableAdapter.ClearBeforeFill = true;
            // 
            // frmTelaRelatorioEntradaProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(822, 575);
            this.Controls.Add(this.reportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTelaRelatorioEntradaProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela Relatório Entrada Produto";
            this.Load += new System.EventHandler(this.frmTelaRelatorioEntradaProduto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetControleEstoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetControleEstoqueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.historicoprodutoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private relatorios.DataSetControleEstoque dataSetControleEstoque;
        private System.Windows.Forms.BindingSource dataSetControleEstoqueBindingSource;
        private System.Windows.Forms.BindingSource historicoprodutoBindingSource;
        private relatorios.DataSetControleEstoqueTableAdapters.historico_produtoTableAdapter historico_produtoTableAdapter;
    }
}