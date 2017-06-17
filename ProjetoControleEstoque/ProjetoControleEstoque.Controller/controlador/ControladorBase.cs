using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoControleEstoque.Controller.interfaces;

namespace ProjetoControleEstoque.Controller.controlador
{
    public abstract class ControladorBase : IControladorBase
    {
        #region Declaration

        protected Button btnInserir, btnSalvar, btnAtualizar, btnCancelar;
        protected List<Control> listaControles = new List<Control>();

        #endregion

        #region Declaration Public Abstract Methods

        public abstract void HabilitarTodosCampos(bool enable);
        public abstract void LimparCampos();
        public abstract void AdicionarListaControles();

        #endregion

        #region Protected Methods

        protected void OperationMode(int opcao)
        {
            btnInserir.Enabled = false;
            btnSalvar.Enabled = false;
            btnAtualizar.Enabled = false;
            btnCancelar.Enabled = false;
            HabilitarTodosCampos(false);
            switch (opcao)
            {
                case 1:
                    btnInserir.Enabled = true;
                    btnCancelar.Enabled = true;
                    HabilitarTodosCampos(false);
                    LimparCampos();
                    break;
                case 2:
                    btnSalvar.Enabled = true;
                    btnCancelar.Enabled = true;
                    HabilitarTodosCampos(true);
                    break;
                case 3:
                    btnAtualizar.Enabled = true;
                    btnCancelar.Enabled = true;
                    HabilitarTodosCampos(true);
                    break;
            }
        }

        #endregion

    }

    public enum EnumOperationMode
    {
        Normal = 1,
        Inserir = 2,
        Atualizar = 3
    }

}
