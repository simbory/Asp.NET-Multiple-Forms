using System.Web.UI;

namespace AspNet.HtmlControls
{
    public class TextArea : Input
    {
        public TextArea() : base("textarea")
        {
            AutoCloseTag = false;
        }

        protected override InputTypes Type
        {
            get { return InputTypes.Invalid;}
        }

        public string Value
        {
            get { return ViewState["Value"] as string; }
            set { ViewState["Value"] = value; }
        }

        protected override void LoadPostData(string postValue, bool hasKey)
        {
            if (hasKey)
                Value = postValue;
        }

        protected override void RenderChildren(HtmlTextWriter writer)
        {
            writer.Write(Value);
        }
    }
}
