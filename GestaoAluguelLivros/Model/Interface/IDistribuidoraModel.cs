using Model.Class;
using System;
using System.Collections.Generic;

namespace Model.Interface
{
    public interface IDistribuidoraModel
    {
        int COD_DISTRIBUIDORA { get; set; }
        string DIST_NOME { get; set; }
        string DIST_CNPJ { get; set; }
        string END_RUA { get; set; }
        string END_BAIRRO { get; set; }
        string END_CIDADE { get; set; }
        string END_NUMERO { get; set; }
        string END_CEP { get; set; }
        string END_UF { get; set; }
        string TEL_NUMERO { get; set; }

        int Inserir();
        bool Alterar();
        bool Apagar();
        IDistribuidoraModel ConsultarPorId(string ID);
        IList<IDistribuidoraModel> ConsultarTodos();
        IList<IDistribuidoraModel> ConsultarPorNome(string Nome);
        bool Validar(out string Alertas);

    }
}