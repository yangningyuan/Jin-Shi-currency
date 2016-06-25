using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace Model
{
    public class ArticleInfo
    {
        private int _ai_wenzid;
        private string _ai_wenzbt;
        private int _ai_wenzlx;
        private string _ai_wenzlc;
        private int _ai_fabr;
        private DateTime _ai_fabrq;
        private int _ai_deleted;

        /// <summary>
        /// 文章ID
        /// </summary>		
        public int ai_WenZID
        {
            get { return _ai_wenzid; }
            set { _ai_wenzid = value; }
        }
        /// <summary>
        /// 文章标题
        /// </summary>		
        public string ai_WenZBT
        {
            get { return _ai_wenzbt; }
            set { _ai_wenzbt = value; }
        }
        /// <summary>
        /// 文章类型（1 帮助，2交易指南）
        /// </summary>		
        public int ai_WenZLX
        {
            get { return _ai_wenzlx; }
            set { _ai_wenzlx = value; }
        }
        /// <summary>
        /// 文章内容
        /// </summary>		
        public string ai_WenZLC
        {
            get { return _ai_wenzlc; }
            set { _ai_wenzlc = value; }
        }
        /// <summary>
        /// 发布人
        /// </summary>		
        public int ai_FaBR
        {
            get { return _ai_fabr; }
            set { _ai_fabr = value; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>		
        public DateTime ai_FaBRQ
        {
            get { return _ai_fabrq; }
            set { _ai_fabrq = value; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>		
        public int ai_Deleted
        {
            get { return _ai_deleted; }
            set { _ai_deleted = value; }
        }

    }
}