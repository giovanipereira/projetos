namespace ProjetoControleEstoque.View.layout
{
    partial class frmTelaRelatorioPedido
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetControleEstoque = new ProjetoControleEstoque.View.relatorios.DataSetControleEstoque();
            this.historicopedidoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.historico_pedidoTableAdapter = new ProjetoControleEstoque.View.relatorios.DataSetControleEstoqueTableAdapters.historico_pedidoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetControleEstoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.historicopedidoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSetEstoque";
            reportDataSource2.Value = this.historicopedidoBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "ProjetoControleEstoque.View.relatorios.ReportHistoricoPedidos.rdlc";
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
            // historicopedidoBindingSource
            // 
            this.historicopedidoBindingSource.DataMember = "historico_pedido";
            this.historicopedidoBindingSource.DataSource = this.dataSetControleEstoque;
            // 
            // historico_pedidoTableAdapter
            // 
            this.historico_pedidoTableAdapter.ClearBeforeFill = true;
            // 
            // frmTelaRelatorioPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(822, 575);
            this.Controls.Add(this.reportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTelaRelatorioPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela Relatório Pedido";
            this.Load += new System.EventHandler(this.frmTelaRelatorioPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetControleEstoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.historicopedidoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private relatorios.DataSetControleEstoque dataSetControleEstoque;
        private System.Windows.Forms.BindingSource historicopedidoBindingSource;
        private relatorios.DataSetControleEstoqueTableAdapters.historico_pedidoTableAdapter historico_pedidoTableAdapter;
    }
}