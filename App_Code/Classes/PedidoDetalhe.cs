using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTermo.Classes
{
    /// <summary>
    /// Descrição resumida de PedidoDetalhe
    /// </summary>
    public class Pedidodetalhe
    {
        public int Registro { get; set; }
        public int Relacaopedido { get; set; }
        public string Produto { get; set; }
        public double Quantidade { get; set; }
        public double Valorunitario { get; set; }
        public double Valortotal { get; set; }
        public double Quantidadeatendida { get; set; }

        //construtor
        public Pedidodetalhe()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }
    }
}
