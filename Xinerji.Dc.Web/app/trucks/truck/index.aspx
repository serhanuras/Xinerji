<%@ Page Title="" Language="C#" MasterPageFile="~/app/masterpages/dashboard.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Xinerji.Dc.Web.app.parameters.truck.index" %>
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
    
    <!-- ============================================================== -->
    <!-- START OF TABLE LIST -->
    <!-- ============================================================== -->
    <div class="row" id="page01" ng-show="totalPages != -1">
        <button type="button" class="btn btn-info waves-effect waves-light" style="float:right; margin-right:15px; margin-bottom:15px;" data-toggle="modal" data-target="#form-modal" class="model_img img-responsive" ng-click="AddView()"><%=generalBundle.GetValue("addNewRecord") %></button>
        <div class="col-md-12">
            <div class="panel block5">
                
                <div class="table-responsive">
                    <table class="table table-hover manage-u-table">
                        <thead>
                            <tr>
                                <th width="70" class="text-center">#</th>
                                <th><%=pageBundle.GetValue("searchCriteria") %></th>
                                <th><%=pageBundle.GetValue("driverCaption") %></th>
                                <th width="200"><%=pageBundle.GetValue("manage") %></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr ng-repeat="truck in truckList track by $index" id="truck_{{truck.Id}}">
                                <td class="text-center">{{$index+1}}</td>
                                <td>{{truck.Plaque}} </td>  
                                <td>{{truck.MemberName}}</td>
                                <td>
                                    <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="View(truck);"><i class="ti-eye"></i></button>
                                    <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="DeleteView(truck);"><i class="ti-trash"></i></button>
                                    <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="EditView(truck);"><i class="ti-pencil-alt"></i></button>
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
                            <labe><%=pageBundle.GetValue("truckstatus") %></label>
                            <select placeholder="<%=pageBundle.GetValue("js.warning.truckstatus") %>" ng-model="form.TruckStatusId" required ng-options="option.Id as option.Name for option in truckStatusList" class="form-control">

                            </select>
                    </div>
                    <div class="form-group">
                        <labe><%=pageBundle.GetValue("driver") %></label>
                        <div class="input-group">
                            <input type="text" class="form-control" placeholder="<%=pageBundle.GetValue("js.warning.driver") %>" ng-model="form.MemberName" readonly="readonly" ng-click="MemberSelectionView();">    
                             <div class="input-group-addon" ng-click="MemberSelectionView();"><i class="ti-user"></i></div>
                         </div>
                    </div>
                    <div class="form-group">
                        <labe><%=pageBundle.GetValue("plaque") %></label>
                        <input type="text" class="form-control" placeholder="<%=pageBundle.GetValue("js.warning.plaque") %>" ng-model="form.Plaque">      
                    </div>
                    <div class="form-group">
                        <labe><%=pageBundle.GetValue("licenceNo") %></label>
                        <input type="text" class="form-control" placeholder="<%=pageBundle.GetValue("js.warning.licenceNo") %>" ng-model="form.LicenceNo">      
                    </div>
                    <div class="form-group">
                        <labe><%=pageBundle.GetValue("capacity") %></label>
                        <input type="number" class="form-control" placeholder="<%=pageBundle.GetValue("js.warning.capacity") %>" ng-model="form.Capacity">      
                    </div>
                    <div class="form-group">
                        <labe><%=pageBundle.GetValue("model") %></label>
                        <input type="text" class="form-control" placeholder="<%=pageBundle.GetValue("js.warning.model") %>" ng-model="form.Model">      
                    </div>
                    <div class="form-group">
                        <labe><%=pageBundle.GetValue("year") %></label>
                        <input type="number" class="form-control" placeholder="<%=pageBundle.GetValue("js.warning.year") %>" ng-model="form.Year">      
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
                            <label for="companyName"><%=pageBundle.GetValue("driver") %> / <%=pageBundle.GetValue("plaque") %> : </label>
                            {{form.MemberName}} / {{form.Plaque}} 
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
                            <label class="control-label col-md-3"><b><%=pageBundle.GetValue("driver") %> :</b></label>
                            <div class="col-md-9">
                                <p class="form-control-static">  {{form.MemberName}}  </p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3"><b><%=pageBundle.GetValue("plaque") %> :</b></label>
                            <div class="col-md-9">
                                <p class="form-control-static">  {{form.Plaque}}  </p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3"><b><%=pageBundle.GetValue("licenceNo") %> :</b></label>
                            <div class="col-md-9">
                                <p class="form-control-static">  {{form.LicenceNo}}  </p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3"><b><%=pageBundle.GetValue("capacity") %> :</b></label>
                            <div class="col-md-9">
                                <p class="form-control-static">  {{form.Capacity}}  </p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3"><b><%=pageBundle.GetValue("model") %> :</b></label>
                            <div class="col-md-9">
                                <p class="form-control-static">  {{form.Model}}  </p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3"><b><%=pageBundle.GetValue("year") %> :</b></label>
                            <div class="col-md-9">
                                <p class="form-control-static">  {{form.Year}}  </p>
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
    <!-- START OF MEMBER SELECTION -->
    <!-- ============================================================== -->
    <div id="form-member-selection" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog"> 
            <div class="modal-content" id="modal-member-selection">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title"><%=pageBundle.GetValue("driverSearchCaption") %></h4> 
                </div>
                <div class="modal-body">
                   <div class="form-group block7">
                        <div class="input-group"> 
                            <input type="text" id="example-input1-group2" name="example-input1-group2" class="form-control" placeholder="<%=pageBundle.GetValue("driverSearch") %>"  ng-model="MemberSearch"> 
                            <span class="input-group-btn">
                                <button type="button" class="btn waves-effect waves-light btn-info"><i class="fa fa-search" ng-click="SearchMember();"></i></button>
                            </span>
                        </div>
                        
                    </div>
                    <div class="alert alert-danger" id="form-member-selection-warning" style="display:none;" ng-bind-html="warningMsg"><br /> </div>
                    <div class="panel block7 table-responsive" ng-show="visivel">
                        <table class="table table-hover manage-u-table">
                            <thead>
                                <tr>
                                    <th><%=pageBundle.GetValue("tcCaption") %></th>
                                    <th><%=pageBundle.GetValue("nameCaption") %></th>
                                    <th width="50"><%=pageBundle.GetValue("selectCaption") %></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr ng-repeat="member in memberList" id="memberType_{{branch.Id}}">
                                    <td>{{member.TCIdentifier}}</td>
                                    <td>{{member.Name}} {{member.MiddleName}} {{member.Surname}}</td>  
                                    <td>
                                        <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="SelectMember(member);"><i class="ti-pencil-alt"></i></button>
                                    </td>
                                </tr>   
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default waves-effect" data-dismiss="modal"><%=generalBundle.GetValue("close") %></button>
                    </div>
            </div>
            <div class="modal-content" id="modal-member-selection-succced" style="display:none;">
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
            <div class="modal-content" id="modal-member-selection-loading" style="display:none;">
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
    <!-- END OF MEMBER SELECTION -->
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

        <span ng-model="bundle.js.warning.driver" ng-init="bundle.js.warning.driver='<%=pageBundle.GetValue("js.warning.driver") %>'" />
        <span ng-model="bundle.js.warning.truckstatus" ng-init="bundle.js.warning.truckstatus='<%=pageBundle.GetValue("js.warning.truckstatus") %>'" />
        <span ng-model="bundle.js.warning.plaque" ng-init="bundle.js.warning.plaque='<%=pageBundle.GetValue("js.warning.plaque") %>'" />
        <span ng-model="bundle.js.warning.licenceNo" ng-init="bundle.js.warning.licenceNo='<%=pageBundle.GetValue("js.warning.licenceNo") %>'" />
        <span ng-model="bundle.js.warning.capacity" ng-init="bundle.js.warning.capacity='<%=pageBundle.GetValue("js.warning.capacity") %>'" />
        <span ng-model="bundle.js.warning.model" ng-init="bundle.js.warning.model='<%=pageBundle.GetValue("js.warning.model") %>'" />
        <span ng-model="bundle.js.warning.year" ng-init="bundle.js.warning.year='<%=pageBundle.GetValue("js.warning.year") %>'" />
        <span ng-model="bundle.js.warning.membersearch" ng-init="bundle.js.warning.membersearch='<%=pageBundle.GetValue("js.warning.membersearch") %>'" />
        

        <span ng-model="bundle.js.lang" ng-init="bundle.js.lang='<%=language %>'" />
    </div>
    <!-- ************************************************************** -->
    <!-- END OF JAVASCRIPT BUNDLES -->
    <!-- ************************************************************** -->

</asp:Content>