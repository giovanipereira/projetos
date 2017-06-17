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
    public class ControladorTelaCadastroFuncionario : ControladorBase
    {
        #region Declaration

        private TextBox txtCodigo, txtNome, txtEmail, txtUsuario, txtSenha, txtConfirmarSenha;
        private ComboBox cboCargo, cboNivelAcesso;
        private MaskedTextBox mskCpf, mskTelefone;
        private int id_usuario;

        RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();
        Funcionario funcionario;
        Usuario usuario;
        ValidacaoFuncionario validacaoFuncionario;

        #endregion

        #region Constructors

        public ControladorTelaCadastroFuncionario()
        {

        }

        public ControladorTelaCadastroFuncionario(TextBox txtCodigo, TextBox txtNome, TextBox txtEmail,
            TextBox txtUsuario, TextBox txtSenha, TextBox txtConfirmarSenha, ComboBox cboCargo,
            ComboBox cboNivelAcesso, MaskedTextBox mskCpf, MaskedTextBox mskTelefone, Button btnInserir,
            Button btnSalvar, Button btnAtualizar, Button btnCancelar, int id_usuario)
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
            this.id_usuario = id_usuario;
            AdicionarListaControles();
        }

        #endregion

        #region Private Methods

        private void PreencherCargo()
        {
            repositorioFuncionario.PreencherCargo(cboCargo);
        }

        private void PreencherNivelAcesso()
        {
            repositorioFuncionario.PreencherNivelAcesso(cboNivelAcesso);
        }

        private Usuario PreencherUsuario(Usuario usuario)
        {
            usuario.Nome = txtUsuario.Text;
            usuario.Senha = txtSenha.Text;
            usuario.Id_nivel_acesso = int.Parse(cboNivelAcesso.SelectedValue.ToString());
            return usuario;
        }

        private Funcionario PreencherFuncionario(Funcionario funcionario)
        {
            int id;
            funcionario.Id = int.TryParse(txtCodigo.Text, out id) ? id : 0;
            funcionario.Nome = txtNome.Text;
            mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            funcionario.Cpf = long.Parse(mskCpf.Text);
            funcionario.Email = txtEmail.Text;
            mskTelefone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            funcionario.Telefone = long.Parse(mskTelefone.Text);
            funcionario.Id_cargo = int.Parse(cboCargo.SelectedValue.ToString());
            funcionario.Id_Usuario = id_usuario;
            return funcionario;
        }

        private void SalvarFuncionario()
        {
            usuario = new Usuario();
            funcionario = new Funcionario();
            usuario = PreencherUsuario(usuario);
            funcionario = PreencherFuncionario(funcionario);
            if (repositorioFuncionario.Salvar(funcionario, usuario))
                Mensagem.MensagemSalvar();
        }

        private void AtualizarFuncionario()
        {
            usuario = new Usuario();
            funcionario = new Funcionario();
            usuario = PreencherUsuario(usuario);
            funcionario = PreencherFuncionario(funcionario);
            if (repositorioFuncionario.Atualizar(funcionario, usuario))
                Mensagem.MensagemAtualizar();
        }

        #endregion

        #region Abstracts Methods

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
            validacaoFuncionario = new ValidacaoFuncionario(listaControles);
        }

        public override void HabilitarTodosCampos(bool enable)
        {
            validacaoFuncionario.EnableControle(enable);
            txtCodigo.ReadOnly = true;
        }

        public override void LimparCampos()
        {
            validacaoFuncionario.LimparControles();
        }

        #endregion

        #region Event Functions

        public void PreencherCombobox()
        {
            PreencherCargo();
            PreencherNivelAcesso();
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
                    break;
            }
        }

        public void Salvar()
        {
            SalvarFuncionario();
            OperationMode((int)EnumOperationMode.Normal);
        }

        public void Inserir()
        {
            OperationMode((int)EnumOperationMode.Inserir);
        }

        public void Atualizar(Form form)
        {
            AtualizarFuncionario();
            form.Close();
        }

        #endregion
    }
}
