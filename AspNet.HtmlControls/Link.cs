using System.Web.UI;

namespace AspNet.HtmlControls
{
    [ParseChildren(false)]
    [PersistChildren(true)]
    public class Link : GeneralControl
    {
        public Link() : base("a")
        {
            AutoCloseTag = false;
        }

        [UrlProperty]
        public string Url { get; set; }

        public string Target { get; set; }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            if (!string.IsNullOrEmpty(Url))
                writer.WriteAttribute("href", Url);
            if (!string.IsNullOrEmpty(Target))
                writer.WriteAttribute("target", Target);
        }
    }
}
