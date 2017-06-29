using ProjetoControleEstoque.Controller.utility;
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
    public class ControladorTelaCadastroPedido : ControladorBase
    {
        #region Declaration

        private TextBox txtCodigo, txtHorario, txtTotal;
        private ComboBox cboMesa;
        private Button btnRemoverItem, btnEditarItem, btnSelecionar;
        private DataGridView dgvListaCardapios;
        private DateTimePicker dtpData;

        ValidacaoPedido validacaoPedido;
        IList<Cardapio> listaCardapios = new List<Cardapio>();
        IList<ItemPedido> listaItensPedido = new List<ItemPedido>();
        IList<Pedido> listaPedidos = new List<Pedido>();
        RepositorioPedido repositorioPedido = new RepositorioPedido();
        RepositorioCardapio repositorioCardapio = new RepositorioCardapio();
        ItemPedido itemPedido;
        Pedido pedido;

        #endregion

        #region Constructors

        public ControladorTelaCadastroPedido()
        {

        }

        public ControladorTelaCadastroPedido(TextBox txtCodigo, TextBox txtHorario, TextBox txtTotal,
            ComboBox cboMesa, Button btnRemoverItem, Button btnEditarItem, Button btnSelecionar, DataGridView dgvListaCardapios,
            DateTimePicker dtpData, Button btnInserir, Button btnSalvar, Button btnAtualizar, Button btnCancelar)
        {
            this.txtCodigo = txtCodigo;
            this.txtHorario = txtHorario;
            this.txtTotal = txtTotal;
            this.cboMesa = cboMesa;
            this.btnRemoverItem = btnRemoverItem;
            this.btnEditarItem = btnEditarItem;
            this.btnSelecionar = btnSelecionar;
            this.dgvListaCardapios = dgvListaCardapios;
            this.dtpData = dtpData;
            this.btnInserir = btnInserir;
            this.btnSalvar = btnSalvar;
            this.btnCancelar = btnCancelar;
            this.btnAtualizar = btnAtualizar;
            AdicionarListaControles();
        }

        #endregion

        #region Public Methods

        public void HabilitarBotaoItem()
        {
            if (dgvListaCardapios.Rows.Count > 0)
            {
                btnEditarItem.Enabled = true;
                btnRemoverItem.Enabled = true;
            }
            else
            {
                btnEditarItem.Enabled = false;
                btnRemoverItem.Enabled = false;
            }
        }

        #endregion

        #region Private Methods

        private void CarregarListas()
        {
            listaCardapios = repositorioCardapio.CarregarCardapios();
        }

        public void ListarProdutos()
        {
            CarregarListas();
            listaItensPedido = repositorioPedido.CarregarItensPedidoTemporarios();
            var Query = from i in listaItensPedido
                        join c in listaCardapios on i.Id_cardapio equals c.Id
                        orderby i.Id_pedido descending
                        select new
                        {
                            Código = c.Id,
                            Nome = c.Nome,
                            Preço = c.Preco,
                            Quantidade = i.Quantidade
                        };
            if (Query.Count() > 0)
            {
                dgvListaCardapios.DataSource = Query.ToList();
                ConfigurarGrid();
            }
            else
            {
                dgvListaCardapios.DataSource = null;
            }
        }

        private void ConfigurarGrid()
        {
            dgvListaCardapios.Columns[0].Width = 145;
            dgvListaCardapios.Columns[1].Width = 205;
            dgvListaCardapios.Columns[2].Width = 193;
            dgvListaCardapios.Columns[3].Width = 180;
        }

        private void PreencherMesa()
        {
            repositorioPedido.PreencherMesa(cboMesa);
        }

        public void RemoverTodosItensTemporarios()
        {
            repositorioPedido.RemoverTodosItensPedidoTemporariamente();
        }

        public string CalcularValorTotal()
        {
            string total = repositorioPedido.CalcularValorTotal();
            return total;
        }

        public int ObterOrdemItem(int id)
        {
            listaItensPedido = repositorioPedido.CarregarItensPedidoTemporarios();
            var Query = from i in listaItensPedido
                        select new
                        {
                            i.Id_pedido,
                            i.Id_cardapio
                        };
            var item = Query.FirstOrDefault(x => x.Id_cardapio.Equals(id));
            int ordem;
            try
            {
                ordem = item.Id_pedido;
            }
            catch
            {
                ordem = 0;
            }
            return ordem;
        }

        public object[] ObterDadosItem(int id)
        {
            CarregarListas();
            listaItensPedido = repositorioPedido.CarregarItensPedidoTemporarios();
            var Query = from i in listaItensPedido
                        join c in listaCardapios on i.Id_cardapio equals c.Id
                        where i.Id_cardapio.Equals(id)
                        select new
                        {
                            Id = c.Id,
                            Nome = c.Nome,
                            Preço = c.Preco,
                            Figura = c.Figura,
                            Quantidade = i.Quantidade
                        };
            var cardapio = Query.FirstOrDefault(x => x.Id.Equals(id));
            object[] dados = { cardapio.Id, cardapio.Nome, cardapio.Preço, cardapio.Figura, cardapio.Quantidade };
            return dados;
        }

        public void RemoverItem()
        {
            if (dgvListaCardapios.Rows.Count > 0)
            {
                if (Mensagem.MensagemQuestao("Tem certeza que deseja remover esse item?").Equals(DialogResult.Yes))
                {
                    itemPedido = new ItemPedido();
                    int id = int.Parse(dgvListaCardapios.CurrentRow.Cells[0].Value.ToString());
                    itemPedido.Id_pedido = ObterOrdemItem(id);
                    itemPedido.Id_cardapio = id;
                    repositorioPedido.RemoverItemPedidoTemporariamente(itemPedido);
                    ListarProdutos();
                }
            }
        }

        private bool VerificarCampos()
        {
            bool retorno = false;
            if (string.IsNullOrEmpty(cboMesa.Text))
            {
                {
                    Mensagem.MensagemEmpty("Mesa");
                    cboMesa.Focus();
                    retorno = false;
                }
            }
            else
            {
                retorno = true;
            }
            return retorno;
        }

        private Pedido PreencherPedido(Pedido pedido)
        {
            int codigo;
            pedido.Id = int.TryParse(txtCodigo.Text, out codigo) ? codigo : 0;
            pedido.Id_mesa = int.Parse(cboMesa.SelectedValue.ToString());
            pedido.Horario = DateTime.Now.ToString("HH:mm:ss");
            pedido.Data = dtpData.Value;
            pedido.Status = "P";
            pedido.VlTotal = txtTotal.Text;
            return pedido;
        }

        private bool SalvarPedido()
        {
            bool sucesso = false;
            if (VerificarCampos())
            {
                pedido = new Pedido();
                pedido = PreencherPedido(pedido);
                if (dgvListaCardapios.RowCount > 0)
                {
                    if (repositorioPedido.Salvar(pedido))
                    {
                        Mensagem.MensagemSalvar();
                        sucesso = true;
                    }
                    else
                    {
                        sucesso = false;
                    }
                }
                else
                {
                    MessageBox.Show("Obrigatório adicionar itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sucesso = false;
                }
            }
            return sucesso;
        }

        public bool AtualizarPedido()
        {
            bool sucesso = false;
            if (VerificarCampos())
            {
                pedido = new Pedido();
                pedido = PreencherPedido(pedido);
                if (dgvListaCardapios.RowCount > 0)
                {
                    if (repositorioPedido.Atualizar(pedido))
                    {
                        Mensagem.MensagemAtualizar();
                        sucesso = true;
                    }
                    else
                    {
                        sucesso = false;
                    }
                }
                else
                {
                    MessageBox.Show("Obrigatório adicionar itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sucesso = false;
                }
            }
            return sucesso;
        }

        #endregion

        #region Abstracts Methods

        public override void AdicionarListaControles()
        {
            listaControles.Add(txtCodigo);
            listaControles.Add(txtHorario);
            listaControles.Add(cboMesa);
            listaControles.Add(dtpData);
            listaControles.Add(dgvListaCardapios);
            listaControles.Add(btnRemoverItem);
            listaControles.Add(btnSelecionar);
            listaControles.Add(btnEditarItem);
            listaControles.Add(txtTotal);
            validacaoPedido = new ValidacaoPedido(listaControles);
        }

        public override void HabilitarTodosCampos(bool enable)
        {
            validacaoPedido.EnableControle(enable);
            txtCodigo.ReadOnly = true;
            txtHorario.ReadOnly = true;
            txtTotal.ReadOnly = true;
            dtpData.Enabled = false;
            btnRemoverItem.Enabled = false;
            btnEditarItem.Enabled = false;
        }

        public override void LimparCampos()
        {
            validacaoPedido.LimparControles();
        }

        #endregion

        #region Event Functions

        public void PreencherCombobox()
        {
            PreencherMesa();
        }

        public void Load(int opcao)
        {
            switch (opcao)
            {
                case (int)EnumOperationMode.Normal:
                    PreencherCombobox();
                    OperationMode((int)EnumOperationMode.Normal);
                    break;
                case (int)EnumOperationMode.Atualizar:
                    OperationMode((int)EnumOperationMode.Atualizar);
                    ListarProdutos();
                    break;
            }
        }

        public void Salvar()
        {
            if (SalvarPedido())
            {
                OperationMode((int)EnumOperationMode.Normal);
            }
        }

        public void Inserir()
        {
            OperationMode((int)EnumOperationMode.Inserir);
        }

        public void Atualizar(Form form)
        {
            if (AtualizarPedido())
            {
                form.Close();
            }
        }

        #endregion
    }
}
