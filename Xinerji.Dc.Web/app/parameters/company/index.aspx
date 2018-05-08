<%@ Page Title="" Language="C#" MasterPageFile="~/app/masterpages/dashboard.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Xinerji.Dc.Web.app.parameters.company.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="padding-top:70px; padding-bottom:80px; text-align:center; display:block;" id="loadingspinner">
                     
            <img src="/plugins/images/loading.gif" style="width:40px; height: auto; padding-bottom:15px;" />
                <br />İşleminiz yapılıyor, lütfen bekleyiniz...
        </div> 
    
    <!-- ============================================================== -->
        <!-- Demo table -->
        <!-- ============================================================== -->
        <div class="row" id="page01" style="display:none;">
            <div class="col-md-12">
                <div class="panel">
                    <div class="panel-heading">FİRMA YÖNETİMİ</div>
                    <div class="table-responsive">
                        <table class="table table-hover manage-u-table">
                            <thead>
                                <tr>
                                    <th width="70" class="text-center">#</th>
                                    <th>AD</th>
                                    <th>EPOSTA</th>
                                    <th>TELEFON</th>
                                    <th width="300">YÖNETİM</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr ng-repeat="company in companyList" id="company_{{company.Id}}">
                                    <td class="text-center">1</td>
                                    <td>{{company.Name}}</td>
                                    <td>{{company.Email}}</td>
                                    <td>{{company.Phone}}</td>
                                          
                                    <td>
                                        <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5"><i class="ti-trash"></i></button>
                                        <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5"><i class="ti-pencil-alt"></i></button>
                                    </td>
                                </tr>
                                     
                            </tbody>
                        </table>
                    </div>
                </div>
                <button type="button" class="btn btn-info waves-effect waves-light m-t-10" style="float:right; margin-right:15px;" onclick="window.location='#page02'">Yeni Kayıt Ekle</button>
            </div>

            
        </div>

          <div class="row" id="page02" style="display:none;">
              <div class="row">
                    <div class="col-md-12">
                        <div class="white-box">
                            <h3 class="box-title m-b-0">Sample Basic Forms</h3>
                            <p class="text-muted m-b-30 font-13"> Bootstrap Elements </p>
                            <div class="row">
                                <div class="col-sm-12 col-xs-12">
                                    <form>
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">User Name</label>
                                            <input type="text" class="form-control" id="exampleInputEmail1" placeholder="Enter Username"> </div>
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Email address</label>
                                            <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Enter email"> </div>
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">Password</label>
                                            <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password"> </div>
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">Password</label>
                                            <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Confirm Password"> </div>
                                        <div class="form-group">
                                            <div class="checkbox checkbox-success">
                                                <input id="checkbox1" type="checkbox">
                                                <label for="checkbox1"> Remember me </label>
                                            </div>
                                        </div>
                                        <button type="submit" class="btn btn-success waves-effect waves-light m-r-10">Submit</button>
                                        <button type="submit" class="btn btn-inverse waves-effect waves-light">Cancel</button>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                  </div>
         </div>
        <!-- /row -->
</asp:Content>
