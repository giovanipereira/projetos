using ProjetoControleEstoque.Controller.utility;
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
    public class ControladorTelaDetalhesPedido
    {
        private Button btnFinalizar, btnCancelarPedido;
        private Label lblCodigo;

        RepositorioPedido repositorioPedido = new RepositorioPedido();
        Pedido pedido;

        public ControladorTelaDetalhesPedido()
        {

        }

        public ControladorTelaDetalhesPedido(Button btnFinalizar, Button btnCancelarPedido, Label lblCodigo)
        {
            this.btnFinalizar = btnFinalizar;
            this.btnCancelarPedido = btnCancelarPedido;
            this.lblCodigo = lblCodigo;
        }

        private Pedido PreencherPedido(Pedido pedido)
        {
            pedido.Id = int.Parse(lblCodigo.Text);
            return pedido;
        }

        private bool FinalizarPedido()
        {
            bool sucesso = false;
            pedido = new Pedido();
            pedido = PreencherPedido(pedido);
            if (Mensagem.MensagemQuestao("Tem certeza que deseja finalizar o pedido?").Equals(DialogResult.Yes))
            {
                if (repositorioPedido.FinalizarPedido(pedido))
                {
                    MessageBox.Show("Pedido finalizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sucesso = true;
                }
                else
                {
                    sucesso = false;
                }
            }
            return sucesso;
        }

        private bool CancelarPedido()
        {
            bool sucesso = false;
            int id = int.Parse(lblCodigo.Text.ToString());
            pedido = new Pedido();
            pedido.Id = id;
            if (Mensagem.MensagemQuestao("Tem certeza que deseja cancelar o pedido?").Equals(DialogResult.Yes))
            {
                repositorioPedido.Remover(pedido);
                MessageBox.Show("Pedido cancelado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sucesso = true;
            }
            else
            {
                sucesso = false;
            }
            return sucesso;
        }


        public void Finalizar(Form form)
        {
            if (FinalizarPedido())
            {
                form.Close();
            }
        }

        public void Cancelar(Form form)
        {
            if (CancelarPedido())
            {
                form.Close();
            }


        }
    }
}
