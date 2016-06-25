using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Common
{
	/// <summary>
	/// ԭ����:Joel Neubeck 
	/// </summary>
	public class WebWaterMark
	{
		public WebWaterMark()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		//// <summary>
		/// ���ڴ���ͼƬ
		/// ��ͼƬ����ˮӡ
		/// </summary>
		/// <param name="Copyright">��Ҫд��İ�Ȩ��Ϣ</param>
		/// <param name="MarkBmpPath">��Ҫ�����logoͼƬ</param>
		/// <param name="photoPath">��Ҫ�����ͼƬ��·��</param>
		/// <param name="savePhotoPath">�����ͼƬ·��</param>,string MarkBmpPath
		public void MakeWatermark(string Copyright,System.IO.Stream fileStream,string savePhotoPath)
		{

			//����һ��image����,��Ҫ�������ͼƬ
			Image imgPhoto = Image.FromStream(fileStream);
			int phWidth = 640;
			int phHeight = 480;

			//����ԭʼͼƬ��С��Bitmap
			Bitmap bmPhoto = new Bitmap(phWidth, phHeight, PixelFormat.Format24bppRgb);

			bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

			//��λͼbmPhoto���ص�Graphics����
			Graphics grPhoto = Graphics.FromImage(bmPhoto);

			//����һ����Ҫ���ˮ����Image����
//			Image imgWatermark = new Bitmap(MarkBmpPath);
//			int wmWidth = imgWatermark.Width;
//			int wmHeight = imgWatermark.Height;

			//------------------------------------------------------------
			//��һ��,�����Ȩ��Ϣ
			//------------------------------------------------------------

			//����ͼ��ĳ�������
			grPhoto.SmoothingMode = SmoothingMode.AntiAlias;

			//��ԭʼͼ����Ƶ�grPhoto��
			grPhoto.DrawImage(
				imgPhoto,                               // Ҫ���Ƶ�Image����
				new Rectangle(0, 0, phWidth, phHeight), // ����ͼ���λ�úʹ�С
				0,                                      // Ҫ���Ƶ�ԭͼ�󲿷ֵ����Ͻǵ�X����
				0,                                      // Ҫ���Ƶ�ԭͼ�󲿷ֵ����Ͻǵ�Y����
				phWidth,                                // Ҫ���Ƶ�ԭͼ��ĸ߶�
				phHeight,                               // Ҫ���Ƶ�ԭͼ��Ŀ��
				GraphicsUnit.Pixel);                    // Դ���εĶ�����λ

			//-------------------------------------------------------
			//�����С����һ��������,�������Ϊ32.
			//�о��ô�����,�����Լ����޸�����
			//-------------------------------------------------------
			int[] sizes = new int[]{30,7,6,5,4};

			Font crFont = null;
			SizeF crSize = new SizeF();

			//ѭ������������������������С�Ƿ��ʺϰ�Ȩ��Ϣ,������ʾ�ʹ�ô��������С
			for (int i=0 ;i<5; i++)
			{
				//������������,���Ե������,��Ϊ����
				crFont = new Font("Verdana, Helvetica, Arial, sans-serif", sizes[i], FontStyle.Bold);
				//�������������С
				crSize = grPhoto.MeasureString(Copyright, crFont);

				if((ushort)crSize.Width < (ushort)phWidth)
					break;
			}

			//���ײ�����%3�Ŀռ�
			int yPixlesFromBottom = (int)(phHeight *.05);

			//����������ͼƬ�е�λ��
			float yPosFromBottom = ((phHeight - yPixlesFromBottom)-(crSize.Height/2));

			//float xCenterOfImg = (phWidth/2);
			float xCenterOfImg = (phWidth-(crSize.Width)/2);
			//�����������
			StringFormat StrFormat = new StringFormat();
			StrFormat.Alignment = StringAlignment.Center;
            
			//���û����ı�����ɫ������ (Alpha=153)
			SolidBrush semiTransBrush2 = new SolidBrush(Color.FromArgb(123, 0, 0, 0));

			//����Ȩ��Ϣ���Ƶ�ͼ����
			grPhoto.DrawString(Copyright,                     //��Ȩ��Ϣ
				crFont,                                       //����
				semiTransBrush2,                              //�����ı�����ɫ������
				new PointF(xCenterOfImg+1,yPosFromBottom+1),  //�����ı���λ��
				StrFormat);                                   //��ʽ

			//���û����ı�����ɫ������ (Alpha=153)
			SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(123, 255, 255, 255));

			//���»��ư�Ȩ��Ϣ,�����������ӰЧ��
			//���ı��������ƶ�һ������
			grPhoto.DrawString(Copyright,                 //��Ȩ��Ϣ
				crFont,                                   //����
				semiTransBrush,                           //�����ı�����ɫ������
				new PointF(xCenterOfImg,yPosFromBottom),  //�����ı���λ��
				StrFormat);                               //��ʽ

            

			//------------------------------------------------------------
			//�ڶ���,����ͼƬˮӡ
			//------------------------------------------------------------

			//��ԭ���޸Ĺ���bmPhoto�ϴ���һ��ˮ��λͼ
			Bitmap bmWatermark = new Bitmap(bmPhoto);

			bmWatermark.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
			//��λͼbmWatermark���ص�Graphics����
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

            //�½�һ��bmpͼƬ
            Image bitmap = new Bitmap(width, height);

            //�½�һ������
            Graphics g = Graphics.FromImage(bitmap);

            //���ø�������ֵ��
            g.InterpolationMode = InterpolationMode.High;

            //���ø�����,���ٶȳ���ƽ���̶�
            g.SmoothingMode = SmoothingMode.HighQuality;

            //��ջ�������͸������ɫ��� 
            g.Clear(Color.Transparent);

            //��ָ��λ�ò��Ұ�ָ����С����ԭͼƬ��ָ������
            g.DrawImage(originalImage, new Rectangle(0, 0, width, height), new Rectangle(x, y, ow, oh), GraphicsUnit.Pixel);

            try
            {
                //��jpg��ʽ��������ͼ
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
