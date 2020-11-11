using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTermo.Classes
{
    /// <summary>
    /// Descrição resumida de ClienteProduto
    /// </summary>
    public class Clienteproduto
    {
        public int Registro { get; set; }
        public string Cliente { get; set; }
        public string Produto { get; set; }
        public string Produtocliente { get; set; }

        //construtor
        public Clienteproduto()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }
    }
}
