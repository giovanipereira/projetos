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
    public class ControladorTelaCadastroFornecedor : ControladorBase
    {
        #region Declaration

        private TextBox txtCodigo, txtNome, txtEmail, txtEndereco, txtComplemento, txtBairro, txtCidade;
        private ComboBox cboUf;
        private MaskedTextBox mskCnpj, mskTelefone, mskCep;

        RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();
        Fornecedor fornecedor;
        ValidacaoFornecedor validacaoFornecedor;

        #endregion

        #region Constructors

        public ControladorTelaCadastroFornecedor()
        {

        }

        public ControladorTelaCadastroFornecedor(TextBox txtCodigo, TextBox txtNome, TextBox txtEmail,
            TextBox txtEndereco, TextBox txtComplemento, TextBox txtBairro, TextBox txtCidade, ComboBox cboUf,
            MaskedTextBox mskCnpj, MaskedTextBox mskTelefone, MaskedTextBox mskCep, Button btnInserir,
            Button btnSalvar, Button btnAtualizar, Button btnCancelar)
        {
            this.txtCodigo = txtCodigo;
            this.txtNome = txtNome;
            this.txtEmail = txtEmail;
            this.txtEndereco = txtEndereco;
            this.txtComplemento = txtComplemento;
            this.txtBairro = txtBairro;
            this.txtCidade = txtCidade;
            this.cboUf = cboUf;
            this.mskCnpj = mskCnpj;
            this.mskTelefone = mskTelefone;
            this.mskCep = mskCep;
            this.btnInserir = btnInserir;
            this.btnSalvar = btnSalvar;
            this.btnAtualizar = btnAtualizar;
            this.btnCancelar = btnCancelar;
            AdicionarListaControles();
        }

        #endregion

        #region Private Methods

        private void PreencherUf()
        {
            repositorioFornecedor.PreencherUf(cboUf);
        }

        private Fornecedor PreencherFornecedor(Fornecedor fornecedor)
        {
            int id;
            fornecedor.Id = int.TryParse(txtCodigo.Text, out id) ? id : 0;
            fornecedor.Nome = txtNome.Text;
            mskCnpj.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            fornecedor.Cnpj = long.Parse(mskCnpj.Text);
            fornecedor.Endereco = txtEndereco.Text;
            fornecedor.Complemento = txtComplemento.Text;
            fornecedor.Bairro = txtBairro.Text;
            fornecedor.Cidade = txtCidade.Text;
            fornecedor.Ativo = true;
            mskCep.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            fornecedor.Cep = long.Parse(mskCep.Text);
            mskTelefone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            fornecedor.Telefone = long.Parse(mskTelefone.Text);
            fornecedor.Email = txtEmail.Text;
            fornecedor.Id_uf = int.Parse(cboUf.SelectedValue.ToString());
            return fornecedor;
        }

        private bool VerificarCampos()
        {
            mskCnpj.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mskTelefone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mskCep.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            bool retorno;
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                Mensagem.MensagemEmpty("Nome");
                txtNome.Focus();
                retorno = false;
            }
            else if (string.IsNullOrEmpty(mskCnpj.Text))
            {
                Mensagem.MensagemEmpty("Cnpj");
                mskCnpj.Focus();
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
            else if (string.IsNullOrEmpty(txtEndereco.Text))
            {
                Mensagem.MensagemEmpty("Endereço");
                txtEndereco.Focus();
                retorno = false;
            }
            else if (string.IsNullOrEmpty(txtBairro.Text))
            {
                Mensagem.MensagemEmpty("Bairro");
                txtBairro.Focus();
                retorno = false;
            }
            else if (string.IsNullOrEmpty(mskCep.Text))
            {
                Mensagem.MensagemEmpty("Cep");
                mskCep.Focus();
                retorno = false;
            }
            else if (string.IsNullOrEmpty(cboUf.Text))
            {
                Mensagem.MensagemEmpty("Uf");
                cboUf.Focus();
                retorno = false;
            }
            else if (string.IsNullOrEmpty(txtCidade.Text))
            {
                Mensagem.MensagemEmpty("Cidade");
                txtCidade.Focus();
                retorno = false;
            }
            else
            {
                retorno = true;
            }
            return retorno;
        }

        private bool VerificarCnpjExistente(Fornecedor fornecedor)
        {
            IList<Fornecedor> lista = new List<Fornecedor>();
            lista = repositorioFornecedor.CarregarFornecedores();
            if (fornecedor.Id.Equals(0))
            {
                if (lista.Where(f => f.Cnpj.Equals(fornecedor.Cnpj)).Count() > 0)
                    return true;
                else
                {
                    return false;
                }
            }
            else
            {
                if (lista.Where(f => f.Cnpj.Equals(fornecedor.Cnpj)).Where(f => f.Id != fornecedor.Id).Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        private bool VerificarEmailExistente(Fornecedor fornecedor)
        {
            IList<Fornecedor> lista = new List<Fornecedor>();
            lista = repositorioFornecedor.CarregarFornecedores();
            if (fornecedor.Id.Equals(0))
            {
                if (lista.Where(f => f.Email.Equals(fornecedor.Email)).Count() > 0)
                    return true;
                else
                {
                    return false;
                }
            }
            else
            {
                if (lista.Where(f => f.Email.Equals(fornecedor.Email)).Where(f => f.Id != fornecedor.Id).Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool SalvarFornecedor()
        {
            bool sucesso = false;
            if (VerificarCampos())
            {
                fornecedor = new Fornecedor();
                fornecedor = PreencherFornecedor(fornecedor);
                if (!VerificarCnpjExistente(fornecedor))
                {
                    if (!VerificarEmailExistente(fornecedor))
                    {
                        if (repositorioFornecedor.Salvar(fornecedor))
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
                        MessageBox.Show("E-mail já cadastrado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEmail.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Cnpj já cadastrado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mskCnpj.Focus();
                }
            }
            return sucesso;
        }

        private bool AtualizarFornecedor()
        {
            bool sucesso = false;
            if (VerificarCampos())
            {
                fornecedor = new Fornecedor();
                fornecedor = PreencherFornecedor(fornecedor);
                if (!VerificarCnpjExistente(fornecedor))
                {
                    if (!VerificarEmailExistente(fornecedor))
                    {
                        if (repositorioFornecedor.Atualizar(fornecedor))
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
                        MessageBox.Show("E-mail já cadastrado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEmail.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Cnpj já cadastrado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mskCnpj.Focus();
                }
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
            listaControles.Add(txtEndereco);
            listaControles.Add(txtComplemento);
            listaControles.Add(txtBairro);
            listaControles.Add(txtCidade);
            listaControles.Add(cboUf);
            listaControles.Add(mskCnpj);
            listaControles.Add(mskTelefone);
            listaControles.Add(mskCep);
            validacaoFornecedor = new ValidacaoFornecedor(listaControles);
        }

        public override void HabilitarTodosCampos(bool enable)
        {
            validacaoFornecedor.EnableControle(enable);
            txtCodigo.ReadOnly = true;
        }

        public override void LimparCampos()
        {
            validacaoFornecedor.LimparControles();
        }

        #endregion

        #region Event Functions

        public void PreencherCombobox()
        {
            PreencherUf();
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
            if (SalvarFornecedor())
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
            if (AtualizarFornecedor())
            {
                form.Close();
            }
        }

        #endregion

    }
}
