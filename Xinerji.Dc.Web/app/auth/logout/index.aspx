<%@ Page Title="" Language="C#" MasterPageFile="~/app/masterpages/dashboard.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Xinerji.Dc.Web.app.auth.logout.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row">
         <div style="padding-top:70px; padding-bottom:80px; text-align:center; display:block;" id="loadingspinner">
                     
            <img src="/plugins/images/loading.gif" style="width:40px; height: auto; padding-bottom:15px;" />
                <br />İşleminiz yapılıyor, lütfen bekleyiniz...
        </div>
    </div>

     <div class="table-responsive" style="display:none;" id="teminateSessionPage01">
        <div style="text-align:center;padding-bottom:100px;padding-top:100px; font-size:18px; font-weight:500; ">Oturumunuz Başarıyla, kapanmıştır.</div>
    </div>
</asp:Content>
