using System.Web.UI;

namespace AspNet.HtmlControls
{
    public class TextBox : FormField, ITextControl
    {
        protected override InputTypes Type
        {
            get { return InputTypes.Text;}
        }

        public string Text
        {
            get { return Attributes["value"]; }
            set { Attributes["value"] = value; }
        }

        protected override void LoadPostData(string postValue, bool hasKey)
        {
            if (hasKey)
                Text = postValue;
        }
    }
}
