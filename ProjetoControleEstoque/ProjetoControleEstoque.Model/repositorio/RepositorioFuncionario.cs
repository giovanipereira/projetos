using ProjetoControleEstoque.Model.dominio;
using ProjetoControleEstoque.Model.utilitario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace ProjetoControleEstoque.Model.repositorio
{
    public class RepositorioFuncionario : RepositorioBase<Funcionario>
    {

        #region Abstract Methods

        public override bool Atualizar(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public override bool Salvar(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public override bool Remover(Funcionario funcionario)
        {
            SqlTransaction transacao = null;
            bool retorno = false;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_del_funcionario", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id_fun", SqlDbType.Int)).Value = funcionario.Id;
                cmd.Parameters.Add(new SqlParameter("@id_usu", SqlDbType.Int)).Value = funcionario.Id_Usuario;
                cmd.ExecuteNonQuery();
                transacao.Commit();
                retorno = true;
            }
            catch (Exception e)
            {
                if (transacao != null)
                    transacao.Rollback();
                retorno = false;
                throw e;
            }
            finally
            {
                Conexao.Close();
            }
            return retorno;
        }

        #endregion

        #region Public Methods

        public bool Atualizar(Funcionario funcionario, Usuario usuario)
        {
            SqlTransaction transacao = null;
            bool retorno = false;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_upd_funcionario", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id_fun", SqlDbType.Int)).Value = funcionario.Id;
                cmd.Parameters.Add(new SqlParameter("@nome_fun", SqlDbType.VarChar)).Value = funcionario.Nome;
                cmd.Parameters.Add(new SqlParameter("@cpf_fun", SqlDbType.BigInt)).Value = funcionario.Cpf;
                cmd.Parameters.Add(new SqlParameter("@email_fun", SqlDbType.VarChar)).Value = funcionario.Email;
                cmd.Parameters.Add(new SqlParameter("@telefone_fun", SqlDbType.BigInt)).Value = funcionario.Telefone;
                cmd.Parameters.Add(new SqlParameter("@id_car", SqlDbType.Int)).Value = funcionario.Id_cargo;
                cmd.Parameters.Add(new SqlParameter("@id_usu", SqlDbType.Int)).Value = funcionario.Id_Usuario;
                cmd.Parameters.Add(new SqlParameter("@nome_usu", SqlDbType.VarChar)).Value = usuario.Nome;
                cmd.Parameters.Add(new SqlParameter("@senha_usu", SqlDbType.VarChar)).Value = usuario.Senha;
                cmd.Parameters.Add(new SqlParameter("@id_niv", SqlDbType.Int)).Value = usuario.Id_nivel_acesso;
                cmd.ExecuteNonQuery();
                transacao.Commit();
                retorno = true;
            }
            catch (Exception e)
            {
                if (transacao != null)
                    transacao.Rollback();
                retorno = false;
                throw e;
            }
            finally
            {
                Conexao.Close();
            }
            return retorno;
        }

        public bool Salvar(Funcionario funcionario, Usuario usuario)
        {
            SqlTransaction transacao = null;
            bool retorno = false;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_ins_funcionario", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@nome_fun", SqlDbType.VarChar)).Value = funcionario.Nome;
                cmd.Parameters.Add(new SqlParameter("@cpf_fun", SqlDbType.BigInt)).Value = funcionario.Cpf;
                cmd.Parameters.Add(new SqlParameter("@email_fun", SqlDbType.VarChar)).Value = funcionario.Email;
                cmd.Parameters.Add(new SqlParameter("@telefone_fun", SqlDbType.BigInt)).Value = funcionario.Telefone;
                cmd.Parameters.Add(new SqlParameter("@id_car", SqlDbType.Int)).Value = funcionario.Id_cargo;
                cmd.Parameters.Add(new SqlParameter("@nome_usu", SqlDbType.VarChar)).Value = usuario.Nome;
                cmd.Parameters.Add(new SqlParameter("@senha_usu", SqlDbType.VarChar)).Value = usuario.Senha;
                cmd.Parameters.Add(new SqlParameter("@id_niv", SqlDbType.Int)).Value = usuario.Id_nivel_acesso;
                cmd.ExecuteNonQuery();
                transacao.Commit();
                retorno = true;
            }
            catch (Exception e)
            {
                if (transacao != null)
                    transacao.Rollback();
                retorno = false;
                throw e;
            }
            finally
            {
                Conexao.Close();
            }
            return retorno;
        }

        public IList<NivelAcesso> CarregarNiveisAcessos()
        {
            NivelAcesso nivelAcesso;
            SqlCommand cmd = new SqlCommand("select * from nivel_acesso", Conexao.connection);
            Conexao.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<NivelAcesso> listaNiveisAcessos = new List<NivelAcesso>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    nivelAcesso = new NivelAcesso();
                    nivelAcesso.Id = (int)(dr[0]);
                    nivelAcesso.Nome = (dr[1]).ToString();
                    listaNiveisAcessos.Add(nivelAcesso);
                }
            }
            Conexao.Close();
            return listaNiveisAcessos;
        }

        public IList<Usuario> CarregarUsuarios()
        {
            Usuario usuario;
            SqlCommand cmd = new SqlCommand("select * from usuario", Conexao.connection);
            Conexao.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Usuario> listaUsuarios = new List<Usuario>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    usuario = new Usuario();
                    usuario.Id = (int)(dr[0]);
                    usuario.Nome = (dr[1]).ToString();
                    usuario.Senha = (dr[2]).ToString();
                    usuario.Id_nivel_acesso = (int)(dr[3]);
                    listaUsuarios.Add(usuario);
                }
            }
            Conexao.Close();
            return listaUsuarios;
        }

        public IList<Cargo> CarregarCargos()
        {
            Cargo cargo;
            SqlCommand cmd = new SqlCommand("select * from cargo", Conexao.connection);
            Conexao.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Cargo> listaCargos = new List<Cargo>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cargo = new Cargo();
                    cargo.Id = (int)(dr[0]);
                    cargo.Nome = (dr[1]).ToString();
                    listaCargos.Add(cargo);
                }
            }
            Conexao.Close();
            return listaCargos;
        }

        public IList<Funcionario> CarregarFuncionarios()
        {
            Funcionario funcionario;
            SqlCommand cmd = new SqlCommand("select * from funcionario", Conexao.connection);
            Conexao.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Funcionario> listaFuncionarios = new List<Funcionario>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    funcionario = new Funcionario();
                    funcionario.Id = (int)(dr[0]);
                    funcionario.Nome = (dr[1]).ToString();
                    funcionario.Cpf = (long)(dr[2]);
                    funcionario.Email = (dr[3]).ToString();
                    funcionario.Telefone = (long)(dr[4]);
                    funcionario.Id_cargo = (int)(dr[5]);
                    funcionario.Id_Usuario = (int)(dr[6]);
                    listaFuncionarios.Add(funcionario);
                }
            }
            Conexao.Close();
            return listaFuncionarios;
        }

        public void PreencherCargo(ComboBox combobox)
        {
            SqlCommand cmd = new SqlCommand("select id_car,nome_car from cargo order by nome_car asc", Conexao.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            combobox.DataSource = dt;
            combobox.ValueMember = "id_car";
            combobox.DisplayMember = "nome_car";
        }

        public void PreencherNivelAcesso(ComboBox combobox)
        {
            SqlCommand cmd = new SqlCommand("select id_niv,nome_niv from nivel_acesso order by nome_niv asc", Conexao.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            combobox.DataSource = dt;
            combobox.ValueMember = "id_niv";
            combobox.DisplayMember = "nome_niv";
        }

        #endregion

    }
}
