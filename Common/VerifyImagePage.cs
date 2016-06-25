using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Common
{
    /// <summary>
    /// 验证码图片页面类
    /// </summary>
    public class VerifyImagePage : System.Web.UI.Page
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e"></param>
        override protected void OnInit(EventArgs e)
        {
            //
            base.OnInit(e);

            string authStr = StringUtil.CreateAuthStr(5, true);
            Utils.WriteCookie("verifycode", authStr);

            VerifyImage verifyimg = new VerifyImage(authStr, 90, 50);

            Bitmap image = verifyimg.Image;

            System.Web.HttpContext.Current.Response.ContentType = "image/pjpeg";

            //MemoryStream ms = new MemoryStream();
            image.Save(this.Response.OutputStream, ImageFormat.Jpeg);
            //System.Web.HttpContext.Current.Response.OutputStream.Write(ms.ToArray(), 0, (int)ms.Length);
        }
    }
}
