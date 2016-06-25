using System;

namespace Common
{
	/// <summary>
	/// ���ڴ�������
	/// </summary>
	public class DateUtil
	{
		//���캯��
		public DateUtil()
		{

		}
		

        #region ����

		/// <summary>���ر����ж�����</summary>
		/// <param name="iYear">���</param>
		/// <returns>���������</returns>
		public static int GetDaysOfYear(int iYear)
		{
			int cnt = 0  ;
			if (  IsRuYear(iYear) ) 
			{
				//����� 1 �� ����2 ��Ϊ 29 ��
			    cnt = 366;
				
			}
			else
			{
		       //--��������1�� ����2 ��Ϊ 28 ��
			   cnt = 365;
			}
			return cnt;
		}
		/// <summary>
		/// ���ص�ǰ����ʱ���ַ���
		/// </summary>
		/// <returns>����ʱ���ַ���</returns>
		public static string GetDateTimeStr()
		{
			string year = DateTime.Now.Year.ToString().Substring(2,2);
			string StrDateTime = year + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +  DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
			return StrDateTime;
		}

		/// <summary>�����ж�����</summary>
		/// <param name="dt">����</param>
		/// <returns>�����ڵ��������</returns>
		public static int GetDaysOfYear(DateTime idt)
		{
			int n ;
			
			//ȡ�ô����������ݲ��֣������ж��Ƿ�������
			
			n = idt.Year;
			if (  IsRuYear(n) ) 
			{
				//����� 1 �� ����2 ��Ϊ 29 ��
				return 366; 
			}
			else
			{
				//--��������1�� ����2 ��Ϊ 28 ��
				return 365;
			}

		}


		/// <summary>�����ж�����</summary>
		/// <param name="iYear">��</param>
		/// <param name="Month">��</param>
		/// <returns>����</returns>
		public static int GetDaysOfMonth(int iYear,int Month)
		{
		   int days=0;
			switch (Month)
			{
				case 1:
					days = 31;
					break;
				case 2:
					if (  IsRuYear(iYear) ) 
					{
						//����� 1 �� ����2 ��Ϊ 29 ��
						days = 29;
					}
					else
					{
						//--��������1�� ����2 ��Ϊ 28 ��
						days = 28;
					}

					break;
				case 3:
					days = 31;
					break;
				case 4:
					days = 30;
					break;
				case 5:
					days = 31;
					break;
				case 6:
					days = 30;
					break;
				case 7:
					days = 31;
					break;
				case 8:
					days = 31;
					break;
				case 9:
					days = 30;
					break;
				case 10:
					days = 31;
					break;
				case 11:
					days = 30;
					break;
				case 12:
					days = 31;
					break;
			}	   

			return days ;


		}

		
		/// <summary>�����ж�����</summary>
		/// <param name="dt">����</param>
		/// <returns>����</returns>
		public static int GetDaysOfMonth(DateTime dt)
		{
			//--------------------------------//
			//--��dt��ȡ�õ�ǰ���꣬����Ϣ  --//
			//--------------------------------//
			int year,month,days=0;
			year = dt.Year ;
			month = dt.Month ;

			//--����������Ϣ���õ���ǰ�µ�������Ϣ��
			switch (month)
			{
				case 1:
					days = 31;
					break;
				case 2:
					if (  IsRuYear(year) ) 
					{
						//����� 1 �� ����2 ��Ϊ 29 ��
						days = 29;
					}
					else
					{
						//--��������1�� ����2 ��Ϊ 28 ��
						days = 28;
					}

					break;
				case 3:
					days = 31;
					break;
				case 4:
					days = 30;
					break;
				case 5:
					days = 31;
					break;
				case 6:
					days = 30;
					break;
				case 7:
					days = 31;
					break;
				case 8:
					days = 31;
					break;
				case 9:
					days = 30;
					break;
				case 10:
					days = 31;
					break;
				case 11:
					days = 30;
					break;
				case 12:
					days = 31;
					break;
			}	   

			return days ;

		}


