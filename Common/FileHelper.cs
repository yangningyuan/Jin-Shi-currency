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
        /// 上传文件并返回文件所在服务器的相对路径(目录路径+文件的真实名称)
        /// </summary>
        /// <param name="fileUpload">FileUpload服务器控件</param>
        /// <param name="strPath">文件存放目录</param>
        /// <param name="fileSize">允许上传文件的大小</param>
        /// <param name="allowedExtensions">允许上传文件的格式</param>
        /// <param name="stroldPath">是否指定文件路径(目录路径+文件的真实名称)</param>
        /// <returns>返回文件路径(目录路径+文件的真实名称)</returns>
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
                        HttpContext.Current.Response.Write("<script>alert('提示:文件的大小超出规定的大小!');</script>");
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
                HttpContext.Current.Response.Write("<script>alert('提示:你上传的文件格式不正确!');</script>");
            }
            return uploadedPath;
        }

        /// <summary>
        /// 把服务器上的文件下载到本地机上
        /// </summary>
        /// <param name="strDownFile">文件路径</param>
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
                HttpContext.Current.Response.Write("<script>alert('提示:此文件路径不存在!');</script>");
            }
        }

        /// <summary>
        /// 根据时间设置上传文件的文件名
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
