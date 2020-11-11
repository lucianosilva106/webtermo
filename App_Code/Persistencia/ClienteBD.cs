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
    /// Descrição resumida de ClienteBD
    /// </summary>
    public class ClienteBD
    {
        // metodos

        public Cliente Autentica(string email, string senha)
        {
            Cliente obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM tbl_cliente WHERE cli_email = ?email and cli_senha = ?senha", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?email", email));
            objCommand.Parameters.Add(Mapped.Parameter("?senha", senha));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new Cliente();
                obj.Codigo = Convert.ToInt32(objDataReader["cli_codigo"]);
                obj.Nome = Convert.ToString(objDataReader["cli_nome"]);
                obj.Email = Convert.ToString(objDataReader["cli_email"]);
                obj.Senha = Convert.ToString(objDataReader["cli_senha"]);
                obj.Senha = Convert.ToString(objDataReader["cli_liberado"]);
                obj.Senha = Convert.ToString(objDataReader["cli_administrador"]);
            }
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }

        // retorna flag Administrador
        public int FlagAdmin(string email, string senha)
        {
            int flagadm = 0;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM tbl_cliente WHERE cli_email = ?email and cli_senha = ?senha", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?email", email));
            objCommand.Parameters.Add(Mapped.Parameter("?senha", senha));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                flagadm = Convert.ToInt32(objDataReader["cli_administrador"]);
            }
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return flagadm;
        }

        // retorna flag Cliente Liberado
        public int Libera(string email, string senha)
        {
            int flaglib = 0;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM tbl_cliente WHERE cli_email = ?email and cli_senha = ?senha", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?email", email));
            objCommand.Parameters.Add(Mapped.Parameter("?senha", senha));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                flaglib = Convert.ToInt32(objDataReader["cli_liberado"]);
            }
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return flaglib;
        }



        //insert
        public bool Insert(Cliente cliente)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "INSERT INTO tbl_cliente(cli_codigo, cli_nome, cli_email, cli_senha, cli_liberado, cli_administrador) VALUES (?codigo, ?nome, ?email, ?senha, ?liberado, ?administrador)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", cliente.Codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?nome", cliente.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?email", cliente.Email));
            objCommand.Parameters.Add(Mapped.Parameter("?senha", cliente.Senha));
            objCommand.Parameters.Add(Mapped.Parameter("?liberado", cliente.Liberado));
            objCommand.Parameters.Add(Mapped.Parameter("?administrador", cliente.Liberado));
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
            objCommand = Mapped.Command("SELECT * FROM tbl_cliente", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;
        }

        //select
        public Cliente Select(string id)
        {
            Cliente obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();

            objCommand = Mapped.Command("SELECT * FROM tbl_cliente WHERE cli_email = ?email", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?email", id));

            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new Cliente();
                obj.Codigo = Convert.ToInt32(objDataReader["cli_codigo"]);
                obj.Nome = Convert.ToString(objDataReader["cli_nome"]);
                obj.Email = Convert.ToString(objDataReader["cli_email"]);
                obj.Senha = Convert.ToString(objDataReader["cli_senha"]);
                obj.Liberado = Convert.ToInt32(objDataReader["cli_liberado"]);
                obj.Administrador = Convert.ToInt32(objDataReader["cli_administrador"]);
            }
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }

        //update

        public bool Update(Cliente cliente)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "UPDATE tbl_cliente SET cli_codigo, cli_nome, cli_email, cli_senha, cli_liberado WHERE cli_email=?email";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", cliente.Codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?nome", cliente.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?email", cliente.Email));
            objCommand.Parameters.Add(Mapped.Parameter("?senha", cliente.Senha));
            objCommand.Parameters.Add(Mapped.Parameter("?liberado", cliente.Senha));
            objCommand.Parameters.Add(Mapped.Parameter("?administrador", cliente.Senha));
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
            string sql = "DELETE FROM tbl_cliente WHERE cli_email=?email";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?email", id));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return true;
        }

        //construtor
        public ClienteBD()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }
    }
}