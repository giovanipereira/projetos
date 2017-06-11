using ProjetoControleEstoque.Controller.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleEstoque.Controller.validacao
{
    public abstract class ValidacaoBase<T> : IValidacaoBase<T> where T : class
    {
        private List<Control> listaControles;

        public ValidacaoBase(List<Control> listaControles)
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
                    ((DataGridView)control).DataSource = null;

                else if (control is NumericUpDown)
                    ((NumericUpDown)control).Value = 0;
                else if (control is DateTimePicker)
                    ((DateTimePicker)control).Value = DateTime.Now;
            }
        }

        // Função que habilita ou desabilita os controles dependendo do parãmetro recebido
        public void EnableControle(bool enable)
        {
            foreach (var control in listaControles)
            {
                if (control is TextBox || control is MaskedTextBox)
                {
                    if (enable.Equals(true))
                    {
                        if (control is TextBox)
                            ((TextBox)control).ReadOnly = false;
                        else
                            ((MaskedTextBox)control).ReadOnly = false;
                    }
                    else
                    {
                        if (control is TextBox)
                            ((TextBox)control).ReadOnly = true;
                        else if (control is MaskedTextBox)
                            ((MaskedTextBox)control).ReadOnly = true;
                    }
                }
                if (control is ComboBox || control is Button|| control is PictureBox || 
                     control is DataGridView || control is NumericUpDown || control is DateTimePicker)
                 {
                     control.Enabled = enable;
                 }
                /* if (control is TextBox || control is MaskedTextBox || control is ComboBox || control is Button|| control is PictureBox || 
                     control is DataGridView || control is NumericUpDown || control is DateTimePicker)
                 {
                     control.Enabled = enable;
                 }*/
            }
        }
    }
}

