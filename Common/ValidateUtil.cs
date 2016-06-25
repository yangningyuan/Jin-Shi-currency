using System;
using System.Text;

namespace Common
{
	/// <summary>
	/// ��֤�ַ����Ƿ�Ϸ�
	/// </summary>
	public class ValidateUtil
	{
		/// <summary>���캯��</summary>
		public ValidateUtil()
		{

		}

		/// <summary>�Ƿ��</summary>
		/// <param name="strInput">�����ַ���</param>
		/// <returns>true/false</returns>
		public static bool isBlank(string strInput)
		{
			if (strInput==null || strInput.Trim()=="") 
			{
			  return true;
			}
			else
			{
			  return false;
			}
			
		}

		/// <summary>�Ƿ�����</summary>
		/// <param name="strInput">�����ַ���</param>
		/// <returns>true/false</returns>
		public static bool isNumeric(string strInput)
		{  
			 
			char[] ca =strInput.ToCharArray();
			bool found=true;
			for (int i=0;i<ca.Length;i++)
			{
				if ((ca[i]<'0' || ca[i]>'9') && ca[i]!='.')
				{
					 
					found=false;
					break;
					
				};				

			};
			return found ;
			
		}
		/// <summary>�Ƿ�Ϊ1-9֮�������</summary>
		/// <param name="strInput">���������ַ���</param>
		/// <returns>true/false</returns>
		public static bool isIntNumeric(string strInput)
		{  
			char[] ca =strInput.ToCharArray();
			bool found=false;
			for (int i=0;i<ca.Length;i++)
			{
				if ((ca[i]>'0' || ca[i]<'9') && ca[i] !='-' && ca[i] != '.')	 
					found=true;
				else
				{
					found=false;
					break;
				}
			};
			return found;		
		}
		/// <summary>�Ƿ�����</summary>
		/// <param name="strInput">�����ַ���</param>
		/// <returns>true/false</returns>
		public static bool isDate(string strInput)
		{
			string datestr=strInput;
			string year,month,day;
			string [] c={"/","-","."};
            string cs="";
			for (int i=0;i<c.Length;i++)
			{
				if(datestr.IndexOf(c[i])>0) 
				{
				  cs=c[i];
	              break;
				}	
				
			};

			if (cs!="" )
			{
				year=datestr.Substring(0,datestr.IndexOf(cs));
				if(year.Length!=4){return false;};
				datestr = datestr.Substring(datestr.IndexOf(cs) + 1);

				month=datestr.Substring(0,datestr.IndexOf(cs));
				if((month.Length!=2) || (Convert.ToInt16(month)>12))
				{return false;};
				datestr = datestr.Substring(datestr.IndexOf(cs) + 1);

				day=datestr;
				if((day.Length!=2) || (Convert.ToInt16(day)>31)){return false;};

				return checkDatePart(year,month,day); 
			}
			else
			{
			  return false;
			}
	
		}
		
		/// <summary>
		/// ����������Ƿ�Ϸ�
		/// </summary>
		/// <param name="dt"></param>
		/// <param name="part"></param>
		/// <returns></returns>
		private static bool checkDatePart(string year,string month,string day)
		{
             int iyear=Convert.ToInt16(year);
			 int imonth=Convert.ToInt16(month);
			 int iday= Convert.ToInt16(day);
			 if (iyear>2099 || iyear<1900) {return false;}	
			 if (imonth>12 || imonth<1) {return false;}	
		 	 if (iday>DateUtil.GetDaysOfMonth(iyear,imonth)|| iday<1) {return false;};
			 return true;
	
	
		}
        /// <summary>
        /// ����ַ����Ƿ����Sqlע�빥����ȫҪ��
        /// </summary>
        /// <param name="strInputStr">�����ַ���</param>
        /// <returns>true/false</returns>
        public static bool isSafeSqlCode(string strInputStr)
        {
            strInputStr = strInputStr.ToLower();
            string strFilter = "net user|xp_cmdshell|/add|asc|mid|'|\"|truncate|%|-|[|]|";
            strFilter += "alter|script|object|applet|applet|";
            strFilter += "create|rename|nchar|char|cast|join|union|where|char|select|count|insert|delete|update|drop|from|declare|like";
            string[] arrFilter = strFilter.Split('|');

            bool blResult = true;
            for (int i = 0; i < arrFilter.Length; i++)
            {
                if (strInputStr.IndexOf(arrFilter[i], 0, strInputStr.Length) >= 0)
                {
                    blResult = false;
                    break;
                }
            }
            return blResult;
        }
        /// <summary>
        /// ����ַ����Ƿ���ϵ�¼�ַ����İ�ȫҪ��
        /// </summary>
        /// <param name="strInputStr">�����ַ���</param>
        /// <returns>true/false</returns>
        public static bool isDangerString(string strInputStr)
        {
            string strDangerString = "' ��&<>?%,;:()`~!@#$^*{}[]|+-=" + Convert.ToChar(34) + Convert.ToChar(9) + Convert.ToChar(32);
            int intLenght = strDangerString.Length;
            bool blResult = true;
            string strTemp; int intTemp;
            for (int i = 1; i < intLenght; i++)
            {
                strTemp = strDangerString.Substring(i, 1);
                intTemp = strInputStr.IndexOf(strDangerString.Substring(i, 1), 0, strInputStr.Length);
                if (strInputStr.IndexOf(strDangerString.Substring(i, 1), 0, strInputStr.Length) >= 0)
                {
                    blResult = false;
                    break;
                }
            }
            return blResult;
        }
        public static bool isDangerString()
        {
            bool dr = false;
            return dr;
        }
        public static string test()
        {
            return "";
        }
        /// <summary>�Ƿ�Null</summary>
        /// <param name="strInput">�����ַ���</param>
        /// <returns>true/false</returns>
        public static bool isNull(object strInput)
		{
			return true ;
		}

        public static bool IsDouble(object obj)
        {
            string aa = obj.GetType().ToString();
            if (obj.GetType() == typeof(System.Double))
                return true;
            else
                return false;
        }

		/// <summary>�Ƿ�ΪInt</summary>
		/// <param name="strInput">�����ַ���</param>
		/// <returns>true/false</returns>
		public static bool isInt(string strInput)
		{
            char[] ca = strInput.ToCharArray();
            bool found = false;
            for (int i = 0; i < ca.Length; i++)
            {
                if ((ca[i] > '0' || ca[i] < '9') && ca[i] != '-' && ca[i] != '.')
                    found = true;
                else
                {
                    found = false;
                    break;
                }
            };
            return found;	
		}

		/// <summary>�Ƿ�Ϊ�Ϸ��ĵ绰����</summary>
		/// <param name="strInput">�����ַ���</param>
		/// <returns>true/false</returns>
		public static bool isTel(string strInput)
		{
			//�绰���������Concief������[CurrentPhoneRule]
			return true ; 
		}


		/// <summary>�Ƿ�Ϊ�Ϸ�����������</summary>
		/// <param name="strInput">�����ַ���</param>
		/// <returns>true/false</returns>
		public static bool isZip(string strInput)
		{
			//�������������Concief������[CurrentZipRule]
			return true ; 
		}

		/// <summary>�Ƿ�Ϊ�Ϸ��ĵ����ʼ�</summary>
		/// <param name="strInput">�����ַ���</param>
		/// <returns>true/false</returns>
		public static bool isEmail(string strInput)
		{
			return true ; 
		}


	}

}
