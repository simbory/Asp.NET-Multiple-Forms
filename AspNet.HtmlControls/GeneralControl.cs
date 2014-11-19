using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNet.HtmlControls
{
    public abstract  class GeneralControl : WebControl, IAttributeAccessor
    {
        private readonly string _tag;

        public string ClientTitle
        {
            get { return Attributes["title"]; }
            set { Attributes["title"] = value; }
        }

        [Bindable(true)]
        public string HtmlID
        {
            get { return Attributes["id"]; }
            set { Attributes["id"] = value; }
        }

        protected bool AutoCloseTag { get; set; }

        public bool ClientVisible 
        {
        	get
        	{
        		var obj = ViewState["ClientVisible"]; 
        		if (obj == null)
        		{
        			return false;
        		}
        		return (bool)obj;
        	}
        	set 
        	{
        		ViewState["ClientVisible"] = value;
        	}
        }

        protected GeneralControl(string tag)
        {
            _tag = tag;
            ClientVisible = true;
        }

        protected new virtual void AddAttributesToRender(HtmlTextWriter writer)
        {
        }

        private void RenderAttributes(HtmlTextWriter writer)
        {
            if (!ClientVisible)
            {
                Style.Add("display", "none");
            }
            if (Width != Unit.Empty)
            {
                Style.Add(HtmlTextWriterStyle.Width, Width.ToString());
            }
            if (Height != Unit.Empty)
            {
                Style.Add(HtmlTextWriterStyle.Height, Height.ToString());
            }
            foreach (string key in Attributes.Keys)
            {
                writer.WriteAttribute(key, Attributes[key]);
            }
            AddAttributesToRender(writer);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (!Visible)
                return;
            writer.Write("<" + _tag);
            RenderAttributes(writer);
            if (!AutoCloseTag)
            {
                writer.Write(">");
                RenderChildren(writer);
                writer.Write("</" + _tag + ">");
            }
            else
            {
                writer.Write("/>");
            }  
        }

        public string GetAttribute(string key)
        {
            return Attributes[key];
        }

        public void SetAttribute(string key, string value)
        {
            Attributes[key] = value;
        }
    }
}