using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTermo.Classes
{
    /// <summary>
    /// Descrição resumida de Pedido
    /// </summary>
    public class Pedido
    {
        public int Registro { get; set; }
        public string Cliente { get; set; }
        public string Pedidocliente { get; set; }
        public DateTime Dataprocessamento { get; set; }
        public DateTime Datafaturamento { get; set; }
        public DateTime Emissao { get; set; }
        public DateTime Prazo { get; set; }
        public double Valortotal { get; set; }


        //construtor
        public Pedido()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }
    }
}