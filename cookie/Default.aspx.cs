using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cookie
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string UserName;//定义用户名变量，用于在页面上输出
            if (IsLoginOrSeven(out UserName))//调用用户是否登录或是否7天免登陆的验证方法
            {
                //绑定用户信息
                this.LoginStaus.InnerHtml = "欢迎您 " + UserName + " <a href='#'>我的信息</a>";
            }
            else
            {
                //返回到登录页
                Response.Redirect("Login.aspx");
            }
        }
        public bool IsLoginOrSeven(out string UserName)
        {
            UserName = "";//在方法返回前必须为输出参数赋值
            HttpCookie hc = Request.Cookies["LoginInfo"];//获取名称为LoginInfo的Cookie信息
            if (hc != null)//判断是否为空，如为空说明已过期
            {
                Public pub = new Public();//实例化Public类
                User user = pub.ReadIni();//获取用户登录信息
                UserName = hc.Values["UserName"];//获取Cookie中的用户名
                string SevenToken = hc.Values["SevenToken"];//获取Cookie中7天免登陆凭证
                if (SevenToken != null)//如果存在凭证信息
                {
                    //验证用户名和Guid口令                
                    if (UserName == user.UserName && SevenToken == user.SevenToken)
                    {
                        return true;//验证成功返回tru
                    }
                    else
                    {
                        return false;//否则返回false
                    }
                }
                if (UserName == user.UserName)//如果程序走到这里，说明是普通登录
                {
                    return true;//验证Cookie中的用户名与服务器用户名相同返回true
                }
            }
            return false;//表示上面的验证都为通过，统一返回false
        }
    }
}