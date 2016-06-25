using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Common
{
    /// <summary>
    /// 图像处理类
    /// </summary>
    public class ImageUtils
    {
        public ImageUtils()
        { }

        /// <summary>
        /// 生成缩率图
        /// 缩率图统一保存为PNG格式,其他格式图片缩小后像素失真
        /// </summary>
        /// <param name="fileStream"></param>
        /// <param name="savePhotoPath"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void MakeThumbnail(System.IO.Stream fileStream, string savePhotoPath, int width, int height)
        {
            Image originalImage = Image.FromStream(fileStream);

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            //新建一个bmp图片
            Image bitmap = new Bitmap(width, height);

            //新建一个画板
            Graphics g = Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充 
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, width, height), new Rectangle(x, y, ow, oh), GraphicsUnit.Pixel);

            try
            {
                //以PNG格式保存缩略图
                bitmap.Save(savePhotoPath, ImageFormat.Png);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
    }
}
