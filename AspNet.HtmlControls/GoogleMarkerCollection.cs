using System;
using System.Collections;
using System.Text;
using System.Web.UI;

namespace AspNet.HtmlControls
{
    public sealed class GoogleMarkerCollection : IList, IStateManager
    {
        private ArrayList _googleMacker;

        private bool _marked;

        private bool _saveAll;

        public GoogleMarkerCollection()
        {
            _googleMacker = new ArrayList();
            _marked = false;
            _saveAll = false;
        }

        public IEnumerator GetEnumerator()
        {
            return _googleMacker.GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            _googleMacker.CopyTo(array, index);
        }

        public int Count
        {
            get { return _googleMacker.Count; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public bool IsSynchronized
        {
            get { return _googleMacker.IsSynchronized; }
        }

        public void Add(GoogleMarker marker)
        {
            _googleMacker.Add(marker);
            if (!_marked)
                return;
            marker.Dirty = true;
        }

        int IList.Add(object value)
        {
            if (value == null || value.GetType() != typeof(GoogleMarker))
                throw new ArrayTypeMismatchException();
             return _googleMacker.Add(value);
        }

        public bool Contains(object value)
        {
            return _googleMacker.Contains(value);
        }

        public void Clear()
        {
            _googleMacker.Clear();
            if (!_marked)
                return;
            _saveAll = true;
        }

        public int IndexOf(object value)
        {
            return _googleMacker.IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            _googleMacker.Insert(index, value);
            if (!_marked)
                return;
            _saveAll = true;
        }

        public void Remove(object value)
        {
            _googleMacker.Remove(value);
        }

        public void RemoveAt(int index)
        {
            _googleMacker.RemoveAt(index);
        }

        public GoogleMarker this[int index]
        {
            get { return (GoogleMarker) _googleMacker[index]; }
        }

        object IList.this[int index]
        {
            get { return _googleMacker[index]; }
            set { _googleMacker[index] = value; }
        }

        public bool IsReadOnly
        {
            get { return _googleMacker.IsReadOnly; }
        }

        public bool IsFixedSize
        {
            get { return false; }
        }

        public void LoadViewState(object savedState)
        {
            if (savedState == null)
            {
                return;
            }
            if (savedState is Pair)
            {
                var pair = savedState as Pair;
                var arr1 = (ArrayList) pair.First;
                var arr2 = (ArrayList) pair.Second;
                for (int i = 0; i < arr1.Count; i++)
                {
                    var index2 = (int) arr1[i];
                    if (index2 < Count)
                    {
                        this[index2].LoadViewState(arr2[i]);
                    }
                    else
                    {
                        var marker = new GoogleMarker();
                        marker.LoadViewState(arr2[i]);
                        Add(marker);
                    }
                }
            }
            else
            {
                var triplet = (Triplet)savedState;
                _googleMacker = new ArrayList();
                _saveAll = true;
                var arr1 = (double[]) triplet.First;
                var arr2 = (double[]) triplet.Second;
                var arr3 = (string[]) triplet.Third;
                for (int i = 0; i < arr1.Length; i++)
                {
                    Add(new GoogleMarker {Latitude = arr1[i], Longitude = arr2[i], IconUrl = arr3[i]});
                }
            }
        }

        public object SaveViewState()
        {
            var count = Count;
            if (_saveAll)
            {
                var arr1 = new double[count];
                var arr2 = new double[count];
                var arr3 = new string[count];
                for (var i = 0; i < count; i++)
                {
                    arr1[i] = this[i].Latitude;
                    arr2[i] = this[i].Longitude;
                    arr3[i] = this[i].IconUrl;
                }
                return new Triplet(arr1, arr2, arr3);
            }
            else
            {
                var arr1 = new ArrayList();
                var arr2 = new ArrayList();
                for (int i = 0; i < count; i++)
                {
                    var state = this[i].SaveViewState();
                    if (state != null)
                    {
                        arr1.Add(i);
                        arr2.Add(state);
                    }
                }
                return arr1.Count > 0 ? new Pair(arr1, arr2) : null;
            }
        }

        internal void TrackViewState()
        {
            _marked = true;
            foreach (GoogleMarker googleMarker in this)
            {
                googleMarker.TrackViewState();
            }
        }

        void IStateManager.TrackViewState()
        {
            TrackViewState();
        }

        public bool IsTrackingViewState { get { return _marked; }}

        internal string RenderJavascript(string clientID)
        {
            if (Count < 1)
            {
                return "";
            }
            var builder = new StringBuilder();
            builder.Append("var markers=[");
            for (int i = 0; i < Count; i++)
            {
                if (i > 0)
                {
                    builder.Append(",");
                }
                builder.Append(this[i].RenderJavascript());
            }
            builder.AppendFormat("];createMarkers(Map_{0},markers);", clientID);
            return builder.ToString();
        }
    }
}
