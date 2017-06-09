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
        public override bool Atualizar(Cardapio obj)
        {
            throw new NotImplementedException();
        }

        public override void Remover(Cardapio obj)
        {
            throw new NotImplementedException();
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
                cmd.Parameters.Add(new SqlParameter("@preco_car", SqlDbType.Decimal)).Value = cardapio.Preco;
                cmd.Parameters.Add(new SqlParameter("@figura_car", SqlDbType.VarChar)).Value = cardapio.Figura;
                cmd.Parameters.Add(new SqlParameter("@descricao_car", SqlDbType.VarChar)).Value = cardapio.Descricao;
                cmd.Parameters.Add(new SqlParameter("@id_cat", SqlDbType.Int)).Value = cardapio.Id_categoria;
                var id_car = cmd.ExecuteScalar();
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
            SqlCommand cmd = new SqlCommand("select id_cat, nome_cat from categoria_cardapio", Conexao.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            combobox.DataSource = dt;
            combobox.ValueMember = "id_cat";
            combobox.DisplayMember = "nome_cat";
            combobox.SelectedValue = 0;
        }
    }
}
