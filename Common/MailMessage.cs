using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Specialized;

namespace Common
{
    /// <summary>
    /// �ʼ�����
    /// </summary>
    public class MailMessage
    {
        private string sender = null;
        private StringCollection receivers = new StringCollection();
        private string subject = "";
        private string xMailer = "";
        private StringCollection attachments = new StringCollection();
        private MailEncodings mailEncoding = MailEncodings.GB2312;
        private MailTypes mailType = MailTypes.Html;
        private byte[] mailBody = null;
        /// <summary>
        /// ��ȡ�����÷�����
        /// </summary>
        public string Sender
        {
            get { return this.sender; }
            set { this.sender = value; }
        }
        /// <summary>
        /// ��ȡ�ռ��˵�ַ����
        /// </summary>
        public StringCollection Receivers
        {
            get { return this.receivers; }
        }
        /// <summary>
        /// ��ȡ�������ʼ�����
        /// </summary>
        public string Subject
        {
            get { return this.subject; }
            set { this.subject = value; }
        }
        /// <summary>
        /// ��ȡ�������ʼ�������
        /// </summary>
        public string XMailer
        {
            get { return this.xMailer; }
            set { this.xMailer = value; }
        }
        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        public StringCollection Attachments
        {
            get { return this.attachments; }
        }
        /// <summary>
        /// ��ȡ�������ʼ��ı��뷽ʽ
        /// </summary>
        public MailEncodings MailEncoding
        {
            get { return this.mailEncoding; }
            set { this.mailEncoding = value; }
        }
        /// <summary>
        /// ��ȡ�������ʼ���ʽ
        /// </summary>
        public MailTypes MailType
        {
            get { return this.mailType; }
            set { this.mailType = value; }
        }
        /// <summary>
        /// ��ȡ�������ʼ�����
        /// </summary>
        public byte[] MailBody
        {
            get { return this.mailBody; }
            set { this.mailBody = value; }
        }
    }
    /// <summary>
    /// �ʼ�����
    /// </summary>
    public enum MailEncodings
    {
        GB2312,
        ASCII,
        Unicode,
        UTF8
    }
    /// <summary>
    /// �ʼ���ʽ
    /// </summary>
    public enum MailTypes
    {
        Html,
        Text
    }
    /// <summary>
    /// smtp����������֤��ʽ
    /// </summary>
    public enum SmtpValidateTypes
    {
        /// <summary>
        /// ����Ҫ��֤
        /// </summary>
        None,
        /// <summary>
        /// ͨ�õ�auth login��֤
        /// </summary>
        Login,
        /// <summary>
        /// ͨ�õ�auth plain��֤
        /// </summary>
        Plain
    }
    /// <summary>
    /// �ʼ�������
    /// </summary>
    public class KSN_Smtp
    {
        #region "member fields"
        /// <summary>
        /// ���Ӷ���
        /// </summary>
        private TcpClient tc;
        /// <summary>
        /// ������
        /// </summary>
        private NetworkStream ns;
        /// <summary>
        /// ����Ĵ����ֵ�
        /// </summary>
        private StringDictionary errorCodes = new StringDictionary();
        /// <summary>
        /// ����ִ�гɹ������Ӧ�����ֵ�
        /// </summary>
        private StringDictionary rightCodes = new StringDictionary();
        /// <summary>
        /// ִ�й����д������Ϣ
        /// </summary>
        private string errorMessage = "";
        /// <summary>
        /// ��¼������־
        /// </summary>
        private string logs = "";
        /// <summary>
        /// ������½����֤��ʽ
        /// </summary>
        private StringCollection validateTypes = new StringCollection();
        /// <summary>
        /// ���г���
        /// </summary>
        private const string CRLF = "\r\n";
        private string serverName = "smtp";
        private string logPath = null;
        private string userid = null;
        private string password = null;
        private string mailEncodingName = "GB2312";
        private bool sendIsComplete = false;
        private SmtpValidateTypes smtpValidateType = SmtpValidateTypes.Login;
        #endregion
        #region "propertys"
        /// <summary>
        /// ��ȡ���һ�˳���ִ���еĴ�����Ϣ
        /// </summary>
        public string ErrorMessage
        {
            get { return this.errorMessage; }
        }
        /// <summary>
        /// ��ȡ��������־���·��
        /// </summary>
        public string LogPath
        {
            get
            {
                return this.logPath;
            }
            set { this.logPath = value; }
        }
        /// <summary>
        /// ��ȡ�����õ�½smtp���������ʺ�
        /// </summary>
        public string UserID
        {
            get { return this.userid; }
            set { this.userid = value; }
        }
        /// <summary>
        /// ��ȡ�����õ�½smtp������������
        /// </summary>
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
        /// <summary>
        /// ��ȡ������Ҫʹ�õ�½Smtp����������֤��ʽ
        /// </summary>
        public SmtpValidateTypes SmtpValidateType
        {
            get { return this.smtpValidateType; }
            set { this.smtpValidateType = value; }
        }
        #endregion
        #region "construct functions"
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="server">������</param>
        /// <param name="port">�˿�</param>
        public KSN_Smtp(string server, int port)
        {
            tc = new TcpClient(server, port);
            ns = tc.GetStream();
            this.serverName = server;
            this.initialFields();
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="ip">����ip</param>
        /// <param name="port">�˿�</param>
        public KSN_Smtp(IPAddress ip, int port)
        {
            IPEndPoint endPoint = new IPEndPoint(ip, port);
            tc = new TcpClient(endPoint);
            ns = tc.GetStream();
            this.serverName = ip.ToString();
            this.initialFields();
        }
        #endregion
        #region "methods"
        private void initialFields() //��ʼ������
        {
            logs = "================" + DateTime.Now.ToLongDateString() + "    " + DateTime.Now.ToLongTimeString() + "===============" + CRLF;
            //*****************************************************************
            //�����״̬��
            //*****************************************************************
            errorCodes.Add("421", "����δ����,�رմ���ͨ��");
            errorCodes.Add("432", "��Ҫһ������ת��");
            errorCodes.Add("450", "Ҫ����ʼ�����δ���,���䲻����(��:����æ)");
            errorCodes.Add("451", "����Ҫ��Ĳ���,Ҫ��Ĳ���δִ��");
            errorCodes.Add("452", "ϵͳ�洢����,Ҫ��Ĳ���δ���");
            errorCodes.Add("454", "��ʱ����֤ʧ��");
            errorCodes.Add("500", "�����ַ����");
            errorCodes.Add("501", "������ʽ����");
            errorCodes.Add("502", "�����ʵ��");
            errorCodes.Add("503", "����Ĵ�����ȷ");
            errorCodes.Add("504", "�����������ʵ��");
            errorCodes.Add("530", "��Ҫ��֤");
            errorCodes.Add("534", "��֤���ƹ��ڼ�");
            errorCodes.Add("538", "��ǰ�������֤������Ҫ����");
            errorCodes.Add("550", "��ǰ���ʼ�����δ���,���䲻����(�磺����δ�ҵ������䲻����)");
            errorCodes.Add("551", "�û��Ǳ���,�볢��<forward-path>");
            errorCodes.Add("552", "�����Ĵ洢����,�ƶ��Ĳ���δ���");
            errorCodes.Add("553", "������������,��:�����ַ�ĸ�ʽ����");
            errorCodes.Add("554", "����ʧ��");
            errorCodes.Add("535", "�û������֤ʧ��");
            //****************************************************************
            //����ִ�гɹ����״̬��
            //****************************************************************
            rightCodes.Add("220", "�������");
            rightCodes.Add("221", "����رմ���ͨ��");
            rightCodes.Add("235", "��֤�ɹ�");
            rightCodes.Add("250", "Ҫ����ʼ��������");
            rightCodes.Add("251", "�Ǳ����û�,��ת����<forward-path>");
            rightCodes.Add("334", "��������Ӧ��֤Base64�ַ���");
            rightCodes.Add("354", "��ʼ�ʼ�����,��<CRLF>.<CRLF>����");
            //��ȡϵͳ��Ӧ
            StreamReader reader = new StreamReader(ns);
            logs += reader.ReadLine() + CRLF;
        }
        /// <summary>
        /// ��SMTP��������
        /// </summary>
        /// <param name="cmd"></param>
        private string sendCommand(string cmd, bool isMailData)
        {
            if (cmd != null && cmd.Trim() != string.Empty)
            {
                byte[] cmd_b = null;
                if (!isMailData)//�����ʼ�����
                    cmd += CRLF;

                logs += cmd;
                //��ʼд���ʼ�����
                if (!isMailData)
                {
                    cmd_b = Encoding.ASCII.GetBytes(cmd);
                    ns.Write(cmd_b, 0, cmd_b.Length);
                }
                else
                {
                    cmd_b = Encoding.GetEncoding(this.mailEncodingName).GetBytes(cmd);
                    ns.BeginWrite(cmd_b, 0, cmd_b.Length, new AsyncCallback(this.asyncCallBack), null);
                }
                //��ȡ��������Ӧ
                StreamReader reader = new StreamReader(ns);
                string response = reader.ReadLine();
                logs += response + CRLF;
                //���״̬��
                string statusCode = response.Substring(0, 3);
                bool isExist = false;
                bool isRightCode = true;
                foreach (string err in this.errorCodes.Keys)
                {
                    if (statusCode == err)
                    {
                        isExist = true;
                        isRightCode = false;
                        break;
                    }
                }
                foreach (string right in this.rightCodes.Keys)
                {
                    if (statusCode == right)
                    {
                        isExist = true;
                        break;
                    }
                }
                //����״̬����������һ���Ķ���
                if (!isExist) //���ǺϷ���SMTP����
                {
                    this.setError("���ǺϷ���SMTP����,��������ܾ�����");
                }
                else if (!isRightCode)//����û�ܳɹ�ִ��
                {
                    this.setError(statusCode + ":" + this.errorCodes[statusCode]);
                }
                else //����ɹ�ִ��
                {
                    this.errorMessage = "";
                }
                return response;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// ͨ��auth login��ʽ��½smtp������
        /// </summary>
        private void landingByLogin()
        {
            string base64UserId = this.convertBase64String(this.UserID, "ASCII");
            string base64Pass = this.convertBase64String(this.Password, "ASCII");
            //����
            this.sendCommand("helo " + this.serverName, false);
            //��ʼ��½
            this.sendCommand("auth login", false);
            this.sendCommand(base64UserId, false);
            this.sendCommand(base64Pass, false);
        }
        /// <summary>
        /// ͨ��auth plain��ʽ��½������
        /// </summary>
        private void landingByPlain()
        {
            string NULL = ((char)0).ToString();
            string loginStr = NULL + this.UserID + NULL + this.Password;
            string base64LoginStr = this.convertBase64String(loginStr, "ASCII");
            //����
            this.sendCommand("helo " + this.serverName, false);
            //��½
            this.sendCommand(base64LoginStr, false);
        }
        /// <summary>
        /// �����ʼ�
        /// </summary>
        /// <returns></returns>
        public bool SendMail(MailMessage mail)
        {
            bool isSended = true;
            try
            {
                //��ⷢ���ʼ��ı�Ҫ����
                if (mail.Sender == null)
                {
                    this.setError("û�����÷�����");
                }
                if (mail.Receivers.Count == 0)
                {
                    this.setError("����Ҫ��һ���ռ���");
                }
                if (this.SmtpValidateType != SmtpValidateTypes.None)
                {
                    if (this.userid == null || this.password == null)
                    {
                        this.setError("��ǰ������Ҫsmtp��֤,����û�и�����½�ʺ�");
                    }
                }
                //��ʼ��½
                switch (this.SmtpValidateType)
                {
                    case SmtpValidateTypes.None:
                        this.sendCommand("helo " + this.serverName, false);
                        break;
                    case SmtpValidateTypes.Login:
                        this.landingByLogin();
                        break;
                    case SmtpValidateTypes.Plain:
                        this.landingByPlain();
                        break;
                    default:
                        break;
                }
                //��ʼ���ʼ��Ự(��ӦSMTP����mail)
                this.sendCommand("mail from:<" + mail.Sender + ">", false);
                //��ʶ�ռ���(��ӦSMTP����Rcpt)
                foreach (string receive in mail.Receivers)
                {
                    this.sendCommand("rcpt to:<" + receive + ">", false);
                }
                //��ʶ��ʼ�����ʼ�����(Data)
                this.sendCommand("data", false);
                //��ʼ��д�ʼ�����
                string message = "Subject:" + mail.Subject + CRLF;
                message += "X-mailer:" + mail.XMailer + CRLF;
                message += "MIME-Version:1.0" + CRLF;
                if (mail.Attachments.Count == 0)//û�и���
                {
                    if (mail.MailType == MailTypes.Text) //�ı���ʽ
                    {
                        message += "Content-Type:text/plain;" + CRLF + " ".PadRight(8, ' ') + "charset=\"" +
                         mail.MailEncoding.ToString() + "\"" + CRLF;
                        message += "Content-Transfer-Encoding:base64" + CRLF + CRLF;
                        if (mail.MailBody != null)
                            message += Convert.ToBase64String(mail.MailBody, 0, mail.MailBody.Length) + CRLF + CRLF + CRLF + "." + CRLF;
                    }
                    else//Html��ʽ
                    {
                        message += "Content-Type:multipart/alertnative;" + CRLF + " ".PadRight(8, ' ') + "boundary"
                         + "=\"=====003_Dragon310083331177_=====\"" + CRLF + CRLF + CRLF;
                        message += "This is a multi-part message in MIME format" + CRLF + CRLF;
                        message += "--=====003_Dragon310083331177_=====" + CRLF;
                        message += "Content-Type:text/html;" + CRLF + " ".PadRight(8, ' ') + "charset=\"" +
                         mail.MailEncoding.ToString().ToLower() + "\"" + CRLF;
                        message += "Content-Transfer-Encoding:base64" + CRLF + CRLF;
                        if (mail.MailBody != null)
                            message += Convert.ToBase64String(mail.MailBody, 0, mail.MailBody.Length) + CRLF + CRLF;
                        message += "--=====003_Dragon310083331177_=====--" + CRLF + CRLF + CRLF + "." + CRLF;
                    }
                }
                else//�и���
                {
                    //����Ҫ���ʼ�����ʾ��ÿ������������
                    StringCollection attatchmentDatas = new StringCollection();
                    foreach (string path in mail.Attachments)
                    {
                        if (!File.Exists(path))
                        {
                            this.setError("ָ���ĸ���û���ҵ�" + path);
                        }
                        else
                        {
                            //�õ��������ֽ���
                            FileInfo file = new FileInfo(path);
                            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                            if (fs.Length > (long)int.MaxValue)
                            {
                                this.setError("�����Ĵ�С�������������");
                            }
                            byte[] file_b = new byte[(int)fs.Length];
                            fs.Read(file_b, 0, file_b.Length);
                            fs.Close();
                            string attatchmentMailStr = "Content-Type:application/octet-stream;" + CRLF + " ".PadRight(8, ' ') + "name=" +
                             "\"" + file.Name + "\"" + CRLF;
                            attatchmentMailStr += "Content-Transfer-Encoding:base64" + CRLF;
                            attatchmentMailStr += "Content-Disposition:attachment;" + CRLF + " ".PadRight(8, ' ') + "filename=" +
                             "\"" + file.Name + "\"" + CRLF + CRLF;
                            attatchmentMailStr += Convert.ToBase64String(file_b, 0, file_b.Length) + CRLF + CRLF;
                            attatchmentDatas.Add(attatchmentMailStr);
                        }
                    }
                    //�����ʼ���Ϣ
                    if (mail.MailType == MailTypes.Text) //�ı���ʽ
                    {
                        message += "Content-Type:multipart/mixed;" + CRLF + " ".PadRight(8, ' ') + "boundary=\"=====001_Dragon320037612222_=====\""
                         + CRLF + CRLF;
                        message += "This is a multi-part message in MIME format." + CRLF + CRLF;
                        message += "--=====001_Dragon320037612222_=====" + CRLF;
                        message += "Content-Type:text/plain;" + CRLF + " ".PadRight(8, ' ') + "charset=\"" + mail.MailEncoding.ToString().ToLower() + "\"" + CRLF;
                        message += "Content-Transfer-Encoding:base64" + CRLF + CRLF;
                        if (mail.MailBody != null)
                            message += Convert.ToBase64String(mail.MailBody, 0, mail.MailBody.Length) + CRLF;
                        foreach (string s in attatchmentDatas)
                        {
                            message += "--=====001_Dragon320037612222_=====" + CRLF + s + CRLF + CRLF;
                        }
                        message += "--=====001_Dragon320037612222_=====--" + CRLF + CRLF + CRLF + "." + CRLF;
                    }
                    else
                    {
                        message += "Content-Type:multipart/mixed;" + CRLF + " ".PadRight(8, ' ') + "boundary=\"=====001_Dragon255511664284_=====\""
                         + CRLF + CRLF;
                        message += "This is a multi-part message in MIME format." + CRLF + CRLF;
                        message += "--=====001_Dragon255511664284_=====" + CRLF;
                        message += "Content-Type:text/html;" + CRLF + " ".PadRight(8, ' ') + "charset=\"" + mail.MailEncoding.ToString().ToLower() + "\"" + CRLF;
                        message += "Content-Transfer-Encoding:base64" + CRLF + CRLF;
                        if (mail.MailBody != null)
                            message += Convert.ToBase64String(mail.MailBody, 0, mail.MailBody.Length) + CRLF + CRLF;
                        for (int i = 0; i < attatchmentDatas.Count; i++)
                        {
                            message += "--=====001_Dragon255511664284_=====" + CRLF + attatchmentDatas[i] + CRLF + CRLF;
                        }
                        message += "--=====001_Dragon255511664284_=====--" + CRLF + CRLF + CRLF + "." + CRLF;
                    }
                }
                //�����ʼ�����
                this.mailEncodingName = mail.MailEncoding.ToString();
                this.sendCommand(message, true);
                if (this.sendIsComplete)
                    this.sendCommand("QUIT", false);
            }
            catch
            {
                isSended = false;
            }
            finally
            {
                this.disconnect();
                //�����־�ļ� 
                if (this.LogPath != null)
                {
                    FileStream fs = null;
                    if (File.Exists(this.LogPath))
                    {
                        fs = new FileStream(this.LogPath, FileMode.Append, FileAccess.Write);
                        this.logs = CRLF + CRLF + this.logs;
                    }
                    else
                        fs = new FileStream(this.LogPath, FileMode.Create, FileAccess.Write);
                    byte[] logPath_b = Encoding.GetEncoding("gb2312").GetBytes(this.logs);
                    fs.Write(logPath_b, 0, logPath_b.Length);
                    fs.Close();
                }
            }
            return isSended;
        }
        /// <summary>
        /// �첽д������
        /// </summary>
        /// <param name="result"></param>
        private void asyncCallBack(IAsyncResult result)
        {
            if (result.IsCompleted)
                this.sendIsComplete = true;
        }
        /// <summary>
        /// �ر�����
        /// </summary> 
        private void disconnect()
        {
            try
            {
                ns.Close();
                tc.Close();
            }
            catch
            {
                ;
            }
        }
        /// <summary>
        /// ���ó��ִ���ʱ�Ķ���
        /// </summary>
        /// <param name="errorStr"></param>
        private void setError(string errorStr)
        {
            this.errorMessage = errorStr;
            logs += this.errorMessage + CRLF + "���ʼ���������ֹ��" + CRLF;
            this.disconnect();
            throw new ApplicationException("");
        }
        /// <summary>
        ///���ַ���ת��Ϊbase64
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encodingName"></param>
        /// <returns></returns>
        private string convertBase64String(string str, string encodingName)
        {
            byte[] str_b = Encoding.GetEncoding(encodingName).GetBytes(str);
            return Convert.ToBase64String(str_b, 0, str_b.Length);
        }
        #endregion
    }
}
