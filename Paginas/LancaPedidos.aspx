<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/MasterPageCliente.master" AutoEventWireup="true" CodeFile="LancaPedidos.aspx.cs" Inherits="Paginas_LancaPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="container">
        <div class="card mx-auto  shadow-lg p-3 mb-5 bg-white rounded animate__animated animate__zoomIn" style="margin-top: 3%; width: 100%;">
            <div class="card-body">
                <h4 class="display-4 text-center font-weight-light">Lançamento de Pedidos</h4>

                <div class="form-group">
                    <asp:Label Text="  Pedido: " runat="server"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPedido"></asp:TextBox>
                    <asp:Label Text="  Cliente: " runat="server"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCliente"></asp:TextBox>
                </div>
                <div class="form-group form-inline">
                    <asp:Label Text="  Emissao: " runat="server"></asp:Label>
                    <asp:TextBox runat="server" type="date" ID="txtEmissao"></asp:TextBox>
                    <asp:Label Text="  Prazo:   " runat="server"></asp:Label>
                    <asp:TextBox runat="server" type="date" ID="txtPrazo"></asp:TextBox>
                    <asp:Label Text="  No.Pedido Cliente: " runat="server"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPedcliente"></asp:TextBox>
                </div>
                <br />
                <div class="form-group form-inline">
                    <asp:Label Text="Produto:" runat="server"></asp:Label>
                    <asp:DropDownList runat="server" ID="DdlProduto" AutoPostBack="true" CssClass="form-control" Width="153px">
                    </asp:DropDownList>
                    <asp:Label Text="Quantidade:" runat="server"></asp:Label>
                    <asp:TextBox runat="server" type="number" ID="txtQuantidade" CssClass="form-control"></asp:TextBox>
                    <asp:Label Text="Valor Unitario:" runat="server"></asp:Label>
                    <asp:TextBox runat="server" ID="txtValorunitario" CssClass="form-control"></asp:TextBox>
                </div>

                <asp:Button runat="server" ID="BtnGravaProduto" onClick="BtnGravaProduto_Click" Text="Grava Produto"/>
                <br />
                <asp:Label Text="Mensagem:" runat="server"></asp:Label>
                <asp:Literal runat="server" ID="ltlMensagem" Text=""></asp:Literal>

                <div class="container">
                    <h3>Produtos lançados</h3>
                    <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" BackColor="White">
                        <Columns>
                        </Columns>
                    </asp:GridView>
                </div>
                <br />
                <div>
                    <asp:Button runat="server" ID="btnIncped" OnClick="btnIncped_Click" Text="Gravar Pedido"/>
                    <asp:Label Text="Pedido Gerado:" runat="server"></asp:Label>
                    <asp:Literal runat="server" ID="ltlMsgPedidoGerado" Text=""></asp:Literal>
                    <asp:Button runat="server" ID="btnNewPedido" onClick="btnNewPedido_Click" text="Novo Pedido"/>
                    <asp:Button runat="server" ID="btnSair" onClick="btnSair_Click" text="Sair" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>

