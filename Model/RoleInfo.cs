using System;
namespace Model
{
	/// <summary>
	/// RoleInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RoleInfo
	{
		public RoleInfo()
		{}
        #region Model
        private int _ri_juesid;
        private string _ri_juesmc;
        private int _ri_deleted = 0;
        private string _ri_juesbz;
        /// <summary>
        /// 
        /// </summary>
        public int ri_JueSID
        {
            set { _ri_juesid = value; }
            get { return _ri_juesid; }
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string ri_JueSMC
        {
            set { _ri_juesmc = value; }
            get { return _ri_juesmc; }
        }
        /// <summary>
        /// 是否删除(默认0：非删除；1删除)
        /// </summary>
        public int ri_deleted
        {
            set { _ri_deleted = value; }
            get { return _ri_deleted; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string ri_JueSBZ
        {
            set { _ri_juesbz = value; }
            get { return _ri_juesbz; }
        }
        #endregion Model

	}
}

