using System.ComponentModel;
using System.Web.UI;

namespace AspNet.HtmlControls
{
    public class ImageButton : FormField
    {
        protected override InputTypes Type
        {
            get { return InputTypes.Image;}
        }

        /// <summary>
        /// 定义图像的替代文本。仅可与 type="image" 配合使用。
        /// </summary>
        public string Alt
        {
            get { return Attributes["alt"]; }
            set { Attributes["alt"] = value; }
        }

        /// <summary>
        /// 定义要显示的图像的 URL。仅用于 type="image" 时。
        /// </summary>
        [DefaultValue("")]
        [UrlProperty]
        [Bindable(true)]
        public string Src
        {
            get { return Attributes["src"]; }
            set { Attributes["src"] = value; }
        }
    }
}
