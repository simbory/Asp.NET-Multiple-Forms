using System.ComponentModel;
using System.Web.UI;

namespace AspNet.HtmlControls
{
    [ParseChildren(true)]
    public class Img : GeneralControl
    {
        public Img() : base("img")
        {
            AutoCloseTag = true;
        }

        [DefaultValue("")]
        [Bindable(true)]
        public string Alt
        {
            get { return Attributes["alt"]; }
            set { Attributes["alt"] = value; }
        }

        [UrlProperty]
        [DefaultValue("")]
        [Bindable(true)]
        public string Src
        {
            get { return Attributes["src"]; }
            set { Attributes["src"] = value; }
        }
    }
}