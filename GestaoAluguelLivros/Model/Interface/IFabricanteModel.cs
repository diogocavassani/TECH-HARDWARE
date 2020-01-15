using Model.Class;
using System;
using System.Collections.Generic;

namespace Model.Interface
{
    public interface IFabricanteModel
    {
        int COD_FABRICANTE { get; set; }
        string FABR_NOME { get; set; }

        int Inserir();
        bool Alterar();
        bool Apagar();
        IFabricanteModel ConsultarPorId(string ID);
        IList<IFabricanteModel> ConsultarTodos();
        IList<IFabricanteModel> ConsultarPorNome(string Nome);
        bool Validar(out string Alertas);

    }
}