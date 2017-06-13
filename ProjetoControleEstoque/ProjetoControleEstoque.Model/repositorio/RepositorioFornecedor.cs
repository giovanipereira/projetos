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
        public override bool Atualizar(Fornecedor fornecedor)
        {
            throw new NotImplementedException();
        }

        public override void Remover(Fornecedor fornecedor)
        {
            throw new NotImplementedException();
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

        public void PreencherUf(ComboBox combobox)
        {
            SqlCommand cmd = new SqlCommand("select id_uf, sigla_uf from estado", Conexao.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            combobox.DataSource = dt;
            combobox.ValueMember = "id_uf";
            combobox.DisplayMember = "sigla_uf";
            combobox.SelectedValue = 0;
        }
    }
}
