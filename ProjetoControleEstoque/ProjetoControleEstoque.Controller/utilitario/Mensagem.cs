using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleEstoque.Controller.utility
{
    public static class Mensagem
    { 

        public static void MensagemSalvar()
        {
            MessageBox.Show("Cadastrado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool MensagemQuestao(string message)
        {
            if (MessageBox.Show(message, "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                return true;
            else
                return false;
        }

        public static void MensagemExclusao()
        {
            MessageBox.Show("Excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MensagemAtualizar()
        {
            MessageBox.Show("Atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MensagemObrigatoriedade()
        {

        }

    }
}
