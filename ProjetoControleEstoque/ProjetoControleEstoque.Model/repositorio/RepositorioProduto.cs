using ProjetoControleEstoque.Model.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ProjetoControleEstoque.Model.utilitario;
using System.Windows.Forms;

namespace ProjetoControleEstoque.Model.repositorio
{
    public class RepositorioProduto : RepositorioBase<Produto>
    {
        #region Abstract Methods

        public override bool Atualizar(Produto produto)
        {
            SqlTransaction transacao = null;
            bool retorno = false;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_upd_produto", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id_pro", SqlDbType.Int)).Value = produto.Id;
                cmd.Parameters.Add(new SqlParameter("@nome_pro", SqlDbType.VarChar)).Value = produto.Nome;
                cmd.Parameters.Add(new SqlParameter("@vlunitario_pro", SqlDbType.VarChar)).Value = produto.Vlunitario;
                cmd.Parameters.Add(new SqlParameter("@qtd_estoque_pro", SqlDbType.Int)).Value = produto.Qtd_estoque;
                cmd.Parameters.Add(new SqlParameter("@qtd_minima_pro", SqlDbType.Int)).Value = produto.Qtd_minima;
                cmd.Parameters.Add(new SqlParameter("@qtd_maxima_pro", SqlDbType.Int)).Value = produto.Qtd_maxima;
                cmd.Parameters.Add(new SqlParameter("@quantidade_pro", SqlDbType.VarChar)).Value = produto.Quantidade;
                cmd.Parameters.Add(new SqlParameter("@dt_validade_pro", SqlDbType.Date)).Value = produto.Data_validade;
                cmd.Parameters.Add(new SqlParameter("@descricao_pro", SqlDbType.VarChar)).Value = produto.Descricao;
                cmd.Parameters.Add(new SqlParameter("@id_sub", SqlDbType.Int)).Value = produto.Id_subcategoria;
                cmd.Parameters.Add(new SqlParameter("@id_for", SqlDbType.Int)).Value = produto.Id_fornecedor;
                cmd.Parameters.Add(new SqlParameter("@id_uni", SqlDbType.Int)).Value = produto.Id_unidade;
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

