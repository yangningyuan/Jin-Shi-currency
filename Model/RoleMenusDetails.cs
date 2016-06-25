using System;
namespace Model
{
	/// <summary>
	/// CompetenceInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class RoleMenusDetails
	{
        public RoleMenusDetails()
        { }
        #region Model
        private int _ci_juesid;
        private int _ci_caidid;
        /// <summary>
        /// 角色id
        /// </summary>
        public int ci_JueSID
        {
            set { _ci_juesid = value; }
            get { return _ci_juesid; }
        }
        /// <summary>
        /// 菜单id
        /// </summary>
        public int ci_CaiDID
        {
            set { _ci_caidid = value; }
            get { return _ci_caidid; }
        }
        #endregion Model

	}
}

