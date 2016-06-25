using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Common
{
	/// <summary>
	/// 原作者:Joel Neubeck 
	/// </summary>
	public class WebWaterMark
	{
		public WebWaterMark()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//// <summary>
		/// 用于处理图片
		/// 给图片加入水印
		/// </summary>
		/// <param name="Copyright">需要写入的版权信息</param>
		/// <param name="MarkBmpPath">需要假如的logo图片</param>
		/// <param name="photoPath">需要处理的图片的路径</param>
		/// <param name="savePhotoPath">保存的图片路径</param>,string MarkBmpPath
		public void MakeWatermark(string Copyright,System.IO.Stream fileStream,string savePhotoPath)
		{

			//创建一个image对象,即要被处理的图片
			Image imgPhoto = Image.FromStream(fileStream);
			int phWidth = 640;
			int phHeight = 480;

			//创建原始图片大小的Bitmap
			Bitmap bmPhoto = new Bitmap(phWidth, phHeight, PixelFormat.Format24bppRgb);

			bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

			//将位图bmPhoto加载到Graphics对象
			Graphics grPhoto = Graphics.FromImage(bmPhoto);

			//创建一个需要填充水银的Image对象
//			Image imgWatermark = new Bitmap(MarkBmpPath);
//			int wmWidth = imgWatermark.Width;
//			int wmHeight = imgWatermark.Height;

			//------------------------------------------------------------
			//第一步,插入版权信息
			//------------------------------------------------------------

			//设置图象的成相质量
			grPhoto.SmoothingMode = SmoothingMode.AntiAlias;

			//将原始图象绘制到grPhoto上
			grPhoto.DrawImage(
				imgPhoto,                               // 要绘制的Image对象
				new Rectangle(0, 0, phWidth, phHeight), // 绘制图象的位置和大小
				0,                                      // 要绘制的原图象部分的左上角的X坐标
				0,                                      // 要绘制的原图象部分的左上角的Y坐标
				phWidth,                                // 要绘制的原图象的高度
				phHeight,                               // 要绘制的原图象的宽度
				GraphicsUnit.Pixel);                    // 源矩形的度量单位

			//-------------------------------------------------------
			//字体大小放在一个数组中,最大字体为32.
			//感觉用处不大,可以自己再修改这里
			//-------------------------------------------------------
			int[] sizes = new int[]{30,7,6,5,4};

			Font crFont = null;
			SizeF crSize = new SizeF();

			//循环测试数组中所定义的字体大小是否适合版权信息,如果合适就使用此种字体大小
			for (int i=0 ;i<5; i++)
			{
				//设置字体类型,可以单独提出,作为参数
				crFont = new Font("Verdana, Helvetica, Arial, sans-serif", sizes[i], FontStyle.Bold);
				//测量此种字体大小
				crSize = grPhoto.MeasureString(Copyright, crFont);

				if((ushort)crSize.Width < (ushort)phWidth)
					break;
			}

			//给底部保留%3的空间
			int yPixlesFromBottom = (int)(phHeight *.05);

			//设置字体在图片中的位置
			float yPosFromBottom = ((phHeight - yPixlesFromBottom)-(crSize.Height/2));

			//float xCenterOfImg = (phWidth/2);
			float xCenterOfImg = (phWidth-(crSize.Width)/2);
			//设置字体居中
			StringFormat StrFormat = new StringFormat();
			StrFormat.Alignment = StringAlignment.Center;
            
			//设置绘制文本的颜色和纹理 (Alpha=153)
			SolidBrush semiTransBrush2 = new SolidBrush(Color.FromArgb(123, 0, 0, 0));

			//将版权信息绘制到图象上
			grPhoto.DrawString(Copyright,                     //版权信息
				crFont,                                       //字体
				semiTransBrush2,                              //绘制文本的颜色及纹理
				new PointF(xCenterOfImg+1,yPosFromBottom+1),  //绘制文本的位置
				StrFormat);                                   //格式

			//设置绘制文本的颜色和纹理 (Alpha=153)
			SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(123, 255, 255, 255));

			//重新绘制版权信息,以让其具有阴影效果
			//将文本向又下移动一个象素
			grPhoto.DrawString(Copyright,                 //版权信息
				crFont,                                   //字体
				semiTransBrush,                           //绘制文本的颜色及纹理
				new PointF(xCenterOfImg,yPosFromBottom),  //绘制文本的位置
				StrFormat);                               //格式

            

			//------------------------------------------------------------
			//第二步,插入图片水印
			//------------------------------------------------------------

			//在原来修改过的bmPhoto上创建一个水银位图
			Bitmap bmWatermark = new Bitmap(bmPhoto);

			bmWatermark.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
			//将位图bmWatermark加载到Graphics对象
			Graphics grWatermark = Graphics.FromImage(bmWatermark);

			//Replace the original photgraphs bitmap with the new Bitmap
			imgPhoto = bmWatermark;
			grPhoto.Dispose();
			grWatermark.Dispose();

			//save new image to file system.
			imgPhoto.Save(savePhotoPath, ImageFormat.Jpeg);
			imgPhoto.Dispose();
//			imgWatermark.Dispose();

		}

        public void ImageUtils(System.IO.Stream fileStream, string savePhotoPath, int width, int height)
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
                //以jpg格式保存缩略图
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
