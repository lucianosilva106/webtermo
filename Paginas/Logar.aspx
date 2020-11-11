<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/MasterPageLogin.master" AutoEventWireup="true" CodeFile="Logar.aspx.cs" Inherits="Paginas_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="container">
        <div class="card mx-auto  shadow-lg p-3 mb-5 bg-white rounded animate__animated animate__zoomIn" style="margin-top: 10%; width: 50%;">
            <div class="card-body">
                <h1 class="display-3 text-center font-weight-light">Bem-Vindo</h1>

                    <div class="form-group input-field">

                        <asp:Label Text="Email:" runat="server"></asp:Label>
                        <asp:TextBox ID="txtEmail" CssClass="radiusInput" runat="server"></asp:TextBox>

                    </div>

                    <div class="form-group input-field">

                        <asp:Label Text="Senha  :" runat="server"></asp:Label>
                        <asp:TextBox type="password" ID="txtSenha" CssClass="radiusInput" runat="server"></asp:TextBox>

                    </div>

                    <asp:Button runat="server" ID="btnLogar" OnClick="btnLogar_Click" Text="Entrar" />
                    <asp:Button runat="server" ID="btnCadastrar" OnClick="btnCadastrar_Click" Text="Cadastrar-se" />
                    <br />
                    <asp:Literal runat="server" ID="ltlMensagem" Text=""></asp:Literal>
            </div>
        </div>
    </div>


</asp:Content>

