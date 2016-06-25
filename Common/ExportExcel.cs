using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using System.IO;
using NPOI.SS.Util;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using System.Web;

namespace Common
{
    public class ExportExcel
    {

        #region 导出DataGrid数据到Excel的实现方法

        public void DataTableToExcel(System.Data.DataTable dtData)
        {
            string filename = DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
            System.Web.UI.WebControls.DataGrid dgExport = null;
            // 当前对话 
            System.Web.HttpContext curContext = System.Web.HttpContext.Current;
            // IO用于导出并返回excel文件 
            System.IO.StringWriter strWriter = null;
            System.Web.UI.HtmlTextWriter htmlWriter = null;
            if (dtData != null)
            {
                // 设置编码和附件格式 
                //Response.ContentType指定文件类型 可以为application/ms-excel、application/ms-word、application/ms-txt、application/ms-html 
                curContext.Response.ContentType = "application/vnd.ms-excel";
                curContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
                System.Web.HttpContext.Current.Response.Charset = "GB2312";
                //下面这行很重要， attachment 参数表示作为附件下载，您可以改成 online在线打开 
                //filename=FileFlow.xls 指定输出文件的名称，注意其扩展名和指定文件类型相符，可以为：.doc  .xls .txt　.htm　　 

                System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(filename, Encoding.GetEncoding("utf-8")));
                //    curContext.Response.Charset = ""; 

                // 导出excel文件 
                strWriter = new System.IO.StringWriter();
                htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);

                // 为了解决dgData中可能进行了分页的情况，需要重新定义一个无分页的DataGrid 
                dgExport = new System.Web.UI.WebControls.DataGrid();

                dgExport.DataSource = dtData.DefaultView;
                dgExport.AllowPaging = false;

                //身份证号的处理的关键在此事件            

                dgExport.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(gridHrInfo_ItemDataBound1);

                dgExport.DataBind();

