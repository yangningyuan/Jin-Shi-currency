using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web.UI.WebControls;
using System.Web;

namespace Common
{
    public class FileHelper
    {
        /// <summary>
        /// �ϴ��ļ��������ļ����ڷ����������·��(Ŀ¼·��+�ļ�����ʵ����)
        /// </summary>
        /// <param name="fileUpload">FileUpload�������ؼ�</param>
        /// <param name="strPath">�ļ����Ŀ¼</param>
        /// <param name="fileSize">�����ϴ��ļ��Ĵ�С</param>
        /// <param name="allowedExtensions">�����ϴ��ļ��ĸ�ʽ</param>
        /// <param name="stroldPath">�Ƿ�ָ���ļ�·��(Ŀ¼·��+�ļ�����ʵ����)</param>
        /// <returns>�����ļ�·��(Ŀ¼·��+�ļ�����ʵ����)</returns>
        public static string UploadFile(FileUpload fileUpload, string strPath, int fileSize, string[] allowedExtensions, bool blDatePath, string stroldPath)
        {
            string uploadedPath = "";
            bool fileOk = false;
            string filePath = HttpContext.Current.Server.MapPath(strPath);
            string fileExtension = System.IO.Path.GetExtension(fileUpload.FileName).ToLower();

            if (fileUpload.HasFile)
            {
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i].ToLower())
                    {
                        fileOk = true;
                    }
                }
            }

            if (fileOk)
            {
                try
                {
                    if (fileUpload.PostedFile.ContentLength < fileSize * 1024)
                    {
                        if (stroldPath == "")
                        {
                            if (blDatePath)
                            {
                                string dateFileName = GetDateTimeFileName();
                                fileUpload.PostedFile.SaveAs(filePath + dateFileName + fileExtension);
                                uploadedPath = strPath + dateFileName + fileExtension;
                            }
                            else
                            {
                                fileUpload.PostedFile.SaveAs(filePath + fileUpload.FileName);
                                uploadedPath = strPath + fileUpload.FileName;
                            }
                        }
                        else
                        {
                            stroldPath = strPath + System.IO.Path.GetFileNameWithoutExtension(stroldPath) + fileExtension;
                            fileUpload.PostedFile.SaveAs(HttpContext.Current.Server.MapPath(stroldPath));
                            uploadedPath = stroldPath;
                        }
                    }
                    else
                    {
                        uploadedPath = "";
                        HttpContext.Current.Response.Write("<script>alert('��ʾ:�ļ��Ĵ�С�����涨�Ĵ�С!');</script>");
                    }
                }
                catch
                {
                    uploadedPath = "";
                }
            }
            else
            {
                uploadedPath = "";
                HttpContext.Current.Response.Write("<script>alert('��ʾ:���ϴ����ļ���ʽ����ȷ!');</script>");
            }
            return uploadedPath;
        }

        /// <summary>
        /// �ѷ������ϵ��ļ����ص����ػ���
        /// </summary>
        /// <param name="strDownFile">�ļ�·��</param>
        public static void DownloadFile(string strDownFile)
        {
            string str = HttpContext.Current.Server.MapPath(strDownFile);
            if (System.IO.File.Exists(str))
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(str);
                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.ClearHeaders();
                System.Web.HttpContext.Current.Response.Buffer = false;
                System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
                System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fi.FullName, System.Text.Encoding.UTF8));
                System.Web.HttpContext.Current.Response.AppendHeader("Content-Length", fi.Length.ToString());
                System.Web.HttpContext.Current.Response.WriteFile(fi.FullName);
                System.Web.HttpContext.Current.Response.Flush();
                System.Web.HttpContext.Current.Response.End();
            }
            else
            {
                HttpContext.Current.Response.Write("<script>alert('��ʾ:���ļ�·��������!');</script>");
            }
        }

        /// <summary>
        /// ����ʱ�������ϴ��ļ����ļ���
        /// </summary>
        /// <returns></returns>
        public static string GetDateTimeFileName()
        {
            string File = DateTime.Now.ToString();
            File = File.Replace(":", "");
            File = File.Replace(" ", "");
            File = File.Replace("-", "");
            Random Ran = new Random();
            File = File + Ran.Next(9999);
            return File;
        }
    }
}
