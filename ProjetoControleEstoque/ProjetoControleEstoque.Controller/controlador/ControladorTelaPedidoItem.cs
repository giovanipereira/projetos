using ProjetoControleEstoque.Controller.validacao;
using ProjetoControleEstoque.Model.dominio;
using ProjetoControleEstoque.Model.repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleEstoque.Controller.controlador
{
    public class ControladorTelaPedidoItem : ControladorBase
    {
        #region Declaration

        private TextBox txtCodigo, txtNome, txtPreco;
        private PictureBox picFigura;
        private NumericUpDown nudQuantidade;
        private Button btnAdicionar;
        RepositorioPedido repositorioPedido = new RepositorioPedido();
        ValidacaoPedido validacaoPedido;
        ItemPedido itemPedido;

        #endregion

        #region Constructors
        public ControladorTelaPedidoItem()
        {

        }

        public ControladorTelaPedidoItem(TextBox txtCodigo, TextBox txtNome, TextBox txtPreco, PictureBox picFigura,
            NumericUpDown nudQuantidade, Button btnAdicionar, Button btnAtualizar, Button btnCancelar)
        {
            this.txtCodigo = txtCodigo;
            this.txtNome = txtNome;
            this.picFigura = picFigura;
            this.nudQuantidade = nudQuantidade;
            this.txtPreco = txtPreco;
            this.btnAdicionar = btnAdicionar;
            this.btnAtualizar = btnAtualizar;
            this.btnCancelar = btnCancelar;
            AdicionarListaControles();
        }

        #endregion

        #region Private Methods

        private ItemPedido PreencherItemPedido(ItemPedido itemPedido)
        {
            itemPedido.Id_cardapio = int.Parse(txtCodigo.Text);
            itemPedido.Quantidade = (int)nudQuantidade.Value;
            return itemPedido;
        }

        public bool VerificarItemExistente(ItemPedido itemPedido)
        {
            IList<ItemPedido> lista = new List<ItemPedido>();
            lista = repositorioPedido.CarregarItensPedidoTemporarios();
            if (lista.Where(i => i.Id_cardapio.Equals(itemPedido.Id_cardapio)).Count() > 0)
                return true;
            else
            {
                return false;
            }
        }

        private bool SalvarItemPedido()
        {
            bool retorno = false;
            itemPedido = new ItemPedido();
            itemPedido = PreencherItemPedido(itemPedido);
            if (!VerificarItemExistente(itemPedido))
            {
                if (repositorioPedido.SalvarItemPedidoTemporariamente(itemPedido))
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            else
            {
                MessageBox.Show("Item já adicionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                retorno = true;
            }

            return retorno;
        }

        private bool AtualizarItemPedido()
        {
            bool retorno = false;
            itemPedido = new ItemPedido();
            itemPedido = PreencherItemPedido(itemPedido);
            if (repositorioPedido.AtualizarItemPedidoTemporariamente(itemPedido))
            {
                retorno = true;
            }
            else
            {
                retorno = false;
            }
            return retorno;
        }

    #endregion

    #region Abstracts Methods

    public override void AdicionarListaControles()
    {
        listaControles.Add(txtCodigo);
        listaControles.Add(txtNome);
        listaControles.Add(txtPreco);
        validacaoPedido = new ValidacaoPedido(listaControles);
    }

    public override void HabilitarTodosCampos(bool enable)
    {
        txtCodigo.ReadOnly = true;
        txtNome.ReadOnly = true;
        txtPreco.ReadOnly = true;
    }

    public override void LimparCampos()
    {

    }

    #endregion

    public void Load(int opcao)
    {
        if (opcao.Equals((int)EnumOperationMode.Normal))
        {
            HabilitarTodosCampos(false);
            btnAtualizar.Enabled = false;
        }
        else if (opcao.Equals((int)EnumOperationMode.Atualizar))
        {
            HabilitarTodosCampos(false);
            nudQuantidade.Focus();
            btnAdicionar.Enabled = false;
        }
    }

    public void Salvar(Form form)
    {
        if (SalvarItemPedido())
        {
            form.Close();
        }
    }

    public void Atualizar(Form form)
    {
        if (AtualizarItemPedido())
            {
                form.Close();
            }
        }
    }
}
