using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace cookie
{
    public class Public
    {
        public Public()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public User ReadIni()
        {
            User user = null;
            using (FileStream fs = OpenIni(FileMode.Open))
            {
                byte[] bs = new byte[fs.Length];
                fs.Read(bs, 0, bs.Length);
                string str = Encoding.UTF8.GetString(bs);
                string[] RowsKeyValue = str.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                string RowKeyValue = RowsKeyValue[1];
                string[] UserName = RowKeyValue.Split('=');
                RowKeyValue = RowsKeyValue[2];
                string[] UserPwd = RowKeyValue.Split('=');
                RowKeyValue = RowsKeyValue[3];
                string[] SevenToken = RowKeyValue.Split('=');
                user = new User();
                user.UserName = UserName[1];
                user.Password = UserPwd[1];
                user.SevenToken = SevenToken[1];
            }
            return user;
        }
        public void WriteIni(string TokenStr)
        {
            User user = ReadIni();
            using (FileStream fs = OpenIni(FileMode.Append))
            {
                byte[] bs = Encoding.UTF8.GetBytes(TokenStr);
                fs.Write(bs, 0, bs.Length);
            }
        }
        public FileStream OpenIni(FileMode FM)
        {
            string FileUrl = HttpContext.Current.Server.MapPath("token/token.ini");
            return File.Open(FileUrl, FM);
        }
    }
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SevenToken { get; set; }
    }
}