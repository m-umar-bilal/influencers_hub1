<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TweetsTrends.aspx.cs" Inherits="TestingLinq.Tweets"  Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 473px">
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server" style="z-index: 1; left: 285px; top: 53px; position: absolute; width: 221px"></asp:TextBox>
    <div>
    
    </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="z-index: 1; left: 145px; top: 53px; position: absolute; right: 705px" Text="Search" />
        <asp:ListBox ID="ListBox1" runat="server" style="z-index: 1; left: 110px; top: 107px; position: absolute; height: 339px; width: 496px"></asp:ListBox>
        <asp:ListBox ID="ListBox2" runat="server" style="z-index: 1; left: 629px; top: 108px; position: absolute; height: 524px; width: 770px"></asp:ListBox>
    </form>
</body>
</html>
