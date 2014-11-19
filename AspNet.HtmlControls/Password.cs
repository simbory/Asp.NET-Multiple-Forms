namespace AspNet.HtmlControls
{
    public class Password : Input
    {
        protected override InputTypes Type
        {
            get { return InputTypes.Password;}
        }

        public string Value { get; set; }

        protected override void LoadPostData(string postValue, bool hasKey)
        {
            if (hasKey)
                Value = postValue;
        }
    }
}
