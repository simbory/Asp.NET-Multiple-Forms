using System.Web.UI;

namespace AspNet.HtmlControls
{
    [ParseChildren(false)]
    [PersistChildren(true)]
    public class Label : GeneralControl
    {
        public Label() : base("label")
        {
            AutoCloseTag = false;
        }

        public string For
        {
            get { return Attributes["for"]; }
            set { Attributes["for"] = value; }
        }

        public string Text { get; set; }

        protected override void RenderChildren(HtmlTextWriter writer)
        {
            if (string.IsNullOrEmpty(Text))
                base.RenderChildren(writer);
            else
                writer.Write(Text);
        }
    }
}