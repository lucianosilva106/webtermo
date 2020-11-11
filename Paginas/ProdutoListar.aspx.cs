using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTermo.Persistencia;
using System.Data;

public partial class Paginas_ProdutoListar : System.Web.UI.Page
{
    private void Carrega()
    {
        ProdutoBD bd = new ProdutoBD();
        DataSet ds = bd.SelectAll();
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Carrega();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void BtnAtuProd_Click(object sender, EventArgs e)
    {

    }
}