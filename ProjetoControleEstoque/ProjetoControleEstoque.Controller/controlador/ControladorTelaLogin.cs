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
    public class ControladorTelaLogin
    {
        private TextBox txtUsuario, txtSenha;
        private Button btnEntrar;

        Usuario usuario;
        RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();


        public ControladorTelaLogin()
        {

        }

        public ControladorTelaLogin(TextBox txtUsuario, TextBox txtSenha, Button btnEntrar)
        {
            this.txtUsuario = txtUsuario;
            this.txtSenha = txtSenha;
            this.btnEntrar = btnEntrar;
        }

        private bool VerificarCampos()
        {
            bool retorno;
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                retorno = false;
            }
            else if (string.IsNullOrEmpty(txtSenha.Text))
            {
                retorno = false;
            }
            else
            {
                retorno = true;
            }
            return retorno;
        }

        public void LimparCampos()
        {
            txtUsuario.Clear();
            txtSenha.Clear();
        }

        private Usuario PreencherUsuario(Usuario usuario)
        {
            usuario.Nome = txtUsuario.Text;
            usuario.Senha = txtSenha.Text;
            return usuario;
        }

        private bool VerificarUsuario(Usuario usuario)
        {
            IList<Usuario> lista = new List<Usuario>();
            lista = repositorioFuncionario.CarregarUsuarios();
            if (lista.Where(f => f.Nome.Equals(usuario.Nome)).Where(f => f.Senha.Equals(usuario.Senha)).Count() > 0)
                return true;
            else
            {
                return false;
            }
        }

        public bool EfetuarLogin()
        {
            bool sucesso = false;
            if (VerificarCampos())
            {
                usuario = new Usuario();
                usuario = PreencherUsuario(usuario);
                if (VerificarUsuario(usuario))
                    sucesso = true;
                else
                    sucesso = false;
            }
            return sucesso;
        }

    }
}
