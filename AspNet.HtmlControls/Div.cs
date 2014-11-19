using System.Web.UI;

namespace AspNet.HtmlControls
{
    [ParseChildren(false)]
    [PersistChildren(true)]
    public class Div : GeneralControl
    {
        public Div()
            : base("div")
        {
            AutoCloseTag = false;
        }

        public string InnerHtml { get; set; }

        protected override void RenderChildren(HtmlTextWriter writer)
        {
            if (!string.IsNullOrEmpty(InnerHtml))
                writer.Write(InnerHtml);
            else
                base.RenderChildren(writer);
        }
    }
}
