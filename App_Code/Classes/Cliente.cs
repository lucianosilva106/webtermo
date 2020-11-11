using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTermo.Classes
{
    /// <summary>
    /// Descrição resumida de Cliente
    /// </summary>
    public class Cliente
    {
        // propriedade
        public int Registro { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Liberado { get; set; }
        public int Administrador { get; set; }

        // construtor
        public Cliente()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }
    }
}
