using System;
using System.Data;
using System.Text;

namespace Common
{
	/// <summary>
	/// function ��ժҪ˵����
	/// </summary>
	public class function
	{
		public function()
		{

		}
		/// <summary>
		/// ��ҳ��ť
		/// </summary>
		/// <param name="strUrl">��һҳ�����ļ���</param>
		/// <param name="CurrentPage">��ǰҳ��</param>
		/// <param name="TatalNum">��ҳ��</param>
		/// <param name="PageSize">ÿҳ��ʾ��¼��</param>
		/// <returns></returns>
		public static string pages(string strUrl,int CurrentPage,int TatalNum,int PageSize)
		{
			int n=0;

			if((TatalNum%PageSize)==0)
				n=TatalNum/PageSize;
			else
				n=TatalNum/PageSize+1;

			if (n<CurrentPage)
				CurrentPage=n;
			if (n<=0)
				CurrentPage=1;

			string str="";
			str+="<table align='center'><tr class='font12'><td>";
			if(CurrentPage<2)
				str+="��ҳ����һҳ";
			else
			{
				str+="<a href='"+strUrl+"page=1' class='font12'>��ҳ</a>";
				str+="&nbsp;<a href='" +strUrl+ "page="+(CurrentPage-1)+"' class='font12'>��һҳ</a>";
			}
			str+="</td><td><font color=red>"+CurrentPage+"</font>&nbsp;/&nbsp;" + n + "</td><td>";
			if((n-CurrentPage)<1)
				str+="��һҳ��ĩҳ";
			else
			{
				str+="<a href='"+strUrl+"page="+(CurrentPage+1)+"' class='font12'>��һҳ</a>";
				str+="&nbsp;<a href='"+strUrl+"page="+n+"' class='font12'>ĩҳ</a>";
			}
			str+="</td><td>��&nbsp;"+TatalNum+"����¼&nbsp;&nbsp;&nbsp;&nbsp;";
			str+="</tr></td></table>";

			return str;
		}
		
		/// <summary>
		/// �����ַ���ʾ���ȣ��������Ʊ����һЩ�ı�����ʾ����
		/// </summary>
		/// <param name="inputstr">��Ҫ���Ƶ��ַ�</param>
		/// <param name="len">���Ƶĳ���</param>
		/// <returns></returns>
		public static string cutstring(string inputstr,int len)
		{
			ASCIIEncoding asci=new ASCIIEncoding();
			int strlen=0;
			string str=null;
			byte [] s=asci.GetBytes(inputstr);
			for(int i=0;i<s.Length;i++)
			{
				if((int)s[i]==63)
				{
					strlen+=2;
				}
				else
				{
					strlen+=1;
				}
				try
				{
					str+=inputstr.Substring(i,1);
				}
				catch
				{
					break;
				}
				if(strlen>len)
					break;
			}
			byte[] mybyte=Encoding.Default.GetBytes(inputstr);
			if(mybyte.Length>len)
			{
				str+="��";
			}
			return str;
		}
		 
	}
}
