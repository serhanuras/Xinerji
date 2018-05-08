using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Xinerji.Dc.Web.app.dashboard
{
    public partial class index : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ((masterpages.dashboard)this.Master).app_path = "dashboard";
            ((masterpages.dashboard)this.Master).main_menu = "Dashboard";
            ((masterpages.dashboard)this.Master).sub_menu = " ";
        }
    }
}