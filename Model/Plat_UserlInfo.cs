using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Plat_UserlInfo
    {
        /// <summary>
        /// 用户注册ＩＤ
        /// </summary>		
        private int _pt_yonghid;
        /// <summary>
        /// 用户注册名称
        /// </summary>		
        private string _pt_denglmc;
        /// <summary>
        /// 登陆名称
        /// </summary>		
        private string _pt_denglmm;
        /// <summary>
        /// 注册日期
        /// </summary>		
        private DateTime _pt_zhucsj;
        /// <summary>
        /// 是否启用
        /// </summary>		
        private int _pt_enabled;
        /// <summary>
        /// 是否删除
        /// </summary>		
        private int _pt_deleted;
        /// <summary>
        /// 注册标识
        /// </summary>		
        private string _pt_zcbz;
        /// <summary>
        /// 用户邮箱
        /// </summary>
        private string _pt_yonghyx;
        

        /// <summary>
        /// 用户注册ＩＤ
        /// </summary>		
        public int pt_YongHID
        {
            get { return _pt_yonghid; }
            set { _pt_yonghid = value; }
        }
        /// <summary>
        /// 用户注册名称
        /// </summary>		
        public string pt_DengLMC
        {
            get { return _pt_denglmc; }
            set { _pt_denglmc = value; }
        }
        /// <summary>
        /// 登陆名称
        /// </summary>		
        public string pt_DengLMM
        {
            get { return _pt_denglmm; }
            set { _pt_denglmm = value; }
        }
        /// <summary>
        /// 注册日期
        /// </summary>		
        public DateTime pt_ZhuCSJ
        {
            get { return _pt_zhucsj; }
            set { _pt_zhucsj = value; }
        }
        /// <summary>
        /// 是否启用
        /// </summary>		
        public int pt_Enabled
        {
            get { return _pt_enabled; }
            set { _pt_enabled = value; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>		
        public int pt_Deleted
        {
            get { return _pt_deleted; }
            set { _pt_deleted = value; }
        }
        /// <summary>
        /// 注册标识
        /// </summary>		
        public string pt_ZCBZ
        {
            get { return _pt_zcbz; }
            set { _pt_zcbz = value; }
        }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string pt_YongHYX
        {
            get { return _pt_yonghyx; }
            set { _pt_yonghyx = value; }
        }
    }
}
