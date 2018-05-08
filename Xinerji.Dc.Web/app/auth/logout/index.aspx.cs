using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Xinerji.Dc.Web.app.auth.logout
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((masterpages.dashboard)this.Master).app_path = "auth/logout";
        }
    }
}