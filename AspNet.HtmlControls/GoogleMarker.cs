using System.Globalization;
using System.Text;
using System.Web.UI;

namespace AspNet.HtmlControls
{
    public class GoogleMarker : IAttributeAccessor, ICoordinate, IStateManager
    {
        private AttributeCollection _attributes;

        private bool _marked;

        private bool _latisdirty;

        private bool _lngisdirty;

        private bool _urlisdirty;

        internal bool Dirty
        {
            get
            {
                if (!_latisdirty && !_lngisdirty)
                    return _urlisdirty;
                return true;
            }
            set
            {
                _latisdirty = value;
                _lngisdirty = value;
                _urlisdirty = value;
            }
        }

        public AttributeCollection Attributes
        {
            get { return _attributes ?? (_attributes = new AttributeCollection(new StateBag(true))); }
        }

        public double Latitude
        {
            get { return double.Parse(Attributes["Latitude"]); }
            set { Attributes["Latitude"] = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double Longitude
        {
            get { return double.Parse(Attributes["Longitude"]); }
            set { Attributes["Longitude"] = value.ToString(CultureInfo.InvariantCulture); }
        }

        [UrlProperty]
        public string IconUrl
        {
            get { return Attributes["IconUrl"]; }
            set { Attributes["IconUrl"] = value; }
        }

        public string Title
        {
            get { return Attributes["Marker_Title"]; }
            set { Attributes["Marker_Title"] = value; }
        }

        public string OnClientClick
        {
            get { return Attributes["OnClientClick"]; }
            set { Attributes["OnClientClick"] = value; }
        }

        public string GetAttribute(string key)
        {
            return Attributes[key];
        }

        public void SetAttribute(string key, string value)
        {
            Attributes[key] = value;
        }

        public void LoadViewState(object state)
        {
            if (state == null)
                return;
            if (state is Quintuple)
            {
                var data = state as Quintuple;
                Latitude = (double) data.First;
                Longitude = (double) data.Second;
                IconUrl = data.Third as string;
                Title = data.Fourth as string;
                OnClientClick = data.Fifth as string;
            }
        }

        public object SaveViewState()
        {
            return new Quintuple(Latitude, Longitude, IconUrl ?? "", Title ?? "", OnClientClick ?? "");
        }

        public void TrackViewState()
        {
            _marked = true;
        }

        public bool IsTrackingViewState
        {
            get { return _marked; }
        }

        internal string RenderJavascript()
        {
            var builder = new StringBuilder();
            builder.AppendFormat("{{lat:{0},lng:{1}", Latitude, Longitude);
            if (!string.IsNullOrEmpty(IconUrl))
            {
                builder.AppendFormat(",icon:'{0}'", IconUrl);
            }
            if (!string.IsNullOrEmpty(Title))
            {
                builder.AppendFormat(",title:'{0}'", Title.Replace("'", "\\'"));
            }
            if (!string.IsNullOrEmpty(OnClientClick))
            {
                builder.AppendFormat(",click:{0}", OnClientClick);
            }
            builder.Append("}");
            return builder.ToString();
        }
    }
}
