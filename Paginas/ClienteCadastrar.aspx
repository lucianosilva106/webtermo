<%@ Page Language="C#" MasterPageFile="~/Paginas/MasterPage.master" AutoEventWireup="true" CodeFile="ClienteCadastrar.aspx.cs" Inherits="Paginas_ClienteCadastrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        
    <div class="container">
        <div class="card mx-auto  shadow-lg p-3 mb-5 bg-white rounded animate__animated animate__zoomIn" style="margin-top: 10%; width: 100%;">
            <div class="card-body">
                <h4>Cadastro de Cliente</h4>
            </div>
            <div class="form-group form-inline">
                <label>Codigo:</label>
                <asp:TextBox runat="server" ID="txtCodigo"></asp:TextBox>
            </div>
            <div class="form-group form-inline">
                <label>Nome:</label>
                <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>
            </div>
            <div class="form-group form-inline">
                <label>Email:</label>
                <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
            </div>
            <div class="form-group form-inline">
                <label>Senha:</label>
                <asp:TextBox runat="server" type="password" ID="txtSenha"></asp:TextBox>
                <label>Digite a Senha novamente:</label>
                <asp:TextBox runat="server" type="password" ID="txtSenhaAgain"></asp:TextBox>
            </div>
            <div>
                <asp:Button runat="server" ID="BtnSalvar" OnClick="BtnSalvar_Click" Text="Salvar" />
                <asp:Literal runat="server" ID="lblMensagem" Text=""></asp:Literal>
                <asp:Button runat="server" ID="BtnSair" OnClick="BtnSair_Click" Text="Sair" />
            </div>
            <div>
                <asp:Button runat="server" ID="BtnClitodos" OnClick="BtnClitodos_Click" Text="Ver Lista" />
            </div>
        </div>
    </div>
</asp:Content>