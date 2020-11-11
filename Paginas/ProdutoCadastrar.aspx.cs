using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTermo.Classes;
using WebTermo.Persistencia;

public partial class Paginas_ProdutoCadastrar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnSalvar_Click(object sender, EventArgs e)
    {
        Produto produto = new Produto
        {
            Codigo = txtCodigo.Text,
            Descricao = txtDescricao.Text,
            Unidade = txtUnidade.Text,
            Estoque = Convert.ToDouble(txtEstoque.Text),
            Estoquecritico = Convert.ToDouble(txtEstoquecritico.Text),
            Valorunitario = Convert.ToDouble(txtValorunitario.Text)
        };

        ProdutoBD bd = new ProdutoBD();
        if (bd.Insert(produto))
        {
            lblMensagem.Text = "Produto cadastrado com sucesso";
            txtCodigo.Text = "";
            txtDescricao.Text = "";
            txtUnidade.Text = "";
            txtEstoque.Text = "";
            txtValorunitario.Text = "";
            txtEstoquecritico.Text = "";
            txtCodigo.Focus();
        }
        else
        {
            lblMensagem.Text = "Erro ao salvar.";
        }
    }
}