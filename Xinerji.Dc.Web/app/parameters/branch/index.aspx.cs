using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Interfaces;
using Xinerji.Dc.Services;

namespace Xinerji.Dc.Web.app.parameters.branch
{
    public partial class index : System.Web.UI.Page
    {
        public Configuration.BundleManager generalBundle;
        public Configuration.BundleManager pageBundle;

        public string language = "";
        public string companyId = "0";
        public Company company;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string app_pathKey = "parameters/branch";
                string pageBundleKey = "parameterBranch";

                Session session = ((masterpages.dashboard)this.Master).checkSession();
                ((masterpages.dashboard)this.Master).app_path = app_pathKey;
                generalBundle = new Configuration.BundleManager("general", session.Language);
                pageBundle = new Configuration.BundleManager(pageBundleKey, session.Language);
                language = session.Language.ToString();

                if (Request.QueryString["companyId"] == null)
                {
                    Response.Redirect("/app/company/index.aspx");
                }
                else
                {
                    ICompanyService companyService = new CompanyServiceImp();
                    companyId = Request.QueryString["companyId"];

                    company = companyService.GetById(long.Parse(Request.QueryString["companyId"].ToString()));
                }
            }
            catch
            {
                Response.Redirect("/app/company/index.aspx");
            }

        }
    }
}