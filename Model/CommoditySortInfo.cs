using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CommoditySortInfo
    {

        /// <summary>
        /// 商品分类ID
        /// </summary>		
        private int _sp_fenlid;
        /// <summary>
        /// 分类代码
        /// </summary>		
        private string _sp_fenlcode;
        /// <summary>
        /// 分类名称
        /// </summary>		
        private string _sp_fenlmc;
        /// <summary>
        /// 商品分类级别
        /// </summary>		
        private int _sp_fenljb;
        /// <summary>
        /// 商品父分类
        /// </summary>		
        private string _sp_fcode;
        /// <summary>
        /// 是否删除
        /// </summary>		
        private int _sp_deleted;
        /// <summary>
        /// 商品分类排序
        /// </summary>		
        private int _sp_fenlpx;
        /// <summary>
        /// 商品分类备注
        /// </summary>		
        private string _sp_fenlbz;

        /// <summary>
        /// 商品分类ID
        /// </summary>		
        public int sp_FenLID
        {
            get { return _sp_fenlid; }
            set { _sp_fenlid = value; }
        }
        /// <summary>
        /// 分类代码
        /// </summary>		
        public string sp_FenLCode
        {
            get { return _sp_fenlcode; }
            set { _sp_fenlcode = value; }
        }
        /// <summary>
        /// 分类名称
        /// </summary>		
        public string sp_FenLMC
        {
            get { return _sp_fenlmc; }
            set { _sp_fenlmc = value; }
        }
        /// <summary>
        /// 商品分类级别
        /// </summary>		
        public int sp_FenLJB
        {
            get { return _sp_fenljb; }
            set { _sp_fenljb = value; }
        }
        /// <summary>
        /// 商品父分类
        /// </summary>		
        public string sp_FCode
        {
            get { return _sp_fcode; }
            set { _sp_fcode = value; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>		
        public int sp_Deleted
        {
            get { return _sp_deleted; }
            set { _sp_deleted = value; }
        }
        /// <summary>
        /// 商品分类排序
        /// </summary>		
        public int sp_FenLPX
        {
            get { return _sp_fenlpx; }
            set { _sp_fenlpx = value; }
        }
        /// <summary>
        /// 商品分类备注
        /// </summary>		
        public string sp_FenLBZ
        {
            get { return _sp_fenlbz; }
            set { _sp_fenlbz = value; }
        }
    }
}