using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   public  class RecoverInfo
    {
        /// <summary>
        /// 商品回收ID
        /// </summary>		
        private int _sr_huisid;
        /// <summary>
        /// 回收信息标题
        /// </summary>		
        private string _sr_xinxbt;
        /// <summary>
        /// 信息内容
        /// </summary>		
        private string _sr_xinxnr;
        /// <summary>
        /// 用户ID
        /// </summary>		
        private int _pt_yonghid;
        /// <summary>
        /// 发布日期
        /// </summary>		
        private DateTime _sr_fabrq;
        /// <summary>
        /// 是否删除
        /// </summary>		
        private int _sr_deleted;
        /// <summary>
        /// 联系地址
        /// </summary>		
        private string _sr_lianxdz;
        /// <summary>
        /// 联系电话
        /// </summary>		
        private string _sr_lianxdh;
        /// <summary>
        /// 联系人
        /// </summary>		
        private string _sr_lianxr;

        /// <summary>
        /// 商品回收ID
        /// </summary>		
        public int sr_HuiSID
        {
            get { return _sr_huisid; }
            set { _sr_huisid = value; }
        }
        /// <summary>
        /// 回收信息标题
        /// </summary>		
        public string sr_XinXBT
        {
            get { return _sr_xinxbt; }
            set { _sr_xinxbt = value; }
        }
        /// <summary>
        /// 信息内容
        /// </summary>		
        public string sr_XinXNR
        {
            get { return _sr_xinxnr; }
            set { _sr_xinxnr = value; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>		
        public int pt_YongHID
        {
            get { return _pt_yonghid; }
            set { _pt_yonghid = value; }
        }
        /// <summary>
        /// 发布日期
        /// </summary>		
        public DateTime sr_FaBRQ
        {
            get { return _sr_fabrq; }
            set { _sr_fabrq = value; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>		
        public int sr_Deleted
        {
            get { return _sr_deleted; }
            set { _sr_deleted = value; }
        }
        /// <summary>
        /// 联系地址
        /// </summary>		
        public string sr_LianXDZ
        {
            get { return _sr_lianxdz; }
            set { _sr_lianxdz = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>		
        public string sr_LianXDH
        {
            get { return _sr_lianxdh; }
            set { _sr_lianxdh = value; }
        }
        /// <summary>
        /// 联系人
        /// </summary>		
        public string sr_LianXR
        {
            get { return _sr_lianxr; }
            set { _sr_lianxr = value; }
        }        
    }
}
