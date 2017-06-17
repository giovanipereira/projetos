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

namespace ProjetoControleEstoque.Model.repositorio
{
    public class RepositorioFornecedor : RepositorioBase<Fornecedor>
    {
        #region Abstract Methods

        public override bool Atualizar(Fornecedor fornecedor)
        {
            SqlTransaction transacao = null;
            bool retorno = false;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_upd_fornecedor", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id_for", SqlDbType.Int)).Value = fornecedor.Id;
                cmd.Parameters.Add(new SqlParameter("@nome_for", SqlDbType.VarChar)).Value = fornecedor.Nome;
                cmd.Parameters.Add(new SqlParameter("@cnpj_for", SqlDbType.BigInt)).Value = fornecedor.Cnpj;
                cmd.Parameters.Add(new SqlParameter("@endereco_for", SqlDbType.VarChar)).Value = fornecedor.Endereco;
                cmd.Parameters.Add(new SqlParameter("@complemeto_for", SqlDbType.VarChar)).Value = fornecedor.Complemento;
                cmd.Parameters.Add(new SqlParameter("@bairro_for", SqlDbType.VarChar)).Value = fornecedor.Bairro;
                cmd.Parameters.Add(new SqlParameter("@cidade_for", SqlDbType.VarChar)).Value = fornecedor.Cidade;
                cmd.Parameters.Add(new SqlParameter("@ativo_for", SqlDbType.Bit)).Value = fornecedor.Ativo;
                cmd.Parameters.Add(new SqlParameter("@cep_for", SqlDbType.BigInt)).Value = fornecedor.Cep;
                cmd.Parameters.Add(new SqlParameter("@telefone_for", SqlDbType.BigInt)).Value = fornecedor.Telefone;
                cmd.Parameters.Add(new SqlParameter("@email_for", SqlDbType.VarChar)).Value = fornecedor.Email;
                cmd.Parameters.Add(new SqlParameter("@id_uf", SqlDbType.Int)).Value = fornecedor.Id_uf;
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

        public override bool Remover(Fornecedor fornecedor)
        {
            SqlTransaction transacao = null;
            bool retorno = false;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_del_fornecedor", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id_for", SqlDbType.Int)).Value = fornecedor.Id;
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

        public override bool Salvar(Fornecedor fornecedor)
        {
            SqlTransaction transacao = null;
            bool retorno = false;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_ins_fornecedor", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@nome_for", SqlDbType.VarChar)).Value = fornecedor.Nome;
                cmd.Parameters.Add(new SqlParameter("@cnpj_for", SqlDbType.BigInt)).Value = fornecedor.Cnpj;
                cmd.Parameters.Add(new SqlParameter("@endereco_for", SqlDbType.VarChar)).Value = fornecedor.Endereco;
                cmd.Parameters.Add(new SqlParameter("@complemeto_for", SqlDbType.VarChar)).Value = fornecedor.Complemento;
                cmd.Parameters.Add(new SqlParameter("@bairro_for", SqlDbType.VarChar)).Value = fornecedor.Bairro;
                cmd.Parameters.Add(new SqlParameter("@cidade_for", SqlDbType.VarChar)).Value = fornecedor.Cidade;
                cmd.Parameters.Add(new SqlParameter("@ativo_for", SqlDbType.Bit)).Value = fornecedor.Ativo;
                cmd.Parameters.Add(new SqlParameter("@cep_for", SqlDbType.BigInt)).Value = fornecedor.Cep;
                cmd.Parameters.Add(new SqlParameter("@telefone_for", SqlDbType.BigInt)).Value = fornecedor.Telefone;
                cmd.Parameters.Add(new SqlParameter("@email_for", SqlDbType.VarChar)).Value = fornecedor.Email;
                cmd.Parameters.Add(new SqlParameter("@id_uf", SqlDbType.Int)).Value = fornecedor.Id_uf;
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

        public IList<Fornecedor> CarregarFornecedores()
        {
            Fornecedor fornecedor;
            SqlCommand cmd = new SqlCommand("select * from fornecedor", Conexao.connection);
            Conexao.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Fornecedor> listaFornecedores = new List<Fornecedor>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    fornecedor = new Fornecedor();
                    fornecedor.Id = (int)(dr[0]);
                    fornecedor.Nome = (dr[1]).ToString();
                    fornecedor.Cnpj = (long)(dr[2]);
                    fornecedor.Endereco = (dr[3]).ToString();
                    fornecedor.Complemento = (dr[4]).ToString();
                    fornecedor.Bairro = (dr[5]).ToString();
                    fornecedor.Cidade = (dr[6]).ToString();
                    fornecedor.Ativo = Convert.ToBoolean(dr[7]);
                    fornecedor.Cep = (long)(dr[8]);
                    fornecedor.Telefone = (long)(dr[9]);
                    fornecedor.Email = (dr[10]).ToString();
                    fornecedor.Id_uf = (int)(dr[11]);
                    listaFornecedores.Add(fornecedor);
                }
            }
            Conexao.Close();
            return listaFornecedores;

        }

        public IList<Estado> CarregarEstados()
        {
            Estado estado;
            SqlCommand cmd = new SqlCommand("select * from estado", Conexao.connection);
            Conexao.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Estado> listaEstados = new List<Estado>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    estado = new Estado();
                    estado.Id = (int)(dr[0]);
                    estado.Sigla = (dr[1]).ToString();
                    estado.Descricao = (dr[2]).ToString();
                    listaEstados.Add(estado);
                }
            }
            Conexao.Close();
            return listaEstados;
        }

        public void PreencherUf(ComboBox combobox)
        {
            SqlCommand cmd = new SqlCommand("select id_uf, sigla_uf from estado", Conexao.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            combobox.DataSource = dt;
            combobox.ValueMember = "id_uf";
            combobox.DisplayMember = "sigla_uf";
        }

        #endregion

    }
}
