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
    public class RepositorioPedido : RepositorioBase<Pedido>
    {
        #region Abstract Methods

        public override bool Atualizar(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public override bool Remover(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public override bool Salvar(Pedido pedido)
        {
            bool retorno = false;
            SqlTransaction transacao = null;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_ins_pedido", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@data_ped", SqlDbType.Date)).Value = pedido.Data;
                cmd.Parameters.Add(new SqlParameter("@horario_ped", SqlDbType.Time)).Value = pedido.Horario;
                cmd.Parameters.Add(new SqlParameter("@status_ped", SqlDbType.Int)).Value = pedido.Status;
                cmd.Parameters.Add(new SqlParameter("@vltotal_ped", SqlDbType.VarChar)).Value = pedido.VlTotal;
                cmd.Parameters.Add(new SqlParameter("@id_mes", SqlDbType.Int)).Value = pedido.Id_mesa;
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


        public void PreencherMesa(ComboBox combobox)
        {
            SqlCommand cmd = new SqlCommand("select id_mes from mesa", Conexao.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            combobox.DataSource = dt;
            combobox.ValueMember = "id_mes";
            combobox.DisplayMember = "id_mes";
        }

        #region Temporary Methods

        public bool SalvarItemPedidoTemporariamente(ItemPedido itemPedido)
        {
            bool retorno = false;
            SqlTransaction transacao = null;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_ins_item_pedido_temp", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id_cardapio", SqlDbType.Int)).Value = itemPedido.Id_cardapio;
                cmd.Parameters.Add(new SqlParameter("@quantidade", SqlDbType.Int)).Value = itemPedido.Quantidade;
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

        public bool SalvarItemPedidoTemporariamenteParaAlterar(ItemPedido itemPedido)
        {
            bool retorno = false;
            SqlTransaction transacao = null;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_ins_temp_item_pedido", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id_pedido", SqlDbType.Int)).Value = itemPedido.Id_pedido;
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

        public bool AtualizarItemPedidoTemporariamente(ItemPedido itemPedido)
        {
            bool retorno = false;
            SqlTransaction transacao = null;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_upd_item_pedido_temp", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id_cardapio", SqlDbType.Int)).Value = itemPedido.Id_cardapio;
                cmd.Parameters.Add(new SqlParameter("@quantidade", SqlDbType.Int)).Value = itemPedido.Quantidade;
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

        public void RemoverItemPedidoTemporariamente(ItemPedido itemPedido)
        {
            SqlTransaction transacao = null;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_delitem_item_pedido_temp", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@ordem", SqlDbType.Int)).Value = itemPedido.Id_pedido;
                cmd.Parameters.Add(new SqlParameter("@id_cardapio", SqlDbType.Int)).Value = itemPedido.Id_cardapio;
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

        public IList<ItemPedido> CarregarItensPedidoTemporarios()
        {
            ItemPedido itemPedido;
            SqlCommand cmd = new SqlCommand("select * from item_pedido_temp", Conexao.connection);
            Conexao.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<ItemPedido> listaItensPedido = new List<ItemPedido>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    itemPedido = new ItemPedido();
                    itemPedido.Id_pedido = (int)(dr[0]);
                    itemPedido.Id_cardapio = (int)(dr[1]);
                    itemPedido.Quantidade = (int)(dr[2]);
                    listaItensPedido.Add(itemPedido);
                }
            }
            Conexao.Close();
            return listaItensPedido;
        }

        public void RemoverTodosItensPedidoTemporariamente()
        {
            SqlTransaction transacao = null;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_deltodos_item_pedido_temp", Conexao.connection, transacao);
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

        public string CalcularValorTotal()
        {
            SqlCommand cmd = new SqlCommand("select sum(t2.preco_car * t1.quantidade)  from item_pedido_temp t1 " +
                "inner join cardapio t2 on t1.id_car = t2.id_car", Conexao.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string total;
            if (dt.Rows[0].ItemArray[0].ToString() != null)
            {
                total = dt.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                total = string.Empty;
            }
            return total;
        }

        #endregion
    }
}
