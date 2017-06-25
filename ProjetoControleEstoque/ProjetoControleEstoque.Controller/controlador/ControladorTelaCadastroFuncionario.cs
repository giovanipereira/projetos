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

        private bool VerificarCampos()
        {
            mskTelefone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            bool retorno;
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                Mensagem.MensagemEmpty("Nome");
                txtNome.Focus();
                retorno = false;
            }
            else if (string.IsNullOrEmpty(mskCpf.Text))
            {
                Mensagem.MensagemEmpty("Cpf");
                mskCpf.Focus();
                retorno = false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                Mensagem.MensagemEmpty("E-mail");
                txtEmail.Focus();
                retorno = false;
            }
            else if (string.IsNullOrEmpty(mskTelefone.Text))
            {
                Mensagem.MensagemEmpty("Telefone");
                mskTelefone.Focus();
                retorno = false;
            }
            else if (string.IsNullOrEmpty(cboCargo.Text))
            {
                Mensagem.MensagemEmpty("Cargo");
                cboCargo.Focus();
                retorno = false;
            }
            else if (string.IsNullOrEmpty(cboNivelAcesso.Text))
            {
                Mensagem.MensagemEmpty("Nível de acesso");
                cboNivelAcesso.Focus();
                retorno = false;
            }
            else if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                Mensagem.MensagemEmpty("Nome de usuário");
                txtUsuario.Focus();
                retorno = false;
            }
            else if (string.IsNullOrEmpty(txtSenha.Text))
            {
                Mensagem.MensagemEmpty("Senha");
                txtSenha.Focus();
                retorno = false;
            }
            else if (string.IsNullOrEmpty(txtConfirmarSenha.Text))
            {
                Mensagem.MensagemEmpty("Confirmar senha");
                txtConfirmarSenha.Focus();
                retorno = false;
            }
            else
            {
                retorno = true;
            }
            return retorno;
        }

        private bool VerificarSenhas()
        {
            if (txtSenha.Text.Equals(txtConfirmarSenha.Text))
                return true;
            else
            {
                return false;
            }
        }

        private void LimparSenhas()
        {
            txtSenha.Clear();
            txtConfirmarSenha.Clear();
            txtSenha.Focus();
        }

        private bool VerificarCpfExistente(Funcionario funcionario)
        {
            IList<Funcionario> lista = new List<Funcionario>();
            lista = repositorioFuncionario.CarregarFuncionarios();
            if (funcionario.Id.Equals(0))
            {
                if (lista.Where(f => f.Cpf.Equals(funcionario.Cpf)).Count() > 0)
                    return true;
                else
                {
                    return false;
                }
            }
            else
            {
                if (lista.Where(f => f.Cpf.Equals(funcionario.Cpf)).Where(f => f.Id != funcionario.Id).Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool VerificarEmailExistente(Funcionario funcionario)
        {
            IList<Funcionario> lista = new List<Funcionario>();
            lista = repositorioFuncionario.CarregarFuncionarios();
            if (funcionario.Id.Equals(0))
            {
                if (lista.Where(f => f.Email.Equals(funcionario.Email)).Count() > 0)
                    return true;
                else
                {
                    return false;
                }
            }
            else
            {
                if (lista.Where(f => f.Email.Equals(funcionario.Email)).Where(f => f.Id != funcionario.Id).Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }          

        private bool VerificarUsuarioExistente(Usuario usuario, Funcionario funcionario)
        {
            IList<Funcionario> listaFuncionarios = new List<Funcionario>();
            IList<Usuario> listaUsuarios = new List<Usuario>();
            listaFuncionarios = repositorioFuncionario.CarregarFuncionarios();
            listaUsuarios = repositorioFuncionario.CarregarUsuarios();
            var Query = from f in listaFuncionarios
                        join u in listaUsuarios on f.Id_Usuario equals u.Id
                        select new { f.Id, u.Nome };
            if (funcionario.Id.Equals(0))
            {
                if (Query.Where(f => f.Nome.Equals(usuario.Nome)).Count() > 0)
                    return true;
                else
                {
                    return false;
                }
            }
            else
            {
                if (Query.Where(f => f.Nome.Equals(usuario.Nome)).Where(f => f.Id != funcionario.Id).Count() > 0)
                    return true;
                else
                {
                    return false;
                }
            }
        }

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

        private bool SalvarFuncionario()
        {
            bool sucesso = false;
            if (VerificarCampos())
            {
                usuario = new Usuario();
                funcionario = new Funcionario();
                usuario = PreencherUsuario(usuario);
                funcionario = PreencherFuncionario(funcionario);
                if (VerificarSenhas())
                {
                    if (!VerificarCpfExistente(funcionario))
                    {
                        if (!VerificarEmailExistente(funcionario))
                        {
                            if (!VerificarUsuarioExistente(usuario,funcionario))
                            {
                                if (repositorioFuncionario.Salvar(funcionario, usuario))
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
                                MessageBox.Show("Nome de usuário já cadastrado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtUsuario.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("E-mail já cadastrado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtEmail.Focus();
                        }
                        
                        
                    }
                    else
                    {
                        MessageBox.Show("Cpf já cadastrado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mskCpf.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("As senhas não coincidem", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparSenhas();
                }

            }
            return sucesso;
        }

        private bool AtualizarFuncionario()
        {
            bool sucesso = false;
            if (VerificarCampos())
            {
                usuario = new Usuario();
                funcionario = new Funcionario();
                usuario = PreencherUsuario(usuario);
                funcionario = PreencherFuncionario(funcionario);
                if (VerificarSenhas())
                {
                    if (!VerificarCpfExistente(funcionario))
                    {
                        if (!VerificarEmailExistente(funcionario))
                        {
                            if (!VerificarUsuarioExistente(usuario, funcionario))
                            {
                                if (repositorioFuncionario.Atualizar(funcionario, usuario))
                                {
                                    Mensagem.MensagemAtualizar();
                                    sucesso = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nome de usuário já cadastrado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtUsuario.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("E-mail já cadastrado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtEmail.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cpf já cadastrado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mskCpf.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("As senhas não coincidem", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparSenhas();
                }
            }
            else
            {
                sucesso = false;
            }
            return sucesso;
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
            if (SalvarFuncionario())
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
            if (AtualizarFuncionario())
            {
                form.Close();
            }

        }

        #endregion
    }
}
