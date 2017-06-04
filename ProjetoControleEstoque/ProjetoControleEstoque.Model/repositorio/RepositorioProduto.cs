using ProjetoControleEstoque.Model.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ProjetoControleEstoque.Model.utilitario;

namespace ProjetoControleEstoque.Model.repositorio
{
    public class RepositorioProduto : RepositorioBase<Produto>
    {
        public override bool Atualizar(Produto obj)
        {
            throw new NotImplementedException();
        }

        public override void Remover(Produto obj)
        {
            throw new NotImplementedException();
        }

        public override bool Salvar(Produto produto)
        {
            SqlTransaction transacao = null;
            bool retorno = false;
            try
            {
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_ins_produto", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@nome_pro", SqlDbType.VarChar)).Value = produto.Nome;
                cmd.Parameters.Add(new SqlParameter("@vlcompra_pro", SqlDbType.Decimal)).Value = produto.Valor_compra;
                cmd.Parameters.Add(new SqlParameter("@qtd_estoque_pro", SqlDbType.Int)).Value = produto.Qtd_estoque;
                cmd.Parameters.Add(new SqlParameter("@qtd_minima_pro", SqlDbType.Int)).Value = produto.Qtd_minima;
                cmd.Parameters.Add(new SqlParameter("@qtd_maxima_pro", SqlDbType.Int)).Value = produto.Qtd_maxima;
                cmd.Parameters.Add(new SqlParameter("@medida_pro", SqlDbType.Decimal)).Value = produto.Medida_pro;
                cmd.Parameters.Add(new SqlParameter("@dt_validade_pro", SqlDbType.Date)).Value = produto.Data_validade;
                cmd.Parameters.Add(new SqlParameter("@descricao_pro", SqlDbType.VarChar)).Value = produto.Descricao;
                cmd.Parameters.Add(new SqlParameter("@qtd_fornecidas_pro", SqlDbType.Int)).Value = produto.Qtd_fornecidas;
                cmd.Parameters.Add(new SqlParameter("@id_sub", SqlDbType.Int)).Value = produto.Subcategoria;
                cmd.Parameters.Add(new SqlParameter("@id_for", SqlDbType.Int)).Value = produto.Fornecedor;
                cmd.Parameters.Add(new SqlParameter("@id_uni", SqlDbType.Int)).Value = produto.Unidade;
                //@id_fun integer falta o funcionario
                Conexao.Open();
                transacao.Commit();
                cmd.ExecuteNonQuery();
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
    }
}
