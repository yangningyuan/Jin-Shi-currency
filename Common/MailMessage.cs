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
    /// 邮件内容
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
        /// 获取或设置发件人
        /// </summary>
        public string Sender
        {
            get { return this.sender; }
            set { this.sender = value; }
        }
        /// <summary>
        /// 获取收件人地址集合
        /// </summary>
        public StringCollection Receivers
        {
            get { return this.receivers; }
        }
        /// <summary>
        /// 获取或设置邮件主题
        /// </summary>
        public string Subject
        {
            get { return this.subject; }
            set { this.subject = value; }
        }
        /// <summary>
        /// 获取或设置邮件传送者
        /// </summary>
        public string XMailer
        {
            get { return this.xMailer; }
            set { this.xMailer = value; }
        }
        /// <summary>
        /// 获取附件列表
        /// </summary>
        public StringCollection Attachments
        {
            get { return this.attachments; }
        }
        /// <summary>
        /// 获取或设置邮件的编码方式
        /// </summary>
        public MailEncodings MailEncoding
        {
            get { return this.mailEncoding; }
            set { this.mailEncoding = value; }
        }
        /// <summary>
        /// 获取或设置邮件格式
        /// </summary>
        public MailTypes MailType
        {
            get { return this.mailType; }
            set { this.mailType = value; }
        }
        /// <summary>
        /// 获取或设置邮件正文
        /// </summary>
        public byte[] MailBody
        {
            get { return this.mailBody; }
            set { this.mailBody = value; }
        }
    }
    /// <summary>
    /// 邮件编码
    /// </summary>
    public enum MailEncodings
    {
        GB2312,
        ASCII,
        Unicode,
        UTF8
    }
    /// <summary>
    /// 邮件格式
    /// </summary>
    public enum MailTypes
    {
        Html,
        Text
    }
    /// <summary>
    /// smtp服务器的验证方式
    /// </summary>
    public enum SmtpValidateTypes
    {
        /// <summary>
        /// 不需要验证
        /// </summary>
        None,
        /// <summary>
        /// 通用的auth login验证
        /// </summary>
        Login,
        /// <summary>
        /// 通用的auth plain验证
        /// </summary>
        Plain
    }
    /// <summary>
    /// 邮件发送类
    /// </summary>
    public class KSN_Smtp
    {
        #region "member fields"
        /// <summary>
        /// 连接对象
        /// </summary>
        private TcpClient tc;
        /// <summary>
        /// 网络流
        /// </summary>
        private NetworkStream ns;
        /// <summary>
        /// 错误的代码字典
        /// </summary>
        private StringDictionary errorCodes = new StringDictionary();
        /// <summary>
        /// 操作执行成功后的响应代码字典
        /// </summary>
        private StringDictionary rightCodes = new StringDictionary();
        /// <summary>
        /// 执行过程中错误的消息
        /// </summary>
        private string errorMessage = "";
        /// <summary>
        /// 记录操作日志
        /// </summary>
        private string logs = "";
        /// <summary>
        /// 主机登陆的验证方式
        /// </summary>
        private StringCollection validateTypes = new StringCollection();
        /// <summary>
        /// 换行常数
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
        /// 获取最后一此程序执行中的错误消息
        /// </summary>
        public string ErrorMessage
        {
            get { return this.errorMessage; }
        }
        /// <summary>
        /// 获取或设置日志输出路径
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
        /// 获取或设置登陆smtp服务器的帐号
        /// </summary>
        public string UserID
        {
            get { return this.userid; }
            set { this.userid = value; }
        }
        /// <summary>
        /// 获取或设置登陆smtp服务器的密码
        /// </summary>
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
        /// <summary>
        /// 获取或设置要使用登陆Smtp服务器的验证方式
        /// </summary>
        public SmtpValidateTypes SmtpValidateType
        {
            get { return this.smtpValidateType; }
            set { this.smtpValidateType = value; }
        }
        #endregion
        #region "construct functions"
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="server">主机名</param>
        /// <param name="port">端口</param>
        public KSN_Smtp(string server, int port)
        {
            tc = new TcpClient(server, port);
            ns = tc.GetStream();
            this.serverName = server;
            this.initialFields();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ip">主机ip</param>
        /// <param name="port">端口</param>
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
        private void initialFields() //初始化连接
        {
            logs = "================" + DateTime.Now.ToLongDateString() + "    " + DateTime.Now.ToLongTimeString() + "===============" + CRLF;
            //*****************************************************************
            //错误的状态码
            //*****************************************************************
            errorCodes.Add("421", "服务未就绪,关闭传输通道");
            errorCodes.Add("432", "需要一个密码转换");
            errorCodes.Add("450", "要求的邮件操作未完成,邮箱不可用(如:邮箱忙)");
            errorCodes.Add("451", "放弃要求的操作,要求的操作未执行");
            errorCodes.Add("452", "系统存储不足,要求的操作未完成");
            errorCodes.Add("454", "临时的认证失败");
            errorCodes.Add("500", "邮箱地址错误");
            errorCodes.Add("501", "参数格式错误");
            errorCodes.Add("502", "命令不可实现");
            errorCodes.Add("503", "命令的次序不正确");
            errorCodes.Add("504", "命令参数不可实现");
            errorCodes.Add("530", "需要认证");
            errorCodes.Add("534", "认证机制过于简单");
            errorCodes.Add("538", "当前请求的认证机制需要加密");
            errorCodes.Add("550", "当前的邮件操作未完成,邮箱不可用(如：邮箱未找到或邮箱不能用)");
            errorCodes.Add("551", "用户非本地,请尝试<forward-path>");
            errorCodes.Add("552", "过量的存储分配,制定的操作未完成");
            errorCodes.Add("553", "邮箱名不可用,如:邮箱地址的格式错误");
            errorCodes.Add("554", "传送失败");
            errorCodes.Add("535", "用户身份验证失败");
            //****************************************************************
            //操作执行成功后的状态码
            //****************************************************************
            rightCodes.Add("220", "服务就绪");
            rightCodes.Add("221", "服务关闭传输通道");
            rightCodes.Add("235", "验证成功");
            rightCodes.Add("250", "要求的邮件操作完成");
            rightCodes.Add("251", "非本地用户,将转发向<forward-path>");
            rightCodes.Add("334", "服务器响应验证Base64字符串");
            rightCodes.Add("354", "开始邮件输入,以<CRLF>.<CRLF>结束");
            //读取系统回应
            StreamReader reader = new StreamReader(ns);
            logs += reader.ReadLine() + CRLF;
        }
        /// <summary>
        /// 向SMTP发送命令
        /// </summary>
        /// <param name="cmd"></param>
        private string sendCommand(string cmd, bool isMailData)
        {
            if (cmd != null && cmd.Trim() != string.Empty)
            {
                byte[] cmd_b = null;
                if (!isMailData)//不是邮件数据
                    cmd += CRLF;

                logs += cmd;
                //开始写入邮件数据
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
                //读取服务器响应
                StreamReader reader = new StreamReader(ns);
                string response = reader.ReadLine();
                logs += response + CRLF;
                //检查状态码
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
                //根据状态码来处理下一步的动作
                if (!isExist) //不是合法的SMTP主机
                {
                    this.setError("不是合法的SMTP主机,或服务器拒绝服务");
                }
                else if (!isRightCode)//命令没能成功执行
                {
                    this.setError(statusCode + ":" + this.errorCodes[statusCode]);
                }
                else //命令成功执行
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
        /// 通过auth login方式登陆smtp服务器
        /// </summary>
        private void landingByLogin()
        {
            string base64UserId = this.convertBase64String(this.UserID, "ASCII");
            string base64Pass = this.convertBase64String(this.Password, "ASCII");
            //握手
            this.sendCommand("helo " + this.serverName, false);
            //开始登陆
            this.sendCommand("auth login", false);
            this.sendCommand(base64UserId, false);
            this.sendCommand(base64Pass, false);
        }
        /// <summary>
        /// 通过auth plain方式登陆服务器
        /// </summary>
        private void landingByPlain()
        {
            string NULL = ((char)0).ToString();
            string loginStr = NULL + this.UserID + NULL + this.Password;
            string base64LoginStr = this.convertBase64String(loginStr, "ASCII");
            //握手
            this.sendCommand("helo " + this.serverName, false);
            //登陆
            this.sendCommand(base64LoginStr, false);
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <returns></returns>
        public bool SendMail(MailMessage mail)
        {
            bool isSended = true;
            try
            {
                //检测发送邮件的必要条件
                if (mail.Sender == null)
                {
                    this.setError("没有设置发信人");
                }
                if (mail.Receivers.Count == 0)
                {
                    this.setError("至少要有一个收件人");
                }
                if (this.SmtpValidateType != SmtpValidateTypes.None)
                {
                    if (this.userid == null || this.password == null)
                    {
                        this.setError("当前设置需要smtp验证,但是没有给出登陆帐号");
                    }
                }
                //开始登陆
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
                //初始化邮件会话(对应SMTP命令mail)
                this.sendCommand("mail from:<" + mail.Sender + ">", false);
                //标识收件人(对应SMTP命令Rcpt)
                foreach (string receive in mail.Receivers)
                {
                    this.sendCommand("rcpt to:<" + receive + ">", false);
                }
                //标识开始输入邮件内容(Data)
                this.sendCommand("data", false);
                //开始编写邮件内容
                string message = "Subject:" + mail.Subject + CRLF;
                message += "X-mailer:" + mail.XMailer + CRLF;
                message += "MIME-Version:1.0" + CRLF;
                if (mail.Attachments.Count == 0)//没有附件
                {
                    if (mail.MailType == MailTypes.Text) //文本格式
                    {
                        message += "Content-Type:text/plain;" + CRLF + " ".PadRight(8, ' ') + "charset=\"" +
                         mail.MailEncoding.ToString() + "\"" + CRLF;
                        message += "Content-Transfer-Encoding:base64" + CRLF + CRLF;
                        if (mail.MailBody != null)
                            message += Convert.ToBase64String(mail.MailBody, 0, mail.MailBody.Length) + CRLF + CRLF + CRLF + "." + CRLF;
                    }
                    else//Html格式
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
                else//有附件
                {
                    //处理要在邮件中显示的每个附件的数据
                    StringCollection attatchmentDatas = new StringCollection();
                    foreach (string path in mail.Attachments)
                    {
                        if (!File.Exists(path))
                        {
                            this.setError("指定的附件没有找到" + path);
                        }
                        else
                        {
                            //得到附件的字节流
                            FileInfo file = new FileInfo(path);
                            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                            if (fs.Length > (long)int.MaxValue)
                            {
                                this.setError("附件的大小超出了最大限制");
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
                    //设置邮件信息
                    if (mail.MailType == MailTypes.Text) //文本格式
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
                //发送邮件数据
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
                //输出日志文件 
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
        /// 异步写入数据
        /// </summary>
        /// <param name="result"></param>
        private void asyncCallBack(IAsyncResult result)
        {
            if (result.IsCompleted)
                this.sendIsComplete = true;
        }
        /// <summary>
        /// 关闭连接
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
        /// 设置出现错误时的动作
        /// </summary>
        /// <param name="errorStr"></param>
        private void setError(string errorStr)
        {
            this.errorMessage = errorStr;
            logs += this.errorMessage + CRLF + "【邮件处理动作中止】" + CRLF;
            this.disconnect();
            throw new ApplicationException("");
        }
        /// <summary>
        ///将字符串转换为base64
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
