using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CommodityCollectInfo
    {
        /// <summary>
        /// 商品收藏ID
        /// </summary>		
        private int _cc_shoucid;
        /// <summary>
        /// 商品交易ＩＤ
        /// </summary>		
        private int _cc_shangpid;
        /// <summary>
        /// 用户ID
        /// </summary>		
        private int _cc_yonghid;
        /// <summary>
        /// 商品收藏日期
        /// </summary>		
        private DateTime _cc_shoucrq;
        /// <summary>
        /// 是否删除
        /// </summary>		
        private int _cc_deleted;
        /// <summary>
        /// 收藏类型（1：商品转让；2：商品求购）
        /// </summary>		
        private int _cc_shouclx;

        /// <summary>
        /// 商品收藏ID
        /// </summary>		
        public int cc_ShouCID
        {
            get { return _cc_shoucid; }
            set { _cc_shoucid = value; }
        }
        /// <summary>
        /// 商品交易ＩＤ
        /// </summary>		
        public int cc_ShangPID
        {
            get { return _cc_shangpid; }
            set { _cc_shangpid = value; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>		
        public int cc_YongHID
        {
            get { return _cc_yonghid; }
            set { _cc_yonghid = value; }
        }
        /// <summary>
        /// 商品收藏日期
        /// </summary>		
        public DateTime cc_ShouCRQ
        {
            get { return _cc_shoucrq; }
            set { _cc_shoucrq = value; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>		
        public int cc_Deleted
        {
            get { return _cc_deleted; }
            set { _cc_deleted = value; }
        }
        /// <summary>
        /// 收藏类型（1：商品转让；2：商品求购）
        /// </summary>		
        public int cc_ShouCLX
        {
            get { return _cc_shouclx; }
            set { _cc_shouclx = value; }
        }
    }
}
