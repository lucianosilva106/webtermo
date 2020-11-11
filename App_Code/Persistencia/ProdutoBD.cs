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
    /// Descrição resumida de ProdutoBD
    /// </summary>
    public class ProdutoBD
    {
        // metodos
        //insert
        public bool Insert(Produto produto)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "INSERT INTO tbl_produto(pro_codigo, pro_descricao, pro_unidade, pro_estoque, pro_estoquecritico, pro_valorunitario) VALUES (?codigo, ?descricao, ?unidade, ?estoque, ?estoquecritico, ?valorunitario)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", produto.Codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?descricao", produto.Descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?unidade", produto.Unidade));
            objCommand.Parameters.Add(Mapped.Parameter("?estoque", produto.Estoque));
            objCommand.Parameters.Add(Mapped.Parameter("?estoquecritico", produto.Estoquecritico));
            objCommand.Parameters.Add(Mapped.Parameter("?valorunitario", produto.Valorunitario));
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
            objCommand = Mapped.Command("SELECT * FROM tbl_produto", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;
        }

        //select

        //update

        //construtor
        public ProdutoBD()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }
    }
}