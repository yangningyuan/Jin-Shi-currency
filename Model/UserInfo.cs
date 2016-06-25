using System;
namespace Model
{
	/// <summary>
	/// UserInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserInfo
	{
        public UserInfo()
        { }
        #region Model
        private int _ui_yonghid;
        private string _ui_yonghdlmc;
        private string _ui_yonghdlmm;
        private int _ui_juesid;
        private int _ui_enalbed = 0;
        private int _ui_deleted = 0;
        private string _ui_yonghbz;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int ui_YongHID
        {
            set { _ui_yonghid = value; }
            get { return _ui_yonghid; }
        }
        /// <summary>
        /// 用户登陆名称
        /// </summary>
        public string ui_YongHDLMC
        {
            set { _ui_yonghdlmc = value; }
            get { return _ui_yonghdlmc; }
        }
        /// <summary>
        /// 用户登陆密码
        /// </summary>
        public string ui_YongHDLMM
        {
            set { _ui_yonghdlmm = value; }
            get { return _ui_yonghdlmm; }
        }
        /// <summary>
        /// 角色id
        /// </summary>
        public int ui_JueSID
        {
            set { _ui_juesid = value; }
            get { return _ui_juesid; }
        }
        /// <summary>
        /// 是否启用（0：启用；1：未启用）
        /// </summary>
        public int ui_Enalbed
        {
            set { _ui_enalbed = value; }
            get { return _ui_enalbed; }
        }
        /// <summary>
        /// 是否删除（默认0：非删除；1：删除）
        /// </summary>
        public int ui_Deleted
        {
            set { _ui_deleted = value; }
            get { return _ui_deleted; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string ui_YongHBZ
        {
            set { _ui_yonghbz = value; }
            get { return _ui_yonghbz; }
        }
        #endregion Model

	}
}

