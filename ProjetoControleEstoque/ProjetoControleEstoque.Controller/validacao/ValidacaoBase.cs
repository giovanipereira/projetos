using ProjetoControleEstoque.Controller.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleEstoque.Controller.validacao
{
    public abstract class ValidacaoBase
    {
        private List<Control> listaControles;

        public ValidacaoBase(List<Control> listaControles)
        {
            this.listaControles = listaControles;
        }

        public void LimparControles()
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
                {
                    ((ComboBox)control).Text = null;
                    ((ComboBox)control).SelectedValue = 0;
                }
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
                if (control is ComboBox || control is Button || control is PictureBox ||
                     control is DataGridView || control is NumericUpDown || control is DateTimePicker)
                {
                    control.Enabled = enable;
                }
            }
        }
    }
}

