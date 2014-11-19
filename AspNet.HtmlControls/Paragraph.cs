using System.Web.UI;

namespace AspNet.HtmlControls
{
    [ParseChildren(false)]
    [PersistChildren(true)]
    public class Paragraph : GeneralControl
    {
        public Paragraph() : base("p")
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
