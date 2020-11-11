<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErroSessionNull.aspx.cs" Inherits="Paginas_ErroSessionNull" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Literal runat="server" ID="ltlErroSession" Text="Realize o Login para ter acesso!" />
            <asp:Button runat="server" ID="btnErroSession" OnClick="btnErroSession_Click" Text="Fechar" />
        </div>
    </form>
</body>
</html>
