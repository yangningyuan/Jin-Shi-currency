using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class WebSiteBase
    {
        private int _ws_Id;
        private string _ws_MingC;
        private string _ws_BianM;
        private string _ws_LeiB;
        private string _ws_NeiR;

        /// <summary>
        /// 优化ID
        /// </summary>
        public int Ws_Id
        {
            get { return _ws_Id; }
            set { _ws_Id = value; }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Ws_MingC
        {
            get { return _ws_MingC; }
            set { _ws_MingC = value; }
        }

        /// <summary>
        /// 编码
        /// </summary>
        public string Ws_BianM
        {
            get { return _ws_BianM; }
            set { _ws_BianM = value; }
        }

        /// <summary>
        /// 类别
        /// </summary>
        public string Ws_LeiB
        {
            get { return _ws_LeiB; }
            set { _ws_LeiB = value; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Ws_NeiR
        {
            get { return _ws_NeiR; }
            set { _ws_NeiR = value; }
        }
    }
}

