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
    public class RepositorioSubcategoria : RepositorioBase<Subcategoria>
    {
        public override bool Atualizar(Subcategoria obj)
        {
            throw new NotImplementedException();
        }

        public override void Remover(Subcategoria obj)
        {
            throw new NotImplementedException();
        }

        public override bool Salvar(Subcategoria subcategoria)
        {
            SqlTransaction transacao = null;
            bool retorno = false;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_ins_subcategoria", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@nome_sub", SqlDbType.VarChar)).Value = subcategoria.Nome;
                cmd.Parameters.Add(new SqlParameter("@id_cat", SqlDbType.Int)).Value = subcategoria.Categoria;
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
            SqlCommand cmd = new SqlCommand("select id_cat, nome_cat from categoria", Conexao.connection);
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
