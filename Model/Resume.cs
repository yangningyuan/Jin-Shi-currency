using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// Resume:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Resume
    {
        public Resume()
        { }
        #region Model
        private int _r_id;
        private int _re_id;
        private string _r_fileurl;
        private int? _r_delete = 0;
        private DateTime? _r_createdate = DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? r_createdate
        {
            set { _r_createdate = value; }
            get { return _r_createdate; }
        }
        /// <summary>
        /// 简历id
        /// </summary>
        public int r_id
        {
            set { _r_id = value; }
            get { return _r_id; }
        }
        /// <summary>
        /// 岗位信息id
        /// </summary>
        public int re_id
        {
            set { _re_id = value; }
            get { return _re_id; }
        }
        /// <summary>
        /// 简历路径
        /// </summary>
        public string r_fileurl
        {
            set { _r_fileurl = value; }
            get { return _r_fileurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? r_delete
        {
            set { _r_delete = value; }
            get { return _r_delete; }
        }
        #endregion Model

    }
}
