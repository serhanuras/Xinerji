using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Interfaces;
using Xinerji.Dc.Services;

namespace Xinerji.Dc.Web.app.orderdetail
{
    public partial class index : System.Web.UI.Page
    {
        public Configuration.BundleManager generalBundle;
        public Configuration.BundleManager pageBundle;
        public string language = "";
        public string orderId = "0";
        public Order order;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string app_pathKey = "orderdetail";
                string pageBundleKey = "orderdetail";

                Session session = ((masterpages.dashboard)this.Master).checkSession();
                ((masterpages.dashboard)this.Master).app_path = app_pathKey;
                generalBundle = new Configuration.BundleManager("general", session.Language);
                pageBundle = new Configuration.BundleManager(pageBundleKey, session.Language);
                language = session.Language.ToString();

                if (Request.QueryString["orderId"] == null)
                {
                    Response.Redirect("/app/order/index.aspx");
                }
                else
                {
                    IOrderService orderService = new OrderServiceImp();
                    orderId = Request.QueryString["orderId"];

                    order = orderService.GetById(long.Parse(Request.QueryString["orderId"].ToString()));
                }
            }
            catch
            {
                Response.Redirect("/app/order/index.aspx");
            }

        }
    }
}