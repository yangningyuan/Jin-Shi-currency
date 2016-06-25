using System;
namespace Model
{
	/// <summary>
	/// WebNews:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WebNews
	{
		public WebNews()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _fromname;
		private string _frompath;
		private string _author;
		private string _type;
		private int _typeid;
		private int _seque;
		private int _userid;
		private int _roleid;
		private string _limits;
		private string _sethome;
		private string _defined;
		private DateTime _putdate;
		private DateTime _editdate;
		private DateTime _verifydate;
		private int _deadline;
		private string _contents;
		private string _details;
		private string _style;
		private string _contants;
		private int _visit;
		private string _videohtml;
		private string _videotype;
		private int _videoid;
		private string _videopath;
		private string _imageurl;
		private int _detestate=0;
		private bool _istop= false;
        private int _browsecount = 0;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fromName
		{
			set{ _fromname=value;}
			get{return _fromname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fromPath
		{
			set{ _frompath=value;}
			get{return _frompath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int typeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int seque
		{
			set{ _seque=value;}
			get{return _seque;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int userId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int roleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string limits
		{
			set{ _limits=value;}
			get{return _limits;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string setHome
		{
			set{ _sethome=value;}
			get{return _sethome;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string defined
		{
			set{ _defined=value;}
			get{return _defined;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime putDate
		{
			set{ _putdate=value;}
			get{return _putdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime editDate
		{
			set{ _editdate=value;}
			get{return _editdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime verifyDate
		{
			set{ _verifydate=value;}
			get{return _verifydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int deadline
		{
			set{ _deadline=value;}
			get{return _deadline;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string contents
		{
			set{ _contents=value;}
			get{return _contents;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string details
		{
			set{ _details=value;}
			get{return _details;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string style
		{
			set{ _style=value;}
			get{return _style;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string contants
		{
			set{ _contants=value;}
			get{return _contants;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int visit
		{
			set{ _visit=value;}
			get{return _visit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string videoHtml
		{
			set{ _videohtml=value;}
			get{return _videohtml;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string videoType
		{
			set{ _videotype=value;}
			get{return _videotype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int videoId
		{
			set{ _videoid=value;}
			get{return _videoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string videoPath
		{
			set{ _videopath=value;}
			get{return _videopath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imageUrl
		{
			set{ _imageurl=value;}
			get{return _imageurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int deteState
		{
			set{ _detestate=value;}
			get{return _detestate;}
		}
		/// <summary>
		/// 是否置顶
		/// </summary>
		public bool IsTop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int browsecount
        {
            set { _browsecount = value; }
            get { return _browsecount; }
        }
		#endregion Model

	}
}

