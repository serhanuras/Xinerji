var mainapp = angular.module('mainApp', ['ngSanitize']);



mainapp.controller('sectionCtrl', ['$scope', 'utilities', '$http', '$templateCache', '$location',
    function ($scope, utilities, $http, $templateCache, $location) {

        $scope.totalPages = -1;
        $scope.totalPageArray = new Array(0);
        $scope.selectedPage = 0;
        $scope.TruckSearch = '';

        

        $scope.visivel = false;

        //Init function
        $scope.init = function () {           
            $scope.savingType = 1; /* 1-New record saving, 2-Existing record updating...*/

           

            $scope.form = {
                'Id': '',
                'FirmId': 0,
                'Name': '',
                'TruckId': 0,
                'Truck': '',
                'ConsigneeId': '',
                'CompanyId': 0
            };

            $scope.selectedTruck = {
                'Id': '',
                'MemberId': 0,
                'MemberName': '',
                'LicenceNo': '',
                'Capacity': 0,
                'Birthdate': '',
                'Model': '',
                'Year': 0,
                'TruckStatusId': 0,
                'Plaque': ''
            }

         
            refreshTable();
            
        }       

        $scope.setPage = function (i) {
            $scope.selectedPage = i;
            refreshTable();
        }

        $scope.nextPage = function () {
            if ($scope.selectedPage < $scope.totalPages - 1)
                $scope.selectedPage = $scope.selectedPage + 1;

            refreshTable();
        }

        $scope.prevPage = function () {
            if ($scope.selectedPage > 0)
                $scope.selectedPage = $scope.selectedPage - 1;

            refreshTable();
        }

        //Search function
        $scope.search = function () {
            $scope.selectedPage = 0;
            refreshTable();
        }

        
        //Show Add View Model function
        $scope.AddView = function () {
           
            $scope.savingType = 1;
            $('#form-warning').hide();

            $scope.form = {
                'Id': '',
                'FirmId': 0,
                'Name': '',
                'TruckId': 0,
                'Truck': '',
                'ConsigneeId': '',
                'CompanyId': 0
            };

            $scope.transactionType = $scope.bundle.add;

            $('#modal-form-succced').hide();
            $('#modal-form').show();
        }

        //EditView function
        $scope.EditView = function (form) {
            $scope.savingType = 2;

            $('#modal-form-succced').hide();
            $('#modal-form').show();
            $scope.form = form;
            $scope.transactionType = $scope.bundle.edit;
            $('#form-modal').modal('toggle');
            $('#form-warning').hide();
           
        }

        //DeleteView function
        $scope.DeleteView = function (form) {
            $('#modal-delete-succced').hide();
            $('#modal-delete').show();
            $scope.form = form;
            $scope.transactionType = $scope.bundle.delete;
            $('#form-delete').modal('toggle');
            $('#form-warning').hide();
        }


        //TruckSelectionView function
        $scope.TruckSelectionView = function () {
            $('#modal-truck-selection-succced').hide();
            $('#modal-truck-selection').show();
            $('#form-truck-selection').modal('toggle');
            $('#form-warning').hide();
            $('#form-truck-selection-warning').hide();
        }

        //Save function
        $scope.Save = function () {

            var tempJsonRequest = {
                'Trip': $scope.form
            };

            console.log(tempJsonRequest);

            $scope.warningMsg = '';
            if ($scope.form.TruckId == 0) {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.truck + '<br/>';
            }

            if ($scope.warningMsg.trim() == '') {
                $('#modal-form').hide();
                $("#modal-form-loading").show();

                if ($scope.savingType == 1) {
                    $scope.url = jsonServiceURL + "/trip/inserttrip";
                }
                else {
                    $scope.url = jsonServiceURL + "/trip/edittrip";
                }
                $scope.method = "POST";

                $http({
                    method: $scope.method, url: $scope.url, data: tempJsonRequest
                }).
                    then(function (response) {

                        if (response.data.Header.Error.ErrorCode == 0) {
                            refreshTable();

                            $('#modal-form-succced').show();
                            $('#modal-form').hide();
                            $('#modal-form-loading').hide();

                        } else {
                            $('#form-warning').show();
                            $('#modal-form').show();
                            $("#modal-form-loading").hide();

                            if ($scope.bundle.js.lang == 'TR')
                                $scope.warningMsg = response.data.Header.Error.ErrorDescriptionTR;
                            else
                                $scope.warningMsg = response.data.Header.Error.ErrorDescriptionENG;
                        }

                    }, function (response) {

                        $("#modal-form-loading").hide();
                        $('#form-warning').show();
                        $('#modal-form').show();

                        $scope.warningMsg = $scope.bundle.connectionError;

                    });

            }
            else {
                $('#form-warning').show();
            }
           
        }

        

        //Delete function
        $scope.Delete = function (form) {

            $("#modal-delete-loading").show();
            $('#modal-delete').hide();

            var tempJsonRequest = {
                'Id': $scope.form.Id
            };

            $scope.method = "POST";
            $scope.url = jsonServiceURL + "/trip/deletetrip";
            $http({
                method: $scope.method, url: $scope.url, data: tempJsonRequest
            }).
                then(function (response) {

                    if (response.data.Header.Error.ErrorCode == 0) {
                        refreshTable();

                        $('#modal-delete-succced').show();
                        $('#modal-delete').hide();
                        $("#modal-delete-loading").hide();



                    } else {
                        $('#form-delete-warning').show();
                        $('#modal-delete-succced').hide();
                        $('#modal-delete').show();
                        $("#modal-delete-loading").hide();

                        if ($scope.bundle.js.lang == 'TR')
                            $scope.warningMsg = response.data.Header.Error.ErrorDescriptionTR;
                        else
                            $scope.warningMsg = response.data.Header.Error.ErrorDescriptionENG;
                    }

                }, function (response) {
                    $('#form-delete-warning').show();
                    $('#modal-delete-succced').hide();
                    $('#modal-delete').show();
                    $("#modal-delete-loading").hide();
                    $scope.warningMsg = $scope.bundle.connectionError;
                });
        }

        //View function
        $scope.View = function (form) {
            $scope.form = form;
            $scope.transactionType = $scope.bundle.detail;
            
            $('#form-view').modal('toggle');
        }

        

        $scope.SearchTruck = function () {
            
            $('#form-truck-selection-warning').hide();

            $scope.warningMsg = '';
            if ($scope.TruckSearch.trim() == '') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.truckSearch + '<br/>';
            }

            $scope.url = '/parameter/gettrucklist';
            $scope.method = 'POST';

            console.log($scope.warningMsg);
            if ($scope.warningMsg.trim() == '') {
                $('div.block7').block({
                    message: '<h4><img src="/plugins/images/busy.gif" /> ' + $scope.bundle.pleaseWait + '</h4>',
                    overlayCSS: {
                        backgroundColor: '#02bec9'
                    },
                    css: {
                        border: '1px solid #fff'
                    }
                });

                var tempJsonRequest = {
                    'Search': $scope.TruckSearch
                };
                console.log(tempJsonRequest);


                $http({ method: $scope.method, url: $scope.url, data: tempJsonRequest }).
                    then(function (response) {
                        console.log(response.data);
                        $scope.visivel = true;
                        $scope.truckList = response.data.TruckList;

                        $('div.block7').unblock();
                    });
            }
            else {
                console.log('aloa');
                $('#form-truck-selection-warning').show();
            }
        }

        $scope.SelectTruck = function (truck) {
            console.log(truck);
            $scope.selectedTruck = truck;

            $scope.form.Truck = truck.MemberName;
            $scope.form.TruckId = truck.Id;

            $('#form-truck-selection').modal('toggle');
        }

        //RefreshTable function
        var refreshTable = function () {


            $('div.block5').block({
                message: '<h4><img src="/plugins/images/busy.gif" /> ' + $scope.bundle.pleaseWait + '</h4>',
                overlayCSS: {
                    backgroundColor: '#02bec9'
                },
                css: {
                    border: '1px solid #fff'
                }
            });

            $scope.url = '/trip/gettriplist';
            $scope.method = 'POST';

            var tempJsonRequest = {
                'Search': $scope.Search,
                'SelectedPage': $scope.selectedPage
            };

            $http({ method: $scope.method, url: $scope.url, data: tempJsonRequest }).
                then(function (response) {

                    $scope.tripList = response.data.TripList;

                    $scope.totalPages = response.data.PageSize;
                    $scope.totalPageArray = new Array($scope.totalPages);

                    $('div.block5').unblock();


                });
        }      


        


        $scope.formatDate = function (date) {
            return utilities.converJsonDate(date);
        }

        //DETAILVIEW
        $scope.DetailView = function (trip) {

            window.location = '/app/orders/index.aspx?trip_id=' + trip.Id;
        }
}]);

