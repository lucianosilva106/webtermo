using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTermo.Classes;
using WebTermo.Persistencia;
using System.Data;

public partial class Paginas_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string mail = Convert.ToString(Session["ID"]);
        ltlLogado.Text = mail;
    }


    protected void Btn_Click(object sender, EventArgs e)
    {

    }
}
