<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendNotification.aspx.cs" Inherits="GCMTestServer.SendNotification" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label Text="Token" runat="server" AssociatedControlID="tbRegistrationID" />
        :<asp:TextBox ID="tbRegistrationID" runat="server" Width="1168px" style="margin-left: 19px" ToolTip="Token" ></asp:TextBox>
        <br />
        <br />
        Text Message:<br />
    </div>
        <asp:TextBox ID="TextBox_mess" runat="server" Height="98px" Width="1227px" ToolTip="Message"></asp:TextBox>

    <div id="response">
        <p>
            <asp:Label ID="Label1" runat="server" Text="URL site "></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" ToolTip="URL">http://tut.by</asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Title"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" ToolTip="Title Push Message">title</asp:TextBox>
        </p>
    </div>
        <p>
            <asp:Button ID="Button_snd" runat="server" OnClick="Button_snd_Click" Text="Send" Width="1229px" />
        </p>
        <p>
            <asp:Label ID="Label_result" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Log"></asp:Label>
        </p>
    </form>

    </body>
</html>
