using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;

public partial class lib_ui_HeThong_Login : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        var ok = Security.Login(Username.Text, Pwd.Text, ckb.Checked.ToString());
        if(ok)
        {
            var ret = Request["ret"];
            Response.Redirect(string.IsNullOrEmpty(ret) ? "/KhachHang/" : Server.UrlDecode(ret));
        }
        else
        {
            msg.Visible = true;
        }
    }
}