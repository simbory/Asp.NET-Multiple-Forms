<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forms.aspx.cs" Inherits="AspNet.HtmlControls.Sample.Forms" %>

<%@ Register Src="~/Login.ascx" TagPrefix="uc1" TagName="Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <an:Label runat="server" ID="SubmitText"></an:Label>
    <an:Form runat="server" ID="Form1">
        <an:textbox runat="server" />
        <an:SubmitButton runat="server" Text="Submit1" OnClick="Sub1_Click"/>
    </an:Form>
    <an:Form runat="server" ID="Form2">
        <an:Label runat="server" For="username">username:</an:Label>
        <an:textbox HtmlID="username" Name="username" runat="server" />
        <an:SubmitButton runat="server" Text="Submit2" OnClick="Sub2_Click"/>
    </an:Form>
    <uc1:Login runat="server"/>
    <form runat="server">
        <an:TextArea runat="server" ID="T1" Name="T1"/>
        <an:SubmitButton runat="server" ID="Sub3" OnClick="Sub3_OnClick"/>
    </form>
</body>
</html>