using ProjetoControleEstoque.Controller.utility;
using ProjetoControleEstoque.Controller.validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleEstoque.Controller.controlador
{
    public class ControladorTelaCadastroFuncionario : ControladorBase
    {
        #region Declaration

        private TextBox txtCodigo, txtNome, txtEmail, txtUsuario, txtSenha, txtConfirmarSenha;
        private ComboBox cboCargo, cboNivelAcesso;
        private MaskedTextBox mskCpf, mskTelefone;

        ValidacaoProduto validacao;

        #endregion

        #region Constructors

        public ControladorTelaCadastroFuncionario()
        {

        }

        public ControladorTelaCadastroFuncionario(TextBox txtCodigo, TextBox txtNome, TextBox txtEmail,
            TextBox txtUsuario, TextBox txtSenha, TextBox txtConfirmarSenha, ComboBox cboCargo,
            ComboBox cboNivelAcesso, MaskedTextBox mskCpf, MaskedTextBox mskTelefone, Button btnInserir,
            Button btnSalvar, Button btnAtualizar, Button btnCancelar)
        {
            this.txtCodigo = txtCodigo;
            this.txtNome = txtNome;
            this.txtEmail = txtEmail;
            this.txtUsuario = txtUsuario;
            this.txtSenha = txtSenha;
            this.txtConfirmarSenha = txtConfirmarSenha;
            this.cboCargo = cboCargo;
            this.cboNivelAcesso = cboNivelAcesso;
            this.mskCpf = mskCpf;
            this.mskTelefone = mskTelefone;
            this.btnInserir = btnInserir;
            this.btnSalvar = btnSalvar;
            this.btnAtualizar = btnAtualizar;
            this.btnCancelar = btnCancelar;
            AdicionarListaControles();
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private and Abstracts Methods

        public override void AdicionarListaControles()
        {
            listaControles.Add(txtCodigo);
            listaControles.Add(txtNome);
            listaControles.Add(txtEmail);
            listaControles.Add(txtUsuario);
            listaControles.Add(txtSenha);
            listaControles.Add(txtConfirmarSenha);
            listaControles.Add(cboCargo);
            listaControles.Add(cboNivelAcesso);
            listaControles.Add(mskCpf);
            listaControles.Add(mskTelefone);
            validacao = new ValidacaoProduto(listaControles);
        }

        public override void HabilitarTodosCampos(bool enable)
        {
            validacao.EnableControle(enable);
            txtCodigo.Enabled = false;
        }

        public override void LimparCampos()
        {
            validacao.LimparControl();
        }

        #endregion

        #region Event Functions

        public void Load()
        {
            OperationMode((int)EnumOperationMode.Normal);
        }

        public void Salvar()
        {
            Mensagem.MensagemSalvar();
            OperationMode((int)EnumOperationMode.Normal);
        }

        public void Inserir()
        {
            OperationMode((int)EnumOperationMode.Inserir);
        }

        public void Atualizar()
        {
            OperationMode((int)EnumOperationMode.Atualizar);
        }

        #endregion
    }
}
