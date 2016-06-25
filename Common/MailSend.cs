using System;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Data; 
using System.Net;

namespace Common
{
	/// <summary>
	/// �ʼ��������SMTP
	/// </summary>
	public class MailSend:TcpClient
	{
		#region �ֶ�

		private string server;//SMTP���������� 

		private int port;//�˿� 
   
		private string username;//�û��� 
   
		private string password;//���� 
   
		private string subject;//���� 
   
		private string body;//�ı����� 
   
		private string htmlbody;//���ı����� 
      
		private string sender;//�����˵�ַ 
   
		private string consignee;//�ռ��˵�ַ 
   
		private string senderName;//���������� 
   
		private string consigneeName;//�ռ������� 
   
		private string content_type;//�ʼ����� 
   
		private string encode;//�ʼ����� 
   
		private string charset;//���Ա��� 
   
		private DataTable filelist;//�����б� 
   
		private int priority;//�ʼ����ȼ� 

		private DateTime sendTime;//�ʼ�����ʱ��

		#endregion

		public MailSend()
		{
			
		}


		#region ����
		/// <summary>
		/// SMTP�ʼ�����������
		/// </summary>
		public string SMTPServer 
		{ 
			set{this.server = value;}   
		}
		/// <summary>
		/// �˿�����
		/// </summary>
		public int Port
		{
			get{return port;}
			set{port = value;}
		}
		/// <summary>
		/// �û���
		/// </summary>
		public string UserName
		{
			get{return username;}
			set{username = value;}
		}
		/// <summary>
		/// �û�����
		/// </summary>
		public string Password
		{
			get{return password;}
			set{password = value;}
		}
		/// <summary>
		/// �ʼ�����
		/// </summary>
		public string Subject
		{
			get{return subject;}
			set{subject = value;}
		}
		/// <summary>
		/// �ʼ��ı���ʽ����
		/// </summary>
		public string Body
		{
			get{return body;}
			set{body = value;}
		}
		/// <summary>
		/// �ʼ����ı���ʽ����
		/// </summary>
		public string HtmlBody
		{
			get{return htmlbody;}
			set{htmlbody = value;}
		}
		/// <summary>
		/// �����˵�ַ
		/// </summary>
		public string Sender
		{
			get{return sender;}
			set{sender = value;}
		}
		/// <summary>
		/// �ռ��˵�ַ
		/// </summary>
		public string Consignee
		{
			get{return consignee;}
			set{consignee = value;}
		}
		/// <summary>
		/// �ļ�������
		/// </summary>
		public string SenderName
		{
			get{return senderName;}
			set{senderName = value;}
		}
		/// <summary>
		/// �ռ�������
		/// </summary>
		public string ConsigneeName
		{
			get{return consigneeName;}
			set{consigneeName = value;}
		}
		/// <summary>
		/// �ʼ�����
		/// </summary>
		public string ContentType
		{
			get{return content_type;}
			set{content_type = value;}
		}
		/// <summary>
		/// �ʼ�����
		/// </summary>
		public string Encode
		{
			get{return encode;}
			set{encode = value;}
		}
		/// <summary>
		/// ���Ա���
		/// </summary>
		public string Charset
		{
			get{return charset;}
			set{charset = value;}
		}
		/// <summary>
		/// �����б�
		/// </summary>
		public DataTable Filelist
		{
			get{return filelist;}
			set{filelist = value;}
		}
		/// <summary>
		/// �ʼ����ȼ�
		/// </summary>
		public int Priority
		{
			get{return priority;}
			set{priority = value;}
		}
		/// <summary>
		/// �ʼ�����ʱ��
		/// </summary>
		public DateTime SendTime 
		{ 
			get{return sendTime;} 
			set{this.sendTime = value;}   
		}
		#endregion

