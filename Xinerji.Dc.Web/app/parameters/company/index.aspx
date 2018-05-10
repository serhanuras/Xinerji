<%@ Page Title="" Language="C#" MasterPageFile="~/app/masterpages/dashboard.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Xinerji.Dc.Web.app.parameters.company.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="padding-top:70px; padding-bottom:80px; text-align:center; display:none;" id="loadingspinner">
                     
            <img src="/plugins/images/loading.gif" style="width:40px; height: auto; padding-bottom:15px;" />
                <br />İşleminiz yapılıyor, lütfen bekleyiniz...
        </div> 

     <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-info">
                            <div class="panel-wrapper collapse in" aria-expanded="true">
                                <div class="panel-body">
                                    <form action="#">
                                        <div class="form-body">
                                            <div class="row">
                                                <div class="col-md-9">
                                                    <div class="form-group">
                                                        <label class="control-label">Ara :</label>
                                                        <input type="text" id="firstName" class="form-control" placeholder="Firma Adı..." ng-model="Search"></div>
                                                </div>
                                                <!--/span-->
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <button type="button" class="btn btn-inverse" style="margin-top:28px;" ng-click="search()"> <i class="fa fa-search"></i> Ara</button> 
                                                     </div>
                                                </div>
                                                <!--/span-->
                                            </div>
                                            
                                            
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
    
    <!-- ============================================================== -->
        <!-- Demo table -->
        <!-- ============================================================== -->
        <div class="row" id="page01" style="display:block;">
            <div class="col-md-12">
                <div class="panel block5">
                    <div class="panel-heading">{{transactionName}} YÖNETİMİ</div>
                    <div class="table-responsive">
                        <table class="table table-hover manage-u-table">
                            <thead>
                                <tr>
                                    <th width="70" class="text-center">#</th>
                                    <th>AD</th>
                                    <th>EPOSTA</th>
                                    <th>TELEFON</th>
                                    <th width="200">YÖNETİM</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr ng-repeat="company in companyList" id="company_{{company.Id}}">
                                    <td class="text-center">1</td>
                                    <td>{{company.Name}}</td>
                                    <td>{{company.Email}}</td>
                                    <td>{{company.Phone}}</td>
                                          
                                    <td>
                                        <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="View(company);"><i class="ti-eye"></i></button>
                                        <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="DeleteConfirmation(company);"><i class="ti-trash"></i></button>
                                        <button type="button" class="btn btn-info btn-outline btn-circle btn-lg m-r-5" ng-click="EditView(company);"><i class="ti-pencil-alt"></i></button>
                                    </td>
                                </tr>
                                     
                            </tbody>
                        </table>
                    </div>
                </div>
                <button type="button" class="btn btn-info waves-effect waves-light m-t-10" style="float:right; margin-right:15px;" data-toggle="modal" data-target="#form-modal" class="model_img img-responsive" ng-click="clearForm()">Yeni Kayıt Ekle</button>
            </div>

            
        </div>


        <div id="form-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
            <div class="modal-dialog">
                
                <div class="modal-content" id="modal-form">
                     <div style="padding-top:70px; padding-bottom:80px; text-align:center; display:none;" id="modal-loading-spinner">    
                        <img src="/plugins/images/loading.gif" style="width:40px; height: auto; padding-bottom:15px;" />
                            <br />İşleminiz yapılıyor, lütfen bekleyiniz...
                    </div> 
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">{{transactionName}}  {{transactionType}}</h4> </div>
                    <div class="modal-body">
                         <form>
                               
                                <div class="form-group">
                                    <label for="companyName">Firma Adı</label>
                                    <input type="text" class="form-control" id="companyName" placeholder="Firma Adı Giriniz." ng-model="form.Name"> </div>
                                <div class="form-group">
                                    <label for="companyEmail">Eposta</label>
                                    <input type="text" class="form-control" id="companyEmail" placeholder="Eposta Giriniz." ng-model="form.Email"> </div>
                                <div class="form-group">
                                    <label for="companyAddress">Adres</label>
                                    <textarea class="form-control" id="companyAddress" placeholder="Adres Giriniz." rows="5" ng-model="form.Address"></textarea></div>
                                <div class="form-group">
                                    <label for="companyPhone">Telefon</label>
                                    <input type="text" placeholder="" id="companyPhone" data-mask="(999) 999-9999" class="form-control" ng-model="form.Phone"> <span class="font-13 text-muted">(999) 999-9999</span> </div>
                                        
                                <div class="form-group">
                                        <input type="hidden" id="companyLocation" ng-model="form.Location"> 
                                        <label for="companyAddress">Lokasyon</label>
                                        <input id="pac-input" class="controls" type="text" placeholder="Ara">
                                        <div id="map" style="height:400px;"></div>
                                        <script>
                                            // This example adds a search box to a map, using the Google Place Autocomplete
                                            // feature. People can enter geographical searches. The search box will return a
                                            // pick list containing a mix of places and predicted search terms.

                                            // This example requires the Places library. Include the libraries=places
                                            // parameter when you first load the API. For example:
                                            // <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&libraries=places">

                                            function initAutocomplete() {
                                            var map = new google.maps.Map(document.getElementById('map'), {
                                                center: {lat: 39.1667, lng: 35.6667},
                                                zoom: 6,
                                                mapTypeId: 'roadmap'
                                            });

                                            // Create the search box and link it to the UI element.
                                            var input = document.getElementById('pac-input');
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
		
		                                    var marker;
                                            function placeMarker(location) {
                                                document.getElementById('companyLocation').value = location;
			                                    if(marker==null)
			                                    {
				                                    marker = new google.maps.Marker({
					                                    position: location, 
					                                    map: map
				                                    });
			                                    }else{
				                                    marker.setPosition(location);
			                                    }
			
			                                    //markers.push(marker);
		                                    }
                                            }
	  
	  

                                        </script>
                                        <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCkkYej5EZRQaFw3s8ik_IZ-rLgVM0w9Xw&libraries=places&callback=initAutocomplete"
                                                async defer></script>
                                </div>
                            </form>
                         <div class="alert alert-danger" id="form-warning" style="display:none;" ng-bind-html="warningMsg">Hata Oluştu<br /> </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default waves-effect" data-dismiss="modal">Kapat</button>
                        <button type="button" class="btn btn-danger waves-effect waves-light"  ng-click="addFirm()">Kaydet</button>
                    </div>
                </div>
                <div class="modal-content" id="modal-form-succced" style="display:none;">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">{{transactionName}}  {{transactionType}}</h4> </div>
                    <div class="modal-body">
                        <div class="alert alert-success"> İşleminiz başarıyla gerçekleşmiştir. </div>
                    </div>
                     <div class="modal-footer">
                        <button type="button" class="btn btn-default waves-effect" data-dismiss="modal">Kapat</button>
                    </div>
               </div>
            </div>
        </div>


    <div id="form-delete" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
            <div class="modal-dialog">

                
                <div class="modal-content" id="modal-delete">
                     <div style="padding-top:70px; padding-bottom:80px; text-align:center; display:none;" id="delete-loading-spinner">    
                        <img src="/plugins/images/loading.gif" style="width:40px; height: auto; padding-bottom:15px;" />
                            <br />İşleminiz yapılıyor, lütfen bekleyiniz...
                    </div> 
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">{{transactionName}}  {{transactionType}}</h4> </div>
                    <div class="modal-body">
                       <h4> Altaki kayıt silinecektir, onaylıyor musunuz? </h4><br />
                        <div class="form-group">
                           <span class="font-size:16px;">
                                <label for="companyName">Firma Adı : </label>
                                {{form.Name}}
                            </span>
                        </div>
                                    
                        <div class="alert alert-danger" id="form-delete-warning" style="display:none;" ng-bind-html="warningMsg">Hata Oluştu<br /> </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default waves-effect" data-dismiss="modal">Kapat</button>
                        <button type="button" class="btn btn-danger waves-effect waves-light" ng-click="Delete();">Sil</button>
                    </div>
                </div>
                <div class="modal-content" id="modal-delete-succced" style="display:none;">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">{{transactionName}}  {{transactionType}}</h4> </div>
                    <div class="modal-body">
                        <div class="alert alert-success"> İşleminiz başarıyla gerçekleşmiştir. </div>
                    </div>
                     <div class="modal-footer">
                        <button type="button" class="btn btn-default waves-effect" data-dismiss="modal">Kapat</button>
                    </div>
               </div>
            </div>
        </div>
        <!-- /row -->

      <div id="form-view" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
            <div class="modal-dialog">
                
                <div class="modal-content" >
                    
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">{{transactionName}}  {{transactionType}}</h4> </div>
                    <div class="modal-body">
                       <div class="row">
                            <div class="form-group">
                                <label class="control-label col-md-3"><b>Firma Adı :</b></label>
                                <div class="col-md-9">
                                    <p class="form-control-static"> {{form.Name}}  </p>
                                </div>
                            </div>
                             <div class="form-group">
                                <label class="control-label col-md-3"><b>Eposta :</b></label>
                                <div class="col-md-9">
                                    <p class="form-control-static"> {{form.Email}}  </p>
                                </div>
                            </div>           
                            <div class="form-group">
                                <label class="control-label col-md-3"><b>Adres :</b></label>
                                <div class="col-md-9">
                                    <p class="form-control-static"> {{form.Address}}  </p>
                                </div>
                            </div> 
                            <div class="form-group">
                                 <label class="control-label col-md-3"><b>Telefon :</b></label>
                                <div class="col-md-9">
                                    <p class="form-control-static"> {{form.Phone}}  </p>
                                </div>
                            </div> 
                          </div>
                    </div>
                    
                </div>
                
            </div>
        </div>
</asp:Content>
