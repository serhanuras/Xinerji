﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Interfaces;
using Xinerji.Dc.Services;


namespace Xinerji.Dc.Web.app.orders
{
    public partial class index : System.Web.UI.Page
    {
        public Configuration.BundleManager generalBundle;
        public Configuration.BundleManager pageBundle;
        public string trip_id = "";
        public string language = "";
        public Trip trip = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string app_pathKey = "orders";
            string pageBundleKey = "orders";

            Session session = ((masterpages.dashboard)this.Master).checkSession();
            ((masterpages.dashboard)this.Master).app_path = app_pathKey;
            generalBundle = new Configuration.BundleManager("general", session.Language);
            pageBundle = new Configuration.BundleManager(pageBundleKey, session.Language);
            language = session.Language.ToString();

            if (Request.QueryString["trip_id"] == null)
            {
                trip_id = "0";
            }
            else
            {
                trip_id = Request.QueryString["trip_id"].ToString();

                ITripService tripService = new TripServiceImp();

                trip = tripService.GetById(long.Parse(trip_id));
            }
        }
    }
}