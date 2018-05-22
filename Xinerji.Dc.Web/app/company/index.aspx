<%@ Page Title="" Language="C#" MasterPageFile="~/app/masterpages/dashboard.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Xinerji.Dc.Web.app.parameters.company.index" %>
<asp:Content ID="xinerjiContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- ============================================================== -->
    <!-- START OF BREADCRUMB -->
    <!-- ============================================================== -->
    <div class="row bg-title">
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
    <!-- START OF SEARCH -->
    <!-- ============================================================== -->
     <div class="row">
        <div class="col-md-12">
            <div class="panel block5 panel-info">
                <div class="panel-wrapper collapse in" aria-expanded="true">
                    <div class="panel-body">
                        <div class="form-body">
                            <div class="row">
                                <div class="col-md-9">
                                    <div class="form-group">
                                        <label class="control-label"><%=generalBundle.GetValue("search") %> :</label>
                                        <input type="text" id="firstName" class="form-control" placeholder="<%=pageBundle.GetValue("companyName") %>..." ng-model="Search"></div>
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
    <div class="row" id="page01" style="display:block;">
        <button type="button" class="btn btn-info waves-effect waves-light m-t-10" style="float:right; margin-right:15px; margin-bottom:15px;" data-toggle="modal" data-target="#form-modal" class="model_img img-responsive" ng-click="AddView()"><%=generalBundle.GetValue("addNewRecord") %></button>
        <div class="col-md-12">
            <div class="panel block5">
                <div class="panel-heading"></div>
                <div class="table-responsive">
                    <table class="table table-hover manage-u-table">
                        <thead>
                            <tr>
                                <th width="70" class="text-center">#</th>
                                <th><%=pageBundle.GetValue("companyNameCaption") %></th>
                                <th><%=pageBundle.GetValue("emailCaption") %></th>
                                <th><%=pageBundle.GetValue("phoneCaption") %></th>
                                <th width="250"><%=pageBundle.GetValue("manage") %></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr ng-repeat="company in companyList track by $index" id="company_{{company.Id}}">
                                <td class="text-center">{{$index+1}}</td>
                                <td>{{company.Name}}</td>
                                <td>{{company.Email}}</td>
                                <td>{{company.Phone}}</td>
                                          
                                <td>
                                    <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="View(company);"><i class="ti-eye"></i></button>
                                    <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="DeleteView(company);"><i class="ti-trash"></i></button>
                                    <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="EditView(company);"><i class="ti-pencil-alt"></i></button>
                                    <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="ViewBranches(company);"><i class="ti-angle-right"></i></button>
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
                                <label for="companyName"><%=pageBundle.GetValue("companyName") %></label>
                                <input type="text" class="form-control" id="companyName" placeholder="Firma Adı Giriniz." ng-model="form.Name"> </div>
                            <div class="form-group">
                                <label for="companyEmail"><%=pageBundle.GetValue("email") %></label>
                                <input type="text" class="form-control" id="companyEmail" placeholder="Eposta Giriniz." ng-model="form.Email"> </div>
                            <div class="form-group">
                                <label for="companyAddress"><%=pageBundle.GetValue("adress") %></label>
                                <textarea class="form-control" id="companyAddress" placeholder="Adres Giriniz." rows="5" ng-model="form.Address"></textarea></div>
                            <div class="form-group">
                                <label for="companyPhone"><%=pageBundle.GetValue("phone") %></label>
                                <input type="text" placeholder="" id="companyPhone" data-mask="(999) 999-9999" class="form-control" ng-model="form.Phone"> <span class="font-13 text-muted">(999) 999-9999</span> </div>
                                        
                            <div class="form-group">
                                    <input type="hidden" id="companyLocation" ng-model="form.Location"> 
                                    <label for="companyAddress"><%=pageBundle.GetValue("location") %></label>
                                    <input id="pac-input" class="controls" type="text" placeholder="<%=generalBundle.GetValue("search") %>">
                                    <div id="map" style="height:400px;"></div>
                                    <script>
                                        // This example adds a search box to a map, using the Google Place Autocomplete
                                        // feature. People can enter geographical searches. The search box will return a
                                        // pick list containing a mix of places and predicted search terms.

                                        // This example requires the Places library. Include the libraries=places
                                        // parameter when you first load the API. For example:
                                        // <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&libraries=places">


                                        var input = document.getElementById('pac-input');
                                        var map;
                                        function initAutocomplete() {
                                           map = new google.maps.Map(document.getElementById('map'), {
                                                center: {lat: 39.1667, lng: 35.6667},
                                                zoom: 6,
                                                mapTypeId: 'roadmap'
                                            });

                                            // Create the search box and link it to the UI element.
                                           
                                            var searchBox = new google.maps.places.SearchBox(input);
                                            map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

                                            // Bias the SearchBox results towards current map's viewport.
                                            map.addListener('bounds_changed', function() {
                                                searchBox.setBounds(map.getBounds());
                                            });

                                            var markers = [];
                                            // Listen for the event fired when the user selects a prediction and retrieve
                                            // more details for that place.
                                            searchBox.addListener('places_changed', function() {
                                                var places = searchBox.getPlaces();

                                                if (places.length == 0) {
                                                return;
                                                }

                                                // Clear out the old markers.
                                                markers.forEach(function(marker) {
                                                marker.setMap(null);
                                                });
                                                markers = [];

                                                // For each place, get the icon, name and location.
                                                var bounds = new google.maps.LatLngBounds();
                                                places.forEach(function(place) {
                                                if (!place.geometry) {
                                                    console.log("Returned place contains no geometry");
                                                    return;
                                                }
                                                var icon = {
                                                    url: place.icon,
                                                    size: new google.maps.Size(71, 71),
                                                    origin: new google.maps.Point(0, 0),
                                                    anchor: new google.maps.Point(17, 34),
                                                    scaledSize: new google.maps.Size(25, 25)
                                                };

                                                // Create a marker for each place.
                                                markers.push(new google.maps.Marker({
                                                    map: map,
                                                    icon: icon,
                                                    title: place.name,
                                                    position: place.geometry.location
                                                }));

                                                if (place.geometry.viewport) {
                                                    // Only geocodes have viewport.
                                                    bounds.union(place.geometry.viewport);
                                                } else {
                                                    bounds.extend(place.geometry.location);
                                                }
                                                });
                                                map.fitBounds(bounds);
                                            });
		
		                                    google.maps.event.addListener(map, 'click', function(event) {
		                                        placeMarker(event.latLng);
		                                    });
		
		                                   

                                            
                                        }
	  
                                        var marker;
                                        function placeMarker(location) {
                                            document.getElementById('companyLocation').value = location;
                                            if (marker == null) {
                                                marker = new google.maps.Marker({
                                                    position: location,
                                                    map: map
                                                });
                                            } else {
                                                marker.setPosition(location);
                                            }

                                            //markers.push(marker);
                                        }

                                        function placeDefaultMarker(location) {
                                            console.log(location);
                                            map.setZoom(15);
                                            map.setCenter(location);

                                            document.getElementById('companyLocation').value = location;
                                            if (marker == null) {
                                                marker = new google.maps.Marker({
                                                    position: location,
                                                    map: map
                                                });
                                            } else {
                                                marker.setPosition(location);
                                            }

                                            //markers.push(marker);
                                        }

                                    </script>
                                    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCkkYej5EZRQaFw3s8ik_IZ-rLgVM0w9Xw&libraries=places&callback=initAutocomplete"
                                            async defer></script>
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
                            <label for="companyName"><%=pageBundle.GetValue("companyName") %> : </label>
                            {{form.Name}}
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
                            <label class="control-label col-md-3"><b><%=pageBundle.GetValue("companyName") %> :</b></label>
                            <div class="col-md-9">
                                <p class="form-control-static"> {{form.Name}}  </p>
                            </div>
                        </div>
                            <div class="form-group">
                            <label class="control-label col-md-3"><b><%=pageBundle.GetValue("email") %> :</b></label>
                            <div class="col-md-9">
                                <p class="form-control-static"> {{form.Email}}  </p>
                            </div>
                        </div>           
                        <div class="form-group">
                            <label class="control-label col-md-3"><b><%=pageBundle.GetValue("adress") %> :</b></label>
                            <div class="col-md-9">
                                <p class="form-control-static"> {{form.Address}}  </p>
                            </div>
                        </div> 
                        <div class="form-group">
                                <label class="control-label col-md-3"><b><%=pageBundle.GetValue("phone") %> :</b></label>
                            <div class="col-md-9">
                                <p class="form-control-static"> {{form.Phone}}  </p>
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
    <!-- START OF JAVASCRIPT BUNDLES -->
    <!-- ============================================================== -->
    <div>
        <span ng-model="bundle.add" ng-init="bundle.add='<%=generalBundle.GetValue("add") %>'" />
        <span ng-model="bundle.edit" ng-init="bundle.edit='<%=generalBundle.GetValue("edit") %>'" />
        <span ng-model="bundle.delete" ng-init="bundle.delete='<%=generalBundle.GetValue("delete") %>'" />
        <span ng-model="bundle.transactionName" ng-init="bundle.transactionName='<%=pageBundle.GetValue("transactionName") %>'" />
        <span ng-model="bundle.connectionError" ng-init="bundle.connectionError='<%=generalBundle.GetValue("connectionError") %>'" />
        <span ng-model="bundle.pleaseWait" ng-init="bundle.pleaseWait='<%=generalBundle.GetValue("pleaseWait") %>'" />

        <span ng-model="bundle.js.warning.companyName" ng-init="bundle.js.warning.companyName='<%=pageBundle.GetValue("js.warning.companyName") %>'" />
        <span ng-model="bundle.js.warning.email" ng-init="bundle.js.warning.email='<%=pageBundle.GetValue("js.warning.email") %>'" />
        <span ng-model="bundle.js.warning.address" ng-init="bundle.js.warning.address='<%=pageBundle.GetValue("js.warning.address") %>'" />
        <span ng-model="bundle.js.warning.location" ng-init="bundle.js.warning.location='<%=pageBundle.GetValue("js.warning.location") %>'" />
        <span ng-model="bunlde.js.lang" ng-init="bundle.js.lang='<%=language %>'" />
    </div>
    <!-- ************************************************************** -->
    <!-- END OF JAVASCRIPT BUNDLES -->
    <!-- ************************************************************** -->

</asp:Content>
