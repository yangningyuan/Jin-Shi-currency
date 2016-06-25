using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class AdvertiInfo
    {

        // <summary>
        /// 广告信息ID
        /// </summary>		
        private int _gg_gonggid;

        /// <summary>
        /// 连接路径
        /// </summary>		
        private string _gg_LianJDZ;
        /// <summary>
        /// 广告位置
        /// </summary>		
        private string _gg_gonggwz;
        /// <summary>
        /// 图片路径
        /// </summary>		
        private string _gg_tuplj;
        /// <summary>
        /// 是否删除
        /// </summary>		
        private int _gg_delete;
        /// <summary>
        /// 是否启用
        /// </summary>		
        private int _gg_enabled;
        /// <summary>
        /// 备注
        /// </summary>		
        private string _gg_remark;
        /// <summary>
        /// 广告展示有效日期
        /// </summary>		
        private DateTime _gg_kaisrj;
        /// <summary>
        /// 广告展示结束日期
        /// </summary>		
        private DateTime _gg_jiesrj;
        /// <summary>
        /// 广告添加日期
        /// </summary>		
        private DateTime _gg_tianjrq;
        /// <summary>
        /// 操作人
        /// </summary>		
        private int _gg_caozr;

        /// <summary>
        /// 广告信息ID
        /// </summary>		
        public int gg_GongGID
        {
            get { return _gg_gonggid; }
            set { _gg_gonggid = value; }
        }

        /// <summary>
        /// 连接地址
        /// </summary>		
        public string gg_LianJDZ
        {
            get { return _gg_LianJDZ; }
            set { _gg_LianJDZ = value; }
        }
        /// <summary>
        /// 广告位置
        /// </summary>		
        public string gg_GongGWZ
        {
            get { return _gg_gonggwz; }
            set { _gg_gonggwz = value; }
        }
        /// <summary>
        /// 图片路径
        /// </summary>		
        public string gg_TuPLJ
        {
            get { return _gg_tuplj; }
            set { _gg_tuplj = value; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>		
        public int gg_Delete
        {
            get { return _gg_delete; }
            set { _gg_delete = value; }
        }
        /// <summary>
        /// 是否启用
        /// </summary>		
        public int gg_Enabled
        {
            get { return _gg_enabled; }
            set { _gg_enabled = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>		
        public string gg_Remark
        {
            get { return _gg_remark; }
            set { _gg_remark = value; }
        }
        /// <summary>
        /// 广告展示有效日期
        /// </summary>		
        public DateTime gg_KaiSRJ
        {
            get { return _gg_kaisrj; }
            set { _gg_kaisrj = value; }
        }
        /// <summary>
        /// 广告展示结束日期
        /// </summary>		
        public DateTime gg_JieSRJ
        {
            get { return _gg_jiesrj; }
            set { _gg_jiesrj = value; }
        }
        /// <summary>
        /// 广告添加日期
        /// </summary>		
        public DateTime gg_TianJRQ
        {
            get { return _gg_tianjrq; }
            set { _gg_tianjrq = value; }
        }
        /// <summary>
        /// 操作人
        /// </summary>		
        public int gg_CaoZR
        {
            get { return _gg_caozr; }
            set { _gg_caozr = value; }
        }

    }
}
