using System;
using System.Web;

namespace AspNet.HtmlControls
{
    public class FileUpload : FormField
    {
        protected override InputTypes Type
        {
            get { return InputTypes.File;}
        }

        /// <summary>
        /// 一个逗号分隔的 MIME 类型列表，指示文件传输的 MIME 类型。
        /// </summary>
        public string Accept
        {
            get { return Attributes["accept"]; }
            set { Attributes["accept"] = value; }
        }

        public bool HasFile
        {
            get { return PostedFile != null && PostedFile.ContentLength > 0; }
        }

        public string FileName
        {
            get { return HasFile ? PostedFile.FileName : null; }
        }

        public HttpPostedFile PostedFile { get; set; }

        public void SaveAs(string filename)
        {
            var postedFile = PostedFile;
            if (postedFile == null)
                return;
            postedFile.SaveAs(filename);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Attributes["name"] = Name;
        }

        protected override void LoadPostData(string postValue, bool hasKey)
        {
            PostedFile = Page.Request.Files[Name];
        }
    }
}
