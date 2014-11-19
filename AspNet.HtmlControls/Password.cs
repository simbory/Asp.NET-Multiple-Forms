using System.Web.UI;

namespace AspNet.HtmlControls
{
    public class Password : FormField, ITextControl
    {
        protected override InputTypes Type
        {
            get { return InputTypes.Password;}
        }

        public string Text { get; set; }

        protected override void LoadPostData(string postValue, bool hasKey)
        {
            if (hasKey)
                Text = postValue;
        }
    }
}
