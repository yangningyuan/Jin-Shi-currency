using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class GuestBookBase
    {
        private int _gb_liuyid;
        private string _gb_xingm;
        private string _gb_dianh;
        private string _gb_youx;
        private string _gb_diz;
        private string _gb_liuynr;
        private DateTime? _gb_liuyrq = DateTime.Now;
        private int _gb_huifzid;
        private string _gb_huifnr;
        private string _gb_title;
        private DateTime? _gb_huifrq= DateTime.Now;
        private int _gb_huifzt;
        private int _gb_delete;
        

        /// <summary>
        /// 留言者id
        /// </summary>
        public int gb_LiuYID
        {
            get { return _gb_liuyid; }
            set { _gb_liuyid = value; }
        }

        /// <summary>
        /// 留言者姓名
        /// </summary>
        public string gb_XingM
        {
            get { return _gb_xingm; }
            set { _gb_xingm = value; }
        }
        /// <summary>
        /// 留言者电话
        /// </summary>
        public string gb_DianH
        {
            get { return _gb_dianh; }
            set { _gb_dianh = value; }
        }
        /// <summary>
        /// 留言者邮箱
        /// </summary>
        public string gb_YouX
        {
            get { return _gb_youx; }
            set { _gb_youx = value; }
        }
        /// <summary>
        /// 留言者地址
        /// </summary>
        public string gb_DiZ
        {
            get { return _gb_diz; }
            set { _gb_diz = value; }
        }
        /// <summary>
        /// 留言标题
        /// </summary>
        public string gb_Title
        {
            get { return _gb_title; }
            set { _gb_title = value; }
        }
        /// <summary>
        /// 留言内容
        /// </summary>
        public string gb_LiuYNR
        {
            get { return _gb_liuynr; }
            set { _gb_liuynr = value; }
        }
        /// <summary>
        /// 留言日期
        /// </summary>
        public DateTime? gb_LiuYRQ
        {
            get { return _gb_liuyrq; }
            set { _gb_liuyrq = value; }
        }

        /// <summary>
        /// 回复者id
        /// </summary>
        public int gb_HuiFZID
        {
            get { return _gb_huifzid; }
            set { _gb_huifzid = value; }
        }
        /// <summary>
        /// 回复内容
        /// </summary>
        public string gb_HuiFNR
        {
            get { return _gb_huifnr; }
            set { _gb_huifnr = value; }
        }
        /// <summary>
        /// 回复日期
        /// </summary>
        public DateTime? gb_HuiFRQ
        {
            get { return _gb_huifrq; }
            set { _gb_huifrq = value; }
        }
        /// <summary>
        /// 回复状态（0 未回复，1 已回复）
        /// </summary>
        public int gb_HuiFZT
        {
            get { return _gb_huifzt; }
            set { _gb_huifzt = value; }
        }
        /// <summary>
        /// 删除（0 未删，1 已删）
        /// </summary>
        public int gb_Delete
        {
            get { return _gb_delete; }
            set { _gb_delete = value; }
        }
    }
}
