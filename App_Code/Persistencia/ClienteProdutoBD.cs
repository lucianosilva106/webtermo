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
    /// Descrição resumida de ClienteProdutoBD
    /// </summary>
    public class ClienteprodutoBD
    {
        //metodos
        //insert
        public bool Insert(Clienteproduto clienteproduto)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "INSERT INTO tbl_clienteproduto(clipro_cliente, clipro_produto, clipro_produtocliente) VALUES (?cliente, ?produto, ?produtocliente)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?cliente", clienteproduto.Cliente));
            objCommand.Parameters.Add(Mapped.Parameter("?produto", clienteproduto.Produto));
            objCommand.Parameters.Add(Mapped.Parameter("?produtocliente", clienteproduto.Produtocliente));
            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return true;
        }

        //selectall
        public DataSet SelectAll(string mail)
        {
            DataSet ds = new DataSet();
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT clipro_produto as Produto_Empresa, clipro_produtocliente as Produto_Cliente FROM tbl_clienteproduto WHERE clipro_cliente=?cliente", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?cliente", mail));
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;
        }


        //select
        public Clienteproduto Select(int id)
        {
            Clienteproduto obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM tbl_clienteproduto WHERE clipro_registro = ?registro", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?registro", id));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new Clienteproduto();
                obj.Registro = Convert.ToInt32(objDataReader["clipro_registro"]);
            }
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }

        //update
        public bool Update(Clienteproduto clienteproduto)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "UPDATE tbl_clienteproduto SET clipro_produtocliente=?produtocliente WHERE clipro_registro=?registro";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?registro", clienteproduto.Registro));
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
            string sql = "DELETE FROM tbl_clienteproduto WHERE clipro_registro=?registro";
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
        //select
        //update

        //construtor
        public ClienteprodutoBD()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }
    }
}