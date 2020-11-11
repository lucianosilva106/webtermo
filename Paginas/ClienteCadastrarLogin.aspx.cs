using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTermo.Classes;
using WebTermo.Persistencia;

public partial class Paginas_ClienteCadastrar : System.Web.UI.Page
{
    private const int V = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnSalvar_Click(object sender, EventArgs e)
    {
        if (txtSenha.Text != txtSenhaAgain.Text)
        {
            lblMensagem.Text = "Senhas não conferem!";
            txtEmail.Focus();
            return;
        }

        Cliente cliente = new Cliente
        {
            Codigo = Convert.ToInt32(txtCodigo.Text),
            Nome = txtNome.Text,
            Email = txtEmail.Text,
            Senha = txtSenha.Text,
            Liberado = V,
            Administrador = V
        };
        ClienteBD bd = new ClienteBD();
        if (bd.Insert(cliente))
        {
            lblMensagem.Text = "Cliente cadastrado com sucesso";
            txtNome.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            txtCodigo.Text = "";
            txtCodigo.Focus();
        }
        else
        {
            lblMensagem.Text = "Erro ao salvar.";
        }
        Response.Redirect("DefaultLogin.aspx");
    }
}