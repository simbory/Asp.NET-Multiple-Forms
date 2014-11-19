<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forms.aspx.cs" Inherits="AspNet.HtmlControls.Sample.Forms" %>

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
        <an:textbox runat="server" />
        <an:SubmitButton runat="server" Text="Submit2" OnClick="Sub2_Click"/>
    </an:Form>
</body>
</html>
