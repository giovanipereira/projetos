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

        public static DialogResult MensagemQuestao(string mensagem)
        {
            if (MessageBox.Show(mensagem, "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                return DialogResult.Yes;
            else
                return DialogResult.No;
        }

        public static void MensagemExclusao()
        {
            MessageBox.Show("Excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MensagemAtualizar()
        {
            MessageBox.Show("Atualizado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MensagemEmpty(string campo)
        {
            MessageBox.Show("Campo "+ campo + " é obrigatório.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
