﻿using ProjetoControleEstoque.Controller.utility;
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

        Validacao validacao;

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

        #region Public Methods

        #endregion

        #region Private and Protected Abstracts Methods

        protected override void AdicionarListaControles()
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
            validacao = new Validacao(listaControles);
        }

        protected override void HabilitarTodosCampos(bool enable)
        {
            validacao.EnableControle(enable);
        }

        protected override void LimparCampos()
        {
            validacao.LimparControl();
        }

        #endregion

        #region Event Functions

        #endregion

    }

    internal enum EnumSituacaoFornecedor
    {
        Ativo = 1,
        Desativado = 2
    }
}