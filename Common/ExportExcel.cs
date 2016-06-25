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

        #region ����DataGrid���ݵ�Excel��ʵ�ַ���

        public void DataTableToExcel(System.Data.DataTable dtData)
        {
            string filename = DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
            System.Web.UI.WebControls.DataGrid dgExport = null;
            // ��ǰ�Ի� 
            System.Web.HttpContext curContext = System.Web.HttpContext.Current;
            // IO���ڵ���������excel�ļ� 
            System.IO.StringWriter strWriter = null;
            System.Web.UI.HtmlTextWriter htmlWriter = null;
            if (dtData != null)
            {
                // ���ñ���͸�����ʽ 
                //Response.ContentTypeָ���ļ����� ����Ϊapplication/ms-excel��application/ms-word��application/ms-txt��application/ms-html 
                curContext.Response.ContentType = "application/vnd.ms-excel";
                curContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
                System.Web.HttpContext.Current.Response.Charset = "GB2312";
                //�������к���Ҫ�� attachment ������ʾ��Ϊ�������أ������Ըĳ� online���ߴ� 
                //filename=FileFlow.xls ָ������ļ������ƣ�ע������չ����ָ���ļ��������������Ϊ��.doc  .xls .txt��.htm���� 

                System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(filename, Encoding.GetEncoding("utf-8")));
                //    curContext.Response.Charset = ""; 

                // ����excel�ļ� 
                strWriter = new System.IO.StringWriter();
                htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);

                // Ϊ�˽��dgData�п��ܽ����˷�ҳ���������Ҫ���¶���һ���޷�ҳ��DataGrid 
                dgExport = new System.Web.UI.WebControls.DataGrid();

                dgExport.DataSource = dtData.DefaultView;
                dgExport.AllowPaging = false;

                //���֤�ŵĴ���Ĺؼ��ڴ��¼�            

                dgExport.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(gridHrInfo_ItemDataBound1);

                dgExport.DataBind();

                // ���ؿͻ��� 
                dgExport.RenderControl(htmlWriter);
                curContext.Response.Write(strWriter.ToString());
                //curContext.flush();
                curContext.Response.End();
            }
        }


        //���¼�Ϊ����18λ���֤�� ���¼���datagrid��ʱ

        protected void gridHrInfo_ItemDataBound1(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //cells[10]��ָ����Ҫ������������У���10��Ϊ���֤�У�
                e.Item.Cells[2].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
            }
        }


        /// <summary>
        /// �������ݵ�EXCEL
        /// </summary>
        /// <param name="dataGrid">GridView</param>
        /// <param name="fileName">�ļ�������filename.xls</param>
        public void ExportDataGrid(GridView dataGrid, string fileName)
        {
            ExportDataGrid(dataGrid, fileName, "application/vnd.ms-excel");
        }
        public void ExportDataGrid(GridView dataGrid, string fileName, string applicationType)
        {
            fileName = System.Web.HttpUtility.UrlEncode(fileName, Encoding.GetEncoding("utf-8"));  //��ֹ�����ļ�������

            dataGrid.Visible = true;
            if (dataGrid.Page != null)
            {
                dataGrid.Page.EnableViewState = false;
            }
            System.Web.HttpContext.Current.Response.Clear();   //��ջ�����  
            System.Web.HttpContext.Current.Response.Buffer = true; //�򿪻������   
            System.Web.HttpContext.Current.Response.Charset = "GB2312";    //�����ַ���
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);    //ָ����Ӧͷ��Ϣ,��������������ػ򱣴��ļ�ʱ���������ļ���
            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");     //�����ַ��� 

            System.Web.HttpContext.Current.Response.ContentType = applicationType; //����mime���� excel:application/vnd.ms-excel
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            ClearControls(dataGrid);

            //���ؿͻ���
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
        /// �������ݡ� ʹ�� GridView��
        /// </summary>
        /// <param name="ds">����Դ</param>
        /// <param name="fileName">�ļ������� 2011-12-6.xls</param>
        public void ExportData(System.Data.DataSet ds, string fileName)
        {
            System.Web.UI.WebControls.GridView grid = new GridView();

            grid.Style.Add("vnd.ms-excel.numberformat", "@ ");

            grid.DataSource = ds;
            grid.DataBind();

            ExportDataGrid(grid, fileName);
        }



        //������NPOI

        /// <summary>
        /// ���ù�˾������
        /// </summary>
        public void SetCompany(HSSFWorkbook hssfworkbook)
        {
            #region ����
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "����̽· .NET������Ŀ��";

            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "����̽· .NET������Ŀ��";
            si.Title = "����̽· .NET������Ŀ��";
            si.Author = "����̽· .NET������Ŀ��";
            si.Comments = string.Format("�ļ������� {0}", DateTime.Now);
            hssfworkbook.DocumentSummaryInformation = dsi;
            hssfworkbook.SummaryInformation = si;
            #endregion
        }

        /// <summary>
        /// �ȱ��浽��������������
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="fileName">�����ı���·�� </param>
        /// <param name="fileNameNoPath">���ص�ʱ�򱣴���ļ��� (�� book.xls)</param>
        /// <param name="down">�Ƿ����ء�</param>
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
        /// ���浽������
        /// </summary>
        /// <param name="workbook">HSSFWorkbook</param>
        /// <param name="fileName">����·��</param>
        public void SaveFile(HSSFWorkbook workbook, string fileName)
        {
            tSaveFile(workbook, fileName, null, false);
        }
        /// <summary>
        /// ����  ֧�������ļ����� �ո�ᱻ�滻�� + ��
        /// </summary>
        /// <param name="workbook">HSSFWorkbook</param>
        /// <param name="downfilename">�ļ�������(�벻Ҫʹ������)  �� book.xls</param>
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
        /// ƽ������ͳ�Ʊ���
        /// </summary>
        /// <param name="workbook">HSSFWorkbook</param>
        /// <param name="downfilename">�ļ�������(�벻Ҫʹ������)  �� book.xls</param>
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
        /// ����  ֧�������ļ����� �ո�ᱻ�滻�� + ��
        /// </summary>
        /// <param name="workbook">HSSFWorkbook</param>
        /// <param name="downfilename">�ļ�������(�벻Ҫʹ������)  �� book.xls</param>
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
        /// ����ͷ��Ϣ��ʹ֧���������ء��Ѳ��� Firefox,IE���ȸ裬ƻ����opera��2012��1��12�� by chenxp
        /// ������Ҫʹ�ÿո񣬿ո�ᱻ�滻�� + ��
        /// </summary>
        /// <param name="FileName"></param>
        private void ResponseAddHeader(string FileName)
        {
            string UserAgent = HttpContext.Current.Request.ServerVariables["http_user_agent"].ToLower();

            if (UserAgent.Contains("msie") || UserAgent.Contains("opera"))
                FileName = HttpUtility.UrlEncode(FileName, Encoding.UTF8);
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + FileName); //ָ����Ӧͷ��Ϣ,��������������ػ򱣴��ļ�ʱ���������ļ���
        }
    }


}
