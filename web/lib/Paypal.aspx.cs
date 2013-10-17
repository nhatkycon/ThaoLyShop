using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lib_Paypal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (string key in Request.QueryString.AllKeys)
        {
            Response.Write(String.Format("{0} = {1}<br />", key, Request[key]));
        }
    }
}