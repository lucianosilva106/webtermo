using FATEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTermo.Classes;
using System.Data;

namespace WebTermo.Persistencia
{
    /// <summary>
    /// Descrição resumida de PedidoBD
    /// </summary>
    public class PedidoBD
    {
        //metodos
        //insert
        public bool Insert(Pedido pedido)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "INSERT INTO tbl_pedido(ped_cliente, ped_pedidocliente, ped_dataprocessamento, ped_datafaturamento, ped_emissao, ped_prazo, ped_valortotal) VALUES (?cliente, ?pedidocliente, ?dataprocessamento, ?datafaturamento, ?emissao, ?prazo, ?valortotal)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?cliente", pedido.Cliente));
            objCommand.Parameters.Add(Mapped.Parameter("?pedidocliente", pedido.Pedidocliente));
            objCommand.Parameters.Add(Mapped.Parameter("?dataprocessamento", pedido.Dataprocessamento));
            objCommand.Parameters.Add(Mapped.Parameter("?datafaturamento", pedido.Datafaturamento));
            objCommand.Parameters.Add(Mapped.Parameter("?emissao", pedido.Emissao));
            objCommand.Parameters.Add(Mapped.Parameter("?prazo", pedido.Prazo));
            objCommand.Parameters.Add(Mapped.Parameter("?valortotal", pedido.Valortotal));
            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return true;
        }

        //select all    
        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT ped_cliente as Cliente, ped_pedidocliente as Pedido_Cliente, ped_emissao as Emissao, ped_prazo as Prazo, ped_valortotal as Valor_Total FROM tbl_pedido", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;
        }

        //Retorna pedido inserido
        public int PedidoInserido()
        {
            int pednum = 0;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM tbl_pedido WHERE ped_registro is not null ORDER BY ped_registro", objConexao);
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                pednum = Convert.ToInt32(objDataReader["ped_registro"]);
            }
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return pednum;
        }

        //select
        public Pedido Select(int id)
        {
            Pedido obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM tbl_pedido WHERE ped_registro = ?registro", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?registro", id));

            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new Pedido();
                obj.Registro = Convert.ToInt32(objDataReader["ped_registro"]);
                obj.Cliente = Convert.ToString(objDataReader["ped_cliente"]);
                obj.Pedidocliente = Convert.ToString(objDataReader["ped_pedidocliente"]);
                obj.Dataprocessamento = Convert.ToDateTime(objDataReader["ped_dataprocessamento"]);
                obj.Datafaturamento = Convert.ToDateTime(objDataReader["ped_datafaturamento"]);
                obj.Emissao = Convert.ToDateTime(objDataReader["ped_emissao"]);
                obj.Prazo = Convert.ToDateTime(objDataReader["ped_prazo"]);
                obj.Valortotal = Convert.ToDouble(objDataReader["ped_valortotal"]);
            }
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }

        //update
        public bool Update(Pedido pedido)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "UPDATE tbl_pedido SET ped_registro=?registro, ped_cliente=?cliente, ped_pedidocliente=?pedidocliente, ped_dataprocessamento=?dataprocessamento, ped_datafaturamento=?datafaturamento, ped_emissao=?emissao, ped_prazo=?prazo, ped_valortotal=?valortotal WHERE ped_registro=?registro";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?registro", pedido.Registro));
            objCommand.Parameters.Add(Mapped.Parameter("?cliente", pedido.Cliente));
            objCommand.Parameters.Add(Mapped.Parameter("?pedidocliente", pedido.Pedidocliente));
            objCommand.Parameters.Add(Mapped.Parameter("?dataprocessamento", pedido.Dataprocessamento));
            objCommand.Parameters.Add(Mapped.Parameter("?datafaturamento", pedido.Datafaturamento));
            objCommand.Parameters.Add(Mapped.Parameter("?emissao", pedido.Emissao));
            objCommand.Parameters.Add(Mapped.Parameter("?prazo", pedido.Prazo));
            objCommand.Parameters.Add(Mapped.Parameter("?valortotal", pedido.Valortotal));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return true;
        }
        //delete
        public bool Delete(int id)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "DELETE FROM tbl_pedido WHERE ped_registro=?registro";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?registro", id));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return true;
        }


        //update


        //construtor
        public PedidoBD()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }
    }
}
