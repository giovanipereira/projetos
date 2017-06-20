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

        private void SalvarFornecedor()
        {
            try
            {
                fornecedor = new Fornecedor();
                fornecedor = PreencherFornecedor(fornecedor);
                if (repositorioFornecedor.Salvar(fornecedor))
                    Mensagem.MensagemSalvar();
            }
            catch
            {
                MessageBox.Show("Não foi possível cadastrar", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AtualizarFornecedor()
        {
            try
            {
                fornecedor = new Fornecedor();
                fornecedor = PreencherFornecedor(fornecedor);
                if (repositorioFornecedor.Atualizar(fornecedor))
                    Mensagem.MensagemAtualizar();
            }
            catch
            {
                MessageBox.Show("Não foi possível atualizar", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            SalvarFornecedor();
            OperationMode((int)EnumOperationMode.Normal);
        }

        public void Inserir()
        {
            OperationMode((int)EnumOperationMode.Inserir);
        }

        public void Atualizar(Form form)
        {
            AtualizarFornecedor();
            form.Close();
        }

        #endregion

    }
}
