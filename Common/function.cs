using System;
using System.Data;
using System.Text;

namespace Common
{
	/// <summary>
	/// function 的摘要说明。
	/// </summary>
	public class function
	{
		public function()
		{

		}
		/// <summary>
		/// 分页按钮
		/// </summary>
		/// <param name="strUrl">下一页链接文件名</param>
		/// <param name="CurrentPage">当前页码</param>
		/// <param name="TatalNum">总页数</param>
		/// <param name="PageSize">每页显示记录数</param>
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
				str+="首页　上一页";
			else
			{
				str+="<a href='"+strUrl+"page=1' class='font12'>首页</a>";
				str+="&nbsp;<a href='" +strUrl+ "page="+(CurrentPage-1)+"' class='font12'>上一页</a>";
			}
			str+="</td><td><font color=red>"+CurrentPage+"</font>&nbsp;/&nbsp;" + n + "</td><td>";
			if((n-CurrentPage)<1)
				str+="下一页　末页";
			else
			{
				str+="<a href='"+strUrl+"page="+(CurrentPage+1)+"' class='font12'>下一页</a>";
				str+="&nbsp;<a href='"+strUrl+"page="+n+"' class='font12'>末页</a>";
			}
			str+="</td><td>共&nbsp;"+TatalNum+"条纪录&nbsp;&nbsp;&nbsp;&nbsp;";
			str+="</tr></td></table>";

			return str;
		}
		
		/// <summary>
		/// 限制字符显示长度，用于限制标题等一些文本的显示长度
		/// </summary>
		/// <param name="inputstr">需要限制的字符</param>
		/// <param name="len">限制的长度</param>
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
				str+="…";
			}
			return str;
		}
		 
	}
}
