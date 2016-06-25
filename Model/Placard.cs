using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Model
{
    //Placard
    public class Placard
    {
        private int _pi_gonggid;
        private string _pi_gonggmc;
        private DateTime _pi_gonggrq;
        private string _pi_gongglr;
        private int _pi_deleted;
        private int _pi_gonggzr;

        /// <summary>
        /// 公告ID
        /// </summary>	
        public int pi_GongGID
        {
            get { return _pi_gonggid; }
            set { _pi_gonggid = value; }
        }
        /// <summary>
        ///公告名称
        /// </summary>		
        public string pi_GongGMC
        {
            get { return _pi_gonggmc; }
            set { _pi_gonggmc = value; }
        }
        /// <summary>
        /// 公告时间
        /// </summary>		
        public DateTime pi_GongGRQ
        {
            get { return _pi_gonggrq; }
            set { _pi_gonggrq = value; }
        }
        /// <summary>
        ///公告内容
        /// </summary>		
        public string pi_GongGLR
        {
            get { return _pi_gongglr; }
            set { _pi_gongglr = value; }
        }
        /// <summary>
        ///是否删除
        /// </summary>		
        public int pi_Deleted
        {
            get { return _pi_deleted; }
            set { _pi_deleted = value; }
        }
        /// <summary>
        /// 操作人
        /// </summary>		
        public int pi_GongGZR
        {
            get { return _pi_gonggzr; }
            set { _pi_gonggzr = value; }
        }
    }
}