namespace AspNet.HtmlControls
{
    public class TextBox : Input
    {
        protected override InputTypes Type
        {
            get { return InputTypes.Text;}
        }

        public string Value
        {
            get { return Attributes["value"]; }
            set { Attributes["value"] = value; }
        }

        protected override void LoadPostData(string postValue, bool hasKey)
        {
            if (hasKey)
                Value = postValue;
        }
    }
}
