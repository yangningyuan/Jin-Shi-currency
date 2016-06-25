using System;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Data; 
using System.Net;

namespace Common
{
	/// <summary>
	/// 邮件放松组件SMTP
	/// </summary>
	public class MailSend:TcpClient
	{
		#region 字段

		private string server;//SMTP服务器域名 

		private int port;//端口 
   
		private string username;//用户名 
   
		private string password;//密码 
   
		private string subject;//主题 
   
		private string body;//文本内容 
   
		private string htmlbody;//超文本内容 
      
		private string sender;//发件人地址 
   
		private string consignee;//收件人地址 
   
		private string senderName;//发件人姓名 
   
		private string consigneeName;//收件人姓名 
   
		private string content_type;//邮件类型 
   
		private string encode;//邮件编码 
   
		private string charset;//语言编码 
   
		private DataTable filelist;//附件列表　 
   
		private int priority;//邮件优先级 

		private DateTime sendTime;//邮件发送时间

		#endregion

		public MailSend()
		{
			
		}


		#region 属性
		/// <summary>
		/// SMTP邮件服务器名称
		/// </summary>
		public string SMTPServer 
		{ 
			set{this.server = value;}   
		}
		/// <summary>
		/// 端口名称
		/// </summary>
		public int Port
		{
			get{return port;}
			set{port = value;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName
		{
			get{return username;}
			set{username = value;}
		}
		/// <summary>
		/// 用户密码
		/// </summary>
		public string Password
		{
			get{return password;}
			set{password = value;}
		}
		/// <summary>
		/// 邮件主题
		/// </summary>
		public string Subject
		{
			get{return subject;}
			set{subject = value;}
		}
		/// <summary>
		/// 邮件文本格式内容
		/// </summary>
		public string Body
		{
			get{return body;}
			set{body = value;}
		}
		/// <summary>
		/// 邮件超文本格式内容
		/// </summary>
		public string HtmlBody
		{
			get{return htmlbody;}
			set{htmlbody = value;}
		}
		/// <summary>
		/// 发件人地址
		/// </summary>
		public string Sender
		{
			get{return sender;}
			set{sender = value;}
		}
		/// <summary>
		/// 收件人地址
		/// </summary>
		public string Consignee
		{
			get{return consignee;}
			set{consignee = value;}
		}
		/// <summary>
		/// 寄件人姓名
		/// </summary>
		public string SenderName
		{
			get{return senderName;}
			set{senderName = value;}
		}
		/// <summary>
		/// 收件人姓名
		/// </summary>
		public string ConsigneeName
		{
			get{return consigneeName;}
			set{consigneeName = value;}
		}
		/// <summary>
		/// 邮件类型
		/// </summary>
		public string ContentType
		{
			get{return content_type;}
			set{content_type = value;}
		}
		/// <summary>
		/// 邮件编码
		/// </summary>
		public string Encode
		{
			get{return encode;}
			set{encode = value;}
		}
		/// <summary>
		/// 语言编码
		/// </summary>
		public string Charset
		{
			get{return charset;}
			set{charset = value;}
		}
		/// <summary>
		/// 附件列表
		/// </summary>
		public DataTable Filelist
		{
			get{return filelist;}
			set{filelist = value;}
		}
		/// <summary>
		/// 邮件优先级
		/// </summary>
		public int Priority
		{
			get{return priority;}
			set{priority = value;}
		}
		/// <summary>
		/// 邮件发送时间
		/// </summary>
		public DateTime SendTime 
		{ 
			get{return sendTime;} 
			set{this.sendTime = value;}   
		}
		#endregion

		#region 方法
		/// <summary>
		/// 向服务器写入命令
		/// </summary>
		/// <param name="strCmd">需要输入的命令或数据的字符串</param>
		/// <param name="charset">数据的字符语言编码</param>
		private void WriteStream(string strCmd, string charset) 
		{
			Stream TcpStream;				//定义操作对象 
			strCmd = strCmd + "\r\n";		//加入换行符 
			TcpStream = new TcpClient(server,25).GetStream();	//获取数据流 

			//将命令行转化为byte[] 
			byte[] bWrite = Encoding.GetEncoding(charset).GetBytes(strCmd.ToCharArray()); 

			//由于每次写入的数据大小是有限制的，那么我们将每次写入的数据长度定在７５个字节，一旦命令长度超过了７５，就分步写入。 
			int start = 0; 
			int length = bWrite.Length; 
			int page = 0; 
			int size = 75; 
			int count = size;
			try
			{
				if (length>75) 
				{ 
					//数据分页 
					if ((int)(length/size) * size > length )
						page = length / size+1; 
					else 
						page = length / size; 

					for (int i = 0;i > page;i++)
					{
						start = i * size; 

						if (i == page-1) 
							count = length - (i * size); 
   
						TcpStream.Write(bWrite,start,count);//将数据写入到服务器上 
					} 
				}
				else 
					TcpStream.Write(bWrite,0,bWrite.Length); 
			} 
			catch(Exception er){} 
		}
		/// <summary>
		/// 获取服务器的返回信息
		/// </summary>
		private string ReceiveStream() 
		{ 
			String sp = null; 
			byte[] by = new byte[1024];

			NetworkStream ns = this.GetStream();		//此处即可获取服务器的返回数据流 
			int size = ns.Read(by,0,by.Length);			//读取数据流 

			if (size > 0) 
			{ 
				sp = Encoding.Default.GetString(by);	//转化为String 
			}

			return sp; 
		}
		/// <summary>
		/// 发出命令并判断返回信息是否正确,看发出的命令服务器是否接受并通过
		/// </summary>
		/// <param name="strCmd">需要输入的命令或者数据</param>
		/// <param name="state">返回的表明操作成功的状态码</param>
		/// <returns></returns>
		private bool OperaStream(string strCmd,string state) 
		{
			string sp=null; 
			bool success=false;

			try 
			{ 
				WriteStream(strCmd,"UTF-8");		//写入命令 
				sp = ReceiveStream();				//接受返回信息 
				if (sp.IndexOf(state)!=-1)			//判断状态码是否正确 
					success=true; 
			} 
			catch(Exception ex)
			{Console.Write(ex.ToString());} 

			return success; 
		}
		/// <summary>
		/// 取得服务器的连接
		/// 服务器有SMTP和ESMTP两种,不同的服务器连接的命令格式不一样
		/// </summary>
		/// <returns></returns>
		public bool getMailServer() 
		{ 
			try 
			{ 
				//域名解析 
                System.Net.IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
                System.Net.IPAddress ipaddress = addressList[0]; 
				System.Net.IPEndPoint endpoint=new IPEndPoint(ipaddress,25); 
				Connect(endpoint);				//连接Smtp服务器 
				ReceiveStream();				//获取连接信息 
				if (this.username!=null) 
				{ 
					//开始进行服务器认证 
					//如果状态码是250则表示操作成功 
					if (!OperaStream("EHLO Localhost","250")) 
					{ 
						this.Close(); 
						return false; 
					} 
					if (!OperaStream("AUTH LOGIN","334")) 
					{ 
						this.Close(); 
						return false; 
					} 
					username=AuthStream(username);//此处将username转换为Base64码 
					if (!OperaStream(this.username,"334")) 
					{ 
						this.Close(); 
						return false; 
					} 
					password=AuthStream(password);//此处将password转换为Base64码 
					if (!OperaStream(this.password,"235")) 
					{ 
						this.Close(); 
						return false; 
					} 
					return true; 
				} 
				else 
				{ //如果服务器不需要认证 
					if (OperaStream("HELO Localhost","250")) 
					{ 
						return true; 
					} 
					else 
					{ 
						return false; 
					} 
				} 
			} 
			catch(Exception ex) 
			{ return false;} 
		}
		/// <summary>
		/// 和服务器取得联系
		/// </summary>
		/// <param name="strCmd"></param>
		/// <returns></returns>
		private string AuthStream(String strCmd) 
		{
			try 
			{ 
				byte[] by=Encoding.Default.GetBytes(strCmd.ToCharArray()); 
				strCmd=Convert.ToBase64String(by); 
			} 
			catch(Exception ex) 
			{return ex.ToString();} 
			return strCmd; 
		}
		/// <summary>
		/// 处理邮件的附件，读取文件的内容和信息
		/// </summary>
		/// <param name="path"></param>
		public void LoadAttFile(String path) 
		{ 
			//根据路径读出文件流 

			FileStream fstr=new FileStream(path,FileMode.Open);		//建立文件流对象 
			byte[] by=new byte[Convert.ToInt32(fstr.Length)]; 

			fstr.Read(by,0,by.Length);								//读取文件内容 
			fstr.Close();//关闭 

			//格式转换 
			String fileinfo=Convert.ToBase64String(by);				//转化为base64编码 

			//增加到文件表中 
			DataRow dr=filelist.NewRow(); 
			dr[0]=Path.GetFileName(path);							//获取文件名
			dr[1]=fileinfo;											//文件内容 
			filelist.Rows.Add(dr);									//增加 
		}
		/// <summary>
		/// 处理附件并发送附件
		/// </summary>
		private void Attachment() 
		{ 
			filelist = new DataTable();//已定义变量，初始化操作 
			filelist.Columns.Add(new DataColumn("filename",typeof(string)));//文件名 
			filelist.Columns.Add(new DataColumn("filecontent",typeof(string)));//文件内容 

			//对文件列表做循环 
			for (int i=0;i < filelist.Rows.Count;i++)
			{ 
				DataRow dr = filelist.Rows[i]; 
				WriteStream("--unique-boundary-1","UTF-8");														//邮件内容分隔符 
				WriteStream("Content-Type: application/octet-stream;name=\""+dr[0].ToString()+"\"","UTF-8");	//文件格式 
				WriteStream("Content-Transfer-Encoding: base64","UTF-8");										//内容的编码 
				WriteStream("Content-Disposition:attachment;filename=\""+dr[0].ToString()+"\"","UTF-8");		//文件名 
				WriteStream("","UTF-8"); 
   
				String fileinfo=dr[1].ToString();
				WriteStream(fileinfo,"UTF-8");																	//写入文件的内容 
				WriteStream("","UTF-8"); 
			}
		}
		/// <summary>
		/// 发送邮件
		/// </summary>
		public void SendMial()
		{
			WriteStream("EHLO Localhost",this.charset);
			WriteStream("AUTH LOGIN",this.charset);
			WriteStream(AuthStream(username),this.Charset);
			WriteStream(AuthStream(password),this.Charset);

			//邮件主题
			WriteStream("Date:" + this.sendTime,this.charset);
			WriteStream("From:" + this.sender,this.charset);
			WriteStream("Subject:" + this.subject,this.charset);
			WriteStream("To:" + this.consignee,this.charset);

			//邮件格式
			WriteStream("Content-Type: "+ this.content_type +"; boundary=\"unique-boundary-1\"",this.charset); 
			WriteStream("Reply-To:" + this.sender,this.charset);
			WriteStream("X-Priority:" + this.priority,this.charset);
			WriteStream("MIME-Version:1.0",this.charset);

			//数据
			WriteStream("Message-Id: " + DateTime.Now.ToFileTime() + "harmonydeal.com",this.charset);
			WriteStream("Content-Transfer-Encoding:" + this.encode,this.charset);
			WriteStream("X-Mailer:DS Mail Sender V1.0",this.charset); 
			WriteStream("",charset);
			
			WriteStream(AuthStream("This is a multi-part message in MIME format."),this.charset);
			WriteStream("",this.charset); 
			WriteStream("--unique-boundary-1",this.charset);

			WriteStream("Content-Type: multipart/alternative;Boundary=\"unique-boundary-2\"",this.charset); 
			WriteStream("",this.charset);

			WriteStream("--unique-boundary-2",this.charset);
			WriteStream("Content-Type: text/plain;charset=" + this.charset,this.charset); 

			WriteStream("Content-Transfer-Encoding:" + this.encode,this.charset); 
			WriteStream("",this.charset); 
			WriteStream(body,this.charset);
			WriteStream("",this.charset);
			WriteStream("--unique-boundary-2",this.charset); 
   
   
			WriteStream("Content-Type: text/html;charset=" + this.charset,this.charset); 
			WriteStream("Content-Transfer-Encoding:" + this.encode,this.charset); 
			WriteStream("",this.charset); 
			WriteStream(htmlbody,this.charset); 
			WriteStream("",this.charset); 
			WriteStream("--unique-boundary-2--",this.charset);
			WriteStream("",this.charset); 

			Attachment();
			WriteStream("",this.charset); 
			WriteStream("--unique-boundary-1--",this.charset);
			if (!OperaStream(".","250"))					//最后写完，输入"." 
			{ 
				this.Close();								//关闭连接
			} 
		}
		#endregion
	}
}
