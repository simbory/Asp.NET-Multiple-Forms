using System;

namespace AspNet.HtmlControls
{
    public class SubmitButton : FormField
    {
        private static readonly object EventClick = new object();

        private bool _needRaisePostEvent = false;

        public event EventHandler Click
        {
            add
            {
                Events.AddHandler(EventClick, value);
            }
            remove
            {
                Events.RemoveHandler(EventClick, value);
            }
        }

        protected override InputTypes Type
        {
            get { return  InputTypes.Submit;}
        }

        public string Text
        {
            get { return Attributes["value"]; }
            set { Attributes["value"] = value; }
        }

        protected virtual void OnClick(EventArgs e)
        {
            var eventHandler = (EventHandler)Events[EventClick];
            if (eventHandler == null)
                return;
            eventHandler(this, e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Attributes["name"] = Name;
        }

        protected override void LoadPostData(string postValue, bool hasKey)
        {
            _needRaisePostEvent = hasKey;
        }

        protected override void RaisePostBackEvent()
        {
            if (_needRaisePostEvent)
            {
                OnClick(new EventArgs());
            }
        }
    }
}
