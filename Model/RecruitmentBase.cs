using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class RecruitmentBase
    {
        private int _rm_id;
        private string _rm_zhaopzw;
        private string _rm_rens;
        private string _rm_xuel;
        private string _rm_xingb;
        private string _rm_daiy;
        private string _rm_yaoq;
        private DateTime _rm_creatdate;
        private DateTime _rm_enddate;
        private int _rm_status;
        private int _rm_delete;
        private int _rm_paix;
        private string _rm_gongzdd;

        /// <summary>
        /// 招聘id
        /// </summary>
        public int rm_ID
        {
            get { return _rm_id; }
            set { _rm_id = value; }
        }
        /// <summary>
        /// 招聘职位
        /// </summary>
        public string rm_ZhaoPZW
        {
            get { return _rm_zhaopzw; }
            set { _rm_zhaopzw = value; }
        }
        /// <summary>
        ///人数
        /// </summary>
        public string rm_RenS
        {
            get { return _rm_rens; }
            set { _rm_rens = value; }
        }
        /// <summary>
        /// 学历要求
        /// </summary>
        public string rm_XueL
        {
            get { return _rm_xuel; }
            set { _rm_xuel = value; }
        }
        /// <summary>
        /// 性别要求
        /// </summary>
        public string rm_XingB
        {
            get { return _rm_xingb; }
            set { _rm_xingb = value; }
        }
        /// <summary>
        /// 待遇标准
        /// </summary>
        public string rm_DaiY
        {
            get { return _rm_daiy; }
            set { _rm_daiy = value; }
        }
        /// <summary>
        /// 招聘要求
        /// </summary>
        public string rm_YaoQ
        {
            get { return _rm_yaoq; }
            set { _rm_yaoq = value; }
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime rm_CreatDate
        {
            get { return _rm_creatdate; }
            set { _rm_creatdate = value; }
        }
        public DateTime rm_enddate
        {
            get { return _rm_enddate; }
            set { _rm_enddate = value; }
        }
        /// <summary>
        /// 状态（0 显示，1 隐藏）
        /// </summary>
        public int rm_Status
        {
            get { return _rm_status; }
            set { _rm_status = value; }
        }
        /// <summary>
        /// 删除（0 未删，1 已删）
        /// </summary>
        public int rm_Delete
        {
            get { return _rm_delete; }
            set { _rm_delete = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int rm_PaiX
        {
            get { return _rm_paix; }
            set { _rm_paix = value; }
        }
        /// <summary>
        /// 工作地点
        /// </summary>
        public string rm_GongZDD
        {
            get { return _rm_gongzdd; }
            set { _rm_gongzdd = value; }
        }
    }
}
