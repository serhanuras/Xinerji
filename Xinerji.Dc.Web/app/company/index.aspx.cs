using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;
using Xinerji.Dc.Model.Interfaces;
using Xinerji.Dc.Services;
using Xinerji.Exceptions;

namespace Xinerji.Dc.Web.app.parameters.company
{
    public partial class index : System.Web.UI.Page
    {
        public Configuration.BundleManager generalBundle;
        public Configuration.BundleManager pageBundle;
        public string language = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string app_pathKey = "company";
            string pageBundleKey = "company";

            Session session = ((masterpages.dashboard)this.Master).checkSession(); 
            ((masterpages.dashboard)this.Master).app_path = app_pathKey;
            generalBundle = new Configuration.BundleManager("general", session.Language);
            pageBundle = new Configuration.BundleManager(pageBundleKey, session.Language);
            language = session.Language.ToString();

        }
    }
}