using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class LinkInfo
    {
        /// <summary>
        /// 连接ID
        /// </summary>		
        private int _li_linkid;
        /// <summary>
        /// 名称
        /// </summary>		
        private string _li_linkmc;
        /// <summary>
        /// 链接地址
        /// </summary>		
        private string _li_linkdz;
        /// <summary>
        /// 链接图片
        /// </summary>		
        private string _li_linktpdz;
        /// <summary>
        /// 是否删除
        /// </summary>		
        private int _li_delete;
        /// <summary>
        /// 操作人
        /// </summary>		
        private int _li_caozr;
        /// <summary>
        /// 操作日期
        /// </summary>		
        private DateTime _li_caozrq;

        /// <summary>
        /// 排序
        /// </summary>
        private int _li_linkpx;

        /// <summary>
        /// 连接ID
        /// </summary>		
        public int li_LinKID
        {
            get { return _li_linkid; }
            set { _li_linkid = value; }
        }
        /// <summary>
        /// 名称
        /// </summary>		
        public string li_LinkMC
        {
            get { return _li_linkmc; }
            set { _li_linkmc = value; }
        }
        /// <summary>
        /// 链接地址
        /// </summary>		
        public string li_LinKDZ
        {
            get { return _li_linkdz; }
            set { _li_linkdz = value; }
        }
        /// <summary>
        /// 链接图片
        /// </summary>		
        public string li_LinkTPDZ
        {
            get { return _li_linktpdz; }
            set { _li_linktpdz = value; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>		
        public int li_Delete
        {
            get { return _li_delete; }
            set { _li_delete = value; }
        }
        /// <summary>
        /// 操作人
        /// </summary>		
        public int li_CaoZR
        {
            get { return _li_caozr; }
            set { _li_caozr = value; }
        }
        /// <summary>
        /// 操作日期
        /// </summary>		
        public DateTime li_CaoZRQ
        {
            get { return _li_caozrq; }
            set { _li_caozrq = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int li_LinkPX
        {
            get { return _li_linkpx; }
            set { _li_linkpx = value; }
        }
    }
}

