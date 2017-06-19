using ProjetoControleEstoque.Controller.utility;
using ProjetoControleEstoque.Controller.validacao;
using ProjetoControleEstoque.Model.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleEstoque.Controller.controlador
{
    public class ControladorTelaCardapioItem : ControladorBase
    {
        #region Declaration

        private TextBox txtCodigoProduto, txtNomeProduto, txtQuantidadeProduto;
        private ComboBox cboUnidadeProduto;
        private Button btnAdicionar;

        //ItemCardapio itemCardapio;
        ValidacaoProduto validacao;

        #endregion

        #region Constructors

        public ControladorTelaCardapioItem()
        {
            
        }

        public ControladorTelaCardapioItem(TextBox txtCodigoProduto, TextBox txtNomeProduto, TextBox txtQuantidadeProduto,
            ComboBox cboUnidadeProduto, Button btnAdicionar, Button btnAtualizar, Button btnCancelar)
        {
            this.txtCodigoProduto = txtCodigoProduto;
            this.txtNomeProduto = txtNomeProduto;
            this.txtQuantidadeProduto = txtQuantidadeProduto;
            this.cboUnidadeProduto = cboUnidadeProduto;
            this.btnAdicionar = btnAdicionar;
            this.btnAtualizar = btnAtualizar;
            this.btnCancelar = btnCancelar;
            AdicionarListaControles();
        }

        #endregion

        #region Private Methods

        #endregion

        #region Abstracts Methods

        public override void HabilitarTodosCampos(bool enable)
        {
            txtCodigoProduto.ReadOnly = true;
            txtNomeProduto.ReadOnly = true;
            cboUnidadeProduto.Enabled = false;
        }

        public override void LimparCampos()
        {
            throw new NotImplementedException();
        }

        public override void AdicionarListaControles()
        {
            listaControles.Add(txtCodigoProduto);
            listaControles.Add(txtNomeProduto);
            listaControles.Add(cboUnidadeProduto);
            validacao = new ValidacaoProduto(listaControles);
        }

        #endregion


    }
}
