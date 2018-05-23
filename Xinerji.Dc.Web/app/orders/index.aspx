<%@ Page Title="" Language="C#" MasterPageFile="~/app/masterpages/dashboard.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Xinerji.Dc.Web.app.orders.index" %>
<asp:Content ID="xinerjiContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   
    <!-- ============================================================== -->
    <!-- START OF BREADCRUMB -->
    <!-- ============================================================== -->
    <div class="row bg-title" >
        <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
            <h4 class="page-title">{{bundle.transactionName}} <%=generalBundle.GetValue("management") %></h4> </div>
        <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
            <ol class="breadcrumb">
                <li><a href="/app/dashboard/index.aspx"><%=generalBundle.GetValue("dashboard") %></a></li>
                <%if (trip != null)
                { %>
                <li><a href="/app/trips/index.aspx"><%=pageBundle.GetValue("mainTransactionName") %></a></li>
                <%} %>

                <li class="active">{{bundle.transactionName}}</li>
            </ol>
        </div>
    </div>
     <!-- ************************************************************** -->
    <!-- END OF BREADCRUMB -->
    <!-- ************************************************************** -->
    
    
    <!-- ============================================================== -->
    <!-- START OF PAGE LOADING -->
    <!-- ============================================================== -->
    <div style="padding-top:70px; padding-bottom:80px; text-align:center;" ng-show="totalPages < 0">           
        <img src="/plugins/images/loading.gif" style="width:40px; height: auto; padding-bottom:15px;" />
        <br /><%=generalBundle.GetValue("loading") %>
    </div>
    <!-- ************************************************************** -->
    <!-- END OF PAGE LOADING -->
    <!-- ************************************************************** -->
    
     <%if (trip == null)
        { %>
    <!-- ============================================================== -->
    <!-- START OF SEARCH -->
    <!-- ============================================================== -->
     <div class="row" ng-show="totalPages != -1">
        <div class="col-md-12">
            <div class="panel block5 panel-info">
                <div class="panel-wrapper collapse in" aria-expanded="true">
                    <div class="panel-body">
                        <div class="form-body">
                            <div class="row">
                                <div class="col-md-9">
                                    <div class="form-group">
                                        <label class="control-label"><%=generalBundle.GetValue("search") %> :</label>
                                        <input type="text" id="firstName" class="form-control" placeholder="<%=pageBundle.GetValue("searchCriteria") %>..." ng-model="Search"></div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <button type="button" class="btn btn-inverse" style="margin-top:28px;" ng-click="search()"> <i class="fa fa-search"></i> <%=generalBundle.GetValue("search") %></button> 
                                        </div>
                                </div>
                            </div>       
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ************************************************************** -->
    <!-- END OF SEARCH -->
    <!-- ************************************************************** -->
    <%} %>
    
    <%if (trip != null)
        { %>
    <!-- ============================================================== -->
    <!-- START OF TRIP HEADER -->
    <!-- ============================================================== -->
     <div class="row" ng-show="totalPages != -1">
        <div class="col-md-12">
            <div class="panel block5 panel-info" style="padding:7px;">
                <h3><%=pageBundle.GetValue("tripCode") %> :<%=trip.Name %></h3>
                <h5><%=trip.Truck %> - <%=trip.Company %></h5>
            </div>
        </div>
    </div>
    <!-- ************************************************************** -->
    <!-- END OF TRIP HEADER -->
    <!-- ************************************************************** -->
    <%} %>
    <!-- ============================================================== -->
    <!-- START OF TABLE LIST -->
    <!-- ============================================================== -->
    <div class="row" id="page01" ng-show="totalPages != -1">
        <button type="button" class="btn btn-info waves-effect waves-light" style="float:right; margin-right:15px; margin-bottom:15px;" data-toggle="modal" class="model_img img-responsive" ng-click="AddView()"><%=generalBundle.GetValue("addNewRecord") %></button>
        
        <button type="button" class="btn btn-info waves-effect waves-light" style="float:right; margin-right:15px; margin-bottom:15px;" data-toggle="modal"  class="model_img img-responsive" ng-click="BindOrderView()"><%=pageBundle.GetValue("bindOrder") %></button>

        <div class="col-md-12">
            <div class="panel block5">
                
                <div class="table-responsive">
                    <table class="table table-hover manage-u-table">
                        <thead>
                            <tr>
                                <th width="70" class="text-center">#</th>
                                <th  width="25%"><%=pageBundle.GetValue("companyCaption") %></th>
                                <th  width="25%"><%=pageBundle.GetValue("branchCaption") %></th>
                                <th width="25%"><%=pageBundle.GetValue("titleCaption") %></th>
                                <th width="20%"><%=pageBundle.GetValue("descriptionCaption") %></th>
                                <th><%=pageBundle.GetValue("manage") %></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr ng-repeat="order in orderList track by $index" id="order_{{order.Id}}">
                                <td class="text-center">{{$index+1}}</td>
                                <td>{{order.CompanyName}} </td> 
                                <td>{{order.BranchName}} </td>  
                                <td>{{order.Title}} </td>  
                                <td>{{order.Description}}</td>
                                <td>
                                    <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="View(order);"><i class="ti-eye"></i></button>
                                    <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="DeleteView(order);"><i class="ti-trash"></i></button>
                                    <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="EditView(order);"><i class="ti-pencil-alt"></i></button>
                                    <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="ProductView(order);"><i class="ti-dropbox-alt"></i></button>
                                </td>
                            </tr>   
                        </tbody>
                    </table>
                    <nav style="justify-content: center;width:100%; display: flex; margin-bottom:20px;margin-top:20px;" ng-show="totalPages != 1">
                      <ul class="pagination" style="margin:0;padding:0;display: inline-block;">
                        <li class="page-item" ng-show="selectedPage != 0"><a class="page-link" href="#" ng-click="prevPage()"><%=generalBundle.GetValue("previous") %></a></li>

                        <li class="page-item"  
                            ng-repeat="i in totalPageArray track by $index"  
                            ng-class="{active: $index===selectedPage}"
                            ng-click="setPage($index)">
                                <a class="page-link" href="#">{{$index+1}}</a>
                        </li>
                       
                        <li class="page-item" ng-show="selectedPage < totalPages-1"><a class="page-link" href="#" ng-click="nextPage()"><%=generalBundle.GetValue("next") %></a></li>
                      </ul>
                    </nav>
                </div>
            </div>
            
        </div>
    </div>
    <!-- ************************************************************** -->
    <!-- END OF LIST -->
    <!-- ************************************************************** -->

    <!-- ============================================================== -->
    <!-- START OF ADDING / EDIT -->
    <!-- ============================================================== -->
    <div id="form-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none; ">
        <div class="modal-dialog">
            <div class="modal-content" id="modal-form">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">{{bundle.transactionName}}  {{transactionType}}</h4> 
                </div>
                <div class="modal-body">

                    <div class="form-group">
                        <labe>{{form.CompanyName}} - <%=pageBundle.GetValue("branch") %></label>
                        <div class="input-group">
                            <input type="text" class="form-control" placeholder="<%=pageBundle.GetValue("js.warning.branch") %>" ng-model="form.BranchName" readonly="readonly" ng-click="BranchSelectionView();">    
                             <div class="input-group-addon" ng-click="BranchSelectionView();"><i class="ti-user"></i></div>
                         </div>
                    </div>
                    <div class="form-group">
                        <labe><%=pageBundle.GetValue("title") %></label>
                        <input type="text" class="form-control" placeholder="<%=pageBundle.GetValue("js.warning.title") %>" ng-model="form.Title">      
                    </div>
                    <div class="form-group">
                        <labe><%=pageBundle.GetValue("description") %></label>
                        <input type="text" class="form-control" placeholder="<%=pageBundle.GetValue("js.warning.description") %>" ng-model="form.Description">      
                    </div>
                   
                    
                    <div class="alert alert-danger" id="form-warning" style="display:none;" ng-bind-html="warningMsg"> <br /> </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default waves-effect" data-dismiss="modal"><%=generalBundle.GetValue("close") %></button>
                    <button type="button" class="btn btn-danger waves-effect waves-light"  ng-click="Save()"><%=generalBundle.GetValue("save") %></button>
                </div>
            </div>
            <div class="modal-content" id="modal-form-succced" style="display:none;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">{{bundle.transactionName}}  {{transactionType}}</h4> </div>
                <div class="modal-body">
                    <div class="alert alert-success"> <%=generalBundle.GetValue("succeed") %> </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default waves-effect" data-dismiss="modal"><%=generalBundle.GetValue("close") %></button>
                </div>
            </div>
            <div class="modal-content" id="modal-form-loading" style="display:none;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">{{bundle.transactionName}}  {{transactionType}}</h4> </div>
                <div class="modal-body">
                    <div style="padding-top:70px; padding-bottom:80px; text-align:center; display:block;" id="modal-loading-spinner">    
                        <img src="/plugins/images/loading.gif" style="width:40px; height: auto; padding-bottom:15px;" />
                            <br /><%=generalBundle.GetValue("loading") %>
                    </div> 
                </div>
            </div>
        </div>
    </div>
    <!-- ************************************************************** -->
    <!-- END OF ADDING / EDITING -->
    <!-- ************************************************************** -->

    <!-- ============================================================== -->
    <!-- START OF DELETING -->
    <!-- ============================================================== -->
    <div id="form-delete" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog"> 
            <div class="modal-content" id="modal-delete">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">{{bundle.transactionName}}  {{transactionType}}</h4> 
                </div>
                <div class="modal-body">
                    <h4><%=generalBundle.GetValue("deleteConfirmation") %> </h4><br />
                    <div class="form-group">
                        <span class="font-size:16px;">
                            <label for="companyName"><%=pageBundle.GetValue("title") %> / <%=pageBundle.GetValue("description") %> : </label>
                            {{form.Title}} <br /> {{form.Description}} 
                        </span>
                    </div>           
                    <div class="alert alert-danger" id="form-delete-warning" style="display:none;" ng-bind-html="warningMsg"><br /> </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default waves-effect" data-dismiss="modal"><%=generalBundle.GetValue("close") %></button>
                    <button type="button" class="btn btn-danger waves-effect waves-light" ng-click="Delete();"><%=generalBundle.GetValue("delete") %></button>
                </div>
            </div>
            <div class="modal-content" id="modal-delete-succced" style="display:none;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">{{bundle.transactionName}}  {{transactionType}}</h4> </div>
                <div class="modal-body">
                    <div class="alert alert-success"> <%=generalBundle.GetValue("succeed") %> </div>
                </div>
                    <div class="modal-footer">
                    <button type="button" class="btn btn-default waves-effect" data-dismiss="modal"><%=generalBundle.GetValue("close") %></button>
                </div>
            </div>
            <div class="modal-content" id="modal-delete-loading" style="display:none;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">{{bundle.transactionName}}  {{transactionType}}</h4> </div>
                <div class="modal-body">
                    <div style="padding-top:70px; padding-bottom:80px; text-align:center; display:block;">    
                        <img src="/plugins/images/loading.gif" style="width:40px; height: auto; padding-bottom:15px;" />
                            <br /><%=generalBundle.GetValue("loading") %>
                    </div> 
                </div>
            </div>
        </div>
    </div>
    <!-- ************************************************************** -->
    <!-- END OF DELETING -->
    <!-- ************************************************************** -->

    <!-- ============================================================== -->
    <!-- START OF VIEWING -->
    <!-- ============================================================== -->
     <div id="form-view" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content" >
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">{{bundle.transactionName}}  {{transactionType}}</h4> </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="form-group">
                            <label class="control-label col-md-3"><b><%=pageBundle.GetValue("branch") %> :</b></label>
                            <div class="col-md-9">
                                <p class="form-control-static">  {{form.BranchName}}  </p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3"><b><%=pageBundle.GetValue("title") %> :</b></label>
                            <div class="col-md-9">
                                <p class="form-control-static">  {{form.Title}}  </p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3"><b><%=pageBundle.GetValue("description") %> :</b></label>
                            <div class="col-md-9">
                                <p class="form-control-static">  {{form.Description}}  </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ************************************************************** -->
    <!-- END OF VIEWING -->
    <!-- ************************************************************** -->

     <!-- ============================================================== -->
    <!-- START OF BIND ORDER -->
    <!-- ============================================================== -->
    <div id="form-bindorder-selection" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog"> 
            <div class="modal-content" id="modal-bindorder-selection">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title"><%=pageBundle.GetValue("bindOrderSearchCaption") %></h4> 
                    </div>
                    <div class="modal-body">
                       <div class="form-group block7">
                            <div class="input-group"> 
                                <input type="text" id="example-input1-group2" name="example-input1-group2" class="form-control" placeholder="<%=pageBundle.GetValue("bindOrderSearch") %>"  ng-model="BindOrderSearch"> 
                                <span class="input-group-btn">
                                    <button type="button" class="btn waves-effect waves-light btn-info" ng-click="SearchBindOrder();"><i class="fa fa-search" ></i></button>
                                </span>
                            </div>
                        
                        </div>
                        <div class="alert alert-danger" id="form-bindorder-selection-warning" style="display:none;" ng-bind-html="warningMsg"><br /> </div>
                        <div class="panel block7 table-responsive" ng-show="visivel">
                            <table class="table table-hover manage-u-table">
                                <thead>
                                    <tr>
                                        <th width="25%"><%=pageBundle.GetValue("companyCaption") %></th>
                                        <th width="25%"><%=pageBundle.GetValue("branchCaption") %></th>
                                        <th width="25%"><%=pageBundle.GetValue("titleCaption") %></th>
                                        <th width="25"><%=pageBundle.GetValue("selectCaption") %></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr ng-repeat="bindorder in bindorderList">
                                        <td>{{bindorder.CompanyName}} </td> 
                                        <td>{{bindorder.BranchName}} </td>  
                                        <td>{{bindorder.Title}} </td>  
                                        <td>
                                            <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="SelectBindOrder(bindorder);"><i class="ti-pencil-alt"></i></button>
                                        </td>
                                    </tr>   
                                </tbody>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default waves-effect" data-dismiss="modal"><%=generalBundle.GetValue("close") %></button>
                        </div>
                </div>
                <div class="modal-content" id="modal-bindorder-selection-succced" style="display:none;">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">{{bundle.transactionName}}  {{transactionType}}</h4> </div>
                    <div class="modal-body">
                        <div class="alert alert-success"> <%=generalBundle.GetValue("succeed") %> </div>
                    </div>
                        <div class="modal-footer">
                        <button type="button" class="btn btn-default waves-effect" data-dismiss="modal"><%=generalBundle.GetValue("close") %></button>
                    </div>
                </div>
                <div class="modal-content" id="modal-bindorder-selection-loading" style="display:none;">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">{{bundle.transactionName}}  {{transactionType}}</h4> </div>
                    <div class="modal-body">
                        <div style="padding-top:70px; padding-bottom:80px; text-align:center; display:block;">    
                            <img src="/plugins/images/loading.gif" style="width:40px; height: auto; padding-bottom:15px;" />
                                <br /><%=generalBundle.GetValue("loading") %>
                        </div> 
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ************************************************************** -->
    <!-- END OF BIND ORDER -->
    <!-- ************************************************************** -->


    <!-- ============================================================== -->
    <!-- START OF BRANCH SELECTION -->
    <!-- ============================================================== -->
    <div id="form-branch-selection" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog"> 
            <div class="modal-content" id="modal-branch-selection">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title"><%=pageBundle.GetValue("branchSearchCaption") %></h4> 
                </div>
                <div class="modal-body">
                   <div class="form-group block7">
                        <div class="input-group"> 
                            <input type="text" id="example-input1-group2" name="example-input1-group2" class="form-control" placeholder="<%=pageBundle.GetValue("branchSearch") %>"  ng-model="BranchSearch"> 
                            <span class="input-group-btn">
                                <button type="button" class="btn waves-effect waves-light btn-info" ng-click="SearchBranch();"><i class="fa fa-search" ></i></button>
                            </span>
                        </div>
                        
                    </div>
                    <div class="alert alert-danger" id="form-branch-selection-warning" style="display:none;" ng-bind-html="warningMsg"><br /> </div>
                    <div class="panel block7 table-responsive" ng-show="visivel">
                        <table class="table table-hover manage-u-table">
                            <thead>
                                <tr>
                                    <th><%=pageBundle.GetValue("branchNameCaption") %></th>
                                    <th><%=pageBundle.GetValue("branchCompanyNameCaption") %></th>
                                    <th width="50"><%=pageBundle.GetValue("selectCaption") %></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr ng-repeat="branch in branchList" id="branch_{{branch.Id}}">
                                    <td>{{branch.Name}}</td>
                                    <td>{{branch.CompanyName}}</td> 
                                    <td>
                                        <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="SelectBranch(branch);"><i class="ti-pencil-alt"></i></button>
                                    </td>
                                </tr>   
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default waves-effect" data-dismiss="modal"><%=generalBundle.GetValue("close") %></button>
                    </div>
            </div>
            <div class="modal-content" id="modal-branch-selection-succced" style="display:none;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">{{bundle.transactionName}}  {{transactionType}}</h4> </div>
                <div class="modal-body">
                    <div class="alert alert-success"> <%=generalBundle.GetValue("succeed") %> </div>
                </div>
                    <div class="modal-footer">
                    <button type="button" class="btn btn-default waves-effect" data-dismiss="modal"><%=generalBundle.GetValue("close") %></button>
                </div>
            </div>
            <div class="modal-content" id="modal-branch-selection-loading" style="display:none;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">{{bundle.transactionName}}  {{transactionType}}</h4> </div>
                <div class="modal-body">
                    <div style="padding-top:70px; padding-bottom:80px; text-align:center; display:block;">    
                        <img src="/plugins/images/loading.gif" style="width:40px; height: auto; padding-bottom:15px;" />
                            <br /><%=generalBundle.GetValue("loading") %>
                    </div> 
                </div>
            </div>
        </div>
    </div>
    </div>
    <!-- ************************************************************** -->
    <!-- END OF BRANCH SELECTION -->
    <!-- ************************************************************** -->

   


    <!-- ============================================================== -->
    <!-- START OF JAVASCRIPT BUNDLES -->
    <!-- ============================================================== -->
    <div>       
        <span ng-model="bundle.add" ng-init="bundle.add='<%=generalBundle.GetValue("add") %>'" />
        <span ng-model="bundle.edit" ng-init="bundle.edit='<%=generalBundle.GetValue("edit") %>'" />
        <span ng-model="bundle.delete" ng-init="bundle.delete='<%=generalBundle.GetValue("delete") %>'" />
        <span ng-model="bundle.detail" ng-init="bundle.detail='<%=generalBundle.GetValue("detail") %>'" />
        <span ng-model="bundle.transactionName" ng-init="bundle.transactionName='<%=pageBundle.GetValue("transactionName") %>'" />
        <span ng-model="bundle.connectionError" ng-init="bundle.connectionError='<%=generalBundle.GetValue("connectionError") %>'" />
        <span ng-model="bundle.pleaseWait" ng-init="bundle.pleaseWait='<%=generalBundle.GetValue("pleaseWait") %>'" />
        <span ng-model="bundle.tripId" ng-init="bundle.tripId='<%=trip_id %>'" />

        <span ng-model="bundle.js.warning.branch" ng-init="bundle.js.warning.branch='<%=pageBundle.GetValue("js.warning.branch") %>'" />
        <span ng-model="bundle.js.warning.title" ng-init="bundle.js.warning.title='<%=pageBundle.GetValue("js.warning.title") %>'" />
        <span ng-model="bundle.js.warning.branchsearch" ng-init="bundle.js.warning.branchsearch='<%=pageBundle.GetValue("js.warning.branchsearch") %>'" />
        <span ng-model="bundle.js.warning.bindordersearch" ng-init="bundle.js.warning.bindordersearch='<%=pageBundle.GetValue("js.warning.bindordersearch") %>'" />
        

        <span ng-model="bundle.js.lang" ng-init="bundle.js.lang='<%=language %>'" />
    </div>
    <!-- ************************************************************** -->
    <!-- END OF JAVASCRIPT BUNDLES -->
    <!-- ************************************************************** -->

</asp:Content>