        public override bool Remover(Produto produto)
        {
            SqlTransaction transacao = null;
            bool retorno = false;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_del_produto", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id_pro", SqlDbType.Int)).Value = produto.Id;
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

        public override bool Salvar(Produto produto)
        {
            SqlTransaction transacao = null;
            bool retorno = false;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_ins_produto", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@nome_pro", SqlDbType.VarChar)).Value = produto.Nome;
                cmd.Parameters.Add(new SqlParameter("@vlunitario_pro", SqlDbType.VarChar)).Value = produto.Vlunitario;
                cmd.Parameters.Add(new SqlParameter("@qtd_estoque_pro", SqlDbType.Int)).Value = produto.Qtd_estoque;
                cmd.Parameters.Add(new SqlParameter("@qtd_minima_pro", SqlDbType.Int)).Value = produto.Qtd_minima;
                cmd.Parameters.Add(new SqlParameter("@qtd_maxima_pro", SqlDbType.Int)).Value = produto.Qtd_maxima;
                cmd.Parameters.Add(new SqlParameter("@quantidade_pro", SqlDbType.VarChar)).Value = produto.Quantidade;
                cmd.Parameters.Add(new SqlParameter("@dt_validade_pro", SqlDbType.Date)).Value = produto.Data_validade;
                cmd.Parameters.Add(new SqlParameter("@descricao_pro", SqlDbType.VarChar)).Value = produto.Descricao;
                cmd.Parameters.Add(new SqlParameter("@id_sub", SqlDbType.Int)).Value = produto.Id_subcategoria;
                cmd.Parameters.Add(new SqlParameter("@id_for", SqlDbType.Int)).Value = produto.Id_fornecedor;
                cmd.Parameters.Add(new SqlParameter("@id_uni", SqlDbType.Int)).Value = produto.Id_unidade;
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

        public IList<Produto> CarregarProdutos()
        {
            Produto produto;
            SqlCommand cmd = new SqlCommand("select * from produto", Conexao.connection);
            Conexao.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Produto> listaProdutos = new List<Produto>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    produto = new Produto();
                    produto.Id = (int) (dr[0]);
                    produto.Nome = (dr[1]).ToString();
                    produto.Vlunitario = (dr[2]).ToString();
                    produto.Qtd_estoque = (int) (dr[3]);
                    produto.Qtd_minima = (int) (dr[4]);
                    produto.Qtd_maxima = (int)(dr[5]);
                    produto.Quantidade = (dr[6]).ToString();
                    produto.Data_validade = (DateTime)(dr[7]);
                    produto.Descricao = (dr[8].ToString());
                    produto.Id_subcategoria = (int)(dr[9]);
                    produto.Id_fornecedor = (int)(dr[10]);
                    produto.Id_unidade = (int)(dr[11]);
                    listaProdutos.Add(produto);
                }
            }
            Conexao.Close();
            return listaProdutos;
        }

        public IList<Unidade> CarregarUnidades()
        {
            Unidade unidade;
            SqlCommand cmd = new SqlCommand("select * from unidade", Conexao.connection);
            Conexao.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Unidade> listaUnidades = new List<Unidade>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    unidade = new Unidade();
                    unidade.Id = (int)(dr[0]);
                    unidade.Nome = (dr[1]).ToString();
                    unidade.Sigla = (dr[2]).ToString();
                    listaUnidades.Add(unidade);
                }
            }
            Conexao.Close();
            return listaUnidades;
        }

        public IList<Subcategoria> CarregarSubcategorias()
        {
            Subcategoria subcategoria;
            SqlCommand cmd = new SqlCommand("select * from subcategoria", Conexao.connection);
            Conexao.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Subcategoria> listaSubcategorias = new List<Subcategoria>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    subcategoria = new Subcategoria();
                    subcategoria.Id = (int)(dr[0]);
                    subcategoria.Nome = (dr[1]).ToString();
                    subcategoria.Id_categoria = (int)(dr[2]);
                    listaSubcategorias.Add(subcategoria);
                }
            }
            Conexao.Close();
            return listaSubcategorias;
        }

        public IList<Categoria> CarregarCategorias()
        {
            Categoria categoria;
            SqlCommand cmd = new SqlCommand("select * from categoria", Conexao.connection);
            Conexao.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Categoria> listaCategorias = new List<Categoria>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    categoria = new Categoria();
                    categoria.Id = (int)(dr[0]);
                    categoria.Nome = (dr[1]).ToString();
                    listaCategorias.Add(categoria);
                }
            }
            Conexao.Close();
            return listaCategorias;
        }

        public void PreencherCategoria(ComboBox combobox)
        {
            SqlCommand cmd = new SqlCommand("select id_cat,nome_cat from categoria order by nome_cat asc", Conexao.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            combobox.DataSource = dt;
            combobox.ValueMember = "id_cat";
            combobox.DisplayMember = "nome_cat";
        }

        public void PreencherUnidade(ComboBox combobox)
        {
            SqlCommand cmd = new SqlCommand("select id_uni,nome_uni from unidade order by nome_uni asc", Conexao.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            combobox.DataSource = dt;
            combobox.ValueMember = "id_uni";
            combobox.DisplayMember = "nome_uni";
        }

        public void PreencherFornecedor(ComboBox combobox)
        {

            SqlCommand cmd = new SqlCommand("select id_for,nome_for from fornecedor where ativo_for = 1 order by nome_for asc", Conexao.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Conexao.Open();
            combobox.DataSource = dt;
            combobox.ValueMember = "id_for";
            combobox.DisplayMember = "nome_for";
        }

        public void PreencherSubcategoria(ComboBox combobox, int id_categoria)
        {
            SqlCommand cmd = new SqlCommand("select id_sub,nome_sub from subcategoria where id_cat = @id_cat", Conexao.connection);
            cmd.Parameters.Add(new SqlParameter("@id_cat", SqlDbType.Int)).Value = id_categoria;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Conexao.Open();
            combobox.DataSource = dt;
            combobox.ValueMember = "id_sub";
            combobox.DisplayMember = "nome_sub";
            combobox.SelectedValue = 0;
        }
    }
}
