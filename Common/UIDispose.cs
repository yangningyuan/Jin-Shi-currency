using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Common
{
    public class UIDispose
    {
        public UIDispose() { }

        public static DataTable ShowTableRowNumber(DataTable dt, string message)
        {
            dt.Columns.Add("RowID");
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                dt.Rows[i - 1]["RowID"] = i.ToString() + message;
            }
            return dt;
        }

        public static int StringToInt(string str)
        {
            int result = 0;
            if (str.Trim().Length > 0)
            {
                try
                {
                    result = int.Parse(str);
                }
                catch
                {
                }
            }
            return result;
        }

        public static List<int> StringToList(string ids)
        {
            List<int> lst = new List<int>();
            if (ids.Trim().Length > 0)
            {
                ArrayList ary = new ArrayList(ids.Split(new char[] { ',' }));
                foreach (string temp in ary)
                {
                    if (temp.Trim().Length > 0)
                    {
                        int id = StringToInt(temp);
                        if (id < 0)
                        {
                            id = -id;
                        }
                        if (!((id == 0) || lst.Contains(id)))
                        {
                            lst.Add(id);
                        }
                    }
                }
            }
            return lst;
        }
 
    }
}
