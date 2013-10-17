using System;

public partial class lib_ajax_comment_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(Server.MapPath("~/"));
    }
}