using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;

namespace AspNet.HtmlControls
{
    [ParseChildren(true)]
    public class GoogleMap : GeneralControl, ICoordinate
    {
        private GoogleMarkerCollection _markers;

        public int MinZoom
        {
            get { return (int)ViewState["GoogleMap_MinZoom"]; }
            set { ViewState["GoogleMap_MinZoom"] = value; }
        }

        public int MaxZoom
        {
            get { return (int)ViewState["GoogleMap_MaxZoom"]; }
            set { ViewState["GoogleMap_MaxZoom"] = value; }
        }

        public int Zoom
        {
            get { return (int)ViewState["GoogleMap_Zoom"]; }
            set { ViewState["GoogleMap_Zoom"] = value; }
        }

        public bool ShowZoomControl
        {
            get { return (bool)ViewState["GoogleMap_ShowZoomControl"]; }
            set { ViewState["GoogleMap_ShowZoomControl"] = value; }
        }

        public bool ShowPanControl
        {
            get { return (bool)ViewState["GoogleMap_ShowPanControl"]; }
            set { ViewState["GoogleMap_ShowPanControl"] = value; }
        }

        public bool ShowScaleControl
        {
            get { return (bool)ViewState["GoogleMap_ShowScaleControl"]; }
            set { ViewState["GoogleMap_ShowScaleControl"] = value; }
        }

        public bool ShowStreetViewControl
        {
            get { return (bool)ViewState["GoogleMap_ShowStreetViewControl"]; }
            set { ViewState["GoogleMap_ShowStreetViewControl"] = value; }
        }

        public bool ShowRotateControl
        {
            get { return (bool)ViewState["GoogleMap_ShowRotateControl"]; }
            set { ViewState["GoogleMap_ShowRotateControl"] = value; }
        }

        public bool ShowOverviewMapControl
        {
            get { return (bool)ViewState["GoogleMap_ShowOverviewMapControl"]; }
            set { ViewState["GoogleMap_ShowOverviewMapControl"] = value; }
        }

        public bool EnableScrollWheel
        {
            get { return (bool)ViewState["GoogleMap_EnableScrollWheel"]; }
            set { ViewState["GoogleMap_EnableScrollWheel"] = value; }
        }

        public double Latitude
        {
            get { return (double)ViewState["GoogleMap_Latitude"]; }
            set { ViewState["GoogleMap_Latitude"] = value; }
        }

        public double Longitude
        {
            get { return (double)ViewState["GoogleMap_Longitude"]; }
            set { ViewState["GoogleMap_Longitude"] = value; }
        }

        public GoogleMapType MapType
        {
            get { return (GoogleMapType)ViewState["GoogleMap_MapType"]; }
            set { ViewState["GoogleMap_MapType"] = value; }
        }

        public new string HtmlID
        {
            get { return ClientID; }
        }

        public GoogleMap() : base("div")
        {
            AutoCloseTag = false;
            MaxZoom = -1;
            MinZoom = -1;
            Zoom = 8;
            MapType = GoogleMapType.ROADMAP;
            ShowZoomControl = true;
            ShowPanControl = true;
            ShowScaleControl = true;
            ShowStreetViewControl = true;
            ShowRotateControl = true;
            ShowOverviewMapControl = true;
            EnableScrollWheel = true;
        }

        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        [MergableProperty(false)]
        public GoogleMarkerCollection GoogleMakers
        {
            get
            {
                if (_markers == null)
                {
                    _markers = new GoogleMarkerCollection();
                    if (IsTrackingViewState)
                        _markers.TrackViewState();
                }
                return _markers;
            }
        }

        protected override void TrackViewState()
        {
            base.TrackViewState();
            GoogleMakers.TrackViewState();
        }

        protected override void LoadViewState(object savedState)
        {
            if (savedState != null)
            {
                var pair = (Pair) savedState;
                base.LoadViewState(pair.First);
                GoogleMakers.LoadViewState(pair.Second);
            }
            else
            {
                base.LoadViewState(null);
            }
        }