                // 返回客户端 
                dgExport.RenderControl(htmlWriter);
                curContext.Response.Write(strWriter.ToString());
                //curContext.flush();
                curContext.Response.End();
            }
        }


        //此事件为处理18位身份证号 此事件在datagrid绑定时

        protected void gridHrInfo_ItemDataBound1(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //cells[10]是指表中要进行理的数据列（第10列为身份证列）
                e.Item.Cells[2].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
            }
        }


        /// <summary>
        /// 导出数据到EXCEL
        /// </summary>
        /// <param name="dataGrid">GridView</param>
        /// <param name="fileName">文件名。如filename.xls</param>
        public void ExportDataGrid(GridView dataGrid, string fileName)
        {
            ExportDataGrid(dataGrid, fileName, "application/vnd.ms-excel");
        }
        public void ExportDataGrid(GridView dataGrid, string fileName, string applicationType)
        {
            fileName = System.Web.HttpUtility.UrlEncode(fileName, Encoding.GetEncoding("utf-8"));  //防止中文文件名乱码

            dataGrid.Visible = true;
            if (dataGrid.Page != null)
            {
                dataGrid.Page.EnableViewState = false;
            }
            System.Web.HttpContext.Current.Response.Clear();   //清空缓冲区  
            System.Web.HttpContext.Current.Response.Buffer = true; //打开缓冲输出   
            System.Web.HttpContext.Current.Response.Charset = "GB2312";    //设置字符集
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);    //指定相应头信息,用来在浏览器下载或保存文件时表明它的文件名
            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");     //设置字符集 

            System.Web.HttpContext.Current.Response.ContentType = applicationType; //设置mime类型 excel:application/vnd.ms-excel
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            ClearControls(dataGrid);

            //返回客户端
            dataGrid.RenderControl(oHtmlTextWriter);
            System.Web.HttpContext.Current.Response.Write("<html><head><meta http-equiv=Content-Type content=\"text/html; charset=GB2312\"></head><body>");
            System.Web.HttpContext.Current.Response.Write(oStringWriter.ToString());
            System.Web.HttpContext.Current.Response.Write("</body></html>");
            System.Web.HttpContext.Current.Response.End();
        }
   

        private void ClearControls(Control control)
        {
            for (int i = control.Controls.Count - 1; i >= 0; i--)
            {
                ClearControls(control.Controls[i]);
            }

            if (!(control is TableCell))
            {
                if (control.GetType().GetProperty("SelectedItem") != null)
                {
                    LiteralControl literal = new LiteralControl();
                    control.Parent.Controls.Add(literal);
                    try
                    {
                        literal.Text = (string)control.GetType().GetProperty("SelectedItem").GetValue(control, null);
                    }
                    catch
                    {
                    }

                    control.Parent.Controls.Remove(control);
                }
                else if (control.GetType().GetProperty("Text") != null)
                {
                    LiteralControl literal = new LiteralControl();
                    control.Parent.Controls.Add(literal);
                    literal.Text = (string)control.GetType().GetProperty("Text").GetValue(control, null);
                    control.Parent.Controls.Remove(control);
                }
            }
            return;
        }
        #endregion

        /// <summary>
        /// 导出数据。 使用 GridView绑定
        /// </summary>
        /// <param name="ds">数据源</param>
        /// <param name="fileName">文件名。如 2011-12-6.xls</param>
        public void ExportData(System.Data.DataSet ds, string fileName)
        {
            System.Web.UI.WebControls.GridView grid = new GridView();

            grid.Style.Add("vnd.ms-excel.numberformat", "@ ");

            grid.DataSource = ds;
            grid.DataBind();

            ExportDataGrid(grid, fileName);
        }



        //工具类NPOI

        /// <summary>
        /// 设置公司，作者
        /// </summary>
        public void SetCompany(HSSFWorkbook hssfworkbook)
        {
            #region 作者
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "河南探路 .NET开发项目组";

            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "河南探路 .NET开发项目组";
            si.Title = "河南探路 .NET开发项目组";
            si.Author = "河南探路 .NET开发项目组";
            si.Comments = string.Format("文件创建于 {0}", DateTime.Now);
            hssfworkbook.DocumentSummaryInformation = dsi;
            hssfworkbook.SummaryInformation = si;
            #endregion
        }

        /// <summary>
        /// 先保存到服务器，再下载
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="fileName">完整的保存路径 </param>
        /// <param name="fileNameNoPath">下载的时候保存的文件名 (如 book.xls)</param>
        /// <param name="down">是否下载。</param>
        private void tSaveFile(HSSFWorkbook workbook, string fileName, string fileNameNoPath, bool down)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(ms);
                    ms.Flush();
                    ms.Position = 0;
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();

                    if (down)
                    {
                        ResponseAddHeader(fileNameNoPath);
                        
                        HttpContext.Current.Response.BinaryWrite(ms.ToArray());
                    }
                }
            }
        }

        /// <summary>
        /// 保存到服务器
        /// </summary>
        /// <param name="workbook">HSSFWorkbook</param>
        /// <param name="fileName">完整路径</param>
        public void SaveFile(HSSFWorkbook workbook, string fileName)
        {
            tSaveFile(workbook, fileName, null, false);
        }
        /// <summary>
        /// 下载  支持中文文件名。 空格会被替换成 + 号
        /// </summary>
        /// <param name="workbook">HSSFWorkbook</param>
        /// <param name="downfilename">文件的名称(请不要使用中文)  如 book.xls</param>
        public void Download(HSSFWorkbook workbook, string downfilename)
        {
            string _tempFileName = HttpContext.Current.Server.MapPath("~/_filebase/cachet/");
            DirectoryInfo floder = new DirectoryInfo(_tempFileName);
            if (!floder.Exists)
            {
                floder.Create();
            }
            _tempFileName += "temp_excel.xls";
            tSaveFile(workbook, _tempFileName, downfilename, true);
        }
        /// <summary>
        /// 平安导出统计报表
        /// </summary>
        /// <param name="workbook">HSSFWorkbook</param>
        /// <param name="downfilename">文件的名称(请不要使用中文)  如 book.xls</param>
        public void PinganDownload(HSSFWorkbook workbook, string downfilename,string WenjianName)
        {
            string _tempFileName = HttpContext.Current.Server.MapPath("~/_filebase/cachet/" + WenjianName + "/");

            DirectoryInfo floder = new DirectoryInfo(_tempFileName);
            if (!floder.Exists)
            {
                floder.Create();
            }
            _tempFileName += DateTime.Now.ToString("yyyyMMddHHmmss")+".xls";
            //_tempFileName += downfilename + ".xls";
            tSaveFile(workbook, _tempFileName, downfilename, true);
        }
        /// <summary>
        /// 下载  支持中文文件名。 空格会被替换成 + 号
        /// </summary>
        /// <param name="workbook">HSSFWorkbook</param>
        /// <param name="downfilename">文件的名称(请不要使用中文)  如 book.xls</param>
        public void DownloadCopy(HSSFWorkbook workbook, string downfilename, string MuluName)
        {
            string _tempFileName = HttpContext.Current.Server.MapPath("~/_filebase/cachet/" + MuluName+"/");
            DirectoryInfo floder = new DirectoryInfo(_tempFileName);
            if (!floder.Exists)
            {
                floder.Create();
            }
            _tempFileName += downfilename;
            tSaveFile(workbook, _tempFileName, downfilename, false);
        }

        /// <summary>
        /// 设置头信息，使支持中文下载。已测试 Firefox,IE，谷歌，苹果，opera。2012年1月12日 by chenxp
        /// 尽量不要使用空格，空格会被替换成 + 号
        /// </summary>
        /// <param name="FileName"></param>
        private void ResponseAddHeader(string FileName)
        {
            string UserAgent = HttpContext.Current.Request.ServerVariables["http_user_agent"].ToLower();

            if (UserAgent.Contains("msie") || UserAgent.Contains("opera"))
                FileName = HttpUtility.UrlEncode(FileName, Encoding.UTF8);
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + FileName); //指定相应头信息,用来在浏览器下载或保存文件时表明它的文件名
        }
    }


}
