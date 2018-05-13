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

namespace Xinerji.Dc.Web.app.masterpages
{
    public partial class dashboard : System.Web.UI.MasterPage
    {
        public Configuration.BundleManager generalBundle;
        public Configuration.BundleManager pageBundle;


        public string app_path = "";
        public string main_menu = "";
        public string sub_menu = "";

        public string memberName = "";
        public string memberEmail = "";

        public string otherLanguage = "";

        private LanguageEnum language;

        Member member;

        ISessionService sessionService;
        IMemberService memberService;

        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();

            generalBundle = new Configuration.BundleManager("general", language);
            pageBundle = new Configuration.BundleManager("masterPage", language);

            memberName = member.Name + " " + member.MiddleName + " " + member.Surname;

            memberEmail = member.Email;

            if(language == LanguageEnum.TR)
            {
                otherLanguage = "English";
            }
            else
            {
                otherLanguage = "Türkçe";
            }
        }


        public Session checkSession()
        {
            Session session = null; 
            try
            {

                string sessionId = Request.Cookies["XinerjiToken"] != null ? Request.Cookies["XinerjiToken"].Value : "";

                sessionService = new SessionServiceImp();
                memberService = new MemberServiceImp();

                session  = sessionService.FindSession(sessionId, ChannelCodeEnum.Internet);

                if (session != null)
                {
                    member = memberService.GetById(session.MemberId);
                    language = session.Language;
                }
                else
                {
                    Response.Redirect("/app/auth/login.aspx?err=session_not_found");
                }
            }
            catch (SessionNotFoundException ex)
            {
                Response.Redirect("/app/auth/login/index.aspx?ex=" + ex.Message);
            }
            return session;
        }

        
    }
}