        protected override object SaveViewState()
        {
            var x = base.SaveViewState();
            var y = GoogleMakers.SaveViewState();
            return new Pair(x, y);
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!CoordinateExtension.IsLatitudeValid(this))
            {
                throw new ArgumentOutOfRangeException("Latitude", "Latitude should between -90 and 90");
            }

            if (!CoordinateExtension.IsLongitudeValid(this))
            {
                throw new ArgumentOutOfRangeException("Longitude", "Longitude should between -180 and 180");
            }
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            writer.WriteAttribute("id", ClientID);
        }

        private string CreateOptionItem(string key, object value)
        {
            return string.Format("{0}:{1},", key, value);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            if (Context.Items["GoogleMapJavascript_Write_Include"] == null)
            {
                writer.Write("<script src=\"https://maps.googleapis.com/maps/api/js?v=3.exp\"></script>");
                Context.Items["GoogleMapJavascript_Write_Include"] = new object();
            }
            var builder = new StringBuilder();
            builder.Append(CreateOptionItem("zoom", Zoom));
            builder.Append(CreateOptionItem("center", string.Format("new google.maps.LatLng({0}, {1})", Latitude, Longitude)));
            builder.Append(CreateOptionItem("mapTypeId", "google.maps.MapTypeId." + MapType));
            builder.Append(CreateOptionItem("zoomControl", ShowZoomControl.ToString().ToLower()));
            builder.Append(CreateOptionItem("panControl", ShowPanControl.ToString().ToLower()));
            builder.Append(CreateOptionItem("scaleControl", ShowScaleControl.ToString().ToLower()));
            builder.Append(CreateOptionItem("streetViewControl", ShowStreetViewControl.ToString().ToLower()));
            builder.Append(CreateOptionItem("rotateControl", ShowRotateControl.ToString().ToLower()));
            builder.Append(CreateOptionItem("overviewMapControl", ShowOverviewMapControl.ToString().ToLower()));
            builder.Append(CreateOptionItem("scrollwheel", EnableScrollWheel.ToString().ToLower()));
            if (MaxZoom >= 0)
            {
                builder.Append(CreateOptionItem("maxZoom", MaxZoom));
            }
            if (MinZoom >= 0)
            {
                builder.Append(CreateOptionItem("minZoom", MinZoom));
            }
            if (GoogleMakers.Count > 0 && Context.Items["GoogleMapJavascript_Write_Func"] == null)
            {
                writer.Write("<script>");
                writer.Write("function createMarker(map, data){if(map == null || data == null){return null;}var pos = new google.maps.LatLng(data.lat, data.lng);var opt = {position: pos,map: map};if(typeof data.title === 'string'){opt.title = data.title;}if(typeof data.icon === 'string'){opt.icon = data.icon;}var marker=new google.maps.Marker(opt);marker.marker_data= data;if(typeof data.click === 'function'){google.maps.event.addListener(marker, 'click', function () {data.click(map, marker)});}return marker;}");
                writer.Write("function createMarkers(map, datas){if (map == null || datas == null || datas.length < 1) {return null;}map.markers = [];for (var i = 0; i < datas.length; i++) {var m = createMarker(map, datas[i]);if(m != null){map.markers.push(m);}};}");
                writer.Write("</script>");
                Context.Items["GoogleMapJavascript_Write_Func"] = new object();
            }
            writer.Write("<script>var Map_{0}=null;function initialize_Map_{0}(){{var mapOptions = {{{1}}};Map_{0}=new google.maps.Map(document.getElementById('{0}'),mapOptions);{2}}}google.maps.event.addDomListener(window, 'load', initialize_Map_{0});</script>",
                ClientID,
                builder,
                GoogleMakers.RenderJavascript(ClientID));
        }
    }
}
