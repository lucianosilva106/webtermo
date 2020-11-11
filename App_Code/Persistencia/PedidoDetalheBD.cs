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
    /// Descrição resumida de PedidoDetalheBD
    /// </summary>
    public class PedidodetalheBD
    {
        //metodos
        //insert
        public bool Insert(Pedidodetalhe pedidodetalhe)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "INSERT INTO tbl_detalhe(det_relacaopedido, det_produto, det_quantidade, det_valorunitario, det_valortotal, det_quantidadeatendida) VALUES (?relacaopedido, ?produto, ?quantidade, ?valorunitario, ?valortotal, ?quantidadeatendida)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?relacaopedido", pedidodetalhe.Relacaopedido));
            objCommand.Parameters.Add(Mapped.Parameter("?produto", pedidodetalhe.Produto));
            objCommand.Parameters.Add(Mapped.Parameter("?quantidade", pedidodetalhe.Quantidade));
            objCommand.Parameters.Add(Mapped.Parameter("?valorunitario", pedidodetalhe.Valorunitario));
            objCommand.Parameters.Add(Mapped.Parameter("?valortotal", pedidodetalhe.Valortotal));
            objCommand.Parameters.Add(Mapped.Parameter("?quantidadeatendida", pedidodetalhe.Quantidadeatendida));
            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return true;
        }

        //selectall
        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT det_produto as Produto, det_quantidade as Quantidade, det_valorunitario as Valor_Unitario, det_valortotal as Valor_Total FROM tbl_detalhe WHERE det_relacaopedido = 0", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;
        }

        //calcula valor total do pedido
        public double TotalDetalhe()
        {
            double total = 0;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM tbl_detalhe WHERE det_relacaopedido = 0", objConexao);
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                total += Convert.ToDouble(objDataReader["det_valortotal"]);
            }
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return total;
        }

        //Atualiza Relacao
        public void AtuRelacao(int id)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("UPDATE tbl_detalhe SET det_relacaopedido = ?relacaopedido WHERE det_relacaopedido = 0", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?relacaopedido", id));
            objDataReader = objCommand.ExecuteReader();
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
        }

        //select
        public Pedidodetalhe Select(int id)
        {
            Pedidodetalhe obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM tbl_detalhe WHERE det_registro = ?registro", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?registro", id));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new Pedidodetalhe();
                obj.Produto = Convert.ToString(objDataReader["det_produto"]);
                obj.Quantidade = Convert.ToDouble(objDataReader["det_quantidade"]);
            }
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }

        //update
        public bool Update(Pedidodetalhe pedidodetalhe)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "UPDATE tbl_detalhe SET det_relacaopedido = ?relacaopedido WHERE det_relacaopedido=0";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?relacaopedido", pedidodetalhe.Relacaopedido));
            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return true;
        }

        //delete
        public bool Delete()
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "DELETE FROM tbl_detalhe WHERE det_relacaopedido=0";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return true;
        }

        //update

        //construtor
        public PedidodetalheBD()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }
    }
}