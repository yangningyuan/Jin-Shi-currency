using System;
namespace Model
{
	/// <summary>
	/// MenuInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MenuInfo
	{
        public MenuInfo()
        { }
        #region Model
        private int _mi_caidid;
        private string _mi_caidmc;
        private string _mi_caiddz;
        private DateTime _mi_chuangjrq;
        private int _mi_caidjb;
        private int _mi_caidfid;
        private int _mi_caidpx = 0;
        private int _mi_delete = 0;
        /// <summary>
        /// 菜单地址ID
        /// </summary>
        public int mi_CaiDID
        {
            set { _mi_caidid = value; }
            get { return _mi_caidid; }
        }
        /// <summary>
        /// 菜单地址名称
        /// </summary>
        public string mi_CaiDMC
        {
            set { _mi_caidmc = value; }
            get { return _mi_caidmc; }
        }
        /// <summary>
        /// 菜单地址
        /// </summary>
        public string mi_CaiDDZ
        {
            set { _mi_caiddz = value; }
            get { return _mi_caiddz; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime mi_ChuangJRQ
        {
            set { _mi_chuangjrq = value; }
            get { return _mi_chuangjrq; }
        }
        /// <summary>
        /// 菜单级别
        /// </summary>
        public int mi_CaiDJB
        {
            set { _mi_caidjb = value; }
            get { return _mi_caidjb; }
        }
        /// <summary>
        /// 菜单父ID
        /// </summary>
        public int mi_CaiDFID
        {
            set { _mi_caidfid = value; }
            get { return _mi_caidfid; }
        }
        /// <summary>
        /// 菜单排序
        /// </summary>
        public int mi_CaiDPX
        {
            set { _mi_caidpx = value; }
            get { return _mi_caidpx; }
        }
        /// <summary>
        /// 是否删除（0：非删除；1：删除）
        /// </summary>
        public int mi_Delete
        {
            set { _mi_delete = value; }
            get { return _mi_delete; }
        }

        private string _mi_NewType;
        /// <summary>
        /// 类型
        /// </summary>
        public string mi_NewType
        {
            get { return _mi_NewType; }
            set { _mi_NewType = value; }
        }
        private string _mi_isshow;
        /// <summary>
        /// 是否在首页显示0显示，1不显示
        /// </summary>
        public string mi_IsShow
        {
            get { return _mi_isshow; }
            set { _mi_isshow = value; }
        }
        #endregion Model

	}
}

