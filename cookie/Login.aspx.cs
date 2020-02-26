using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cookie
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Public pub = new Public();//实例化Public类，类中定义了读和写token.ini文件的方法
            User user = pub.ReadIni();//获取token.ini中的用户登录数据用于验证用户登录
            if (txtUserName.Text == user.UserName && txtPwd.Text == user.Password)//验证用户名和密码
            {
                string SevenToken = "";//定义生成Guid变量
                bool IsSeven = this.CheckBox1.Checked;//获取是否勾选了7天免登陆复选框
                if (IsSeven)//判断如果以勾选了复选框
                {
                    SevenToken = Guid.NewGuid().ToString();//生成Guid并赋值给SevenToken变量
                    pub.WriteIni(SevenToken);//将Guid（7天免登陆凭证）写入到token.ini中
                }
                WriteCookie(user.UserName, SevenToken);//将用户名和Guid（如果需要）写入到Cookie中
                Response.Redirect("Default.aspx");//跳转到首页
            }
            else
            {
                //提示用户失败信息并重新刷新页面
                Response.Write("<script>alert('登录失败！请检查用户名和密码是否错误');location.href='Login.aspx'</script>");
            }
        }
        //将用户名和Guid（7天免登陆凭证）写入Cookie
        private void WriteCookie(string userName, string sevenToken)
        {
            HttpCookie hc = new HttpCookie("LoginInfo");//创建以LoginInfo为名称的Cookie
            hc.Values["UserName"] = userName;//写入用户名
            if (sevenToken != "")//如果Guid存在(说明用户已经勾选了7天免登陆)
            {
                hc.Values["SevenToken"] = sevenToken;//写入Guid
                hc.Expires = DateTime.Now.AddDays(7);//有效期为7天
            }
            else//否则为普通登录
            {
                hc.Expires = DateTime.Now.AddSeconds(10);//有效期为10秒
            }
            Response.Cookies.Add(hc);//将设置好的Cookie对象添加到Http响应中
        }
    }
}