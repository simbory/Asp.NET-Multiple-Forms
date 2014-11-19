using System;

namespace AspNet.HtmlControls.Sample
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                FileSave.SaveAs("E:/save.png");
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            
            Map3.GoogleMakers.Add(new GoogleMarker{ Latitude = Map3.Latitude, Longitude = Map3.Longitude});
            ImageBtn.Enabled = true;
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            Map3.GoogleMakers.Clear();
            ImageBtn.Enabled = false;
        }
    }
}