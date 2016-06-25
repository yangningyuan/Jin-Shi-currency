
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace Common
{
    /// <summary>
    /// 
    /// </summary>
    public class EnumUtility
    {

        #region 属性

        #region AtachmentBaseType ysy 上传文件的文件类型
        /// <summary>
        /// 上传文件的文件类型
        /// </summary>
        public enum AttachmentBaseType
        {
            未知类型 = 0,
            doc = 1,
            exe = 2, rar = 2, zip = 2,
            html = 3, htm = 3,
            imges = 4,
            media = 5,
            ppt = 6,
            vsd = 7,
            xls = 8,
            others = 9
        }
        #endregion

        #region InsideLetterState  ysy 站内信的发送状态及 站内信类型

        /// <summary>
        /// 2012年5月18日  站内信写信的发送状态（删除为发送人删除）
        /// </summary>
        public enum InsideLetterState
        {
            已发送 = 0,
            草稿 = 1,
            删除 = 2
        }

        /// <summary>
        /// 2012年5月18日 发送信件的类型
        /// </summary>
        public enum InsideLetterType
        {
            普通邮件 = 0,
            公文 = 1
        }

        /// <summary>
        /// 收件信息的状态
        /// </summary>
        public enum ReceiverDetailsState
        {
            未读 = 0,
            已读 = 1,
            标记删除 = 2,
            发信人删除 = 3
        }

        #endregion

        #endregion

        #region 方法 ysy 枚举类型的处理方法，控件绑定数据
        /// <summary>
        /// 枚举类型绑定控件值
        /// </summary>
        /// <param name="tp"></param>
        /// <param name="ddList"></param>
        public static string controlSelect(Type tp)
        {
            string html = "";
            string[] names = Enum.GetNames(tp);
            int[] values = (int[])Enum.GetValues(tp);
            for (int i = 0; i < names.Length; i++)
            {
                html += "<option value=\"" + values[i] + "\">" + names[i] + "</option>";
            }
            return html;
        }


        public static void controlBind(Type tp, DropDownList ddList)
        {
            string[] names = Enum.GetNames(tp);
            int[] values = (int[])Enum.GetValues(tp);
            for (int i = 0; i < names.Length; i++)
            {
                ddList.Items.Add(new ListItem(names[i], values[i].ToString()));
            }
        }

        public static void controlbindcheckbox(Type tp, CheckBoxList ddl)
        {
            string[] names = Enum.GetNames(tp);
            int[] values = (int[])Enum.GetValues(tp);

            for (int i = 0; i < names.Length; i++)
            {
                ddl.Items.Add(new ListItem(names[i], values[i].ToString()));
            }
        }

        public static void controlbindradiolist(Type tp, RadioButtonList rdl)
        {
            string[] names = Enum.GetNames(tp);
            int[] values = (int[])Enum.GetValues(tp);

            for (int i = 0; i < names.Length; i++)
            {
                rdl.Items.Add(new ListItem(names[i], values[i].ToString()));
            }
        }
        #endregion

    }
}
