using ProjetoControleEstoque.Model.dominio;
using ProjetoControleEstoque.Model.utilitario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.repositorio
{
    public class RepositorioMesa : RepositorioBase<Mesa>
    {
        public override bool Atualizar(Mesa obj)
        {
            throw new NotImplementedException();
        }

        public override void Remover(Mesa obj)
        {
            throw new NotImplementedException();
        }

        public override bool Salvar(Mesa mesa)
        {
            SqlTransaction transacao = null;
            bool retorno = false;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_ins_mesa", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id_mes", SqlDbType.Int)).Value = mesa.Numero_Mesa;
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
    }
}
