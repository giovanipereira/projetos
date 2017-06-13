using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleEstoque.View.layout
{
    public partial class frmTelaSplash : Form
    {
        public frmTelaSplash()
        {
            InitializeComponent();
        }

        private void frmTelaSplash_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            progressBar.Increment(1);
            if(progressBar.Value == 100)
            {
                timer.Stop();
                timer.Enabled = false;
                this.Visible = false;
                frmTelaPrincipal te = new frmTelaPrincipal();
                te.Show();
            }
            else
            {
                
            }
        }
    }
}
