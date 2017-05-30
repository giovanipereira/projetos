using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Controller.interfaces
{
    public interface IControladorBase
    {
        void HabilitarTodosCampos(bool enable);
        void LimparCampos();
        void AdicionarListaControles();
    }
}
