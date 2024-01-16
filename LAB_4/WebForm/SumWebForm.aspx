<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SumWebForm.aspx.cs" Inherits="WebForm.SumWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="sumForm" runat="server">
        <div>
            <div>
                <asp:Label runat="server">A_s</asp:Label>
                <asp:TextBox runat="server" ID="a_s" />

                <asp:Label runat="server">A_k</asp:Label>
                <asp:TextBox runat="server" ID="a_k" />

                <asp:Label runat="server">A_f</asp:Label>
                <asp:TextBox runat="server" ID="a_f" />


                <br /><br /><br />
                <asp:Label runat="server">B_s</asp:Label>
                <asp:TextBox runat="server" ID="b_s" />

                <asp:Label runat="server">B_k</asp:Label>
                <asp:TextBox runat="server" ID="b_k" />

                <asp:Label runat="server">B_f</asp:Label>
                <asp:TextBox runat="server" ID="b_f" />
            </div>
            <asp:Button runat="server" ID="sum" OnClick="Sum_Click" Text="Sum" />
        </div>
        <div>
            <asp:TextBox runat="server" ID="result" />
        </div>
    </form>
</body>
</html>
