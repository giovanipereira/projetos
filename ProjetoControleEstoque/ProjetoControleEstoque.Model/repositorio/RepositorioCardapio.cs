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
    public class RepositorioCardapio : RepositorioBase<Cardapio>
    {
        #region Abstract Methods

        public override bool Atualizar(Cardapio cardapio)
        {
            SqlTransaction transacao = null;
            bool retorno = false;

            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_upd_cardapio", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id_car", SqlDbType.Int)).Value = cardapio.Id;
                cmd.Parameters.Add(new SqlParameter("@nome_car", SqlDbType.VarChar)).Value = cardapio.Nome;
                cmd.Parameters.Add(new SqlParameter("@preco_car", SqlDbType.VarChar)).Value = cardapio.Preco;
                cmd.Parameters.Add(new SqlParameter("@figura_car", SqlDbType.VarChar)).Value = cardapio.Figura;
                cmd.Parameters.Add(new SqlParameter("@descricao_car", SqlDbType.VarChar)).Value = cardapio.Descricao;
                cmd.Parameters.Add(new SqlParameter("@id_cat", SqlDbType.Int)).Value = cardapio.Id_categoria;
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

        public override bool Salvar(Cardapio cardapio)
        {
            SqlTransaction transacao = null;
            bool retorno = false;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_ins_cardapio", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@nome_car", SqlDbType.VarChar)).Value = cardapio.Nome;
                cmd.Parameters.Add(new SqlParameter("@preco_car", SqlDbType.VarChar)).Value = cardapio.Preco;
                cmd.Parameters.Add(new SqlParameter("@figura_car", SqlDbType.VarChar)).Value = cardapio.Figura;
                cmd.Parameters.Add(new SqlParameter("@descricao_car", SqlDbType.VarChar)).Value = cardapio.Descricao;
                cmd.Parameters.Add(new SqlParameter("@id_cat", SqlDbType.Int)).Value = cardapio.Id_categoria;
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

        public override bool Remover(Cardapio cardapio)
        {
            SqlTransaction transacao = null;
            bool retorno = false;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_del_cardapio", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id_car", SqlDbType.Int)).Value = cardapio.Id;
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

        public void PreencherCategoria(ComboBox combobox)
        {
            SqlCommand cmd = new SqlCommand("select id_cat, nome_cat from categoria_cardapio", Conexao.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            combobox.DataSource = dt;
            combobox.ValueMember = "id_cat";
            combobox.DisplayMember = "nome_cat";
        }

        public IList<ItemCardapio> CarregarItensCardapios()
        {
            ItemCardapio itemCardapio;
            SqlCommand cmd = new SqlCommand("select * from item_cardapio", Conexao.connection);
            Conexao.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<ItemCardapio> listaItensCardapio = new List<ItemCardapio>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    itemCardapio = new ItemCardapio();
                    itemCardapio.Id_cardapio = (int)(dr[0]);
                    itemCardapio.Id_produto = (int)(dr[1]);
                    itemCardapio.Quantidade = (dr[2]).ToString();
                    listaItensCardapio.Add(itemCardapio);
                }
            }
            Conexao.Close();
            return listaItensCardapio;
        }

        public IList<Cardapio> CarregarCardapios()
        {
            Cardapio cardapio;
            SqlCommand cmd = new SqlCommand("select * from cardapio", Conexao.connection);
            Conexao.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Cardapio> listaCardapios = new List<Cardapio>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cardapio = new Cardapio();
                    cardapio.Id = (int)(dr[0]);
                    cardapio.Nome = (dr[1]).ToString();
                    cardapio.Preco = (dr[2]).ToString();
                    cardapio.Figura = (dr[3]).ToString();
                    cardapio.Descricao = (dr[4]).ToString();
                    cardapio.Id_categoria = (int)(dr[5]);
                    listaCardapios.Add(cardapio);
                }
            }
            Conexao.Close();
            return listaCardapios;
        }

        public IList<CategoriaCardapio> CarregarCategorias()
        {
            CategoriaCardapio categoria;
            SqlCommand cmd = new SqlCommand("select * from categoria_cardapio", Conexao.connection);
            Conexao.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<CategoriaCardapio> listaCategorias = new List<CategoriaCardapio>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    categoria = new CategoriaCardapio();
                    categoria.Id = (int)(dr[0]);
                    categoria.Nome = (dr[1]).ToString();
                    listaCategorias.Add(categoria);
                }
            }
            Conexao.Close();
            return listaCategorias;
        }

        #endregion

        #region Temporary Methods

        public bool SalvarItemCardapioTemporariamenteParaAlterar(Cardapio Cardapio)
        {
            bool retorno = false;
            SqlTransaction transacao = null;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_ins_temp_item_cardapio", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id_cardapio", SqlDbType.Int)).Value = Cardapio.Id;
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

        public bool SalvarItemCardapioTemporariamente(ItemCardapio itemCardapio)
        {
            bool retorno = false;
            SqlTransaction transacao = null;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_ins_item_cardapio_temp", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id_produto", SqlDbType.Int)).Value = itemCardapio.Id_produto;
                cmd.Parameters.Add(new SqlParameter("@quantidade", SqlDbType.VarChar)).Value = itemCardapio.Quantidade;
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

        public bool AtualizarItemCardapioTemporariamente(ItemCardapio itemCardapio)
        {
            bool retorno = false;
            SqlTransaction transacao = null;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_upd_item_cardapio_temp", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id_produto", SqlDbType.Int)).Value = itemCardapio.Id_produto;
                cmd.Parameters.Add(new SqlParameter("@quantidade", SqlDbType.VarChar)).Value = itemCardapio.Quantidade;
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

        public void RemoverTodosItensCardapioTemporariamente()
        {
            SqlTransaction transacao = null;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_deltodos_item_cardapio_temp", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                transacao.Commit();
            }
            catch (Exception e)
            {
                if (transacao != null)
                    transacao.Rollback();
                throw e;
            }
            finally
            {
                Conexao.Close();
            }
        }

        public void RemoverItemCardapioTemporariamente(ItemCardapio itemCardapio)
        {
            SqlTransaction transacao = null;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_delitem_item_cardapio_temp", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@ordem", SqlDbType.Int)).Value = itemCardapio.Id_cardapio;
                cmd.Parameters.Add(new SqlParameter("@id_produto", SqlDbType.Int)).Value = itemCardapio.Id_produto;
                cmd.ExecuteNonQuery();
                transacao.Commit();
            }
            catch (Exception e)
            {
                if (transacao != null)
                    transacao.Rollback();
                throw e;
            }
            finally
            {
                Conexao.Close();
            }
        }

        public IList<ItemCardapio> CarregarItensCardapiosTemporarios()
        {
            ItemCardapio itemCardapio;
            SqlCommand cmd = new SqlCommand("select * from item_cardapio_temp", Conexao.connection);
            Conexao.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<ItemCardapio> listaItensCardapio = new List<ItemCardapio>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    itemCardapio = new ItemCardapio();
                    itemCardapio.Id_cardapio = (int)(dr[0]);
                    itemCardapio.Id_produto = (int)(dr[1]);
                    itemCardapio.Quantidade = (dr[2]).ToString();
                    listaItensCardapio.Add(itemCardapio);
                }
            }
            Conexao.Close();
            return listaItensCardapio;
        }

        #endregion
    }
}
