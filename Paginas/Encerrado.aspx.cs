using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Encerrado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEncerrado_Click(object sender, EventArgs e)
    {
        Session.Remove("ID");
        Response.Redirect("DefaultLogin.aspx");
    }
}