using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HelloWebService.WebService1SoapClient client = new HelloWebService.WebService1SoapClient();
            Label1.Text = client.GetMessage(TextBox1.Text);

        }
    }
}