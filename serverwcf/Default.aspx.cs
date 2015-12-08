using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace serverwcf
{

    //http://www.sources.ru/asp.net/CaptchaImage.html
    //captcha

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
#if DEBUG
         return;
#endif
            Response.Redirect("http://lena.pw");
        }
    }
}