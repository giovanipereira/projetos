using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleEstoque.Controller.controlador
{
    public abstract class ControladorBase
    {
        #region Declaration

        protected Button btnInserir, btnSalvar, btnAtualizar, btnCancelar;
        protected List<Control> listaControles = new List<Control>();
        #endregion

        #region Declaration Protected Abstract Methods

        protected abstract void HabilitarTodosCampos(bool enable);
        protected abstract void LimparCampos();
        protected abstract void AdicionarListaControles();
        #endregion

        // Função que controla o tipo de operação que o usuário está fazendo
        public void OperationMode(int option)
        {
            // A variável option recebe um valor que pode ser standard, insert ou update
            // Por padrão os botões de operação vem desabilitados
            btnInserir.Enabled = false;
            btnSalvar.Enabled = false;
            btnAtualizar.Enabled = false;
            btnCancelar.Enabled = false;
            // Desabilitar todos os componentes
            HabilitarTodosCampos(false);
            switch (option)
            {
                // Se for standard
                case 1:
                    // Habilita os botões padrões
                    btnInserir.Enabled = true;
                    btnCancelar.Enabled = true;
                    // Desabilita os componentes
                    HabilitarTodosCampos(false);
                    // E limpa os componentes
                    LimparCampos();
                    break;
                // Se for Insert
                case 2:
                    // Habilita os componentes para realizar a operação de salvar
                    btnSalvar.Enabled = true;
                    btnCancelar.Enabled = true;
                    // Habilita os componentes
                    HabilitarTodosCampos(true);
                    break;
                // Se for Update
                case 3:
                    // Habilita os componentes para realizar a operação de atualizar
                    btnAtualizar.Enabled = true;
                    btnCancelar.Enabled = true;
                    // Habilita os componentes
                    HabilitarTodosCampos(true);
                    break;
            }
        }        
    }

    public enum EnumOperationMode
    {
        Normal = 1,
        Inserir = 2,
        Atualizar = 3
    }
}
