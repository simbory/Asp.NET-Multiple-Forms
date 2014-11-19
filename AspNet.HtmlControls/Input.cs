using System;
using System.Collections.Specialized;
using System.Web.UI;

namespace AspNet.HtmlControls
{
    public abstract class Input : GeneralControl
    {
        protected Input(string tag) : base(tag)
        {
            AutoCloseTag = true;
            Enabled = true;
        }

        protected Input() : this("input")
        {
        }

        protected abstract InputTypes Type { get; }

        /// <summary>
        /// 为 input 元素定义唯一的名称。
        /// </summary>
        public string Name
        {
            get { return string.IsNullOrEmpty(Attributes["name"]) ? UniqueID : Attributes["name"]; }
            set { Attributes["name"] = value; }
        }

        public new bool Enabled
        {
            get
            {
                foreach (string key in Attributes.Keys)
                {
                    if ("disabled".Equals(key))
                        return false;
                }
                return true;
            }
            set
            {
                if (value)
                {
                    Attributes.Remove("disabled");
                }
                else
                {
                    Attributes["disabled"] = "disabled";
                }
            }
        }

        private bool HasKey(NameValueCollection collection, string key)
        {
            foreach (var k in collection.AllKeys)
            {
                if (k.Equals(key))
                    return true;
            }
            return false;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!string.IsNullOrEmpty(Name) && Page.Request.HttpMethod == "POST")
            {
                LoadPostData(Page.Request.Form[Name], HasKey(Page.Request.Form, Name));
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Page.Request.HttpMethod == "POST")
            {
                RaisePostBackEvent();
            }
        }

        private bool InForm(Control ctrl)
        {
            if (ctrl == null)
                return false;
            if (ctrl.Parent.GetType() == typeof (Form))
                return true;
            return InForm(ctrl.Parent);
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (InForm(this))
            {
                Attributes["name"] = Name;
            }
            base.OnPreRender(e);
        }

        protected virtual void RaisePostBackEvent()
        {
            
        }

        protected virtual void LoadPostData(string postValue, bool hasKey)
        {
            
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            if (Type == InputTypes.Invalid)
                return;
            writer.WriteAttribute("type", InputTypes.LocalDateTime == Type ? "datetime-local" : Type.ToString().ToLower());
        }
    }
}
