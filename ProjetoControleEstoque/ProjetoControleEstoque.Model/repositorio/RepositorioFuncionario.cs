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
            return true;
        }

        public static void PreencherComboBox(ComboBox combobox)
        {
            SqlCommand cmd = new SqlCommand("select id, nome from cargo", Conexao.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            combobox.ValueMember = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            combobox.DisplayMember = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            combobox.SelectedIndex = 0;
        }
    }
}
