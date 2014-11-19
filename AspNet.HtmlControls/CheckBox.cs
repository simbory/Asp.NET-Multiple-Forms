using System.ComponentModel;

namespace AspNet.HtmlControls
{
    public class CheckBox : Input
    {
        public CheckBox()
        {
            Checked = false;
        }

        protected override InputTypes Type
        {
            get { return InputTypes.Checkbox;}
        }

        [DefaultValue(false)]
        [Bindable(true)]
        public bool Checked
        {
            get { return !"unchecked".Equals(Attributes["checked"]); }
            set
            {
                if (value)
                    Attributes["checked"] = "checked";
                else
                    Attributes.Remove("checked");
            }
        }

        protected override void LoadPostData(string postValue, bool hasKey)
        {
            Checked = hasKey;
        }
    }
}
