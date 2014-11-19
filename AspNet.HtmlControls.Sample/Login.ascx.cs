using System;

namespace AspNet.HtmlControls.Sample
{
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Password.Text);
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Write(Password.Text);
        }
    }
}