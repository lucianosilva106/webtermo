using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTermo.Classes
{

    /// <summary>
    /// Descrição resumida de Produto
    /// </summary>
    public class Produto
    {
        //propriedades
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public double Estoque { get; set; }
        public double Estoquecritico { get; set; }
        public double Valorunitario { get; set; }

        //construtor
        public Produto()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }
    }
}