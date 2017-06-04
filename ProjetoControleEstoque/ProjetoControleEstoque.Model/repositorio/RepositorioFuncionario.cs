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
    public class RepositorioFuncionario : RepositorioBase<Funcionario>
    {

        public override bool Atualizar(Funcionario obj)
        {
            return true;
        }

        public override void Remover(Funcionario obj)
        {
            throw new NotImplementedException();
        }

        public override bool Salvar(Funcionario entidade)
        {
            throw new NotImplementedException();
        }


        public bool Salvar(Funcionario funcionario, Usuario usuario)
        {
            SqlTransaction transacao = null;
            bool retorno = false;
            try
            {
                Conexao.Open();
                transacao = Conexao.connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("proc_ins_funcionario", Conexao.connection, transacao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@nome_fun", SqlDbType.VarChar)).Value = funcionario.Nome;
                cmd.Parameters.Add(new SqlParameter("@cpf_fun", SqlDbType.BigInt)).Value = funcionario.Cpf;
                cmd.Parameters.Add(new SqlParameter("@email_fun", SqlDbType.VarChar)).Value = funcionario.Email;
                cmd.Parameters.Add(new SqlParameter("@telefone_fun", SqlDbType.BigInt)).Value = funcionario.Telefone;
                cmd.Parameters.Add(new SqlParameter("@id_car", SqlDbType.Int)).Value = funcionario.Id_cargo;
                cmd.Parameters.Add(new SqlParameter("@nome_usu", SqlDbType.VarChar)).Value = usuario.Nome_Usuario;
                cmd.Parameters.Add(new SqlParameter("@senha_usu", SqlDbType.VarChar)).Value = usuario.Senha;
                cmd.Parameters.Add(new SqlParameter("@id_niv", SqlDbType.Int)).Value = usuario.Nivel_Acesso;
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

        public void PreencherCargo(ComboBox combobox)
        {
            SqlCommand cmd = new SqlCommand("select id_car,nome_car from cargo order by nome_car asc", Conexao.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            combobox.DataSource = dt;
            combobox.ValueMember = "id_car";
            combobox.DisplayMember = "nome_car";
            combobox.SelectedValue = 0;
        }

        public void PreencherNivelAcesso(ComboBox combobox)
        {
            SqlCommand cmd = new SqlCommand("select id_niv,nome_niv from nivel_acesso order by nome_niv asc", Conexao.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            combobox.DataSource = dt;
            combobox.ValueMember = "id_niv";
            combobox.DisplayMember = "nome_niv";
            combobox.SelectedValue = 0;
        }
    }
}