        /// <summary>���ص�ǰ���ڵ���������</summary>
        /// <param name="dt">����</param>
        /// <returns>��������</returns>
        public static string GetWeekNameOfDay(DateTime idt)
        {
            string dt, week = "";

            dt = idt.DayOfWeek.ToString().ToLower();
            switch (dt)
            {
                case "monday":
                    week = "����һ";
                    break;
                case "tuesday":
                    week = "���ڶ�";
                    break;
                case "wednesday":
                    week = "������";
                    break;
                case "thursday":
                    week = "������";
                    break;
                case "friday":
                    week = "������";
                    break;
                case "saturday":
                    week = "������";
                    break;
                case "sunday":
                    week = "������";
                    break;

            }
            return week;
        }
						
		/// <summary>���ص�ǰ���ڵ����ڱ��</summary>
		/// <param name="dt">����</param>
		/// <returns>�������ֱ��</returns>
		public static string GetWeekNumberOfDay(DateTime idt)
		{ 
				string dt,week="";

                dt = idt.DayOfWeek.ToString().ToLower();
				switch  (dt)
				{
					case "monday":
						week= "1";
						break;
					case "tuesday" :
						week= "2";
						break;
					case "wednesday":
						week= "3";
						break;
					case "thursday" :
						week= "4";
						break;
					case "friday" :
						week= "5";
						break;
					case "saturday":
						week= "6";
						break;
					case "sunday":
						week = "7";
						break;

				}	   
			
			return week;


		}

        /// <summary>
        /// ƥ���ܴΡ�����,��ȡ���������·ݵĵ� week �� �Ŀ�ʼ���ںͽ�������
        /// �����·ݵĵ�һ�ܵ��������� 4 ʱ,����Ϊ�ǵ�һ��, ������Щ�����Ļ����ϼ���7��
        /// </summary>
        /// <param name="date">ָ������</param>
        /// <param name="week">�ܴ�</param>
        /// <returns></returns>
        public static string[] GetWeekBeginDateAndEndDate(DateTime date, int week)
        {
            int days = DateTime.DaysInMonth(date.Year, date.Month);
            DateTime monthBeginDate = DateTime.Parse(date.Year.ToString() + "-" + date.Month.ToString() + "-1"); ;
            int weekBeginNo = int.Parse(GetWeekNumberOfDay(monthBeginDate));
            string[] dateArr = new string[2];

            int first = 0, second = 0, third = 0, fourth = 0;
            if (7 - weekBeginNo > 4)
                first = 6 - weekBeginNo;
            else
                first = 7 + (6 - weekBeginNo);
            second = first + 7;
            third = second + 7;
            fourth = days - 1;

            switch (week)
            {
                case 1:
                    dateArr[0] = monthBeginDate.ToShortDateString();
                    dateArr[1] = monthBeginDate.AddDays(first).ToShortDateString();
                    break;
                case 2:
                    dateArr[0] = monthBeginDate.AddDays(first + 1).ToShortDateString();
                    dateArr[1] = monthBeginDate.AddDays(second).ToShortDateString();
                    break;
                case 3:
                    dateArr[0] = monthBeginDate.AddDays(second + 1).ToShortDateString();
                    dateArr[1] = monthBeginDate.AddDays(third).ToShortDateString();
                    break;
                case 4:
                    dateArr[0] = monthBeginDate.AddDays(third + 1).ToShortDateString();
                    dateArr[1] = monthBeginDate.AddDays(fourth).ToShortDateString();
                    break;
            }

            return dateArr;
        }

