using System.Web.UI;

namespace AspNet.HtmlControls
{
    [ParseChildren(false)]
    [PersistChildren(true)]
    public class Button : GeneralControl
    {
        public Button() : base("button")
        {
            AutoCloseTag = false;
            Type = "button";
        }

        public string Type
        {
            get { return Attributes["type"]; }
            set { Attributes["type"] = value; }
        }
    }
}
