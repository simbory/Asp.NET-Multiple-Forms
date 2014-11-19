namespace AspNet.HtmlControls
{
    public class GeneralInput : Input
    {
        protected override InputTypes Type
        {
            get { return InputType; }
        }

        public InputTypes InputType
        {
            get
            {
                var obj = ViewState["Input_InputType"];
                if (obj == null)
                    return InputTypes.Text;
                return (InputTypes) obj;
            }
            set { ViewState["Input_InputType"] = value; }
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
