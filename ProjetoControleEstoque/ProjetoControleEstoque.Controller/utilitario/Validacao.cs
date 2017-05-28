using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleEstoque.Controller.utility
{
    public class Validacao
    {
        private List<Control> listaControles;

        public Validacao(List<Control> listaControles)
        {
            this.listaControles = listaControles;
        }

        // Função que limpa os controles
        public void LimparControl()
        {
            foreach (var control in listaControles)
            {
                if (control is TextBox || control is MaskedTextBox)
                {
                    if (control is TextBox)
                        ((TextBox)control).Clear();
                    else
                        ((MaskedTextBox)control).Clear();
                }
                else if (control is ComboBox)
                    ((ComboBox)control).Text = null;

                else if (control is PictureBox)
                    ((PictureBox)control).Image = null;

                else if (control is DataGridView)
                    ((DataGridView)control).Rows.Clear();

                else if (control is NumericUpDown)
                    ((NumericUpDown)control).Value = 1;
            }
        }

        // Função que habilita ou desabilita os controles dependendo do parãmetro recebido
        public void EnableControle(bool enable)
        {
            foreach (var control in listaControles)
            {
                if (control is TextBox || control is MaskedTextBox || control is ComboBox ||control is Button
                    || control is PictureBox || control is DataGridView || control is NumericUpDown)
                {
                    control.Enabled = enable;
                }
            }
        }

        public bool VerificarObrigatoriedade()
        {
            bool retorno = false;
            foreach (var control in listaControles)
            {
                if (control is TextBox)
                    if (!control.Text.Equals(string.Empty))
                        retorno = true;
            }
            return retorno;
        }
    }
}
