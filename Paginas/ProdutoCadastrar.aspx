<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/MasterPage.master" AutoEventWireup="true" CodeFile="ProdutoCadastrar.aspx.cs" Inherits="Paginas_ProdutoCadastrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <div class="container">
        <div class="card mx-auto  shadow-lg p-3 mb-5 bg-white rounded animate__animated animate__zoomIn" style="margin-top: 10%; width: 70%;">
            <div class="card-body">
                <h2>Cadastro de Produtos</h2>
            </div>

            <div class="form-group form-inline">
                <label>Codigo:</label>
                <asp:TextBox runat="server" ID="txtCodigo"></asp:TextBox>
                <label>Descricao:</label>
                <asp:TextBox runat="server" ID="txtDescricao"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Unidade:</label>
                <asp:TextBox runat="server" ID="txtUnidade"></asp:TextBox>
            </div>
                <div class="form-group">
                <label>Valor Unitario:</label>
                <asp:TextBox runat="server" ID="txtValorunitario"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Estoque Atual:</label>
                <asp:TextBox runat="server" ID="txtEstoque"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Estoque Critico:</label>
                <asp:TextBox runat="server" ID="txtEstoquecritico"></asp:TextBox>
            </div>
            <asp:Button runat="server" ID="BtnSalvar" OnClick="BtnSalvar_Click" Text="Salvar" />
            <label>Mensagem:</label>
            <asp:Literal runat="server" ID="lblMensagem" Text=""></asp:Literal>
        </div>
      </div>
</asp:Content>