		/// <summary>������������֮����������</summary>
		/// <param name="dt">�������ڲ���</param>
		/// <returns>����</returns>
		public static int DiffDays(DateTime dtfrm,DateTime dtto)
		{ 
			int diffcnt=0;
			//diffcnt = dtto- dtfrm ;
			
			return diffcnt;
		}

		
		/// <summary>�жϵ�ǰ��������������Ƿ������꣬˽�к���</summary>
		/// <param name="dt">����</param>
		/// <returns>�����꣺True ���������꣺False</returns>
		private static bool IsRuYear(DateTime idt)
		{
			//��ʽ����Ϊ�������� 
			//���磺2003-12-12
			int n ;
			n = idt.Year;

			if (  (n % 400  == 0)  ||   (n %  4 == 0 && n % 100  != 0)  ) 
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		
		/// <summary>�жϵ�ǰ����Ƿ������꣬˽�к���</summary>
		/// <param name="dt">���</param>
		/// <returns>�����꣺True ���������꣺False</returns>
		private static bool IsRuYear(int iYear)
		{
			//��ʽ����Ϊ���
			//���磺2003
			int n ;
			n = iYear;

			if  (   (  n % 400 == 0)  ||   (n % 4 == 0 && n % 100  != 0)  ) 
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// ��������ַ���ת��Ϊ���ڡ�����ַ����ĸ�ʽ�Ƿ����򷵻ص�ǰ���ڡ�
		/// </summary>
		/// <param name="strInput">�����ַ���</param>
		/// <returns>���ڶ���</returns>
		public static DateTime ConvertStringToDate(string strInput)
		{
			DateTime oDateTime;

			try
			{
				oDateTime=DateTime.Parse(strInput);       
			}
			catch(Exception)
			{
				oDateTime=DateTime.Today;  
			}

			return oDateTime;
		}


		/// <summary>
		/// �����ڶ���ת��Ϊ��ʽ�ַ���
		/// </summary>
		/// <param name="oDateTime">���ڶ���</param>
		/// <param name="strFormat">
		/// ��ʽ��
		///		"SHORTDATE"===������
		///		"LONGDATE"==������
		///		����====�Զ����ʽ
		/// </param>
		/// <returns>�����ַ���</returns>
		public static string ConvertDateToString(DateTime oDateTime,string strFormat)
		{
			string strDate="";

			try
			{
				switch(strFormat.ToUpper())
				{
					case "SHORTDATE":
						strDate=oDateTime.ToShortDateString();
						break;
					case "LONGDATE":
						strDate=oDateTime.ToLongDateString() ;
						break;
					default:
						strDate=oDateTime.ToString(strFormat) ;
						break;
				}
			}
			catch(Exception)
			{
				strDate=oDateTime.ToShortDateString();
			}

			return strDate;
		}



		/// <summary>
		/// �ж��Ƿ�Ϊ�Ϸ����ڣ��������1800��1��1��
		/// </summary>
		/// <param name="strDate">���������ַ���</param>
		/// <returns>True/False</returns>
		public static bool IsDateTime(string strDate)
		{
			try
			{
				DateTime oDate=DateTime.Parse(strDate); 
				if(oDate.CompareTo(DateTime.Parse("1800-1-1") )>0)
					return true;
				else
					return false;
			}
			catch(Exception)
			{
				return false;
			}
		}
		/// <summary>
		/// ��ʽ����������ַ���
		/// Aug 17, 2006
		/// </summary>
		/// <param name="date">����</param>
		/// <returns></returns>
		public static string formatDateByEN(DateTime date)
		{
			int month = date.Month;
			string monthStr = "",dateStr = "";
			switch (month)
			{
				case 1:
					monthStr = "Jan";
					break;
				case 2:
					monthStr = "Feb";
					break;
				case 3:
					monthStr = "Mar";
					break;
				case 4:
					monthStr = "Apr";
					break;
				case 5:
					monthStr = "May";
					break;
				case 6:
					monthStr = "Jun";
					break;
				case 7:
					monthStr = "Jul";
					break;
				case 8:
					monthStr = "Aug";
					break;
				case 9:
					monthStr = "Sep";
					break;
				case 10:
					monthStr = "Oct";
					break;
				case 11:
					monthStr = "Nov";
					break;
				case 12:
					monthStr = "Dec";
					break;
			} 
			dateStr = monthStr + " " + date.Day.ToString() + "," + date.Year.ToString();
			return dateStr;
		}
		
		#endregion


	}
}
