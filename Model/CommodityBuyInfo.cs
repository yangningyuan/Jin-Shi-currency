using System;
namespace Model
{
	/// <summary>
	/// CommodityBuyInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CommodityBuyInfo
	{
		public CommodityBuyInfo()
		{}
		#region Model
		private int _cb_shangpid;
		private int? _pt_yonghid;
		private string _cb_fenlcode;
		private string _cb_shangpmc;
		private string _cb_qiugjg;
		private string _cb_shangpjj;
		private string _cb_shangpbz;
		private int _cb_enabled=0;
		private int _cb_deleted=0;
        private DateTime _cb_fabrq = DateTime.Now;
		private string _cb_lianxdz;
		private string _cb_quycode;
        private string _cb_shangptp;
		private string _cb_lianxr;
		private string _cb_lianxdh;
        private int _cb_liuls = 0;
        private int _cb_liuys = 0;
		/// <summary>
		/// 商品求购ＩＤ
		/// </summary>
		public int cb_ShangPID
		{
			set{ _cb_shangpid=value;}
			get{return _cb_shangpid;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public int? pt_YongHID
		{
			set{ _pt_yonghid=value;}
			get{return _pt_yonghid;}
		}
		/// <summary>
		/// 商品分类
		/// </summary>
		public string cb_FenLCode
		{
			set{ _cb_fenlcode=value;}
			get{return _cb_fenlcode;}
		}
		/// <summary>
		/// 商品名称
		/// </summary>
		public string cb_ShangPMC
		{
			set{ _cb_shangpmc=value;}
			get{return _cb_shangpmc;}
		}
		/// <summary>
		/// 求购商品价格
		/// </summary>
		public string cb_QiuGJG
		{
			set{ _cb_qiugjg=value;}
			get{return _cb_qiugjg;}
		}
		/// <summary>
		/// 求购商品简介
		/// </summary>
		public string cb_ShangPJJ
		{
			set{ _cb_shangpjj=value;}
			get{return _cb_shangpjj;}
		}
		/// <summary>
		/// 求购商品备注
		/// </summary>
		public string cb_ShangPBZ
		{
			set{ _cb_shangpbz=value;}
			get{return _cb_shangpbz;}
		}
		/// <summary>
		/// 是否启用
		/// </summary>
		public int cb_Enabled
		{
			set{ _cb_enabled=value;}
			get{return _cb_enabled;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int cb_Deleted
		{
			set{ _cb_deleted=value;}
			get{return _cb_deleted;}
		}
		/// <summary>
		/// 发布日期
		/// </summary>
		public DateTime cb_FaBRQ
		{
			set{ _cb_fabrq=value;}
			get{return _cb_fabrq;}
		}
		/// <summary>
		/// 联系地址
		/// </summary>
		public string cb_LianXDZ
		{
			set{ _cb_lianxdz=value;}
			get{return _cb_lianxdz;}
		}
		/// <summary>
		/// 区域代码
		/// </summary>
		public string cb_QuYCode
		{
			set{ _cb_quycode=value;}
			get{return _cb_quycode;}
		}
		/// <summary>
		/// 商品图片
		/// </summary>
		public string cb_ShangPTP
		{
			set{ _cb_shangptp=value;}
			get{return _cb_shangptp;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string cb_LianXR
		{
			set{ _cb_lianxr=value;}
			get{return _cb_lianxr;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string cb_LianXDH
		{
			set{ _cb_lianxdh=value;}
			get{return _cb_lianxdh;}
		}
        /// <summary>
        /// 浏览数
        /// </summary>
        public int cb_LiuLS
        {
            get { return _cb_liuls; }
            set { _cb_liuls = value; }
        }
        /// <summary>
        /// 留言数
        /// </summary>
        public int cb_LiuYS
        {
            get { return _cb_liuys; }
            set { _cb_liuys = value; }
        }
		#endregion Model

	}
}

