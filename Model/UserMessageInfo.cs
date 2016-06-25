using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// UserMessageInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public partial class UserMessageInfo
    {
        public UserMessageInfo()
        { }
        #region Model

        // um_LiuYID
        //pt_YongHID
        //um_LiuYNR
        //um_JIaoYID
        //um_JiaoYLX
        //um_LiuYRQ
        //um_Deleted
        private int _um_liuyid;
        private int _pt_yonghid;
        private string _um_liuynr;
        private int _um_jiaoyid;
        private int _um_jiaoylx;
        private DateTime _um_liuyrq;
        private int _um_deleted;
        /// <summary>
        /// 留言id
        /// </summary>
        public int um_LiuYID
        {
            get { return _um_liuyid; }
            set { _um_liuyid = value; }
        }

        /// <summary>
        /// 留言者id
        /// </summary>
        public int pt_YongHID
        {
            get { return _pt_yonghid; }
            set { _pt_yonghid = value; }
        }

        /// <summary>
        /// 留言内容
        /// </summary>
        public string um_LiuYNR
        {
            get { return _um_liuynr; }
            set { _um_liuynr = value; }
        }

        /// <summary>
        /// 交易物品id
        /// </summary>
        public int um_JIaoYID
        {
            get { return _um_jiaoyid; }
            set { _um_jiaoyid = value; }
        }

        /// <summary>
        /// 交易类型id (1 商品转让，2 商品求购)
        /// </summary>
        public int um_JiaoYLX
        {
            get { return _um_jiaoylx; }
            set { _um_jiaoylx = value; }
        }

        /// <summary>
        /// 留言日期
        /// </summary>
        public DateTime um_LiuYRQ
        {
            get { return _um_liuyrq; }
            set { _um_liuyrq = value; }
        }

        /// <summary>
        /// 是否删除（默认0：非删除；1：删除）,后台进行物理删除
        /// </summary>
        public int um_Deleted
        {
            get { return _um_deleted; }
            set { _um_deleted = value; }
        }

        #endregion Model
    }
}
