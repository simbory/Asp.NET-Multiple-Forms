using System.Web.UI;

namespace AspNet.HtmlControls
{
    [ParseChildren(false)]
    [PersistChildren(true)]
    public class Span : GeneralControl
    {
        public Span() : base("text")
        {
            AutoCloseTag = false;
        }

        public string Text { get; set; }

        protected override void RenderChildren(HtmlTextWriter writer)
        {
            writer.Write(Text);
        }
    }
}