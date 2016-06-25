using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;

namespace Common
{
    /// <summary>
    /// Gridview绑定的数据记录为空时显示Gridview的表头，并显示没有记录的提示
    /// </summary>
    public class GridViewControl
    {
        //当Gridview数据为空时显示的信息
        private static string EmptyText = "没有记录";

        #region 防止PostBack后Gridview不能显示
        /// <summary>
        /// 防止PostBack后Gridview不能显示
        /// </summary>
        /// <param name="gridview"></param>
        public static void ResetGridView(GridView gridview)
        {
            //如果数据为空则重新构造Gridview
            if (gridview.Rows.Count == 1 && gridview.Rows[0].Cells[0].Text == EmptyText)
            {
                int columnCount = gridview.Columns.Count;
                gridview.Rows[0].Cells.Clear();
                gridview.Rows[0].Cells.Add(new TableCell());
                gridview.Rows[0].Cells[0].ColumnSpan = columnCount;
                gridview.Rows[0].Cells[0].Text = EmptyText;
                gridview.Rows[0].Cells[0].Style.Add("text-align", "center");
                gridview.Rows[0].Cells[0].Style.Add("height", "20px");
            }
        }
        #endregion

        #region 初始化行
        /// <summary>
        /// 初始化行
        /// </summary>
        /// <param name="gridview"></param>
        /// <param name="row"></param>
        /// <param name="fields"></param>
        protected static void InitializeRow(GridView gridview, GridViewRow row, DataControlField[] fields)
        {
            DataControlRowType rowType = row.RowType;
            DataControlRowState rowState = row.RowState;
            int rowIndex = row.RowIndex;
            bool useAccessibleHeader = false;

            TableCellCollection cells = row.Cells;
            string rowHeaderColumn = gridview.RowHeaderColumn;
            if (rowType == DataControlRowType.Header)
            {
                useAccessibleHeader = gridview.UseAccessibleHeader;
            }
            for (int i = 0; i < fields.Length; i++)
            {
                DataControlFieldCell cell;
                DataControlCellType header;
                if ((rowType == DataControlRowType.Header) && useAccessibleHeader)
                {
                    cell = new DataControlFieldHeaderCell(fields[i]);
                    ((DataControlFieldHeaderCell)cell).Scope = TableHeaderScope.Column;
                    ((DataControlFieldHeaderCell)cell).AbbreviatedText = fields[i].AccessibleHeaderText;
                }
                else
                {
                    BoundField field = fields[i] as BoundField;
                    if (((rowHeaderColumn.Length > 0) && (field != null)) && (field.DataField == rowHeaderColumn))
                    {
                        cell = new DataControlFieldHeaderCell(fields[i]);
                        ((DataControlFieldHeaderCell)cell).Scope = TableHeaderScope.Row;
                    }
                    else
                    {
                        cell = new DataControlFieldCell(fields[i]);
                    }
                }
                switch (rowType)
                {
                    case DataControlRowType.Header:
                        header = DataControlCellType.Header;
                        break;

                    case DataControlRowType.Footer:
                        header = DataControlCellType.Footer;
                        break;

                    default:
                        header = DataControlCellType.DataCell;
                        break;
                }
                fields[i].InitializeCell(cell, header, rowState, rowIndex);
                cells.Add(cell);
            }
        }
        #endregion

        #region 绑定数据到GridView，当表格数据为空时显示表头(DataTable)
        /// <summary>
        /// 绑定数据到GridView，当表格数据为空时显示表头
        /// </summary>
        /// <param name="gridview"></param>
        /// <param name="dt">DataTable</param>
        /// <param name="dataKeys"></param>
        public static void GridViewDataBind(GridView gridview, DataTable dt, string[] dataKeyName)
        {
            GridViewDataBind(gridview, dt, dataKeyName, "没有记录");
        }
        #endregion

        #region 绑定数据到GridView，当表格数据为空时显示表头(DataTable)
        /// <summary>
        /// 绑定数据到GridView，当表格数据为空时显示表头
        /// </summary>
        /// <param name="gridview"></param>
        /// <param name="dt">DataTable</param>
        /// <param name="dataKeys"></param>
        public static void GridViewDataBind(GridView gridview, DataTable dt, string[] dataKeyName, string emptyText)
        {
            EmptyText = emptyText;
            //记录为空重新构造Gridview
            if (dt.Rows.Count == 0)
            {
                gridview.DataSource = dt;
                gridview.DataBind();

                if (gridview.EmptyDataTemplate != null)
                {
                    GridViewRow rowHeader = new GridViewRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal);
                    DataControlField[] tempDataControlField = new DataControlField[gridview.Columns.Count];
                    int i = 0;
                    foreach (DataControlField field in gridview.Columns)
                    {
                        tempDataControlField[i] = field;
                        i++;
                    }
                    InitializeRow(gridview, rowHeader, tempDataControlField);

                    gridview.Controls[0].Controls.Add(rowHeader);
                    GridViewRow rowBody = new GridViewRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal);

                    TableCell cellBody = new TableCell();

                    cellBody.Text = EmptyText;
                    cellBody.HorizontalAlign = HorizontalAlign.Center;
                    cellBody.ColumnSpan = i;
                    rowBody.Cells.Add(cellBody);
                    rowBody.CssClass = "";

                    gridview.Controls[0].Controls.Add(rowBody);
                }

            }
            else
            {
                //数据不为空直接绑定
                gridview.DataSource = dt;
                gridview.DataKeyNames = dataKeyName;
                gridview.DataBind();
            }

            //重新绑定取消选择
            gridview.SelectedIndex = -1;
        }
        #endregion

        #region 绑定数据到GridView，当表格数据为空时显示表头(DataView)
        /// <summary>
        /// 绑定数据到GridView，当表格数据为空时显示表头
        /// </summary>
        /// <param name="gridview"></param>
        /// <param name="dv">DataView</param>
        /// <param name="dataKeyName"></param>
        public static void GridViewDataBind(GridView gridview, DataView dv, string[] dataKeyName)
        {
            //记录为空重新构造Gridview
            if (dv.Count == 0)
            {
                gridview.DataSource = dv;
                gridview.DataBind();

                if (gridview.EmptyDataTemplate != null)
                {
                    GridViewRow rowHeader = new GridViewRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal);
                    DataControlField[] tempDataControlField = new DataControlField[gridview.Columns.Count];
                    int i = 0;
                    foreach (DataControlField field in gridview.Columns)
                    {
                        tempDataControlField[i] = field;
                        i++;
                    }
                    InitializeRow(gridview, rowHeader, tempDataControlField);

                    gridview.Controls[0].Controls.Add(rowHeader);
                    GridViewRow rowBody = new GridViewRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal);

                    TableCell cellBody = new TableCell();

                    cellBody.Text = EmptyText;
                    cellBody.HorizontalAlign = HorizontalAlign.Center;
                    cellBody.ColumnSpan = i;
                    rowBody.Cells.Add(cellBody);
                    rowBody.CssClass = "";

                    gridview.Controls[0].Controls.Add(rowBody);
                }

            }
            else
            {
                //数据不为空直接绑定
                gridview.DataSource = dv;
                gridview.DataKeyNames = dataKeyName;
                gridview.DataBind();
            }

            //重新绑定取消选择
            gridview.SelectedIndex = -1;
        }
        #endregion

    }
}
