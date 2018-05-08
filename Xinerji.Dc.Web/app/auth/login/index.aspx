<%@ Page Title="" Language="C#" MasterPageFile="~/app/masterpages/login.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Xinerji.Dc.Web.app.auth.login.index" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <a href="javascript:void(0)" class="text-center db">
            <br/>
          <img src="/plugins/images/admin-text-dark.png" alt="Home" /></a>  



         <div style="padding-top:70px; padding-bottom:80px; text-align:center; display:block;" id="loadingspinner">
                     
            <img src="/plugins/images/loading.gif" style="width:40px; height: auto; padding-bottom:15px;" />
                <br />İşleminiz yapılıyor, lütfen bekleyiniz...
        </div>


        <div id="loginPage01" style="padding-top:20px; display:none;" >
             <div class="alert alert-danger" id="warning" style=" display:none;">{{login.errorMessage}}</div>

            <div class="form-group m-t-40">
              <div class="col-xs-12">
                <input class="form-control" type="text" required="" placeholder="Eposta Adresi" ng-model="login.email">
              </div>
            </div>
            <div class="form-group">
              <div class="col-xs-12">
                <input class="form-control" type="password" required="" placeholder="Şifre"  ng-model="login.password">
              </div>
            </div>
       
            <div class="form-group text-center m-t-20">
              <div class="col-xs-12">
                <button class="btn btn-info btn-lg btn-block text-uppercase waves-effect waves-light" type="button" ng-click="logon()">GİRİŞ</button>
              </div>
            </div>

        </div>
    
</asp:Content>
