<%@ Page Title="" Language="C#" MasterPageFile="~/app/masterpages/dashboard.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Xinerji.Dc.Web.app.orderdetail.index" %>
<asp:Content ID="xinerjiContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- ============================================================== -->
    <!-- START OF BREADCRUMB -->
    <!-- ============================================================== -->
    <div class="row bg-title">
        <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
            <h4 class="page-title">{{bundle.transactionName}} <%=generalBundle.GetValue("management") %> <br />  [ <%=pageBundle.GetValue("orderCode") %> : <%=order.Title %> ]</h4> </div>
        <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
            <ol class="breadcrumb">
                <li><a href="/app/dashboard/index.aspx"><%=generalBundle.GetValue("dashboard") %></a></li>
                <li><a href="/app/orders/index.aspx"><%=pageBundle.GetValue("mainTransactionName") %></a></li>
                <li class="active">{{bundle.transactionName}}</li>
            </ol>
        </div>
    </div>
     <!-- ************************************************************** -->
    <!-- END OF BREADCRUMB -->
    <!-- ************************************************************** -->
    
    <!-- ============================================================== -->
    <!-- START OF TABLE LIST -->
    <!-- ============================================================== -->
    <div class="row" id="page01" style="display:block;">
        <button type="button" class="btn btn-info waves-effect waves-light m-t-10" style="float:right; margin-right:15px; margin-bottom:15px;" data-toggle="modal" data-target="#form-modal" class="model_img img-responsive" ng-click="AddView()"><%=generalBundle.GetValue("addNewRecord") %></button>
        <div class="col-md-12">
            <div class="panel block5">
                
                <div class="table-responsive">
                    <table class="table table-hover manage-u-table">
                        <thead>
                            <tr>
                                <th width="70" class="text-center">#</th>
                                <th><%=pageBundle.GetValue("productNameCaption") %></th>
                                <th><%=pageBundle.GetValue("quantityCaption") %></th>
                                <th width="200"><%=pageBundle.GetValue("manage") %></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr ng-repeat="orderDetail in orderDetails track by $index" id="product_{{product.Id}}">
                                <td class="text-center">{{$index+1}}</td>
                                <td>{{orderDetail.ProductDescription}}</td>  
                                <td>{{orderDetail.Quantity}}</td>  
                                <td>
                                    <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="View(orderDetail);"><i class="ti-eye"></i></button>
                                    <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="DeleteView(orderDetail);"><i class="ti-trash"></i></button>
                                    <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="EditView(orderDetail);"><i class="ti-pencil-alt"></i></button>
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
    <div id="form-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content" id="modal-form">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">{{bundle.transactionName}}  {{transactionType}}</h4> 
                </div>
                <div class="modal-body">
                       <div class="form-group">
                        <labe><%=pageBundle.GetValue("productName") %></label>
                            <div class="input-group">
                                <input type="text" class="form-control" placeholder="<%=pageBundle.GetValue("js.warning.productName") %>" ng-model="form.ProductName" readonly="readonly" ng-click="ProductSelectionView();">    
                                 <div class="input-group-addon" ng-click="ProductSelectionView();"><i class="ti-user"></i></div>
                             </div>
                        </div>
                        <div class="form-group">
                            <labe><%=pageBundle.GetValue("quantity") %></label>
                            <input type="number" class="form-control" placeholder="<%=pageBundle.GetValue("js.warning.quantity") %>" ng-model="form.Quantity">      
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
                            <label for="companyName"><%=pageBundle.GetValue("productName") %> : </label>
                            {{form.ProductName}}
                        </span>
                    </div>    
                    <div class="form-group">
                        <span class="font-size:16px;">
                            <label for="companyName"><%=pageBundle.GetValue("quantity") %> : </label>
                            {{form.Quantity}}
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
    </div>
    <!-- ************************************************************** -->
    <!-- END OF ADDING / EDIT -->
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
                            <label class="control-label col-md-3"><b><%=pageBundle.GetValue("productName") %> :</b></label>
                            <div class="col-md-9">
                                <p class="form-control-static"> {{form.ProductName}}  </p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3"><b><%=pageBundle.GetValue("quantity") %> :</b></label>
                            <div class="col-md-9">
                                <p class="form-control-static"> {{form.Quantity}}  </p>
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
    <!-- START OF PRODUCT SELECTION -->
    <!-- ============================================================== -->
    <div id="form-product-selection" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog"> 
            <div class="modal-content" id="modal-product-selection">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title"><%=pageBundle.GetValue("productSearchCaption") %></h4> 
                </div>
                <div class="modal-body">
                   <div class="form-group block7">
                        <div class="input-group"> 
                            <input type="text" id="example-input1-group2" name="example-input1-group2" class="form-control" placeholder="<%=pageBundle.GetValue("productSearch") %>"  ng-model="ProductSearch"> 
                            <span class="input-group-btn">
                                <button type="button" class="btn waves-effect waves-light btn-info"><i class="fa fa-search" ng-click="SearchProduct();"></i></button>
                            </span>
                        </div>
                        
                    </div>
                    <div class="alert alert-danger" id="form-product-selection-warning" style="display:none;" ng-bind-html="warningMsg"><br /> </div>
                    <div class="panel block7 table-responsive" ng-show="visivel">
                        <table class="table table-hover manage-u-table">
                            <thead>
                                <tr>
                                    <th><%=pageBundle.GetValue("productNameCaption2") %></th>
                                    <th><%=pageBundle.GetValue("productBarcode") %></th>
                                    <th width="50"><%=pageBundle.GetValue("selectCaption") %></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr ng-repeat="product in productList" id="product_{{product.Id}}">
                                    <td>{{product.Name}}</td>
                                    <td>{{product.Barcode}}</td> 
                                    <td>
                                        <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="SelectProduct(product);"><i class="ti-pencil-alt"></i></button>
                                    </td>
                                </tr>   
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default waves-effect" data-dismiss="modal"><%=generalBundle.GetValue("close") %></button>
                    </div>
            </div>
            <div class="modal-content" id="modal-product-selection-succced" style="display:none;">
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
            <div class="modal-content" id="modal-product-selection-loading" style="display:none;">
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
    <!-- END OF PRODUCT SELECTION -->
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
        <span ng-model="bundle.orderId" ng-init="bundle.orderId='<%=orderId %>'" />

        <span ng-model="bundle.js.warning.productName" ng-init="bundle.js.warning.productName='<%=pageBundle.GetValue("js.warning.productName") %>'" />
        <span ng-model="bundle.js.warning.quantity" ng-init="bundle.js.warning.quantity='<%=pageBundle.GetValue("js.warning.quantity") %>'" />
        
        
        <span ng-model="bundle.js.lang" ng-init="bundle.js.lang='<%=language %>'" />
    </div>
    <!-- ************************************************************** -->
    <!-- END OF JAVASCRIPT BUNDLES -->
    <!-- ************************************************************** -->

</asp:Content>
