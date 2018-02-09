<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <h1>Find Cyclic Automorphisms of a String</h1>
            <asp:TextBox ID="InputString" runat="server" Style="margin-bottom: 0px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="RunButton" runat="server" Text="Run" OnClick="RunButton_Click" />
        </p>
        <p>
            <asp:Label ID="Result" runat="server" Text="Click &quot;Run&quot; to get results."></asp:Label>
        </p>
    </form>
</body>
</html>
