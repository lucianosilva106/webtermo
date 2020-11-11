using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTermo.Classes;
using WebTermo.Persistencia;
using System.Data;

public partial class Paginas_ProdutoclienteCadastrar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
        {
            Response.Redirect("ErroSessionNull.aspx");
        }

        if (!IsPostBack)
        {
            CarregaProduto();
            CarregaClienteProduto();
        }
        string mail = Convert.ToString(Session["ID"]);
        ClienteBD bd = new ClienteBD();
        Cliente cliente = new Cliente();
        cliente = bd.Select(mail);
        txtCliente.Text = cliente.Email;
    }

    public void CarregaProduto()
    {

        ProdutoBD bd = new ProdutoBD();
        DataSet ds = bd.SelectAll();
        DdlProduto.DataTextField = "pro_codigo";
        DdlProduto.DataValueField = "pro_codigo";
        DdlProduto.DataSource = ds.Tables[0].DefaultView;
        DdlProduto.DataBind();
    }

    public void CarregaClienteProduto()
    {
        string mail = Convert.ToString(Session["ID"]);
        ClienteprodutoBD bd = new ClienteprodutoBD();
        DataSet ds = bd.SelectAll(mail);
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }

    protected void Btn_CadProCli_Click(object sender, EventArgs e)
    {

        Clienteproduto clienteproduto = new Clienteproduto
        {
            Cliente = txtCliente.Text,
            Produto = DdlProduto.SelectedItem.Text,
            Produtocliente = txtCodProdCliente.Text
        };

        ClienteprodutoBD bd = new ClienteprodutoBD();
        if (bd.Insert(clienteproduto))
        {
//            ltlMensagem.Text = "Produto do cliente cadastrado com sucesso";
            txtCodProdCliente.Text = "";
            CarregaClienteProduto();
        }
        else
        {
//            ltlMensagem.Text = "Erro ao salvar.";
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string mail = Convert.ToString(Session["ID"]);

        ClienteprodutoBD bd = new ClienteprodutoBD();
        DataSet ds = bd.SelectAll(mail);
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }

    protected void btnSair_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}