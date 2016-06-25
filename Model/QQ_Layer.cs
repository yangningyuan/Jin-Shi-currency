using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// QQ_Layer:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class QQ_Layer
    {
        public QQ_Layer()
        { }
        #region Model
        private int _q_id;
        private string _qq_code;
        private string _qq_alt;
        private int? _qq_paixu = 0;
        private DateTime? _qq_createdate = DateTime.Now;
        private int? _qq_state = 0;
        private int? _qq_delete = 0;
        /// <summary>
        /// 
        /// </summary>
        public int q_id
        {
            set { _q_id = value; }
            get { return _q_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string qq_code
        {
            set { _qq_code = value; }
            get { return _qq_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string qq_alt
        {
            set { _qq_alt = value; }
            get { return _qq_alt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? qq_paixu
        {
            set { _qq_paixu = value; }
            get { return _qq_paixu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? qq_createdate
        {
            set { _qq_createdate = value; }
            get { return _qq_createdate; }
        }
        /// <summary>
        /// 0 启用 1 禁用
        /// </summary>
        public int? qq_state
        {
            set { _qq_state = value; }
            get { return _qq_state; }
        }
        /// <summary>
        /// 0 正常1 删除
        /// </summary>
        public int? qq_delete
        {
            set { _qq_delete = value; }
            get { return _qq_delete; }
        }
        #endregion Model

    }
}