		#region ����
		/// <summary>
		/// �������д������
		/// </summary>
		/// <param name="strCmd">��Ҫ�������������ݵ��ַ���</param>
		/// <param name="charset">���ݵ��ַ����Ա���</param>
		private void WriteStream(string strCmd, string charset) 
		{
			Stream TcpStream;				//����������� 
			strCmd = strCmd + "\r\n";		//���뻻�з� 
			TcpStream = new TcpClient(server,25).GetStream();	//��ȡ������ 

			//��������ת��Ϊbyte[] 
			byte[] bWrite = Encoding.GetEncoding(charset).GetBytes(strCmd.ToCharArray()); 

			//����ÿ��д������ݴ�С�������Ƶģ���ô���ǽ�ÿ��д������ݳ��ȶ��ڣ������ֽڣ�һ������ȳ����ˣ������ͷֲ�д�롣 
			int start = 0; 
			int length = bWrite.Length; 
			int page = 0; 
			int size = 75; 
			int count = size;
			try
			{
				if (length>75) 
				{ 
					//���ݷ�ҳ 
					if ((int)(length/size) * size > length )
						page = length / size+1; 
					else 
						page = length / size; 

					for (int i = 0;i > page;i++)
					{
						start = i * size; 

						if (i == page-1) 
							count = length - (i * size); 
   
						TcpStream.Write(bWrite,start,count);//������д�뵽�������� 
					} 
				}
				else 
					TcpStream.Write(bWrite,0,bWrite.Length); 
			} 
			catch(Exception er){} 
		}
		/// <summary>
		/// ��ȡ�������ķ�����Ϣ
		/// </summary>
		private string ReceiveStream() 
		{ 
			String sp = null; 
			byte[] by = new byte[1024];

			NetworkStream ns = this.GetStream();		//�˴����ɻ�ȡ�������ķ��������� 
			int size = ns.Read(by,0,by.Length);			//��ȡ������ 

			if (size > 0) 
			{ 
				sp = Encoding.Default.GetString(by);	//ת��ΪString 
			}

			return sp; 
		}
		/// <summary>
		/// ��������жϷ�����Ϣ�Ƿ���ȷ,������������������Ƿ���ܲ�ͨ��
		/// </summary>
		/// <param name="strCmd">��Ҫ����������������</param>
		/// <param name="state">���صı��������ɹ���״̬��</param>
		/// <returns></returns>
		private bool OperaStream(string strCmd,string state) 
		{
			string sp=null; 
			bool success=false;

			try 
			{ 
				WriteStream(strCmd,"UTF-8");		//д������ 
				sp = ReceiveStream();				//���ܷ�����Ϣ 
				if (sp.IndexOf(state)!=-1)			//�ж�״̬���Ƿ���ȷ 
					success=true; 
			} 
			catch(Exception ex)
			{Console.Write(ex.ToString());} 

			return success; 
		}
		/// <summary>
		/// ȡ�÷�����������
		/// ��������SMTP��ESMTP����,��ͬ�ķ��������ӵ������ʽ��һ��
		/// </summary>
		/// <returns></returns>
		public bool getMailServer() 
		{ 
			try 
			{ 
				//�������� 
                System.Net.IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
                System.Net.IPAddress ipaddress = addressList[0]; 
				System.Net.IPEndPoint endpoint=new IPEndPoint(ipaddress,25); 
				Connect(endpoint);				//����Smtp������ 
				ReceiveStream();				//��ȡ������Ϣ 
				if (this.username!=null) 
				{ 
					//��ʼ���з�������֤ 
					//���״̬����250���ʾ�����ɹ� 
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
					username=AuthStream(username);//�˴���usernameת��ΪBase64�� 
					if (!OperaStream(this.username,"334")) 
					{ 
						this.Close(); 
						return false; 
					} 
					password=AuthStream(password);//�˴���passwordת��ΪBase64�� 
					if (!OperaStream(this.password,"235")) 
					{ 
						this.Close(); 
						return false; 
					} 
					return true; 
				} 
				else 
				{ //�������������Ҫ��֤ 
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
		/// �ͷ�����ȡ����ϵ
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
		/// �����ʼ��ĸ�������ȡ�ļ������ݺ���Ϣ
		/// </summary>
		/// <param name="path"></param>
		public void LoadAttFile(String path) 
		{ 
			//����·�������ļ��� 

			FileStream fstr=new FileStream(path,FileMode.Open);		//�����ļ������� 
			byte[] by=new byte[Convert.ToInt32(fstr.Length)]; 

			fstr.Read(by,0,by.Length);								//��ȡ�ļ����� 
			fstr.Close();//�ر� 

			//��ʽת�� 
			String fileinfo=Convert.ToBase64String(by);				//ת��Ϊbase64���� 

			//���ӵ��ļ����� 
			DataRow dr=filelist.NewRow(); 
			dr[0]=Path.GetFileName(path);							//��ȡ�ļ���
			dr[1]=fileinfo;											//�ļ����� 
			filelist.Rows.Add(dr);									//���� 
		}
		/// <summary>
		/// �����������͸���
		/// </summary>
		private void Attachment() 
		{ 
			filelist = new DataTable();//�Ѷ����������ʼ������ 
			filelist.Columns.Add(new DataColumn("filename",typeof(string)));//�ļ��� 
			filelist.Columns.Add(new DataColumn("filecontent",typeof(string)));//�ļ����� 

			//���ļ��б���ѭ�� 
			for (int i=0;i < filelist.Rows.Count;i++)
			{ 
				DataRow dr = filelist.Rows[i]; 
				WriteStream("--unique-boundary-1","UTF-8");														//�ʼ����ݷָ��� 
				WriteStream("Content-Type: application/octet-stream;name=\""+dr[0].ToString()+"\"","UTF-8");	//�ļ���ʽ 
				WriteStream("Content-Transfer-Encoding: base64","UTF-8");										//���ݵı��� 
				WriteStream("Content-Disposition:attachment;filename=\""+dr[0].ToString()+"\"","UTF-8");		//�ļ��� 
				WriteStream("","UTF-8"); 
   
				String fileinfo=dr[1].ToString();
				WriteStream(fileinfo,"UTF-8");																	//д���ļ������� 
				WriteStream("","UTF-8"); 
			}
		}
		/// <summary>
		/// �����ʼ�
		/// </summary>
		public void SendMial()
		{
			WriteStream("EHLO Localhost",this.charset);
			WriteStream("AUTH LOGIN",this.charset);
			WriteStream(AuthStream(username),this.Charset);
			WriteStream(AuthStream(password),this.Charset);

			//�ʼ�����
			WriteStream("Date:" + this.sendTime,this.charset);
			WriteStream("From:" + this.sender,this.charset);
			WriteStream("Subject:" + this.subject,this.charset);
			WriteStream("To:" + this.consignee,this.charset);

			//�ʼ���ʽ
			WriteStream("Content-Type: "+ this.content_type +"; boundary=\"unique-boundary-1\"",this.charset); 
			WriteStream("Reply-To:" + this.sender,this.charset);
			WriteStream("X-Priority:" + this.priority,this.charset);
			WriteStream("MIME-Version:1.0",this.charset);

			//����
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
			if (!OperaStream(".","250"))					//���д�꣬����"." 
			{ 
				this.Close();								//�ر�����
			} 
		}
		#endregion
	}
}
