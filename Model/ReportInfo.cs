using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ReportInfo
    {
        /// <summary>
        /// 举报ID
        /// </summary>
        private int _rt_jubid;
        /// <summary>
        /// 商品交易id
        /// </summary>
        private int _rt_shangpjyid;
        /// <summary>
        /// 举报类型（1：虚假信息；2：实物与描写不符;3：交易已经成交）
        /// </summary>		
        private string _rt_jublx;
        /// <summary>
        /// 举报内容
        /// </summary>		
        private string _rt_jubnr;
        /// <summary>
        /// 举报日期
        /// </summary>		
        private DateTime _rt_jubrq;
        /// <summary>
        /// 用户ID
        /// </summary>		
        private int _rt_yonghid;
        /// <summary>
        /// 是否删除
        /// </summary>		
        private int _rt_deleted;
        /// <summary>
        /// 举报类别（1：商品求购；2:商品转让）
        /// </summary>		
        private string _rt_jublb;
        /// <summary>
        /// 联系电话
        /// </summary>		
        private string _rt_lianxdh;

        /// <summary>
        /// 举报ID 
        /// </summary>		
        public int rt_JuBID
        {
            get { return _rt_jubid; }
            set { _rt_jubid = value; }
        }
        /// <summary>
        /// 商品交易id
        /// </summary>
        public int rt_ShangPJYID
        {
            get { return _rt_shangpjyid; }
            set { _rt_shangpjyid = value; }
        }
        /// <summary>
        /// 举报类型（1：虚假信息；2：实物与描写不符;3：交易已经成交，未关闭）
        /// </summary>		
        public string rt_JuBLX
        {
            get { return _rt_jublx; }
            set { _rt_jublx = value; }
        }
        /// <summary>
        /// 举报内容
        /// </summary>		
        public string rt_JuBNR
        {
            get { return _rt_jubnr; }
            set { _rt_jubnr = value; }
        }
        /// <summary>
        /// 举报日期
        /// </summary>		
        public DateTime rt_JuBRQ
        {
            get { return _rt_jubrq; }
            set { _rt_jubrq = value; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>		
        public int rt_YongHID
        {
            get { return _rt_yonghid; }
            set { _rt_yonghid = value; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>		
        public int rt_Deleted
        {
            get { return _rt_deleted; }
            set { _rt_deleted = value; }
        }
        /// <summary>
        /// 举报类别（1：商品求购；2:商品转让）
        /// </summary>		
        public string rt_JuBLB
        {
            get { return _rt_jublb; }
            set { _rt_jublb = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>		
        public string rt_LianXDH
        {
            get { return _rt_lianxdh; }
            set { _rt_lianxdh = value; }
        }        
    }
}
