using System.ComponentModel;
using System.Web.UI;

namespace AspNet.HtmlControls
{
    [ParseChildren(false)]
    [PersistChildren(true)]
    public class Form : GeneralControl
    {
        public Form() : base("form")
        {
        }

        /// <summary>
        /// 规定当提交表单时，向何处发送表单数据。
        /// </summary>
        [UrlProperty]
        [Bindable(false)]
        public string Action
        {
            get { return Attributes["action"]; }
            set { Attributes["action"] = value; }
        }

        /// <summary>
        /// 规定通过文件上传来提交的文件的类型(MIME_type)。
        /// </summary>
        [Bindable(false)]
        public string Accept
        {
            get { return Attributes["accept"]; }
            set { Attributes["accept"] = value; }
        }

        /// <summary>
        /// 服务器处理表单数据所接受的字符集。
        /// </summary>
        [Bindable(false)]
        public string AcceptCharset
        {
            get { return Attributes["accept-charset"]; }
            set { Attributes["accept-charset"] = value; }
        }

        /// <summary>
        /// 规定表单数据在发送到服务器之前应该如何编码(MIME_type)。
        /// </summary>
        [Bindable(false)]
        public string Enctype
        {
            get { return Attributes["enctype"]; }
            set { Attributes["enctype"] = value; }
        }

        /// <summary>
        /// 规定如何发送表单数据(GET, POST)。
        /// </summary>
        [DefaultValue(typeof(FormMethods), "Post")]
        [Bindable(false)]
        public FormMethods Method
        {
            get
            {
                var obj = ViewState["Form_Method"];
                if (obj == null)
                {
                    return FormMethods.Post;
                }
                return (FormMethods)obj;
            }
            set { ViewState["Form_Method"] = value; }
        }

        /// <summary>
        /// 规定表单的名称。
        /// </summary>
        [Bindable(false)]
        [DefaultValue("")]
        public string FormName
        {
            get { return Attributes["name"]; }
            set { Attributes["name"] = value; }
        }

        public bool MultiPartForm
        {
            get
            {
                if (!string.IsNullOrEmpty(Enctype))
                    return "multipart/form-data" == Enctype.ToLower();
                return false;
            }
            set
            {
                if (value)
                {
                    Enctype = "multipart/form-data";
                }
                else
                {
                    if (!string.IsNullOrEmpty(Enctype) && "multipart/form-data" == Enctype.ToLower())
                        Attributes.Remove("enctype");
                }
            }
        }

        /// <summary>
        /// 规定在何处打开 action URL。
        /// </summary>
        public string Target
        {
            get { return Attributes["target"]; }
            set { Attributes["target"] = value; }
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            writer.WriteAttribute("method", Method.ToString().ToUpper());
        }
    }
}
