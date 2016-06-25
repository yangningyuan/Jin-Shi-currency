using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class AboutUsInfo
    {
        /// <summary>
        /// 关于我们（ID）
        /// </summary>		
        private int _au_xinxid;
        /// <summary>
        /// 名称
        /// </summary>		
        private string _au_xinmc;
        /// <summary>
        /// 排序
        /// </summary>		
        private int _au_xinpx;
        /// <summary>
        /// 内容
        /// </summary>		
        private string _au_xinxnr;
        /// <summary>
        /// 图片路径
        /// </summary>		
        private string _au_tuplj;
        /// <summary>
        /// 是否删除
        /// </summary>		
        private int _au_deleted;

        /// <summary>
        /// 关于我们（ID）
        /// </summary>		
        public int au_XinXID
        {
            get { return _au_xinxid; }
            set { _au_xinxid = value; }
        }
        /// <summary>
        /// 名称
        /// </summary>		
        public string au_XinMC
        {
            get { return _au_xinmc; }
            set { _au_xinmc = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>		
        public int au_XinPX
        {
            get { return _au_xinpx; }
            set { _au_xinpx = value; }
        }
        /// <summary>
        /// 内容
        /// </summary>		
        public string au_XinXNR
        {
            get { return _au_xinxnr; }
            set { _au_xinxnr = value; }
        }
        /// <summary>
        /// 图片路径
        /// </summary>		
        public string au_TuPLJ
        {
            get { return _au_tuplj; }
            set { _au_tuplj = value; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>		
        public int au_Deleted
        {
            get { return _au_deleted; }
            set { _au_deleted = value; }
        }
    }
}
