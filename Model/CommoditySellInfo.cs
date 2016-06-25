using System;
namespace Model
{
	/// <summary>
	/// CommoditySellInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CommoditySellInfo
	{
		public CommoditySellInfo()
		{}
		#region Model
		private int _cs_zhuangrid;
		private int _pt_yonghid;
		private string _cs_fenlcode;
		private string _cs_shangpmc;
		private string _cs_zhuangrjg;
		private string _cs_shangpjj;
		private string _cs_shangpbz;
		private int _cs_enabled=0;
		private int _cs_deleted=0;
        private DateTime _cs_fabrq = Convert.ToDateTime("1900-01-01");
		private string _cs_lianxdz;
		private string _cs_quycode;
		private string _cs_shangptplj;
		private string _cs_lianxr;
		private string _cs_lianxdh;
        private string _cs_xinjcd;
        private int _cs_rescommend = 0;
        private int _cs_liuls = 0;
        private int _cs_liuys = 0;
        
		/// <summary>
		/// 转让商品ＩＤ
		/// </summary>
		public int cs_ZhuangRID
		{
			set{ _cs_zhuangrid=value;}
			get{return _cs_zhuangrid;}
		}
		/// <summary>
		/// 用户ＩＤ
		/// </summary>
		public int pt_YongHID
		{
			set{ _pt_yonghid=value;}
			get{return _pt_yonghid;}
		}
		/// <summary>
		/// 商品分类code
		/// </summary>
		public string cs_FenLCode
		{
			set{ _cs_fenlcode=value;}
			get{return _cs_fenlcode;}
		}
		/// <summary>
		/// 转让商品名称
		/// </summary>
		public string cs_ShangPMC
		{
			set{ _cs_shangpmc=value;}
			get{return _cs_shangpmc;}
		}
		/// <summary>
		/// 转让价格
		/// </summary>
		public string cs_ZhuangRJG
		{
			set{ _cs_zhuangrjg=value;}
			get{return _cs_zhuangrjg;}
		}
		/// <summary>
		/// 商品简介
		/// </summary>
		public string cs_ShangPJJ
		{
			set{ _cs_shangpjj=value;}
			get{return _cs_shangpjj;}
		}
		/// <summary>
		/// 商品备注
		/// </summary>
		public string cs_ShangPBZ
		{
			set{ _cs_shangpbz=value;}
			get{return _cs_shangpbz;}
		}
		/// <summary>
		/// 是否启用
		/// </summary>
		public int cs_Enabled
		{
			set{ _cs_enabled=value;}
			get{return _cs_enabled;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int cs_Deleted
		{
			set{ _cs_deleted=value;}
			get{return _cs_deleted;}
		}
		/// <summary>
		/// 发布日期
		/// </summary>
		public DateTime cs_FaBRQ
		{
			set{ _cs_fabrq=value;}
			get{return _cs_fabrq;}
		}
		/// <summary>
		/// 联系地址
		/// </summary>
		public string cs_LianXDZ
		{
			set{ _cs_lianxdz=value;}
			get{return _cs_lianxdz;}
		}
		/// <summary>
		/// 所属区域代码
		/// </summary>
		public string cs_QuYCode
		{
			set{ _cs_quycode=value;}
			get{return _cs_quycode;}
		}
		/// <summary>
		/// 商品图片
		/// </summary>
		public string cs_ShangPTPLJ
		{
			set{ _cs_shangptplj=value;}
			get{return _cs_shangptplj;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string cs_LianXR
		{
			set{ _cs_lianxr=value;}
			get{return _cs_lianxr;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string cs_LianXDH
		{
			set{ _cs_lianxdh=value;}
			get{return _cs_lianxdh;}
		}
        /// <summary>
        /// 新旧程度
        /// </summary>
        public string cs_XinJCD
        {
            get { return _cs_xinjcd; }
            set { _cs_xinjcd = value; }
        }
        /// <summary>
        /// 是否推荐：0不推荐；1推荐
        /// </summary>
        public int cs_Rescommend
        {
            get { return _cs_rescommend; }
            set { _cs_rescommend = value; }
        }
        /// <summary>
        /// 浏览数
        /// </summary>
        public int cs_LiuLS
        {
            get { return _cs_liuls; }
            set { _cs_liuls = value; }
        }
        /// <summary>
        /// 留言数
        /// </summary>
        public int cs_LiuYS
        {
            get { return _cs_liuys; }
            set { _cs_liuys = value; }
        }
		#endregion Model

	}
}

