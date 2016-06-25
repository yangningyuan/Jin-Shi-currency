using System;
namespace Model
{
    /// <summary>
    /// AreaInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class AreaInfo
    {
        public AreaInfo()
        { }
        /// <summary>
        /// ai_QuYID
        /// </summary>		
        private int _ai_quyid;
        /// <summary>
        /// 地区代码
        /// </summary>		
        private string _ai_quycode;
        /// <summary>
        /// 地区名称
        /// </summary>		
        private string _ai_quymc;
        /// <summary>
        /// 级别
        /// </summary>		
        private int _ai_quyjb;
        /// <summary>
        /// 地区父代码
        /// </summary>		
        private string _ai_quyfcode;
        /// <summary>
        /// 排序
        /// </summary>		
        private int _ai_quypx;
        /// <summary>
        /// 备注
        /// </summary>		
        private string _ai_quybz;
        /// <summary>
        /// 是否删除(0:非删除;1:删除)
        /// </summary>		
        private int _ai_delete;

        /// <summary>
        /// ai_QuYID
        /// </summary>		
        public int ai_QuYID
        {
            get { return _ai_quyid; }
            set { _ai_quyid = value; }
        }
        /// <summary>
        /// 地区代码
        /// </summary>		
        public string ai_QuYCode
        {
            get { return _ai_quycode; }
            set { _ai_quycode = value; }
        }
        /// <summary>
        /// 地区名称
        /// </summary>		
        public string ai_QuYMC
        {
            get { return _ai_quymc; }
            set { _ai_quymc = value; }
        }
        /// <summary>
        /// 级别
        /// </summary>		
        public int ai_QuYJB
        {
            get { return _ai_quyjb; }
            set { _ai_quyjb = value; }
        }
        /// <summary>
        /// 地区父代码
        /// </summary>		
        public string ai_QuYFCode
        {
            get { return _ai_quyfcode; }
            set { _ai_quyfcode = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>		
        public int ai_QuYPX
        {
            get { return _ai_quypx; }
            set { _ai_quypx = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>		
        public string ai_QuYBZ
        {
            get { return _ai_quybz; }
            set { _ai_quybz = value; }
        }
        /// <summary>
        /// 是否删除(0:非删除;1:删除)
        /// </summary>		
        public int ai_Delete
        {
            get { return _ai_delete; }
            set { _ai_delete = value; }
        }

    }
}

