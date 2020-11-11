<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Encerrado.aspx.cs" Inherits="Paginas_Encerrado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Literal runat="server" ID="ltlEcerrado" Text="Sessao Encerrada! Obrigado! Estamos sempre melhorando os canais de relacionamento com nossos clientes." />
            <asp:Button runat="server" ID="btnEncerrado" OnClick="btnEncerrado_Click" Text="Fechar" />
        </div>
    </form>
</body>
</html>
