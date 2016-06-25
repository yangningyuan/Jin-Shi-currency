using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class PT_UserlInfo
    {
        /// <summary>
        /// 用户注册ＩＤ
        /// </summary>		
        private int _pt_yonghid;
        /// <summary>
        /// 登陆名称
        /// </summary>		
        private string _pt_denglmc;
        /// <summary>
        /// 登陆密码
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
        /// 用户名称
        /// </summary>		
        private string _pt_yonghmc;
        /// <summary>
        /// 用户邮箱
        /// </summary>		
        private string _pt_yonghyx;
        /// <summary>
        /// 移动电话
        /// </summary>		
        private string _pt_yiddh;
        /// <summary>
        /// 通讯地址
        /// </summary>		
        private string _pt_tongxdz;
        /// <summary>
        /// 联系人
        /// </summary>		
        private string _pt_lianxr;
        /// <summary>
        /// 用户类型（１：个人用户；２：商家用户）
        /// </summary>		
        private int _pt_yonghlx;

        /// <summary>
        /// 用户注册ＩＤ
        /// </summary>		
        public int pt_YongHID
        {
            get { return _pt_yonghid; }
            set { _pt_yonghid = value; }
        }
        /// <summary>
        /// 登陆名称
        /// </summary>		
        public string pt_DengLMC
        {
            get { return _pt_denglmc; }
            set { _pt_denglmc = value; }
        }
        /// <summary>
        /// 登陆密码
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
        /// 用户名称
        /// </summary>		
        public string pt_YonghMC
        {
            get { return _pt_yonghmc; }
            set { _pt_yonghmc = value; }
        }
        /// <summary>
        /// 用户邮箱
        /// </summary>		
        public string pt_YonghYX
        {
            get { return _pt_yonghyx; }
            set { _pt_yonghyx = value; }
        }
        /// <summary>
        /// 移动电话
        /// </summary>		
        public string pt_YiDDH
        {
            get { return _pt_yiddh; }
            set { _pt_yiddh = value; }
        }
        /// <summary>
        /// 通讯地址
        /// </summary>		
        public string pt_TongXDZ
        {
            get { return _pt_tongxdz; }
            set { _pt_tongxdz = value; }
        }
        /// <summary>
        /// 联系人
        /// </summary>		
        public string pt_LianXR
        {
            get { return _pt_lianxr; }
            set { _pt_lianxr = value; }
        }
        /// <summary>
        /// 用户类型（１：个人用户；２：商家用户）
        /// </summary>		
        public int pt_YongHLX
        {
            get { return _pt_yonghlx; }
            set { _pt_yonghlx = value; }
        }        
		   
    }
}
