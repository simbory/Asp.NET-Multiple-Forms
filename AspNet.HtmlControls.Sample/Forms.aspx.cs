﻿using System;

namespace AspNet.HtmlControls.Sample
{
    public partial class Forms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Sub1_Click(object sender, EventArgs e)
        {
            SubmitText.Text = "Sub1 Clicked";
        }

        protected void Sub2_Click(object sender, EventArgs e)
        {
            SubmitText.Text = "Sub2 Clicked";
        }
    }
}