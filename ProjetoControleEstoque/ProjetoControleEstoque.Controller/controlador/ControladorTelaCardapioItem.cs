using ProjetoControleEstoque.Controller.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleEstoque.Controller.controlador
{
    public class ControladorTelaCardapioItem
    {
        #region Declaration
        Validacao validacao;

        private TextBox txtCodigoProduto, txtNomeProduto, txtQuantidadeProduto;
        private ComboBox cboUnidadeProduto;
        private Button btnAdicionar, btnAtualizar, btnCancelar;

        private List<Control> listControls = new List<Control>();

        #endregion

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
            AddList();
        }

        // Função que adiciona os componentes ao list e inicia o objeto validacao
        public void AddList()
        {
            listControls.Add(txtCodigoProduto);
            listControls.Add(txtNomeProduto);
            listControls.Add(cboUnidadeProduto);
            validacao = new Validacao(listControls);
        }

        // Função que desabilita os componentes
        private void EnableAll()
        {
            validacao.EnableControle(false);
        }

        // Função para o evento load que desabilita os componentes
        public void Load()
        {
            EnableAll();
        }

        public object[] AddItem()
        {
            object[] item = { txtCodigoProduto.Text, txtNomeProduto.Text, cboUnidadeProduto.Text, txtQuantidadeProduto.Text,  };
            return item;
        }

        // Função que atualiza o item do cardápio
        public void UpdateItem()
        {

        }
    }
}
