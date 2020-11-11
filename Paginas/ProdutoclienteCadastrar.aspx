<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/MasterPageCliente.master" AutoEventWireup="true" CodeFile="ProdutoclienteCadastrar.aspx.cs" Inherits="Paginas_ProdutoclienteCadastrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <div class="container">
        <div class="card mx-auto  shadow-lg p-3 mb-5 bg-white rounded animate__animated animate__zoomIn" style="margin-top: 3%; width: 100%;">
            <div class="card-body">
                <h4 class="display-4 text-center font-weight-light">Produtos dos Clientes</h4>

            <div class="form-group form-inline">
                <asp:Label Text="Código do Cliente na Empresa:" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtCliente" CssClass="radiusInput"></asp:TextBox>
            </div>
            <div class="form-group form-inline">
                    <asp:Label Text="Código do Produto da Empresa:" runat="server"></asp:Label>
                    <asp:DropDownList runat="server" ID="DdlProduto" AutoPostBack="true" CssClass="form-control" Width="393px">
                    </asp:DropDownList>
            </div>
            <div class="form-group form-inline">
                <asp:Label Text="código do Produto do Cliente  :" runat="server"></asp:Label>
                <asp:TextBox ID="txtCodProdCliente" CssClass="radiusInput" runat="server"></asp:TextBox>
            </div>
            <div class="form-group form-inline">
                <asp:Button runat="server" ID="Btn_CadProCli" OnClick="Btn_CadProCli_Click" Text="Salvar" />
            </div>
            <br />
            <div class="container">
                <h6>Produtos Relacionados</h6>
                <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" BackColor="White">
                    <Columns>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <asp:Button runat="server" ID="btnSair" OnClick="btnSair_Click" Text="Sair" />
         </div>
      </div>
  </div>
</asp:Content>

