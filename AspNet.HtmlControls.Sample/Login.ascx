<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="AspNet.HtmlControls.Sample.Login" %>
<an:Form runat="server">
    <div class="field">
        <an:Label runat="server" For="username">username:</an:Label>
        <an:TextBox runat="server" HtmlID="username" ID="UserName"/>
    </div>
    <div class="field">
        <an:Label runat="server" For="passowrd">password:</an:Label>
        <an:TextBox runat="server" HtmlID="password" ID="Password"/>
    </div>
    <an:SubmitButton runat="server" Text="Login" OnClick="Login_Click"/>
</an:Form>