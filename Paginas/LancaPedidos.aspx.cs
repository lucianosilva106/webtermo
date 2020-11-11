using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTermo.Classes;
using WebTermo.Persistencia;
using System.Data;

public partial class Paginas_LancaPedidos : System.Web.UI.Page
{
    public int pednumero = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        ltlMensagem.Text = "";

        if (Session["ID"] == null)
        {
            Response.Redirect("ErroSessionNull.aspx");
        }

        if (!IsPostBack)
        {
            CarregaProduto();
            string mail = Convert.ToString(Session["ID"]);
            ClienteBD bdcli = new ClienteBD();
            Cliente cliente = new Cliente();
            cliente = bdcli.Select(mail);
            txtCliente.Text = cliente.Email;

            PedidoBD bdped = new PedidoBD();
            Pedido pedido = new Pedido();
            pedido.Cliente = txtCliente.Text;
            if (bdped.Insert(pedido))
            {
                ltlMsgPedidoGerado.Text = "Pedido Aberto com sucesso!";

                PedidoBD bdped2 = new PedidoBD();
                pednumero = bdped2.PedidoInserido();

                txtPedido.Text = Convert.ToString(pednumero);
            }
            else
            {
                ltlMsgPedidoGerado.Text = "Erro ao salvar.";
            }
        }
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

    public void CarregaDetalhe()
    {
        PedidodetalheBD bd = new PedidodetalheBD();
        DataSet ds = bd.SelectAll();
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }

    protected void BtnGravaProduto_Click(object sender, EventArgs e)
    {

        Pedidodetalhe pedidodetalhe = new Pedidodetalhe
        {
            Relacaopedido = 0,
            Produto = DdlProduto.SelectedItem.Text,
            Quantidade = Convert.ToDouble(txtQuantidade.Text),
            Valorunitario = Convert.ToDouble(txtValorunitario.Text),
            Valortotal = Convert.ToDouble(txtQuantidade.Text) * Convert.ToDouble(txtValorunitario.Text)
        };

        PedidodetalheBD bd = new PedidodetalheBD();
        if (bd.Insert(pedidodetalhe))
        {
            ltlMensagem.Text = "Produto do pedido cadastrado com sucesso";
            txtQuantidade.Text = "";
            txtValorunitario.Text = "";
            DdlProduto.Focus();
            CarregaDetalhe();
        }
        else
        {
            ltlMensagem.Text = "Erro ao salvar.";
        }
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        PedidodetalheBD bd = new PedidodetalheBD();
        DataSet ds = bd.SelectAll();
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }

    protected void btnIncped_Click(object sender, EventArgs e)
    {
        double total = 0;
        int pedido_num = Convert.ToInt32(txtPedido.Text);
        PedidodetalheBD bdp = new PedidodetalheBD();
        total = bdp.TotalDetalhe();

        PedidoBD bdped = new PedidoBD();
        Pedido pedido = new Pedido();

        pedido.Registro = Convert.ToInt32(txtPedido.Text);
        pedido.Cliente = txtCliente.Text;
        pedido.Pedidocliente = txtPedcliente.Text;
        pedido.Dataprocessamento = Convert.ToDateTime(txtEmissao.Text);
        pedido.Datafaturamento = Convert.ToDateTime(txtEmissao.Text);
        pedido.Emissao = Convert.ToDateTime(txtEmissao.Text);
        pedido.Prazo = Convert.ToDateTime(txtPrazo.Text);
        pedido.Valortotal = total;
        if (bdped.Update(pedido))
        {
            ltlMsgPedidoGerado.Text = "Pedido atualizado com sucesso.";
        }
        else
        {
            ltlMsgPedidoGerado.Text = "Erro ao atualizar pedido.";
        }
        PedidodetalheBD bddet = new PedidodetalheBD();
        bddet.AtuRelacao(pedido_num);
        
    }

    protected void btnSair_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void btnNewPedido_Click(object sender, EventArgs e)
    {
        PedidoBD bdped = new PedidoBD();
        Pedido pedido = new Pedido();
        pedido.Cliente = txtCliente.Text;
        if (bdped.Insert(pedido))
        {
            ltlMsgPedidoGerado.Text = "Pedido Aberto com sucesso!";

            PedidoBD bdped2 = new PedidoBD();
            pednumero = bdped2.PedidoInserido();

            txtPedido.Text = Convert.ToString(pednumero);
        }
        else
        {
            ltlMsgPedidoGerado.Text = "Erro ao salvar.";
        }

        CarregaDetalhe();

        txtPedcliente.Text = "";
        txtQuantidade.Text = "";
        txtValorunitario.Text = "";
        txtEmissao.Text = "";
        txtPrazo.Text = "";

    }
}
