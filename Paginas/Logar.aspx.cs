using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTermo.Classes;
using WebTermo.Persistencia;
using System.Data;

public partial class Paginas_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private bool IsPreenchido(string str)
    {
        bool retorno = false;
        if (str != string.Empty)
        {
            retorno = true;
        }
        return retorno;
    }

    private bool UsuarioEncontrado(Cliente cliente)
    {
        bool retorno = false;
        if (cliente != null)
        {
            retorno = true;
        }
        return retorno;
    }

    protected void btnLogar_Click(object sender, EventArgs e)
    {
        int flagadm = 0;
        int flaglib = 0;
        ClienteBD bd = new ClienteBD();
        Cliente cliente = new Cliente();

        cliente = bd.Autentica(txtEmail.Text, txtSenha.Text);

        if (!UsuarioEncontrado(cliente))
        {
            ltlMensagem.Text = "Usuário/senha não encontrado";
            txtEmail.Focus();
            return;
        }

        Session["ID"] = cliente.Email;

        flaglib = bd.Libera(txtEmail.Text, txtSenha.Text);
        if (flaglib == 0)
        {
            ltlMensagem.Text = "Cliente ainda bloqueado!!! Solicitar a liberação junto ao seu fornecedor.";
            txtEmail.Focus();
            return;
        }

        flagadm = bd.FlagAdmin(txtEmail.Text, txtSenha.Text);
        if (flagadm == 1)
        {
            Response.Redirect("DefaultAdm.aspx");
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClienteCadastrarLogin.aspx");
    }
}