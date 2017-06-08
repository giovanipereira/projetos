﻿using ProjetoControleEstoque.Model.dominio;
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
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_ins_produto", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@nome_pro", SqlDbType.VarChar)).Value = produto.Nome;
                cmd.Parameters.Add(new SqlParameter("@vlunitario_pro", SqlDbType.Decimal)).Value = produto.Valor_unitario;
                cmd.Parameters.Add(new SqlParameter("@qtd_estoque_pro", SqlDbType.Int)).Value = produto.Qtd_estoque;
                cmd.Parameters.Add(new SqlParameter("@qtd_minima_pro", SqlDbType.Int)).Value = produto.Qtd_minima;
                cmd.Parameters.Add(new SqlParameter("@qtd_maxima_pro", SqlDbType.Int)).Value = produto.Qtd_maxima;
                cmd.Parameters.Add(new SqlParameter("@porcao_pro", SqlDbType.Decimal)).Value = produto.Porcao_pro;
                cmd.Parameters.Add(new SqlParameter("@dt_validade_pro", SqlDbType.Date)).Value = produto.Data_validade;
                cmd.Parameters.Add(new SqlParameter("@descricao_pro", SqlDbType.VarChar)).Value = produto.Descricao;
                cmd.Parameters.Add(new SqlParameter("@qtd_fornecidas_pro", SqlDbType.Int)).Value = produto.Qtd_fornecidas;
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
        public void PreencherCategoria(ComboBox combobox)
        {
            SqlCommand cmd = new SqlCommand("select id_cat,nome_cat from categoria order by nome_cat asc", Conexao.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            combobox.DataSource = dt;
            combobox.ValueMember = "id_cat";
            combobox.DisplayMember = "nome_cat";
            combobox.SelectedValue = 0;
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
            combobox.SelectedValue = 0;
        }

        public void PreencherFornecedor(ComboBox combobox)
        {
            
            SqlCommand cmd = new SqlCommand("select id_for,nome_for from fornecedor order by nome_for asc", Conexao.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Conexao.Open();
            combobox.DataSource = dt;
            combobox.ValueMember = "id_for";
            combobox.DisplayMember = "nome_for";
            combobox.SelectedValue = 0;
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
