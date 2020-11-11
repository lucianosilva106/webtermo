<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/MasterPage.master" AutoEventWireup="true" CodeFile="ClienteListar.aspx.cs" Inherits="Paginas_ClienteListar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" BackColor="White">
        <Columns>
        </Columns>
    </asp:GridView>

</asp:Content>

