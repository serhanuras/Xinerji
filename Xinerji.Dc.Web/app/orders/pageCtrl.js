var mainapp = angular.module('mainApp', ['ngSanitize']);



mainapp.controller('sectionCtrl', ['$scope', 'utilities', '$http', '$templateCache', '$location',
    function ($scope, utilities, $http, $templateCache, $location) {

        $scope.totalPages = -1;
        $scope.totalPageArray = new Array(0);
        $scope.selectedPage = 0;
        $scope.BranchSearch = '';

        

        $scope.visivel = false;

        //Init function
        $scope.init = function () {           
            $scope.savingType = 1; /* 1-New record saving, 2-Existing record updating...*/

            $scope.form = {
                'Id': '',
                'TripId': 0,
                'BranchName': '',
                'CompanyName':'',
                'Title': '',
                'Description': '',
                'CityId': 0,
                'BranchId': 0,
                'DeliveryStatusId': 0,
                'OrderTypeId': 0

            };

            $scope.selectedBranch = {
                'Id': '',
                'CompanyId': '',
                'Name': '',
                'Email': '',
                'Address': '',
                'Phone': '',
                'Location': '',
            }

            $scope.url = '/parameter/getdeliverystatuslist';
            $scope.method = 'POST';

            var tempJsonRequest = {
                'Search': ''
            };

            $http({ method: $scope.method, url: $scope.url, data: tempJsonRequest }).
                then(function (response) {
                    console.log(response.data);
                    $scope.DeliveryTypeList = response.data.DeliveryStatusList;
                    

                });

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
                'TripId': 0,
                'BranchName': '',
                'CompanyName': '',
                'Title': '',
                'Description': '',
                'CityId': 0,
                'BranchId': 0,
                'DeliveryStatusId': 0,
                'OrderTypeId': 0
            };

            $scope.transactionType = $scope.bundle.add;

            $('#modal-form-succced').hide();
            $('#modal-form').show();
            $('#form-modal').modal('toggle');
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


        //BranchSelectionView function
        $scope.BranchSelectionView = function () {
            $('#modal-branch-selection-succced').hide();
            $('#modal-branch-selection').show();
            $('#form-branch-selection').modal('toggle');
            $('#form-warning').hide();
            $('#form-branch-selection-warning').hide();
        }

        $scope.BindOrderView = function () {
            $('#modal-bindorder-selection-succced').hide();
            $('#modal-bindorder-selection').show();
            $('#form-bindorder-selection').modal('toggle');
            $('#form-warning').hide();
            $('#form-bindorder-selection-warning').hide();
        }

        //Save function
        $scope.Save = function () {

            $scope.form.TripId = $scope.bundle.tripId;
             
            var tempJsonRequest = {
                'Order': $scope.form
            };

            console.log(tempJsonRequest);

            $scope.warningMsg = '';
            if ($scope.form.BranchId == '0') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.branch + '<br/>';
            }
            if ($scope.form.Title.trim() == '') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.title + '<br/>';
            }
            if ($scope.form.Description.trim() == '') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.description + '<br/>';
            }
           

            if ($scope.warningMsg.trim() == '') {
                $('#modal-form').hide();
                $("#modal-form-loading").show();

                if ($scope.savingType == 1) {
                    $scope.url = jsonServiceURL + "/order/insertorder";
                }
                else {
                    $scope.url = jsonServiceURL + "/order/editorder";
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
            $scope.url = jsonServiceURL + "/order/deleteorder";
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

        

        $scope.SearchBranch = function () {
            
            $('#form-branch-selection-warning').hide();

            $scope.warningMsg = '';
            if ($scope.BranchSearch.trim() == '') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.branchsearch + '<br/>';
            }

            $scope.url = '/company/getbranchlist';
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
                    'Search': $scope.BranchSearch,
                    'SelectedPage': -1
                };
                console.log(tempJsonRequest);


                $http({ method: $scope.method, url: $scope.url, data: tempJsonRequest }).
                    then(function (response) {
                        console.log(response.data);
                        $scope.visivel = true;
                        $scope.branchList = response.data.BranchList;

                        $('div.block7').unblock();
                    });
            }
            else {
                console.log('aloa');
                $('#form-branch-selection-warning').show();
            }
        }

        $scope.SearchBindOrder = function () {

            $('#form-bindorder-selection-warning').hide();

            $scope.warningMsg = '';
            if ($scope.BindOrderSearch.trim() == '') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.bindordersearch + '<br/>';
            }

            $scope.url = '/order/gettriporderlist';
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
                    'Search': $scope.BindOrderSearch,
                    'SelectedPage': 0,
                    'TripId': 0
                };
                console.log(tempJsonRequest);


                $http({ method: $scope.method, url: $scope.url, data: tempJsonRequest }).
                    then(function (response) {
                        console.log(response.data);
                        $scope.visivel = true;
                        $scope.bindorderList = response.data.OrderList;

                        $('div.block7').unblock();
                    });
            }
            else {
                console.log('aloa');
                $('#form-branch-selection-warning').show();
            }

        }

        $scope.SelectBranch = function (branch) {
            $scope.selectedBranch = branch;

            $scope.form.CompanyName = branch.CompanyName;
            $scope.form.BranchName = branch.Name;
            $scope.form.BranchId = branch.Id;

            $('#form-branch-selection').modal('toggle');
        }

        $scope.SelectBindOrder = function (bindorder) {
            console.log(bindorder);

            $('#form-bindorder-selection').modal('toggle');

            $scope.url = '/order/bindordertotrip';
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
                    'OrderId': bindorder.Id,
                    'TripId': $scope.bundle.tripId
                };
                console.log(tempJsonRequest);


                $http({ method: $scope.method, url: $scope.url, data: tempJsonRequest }).
                    then(function (response) {
                        console.log(response.data);
                        $scope.visivel = true;

                        $('#form-bindorder-selection').modal('toggle');

                        $('div.block7').unblock();

                        refreshTable();
                    });
            }
            else {
                console.log('aloa');
                $('#form-branch-selection-warning').show();
            }
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

            if ($scope.bundle.tripId==0)
                $scope.url = '/order/getorderlist';
            else
                $scope.url = '/order/gettriporderlist';
            $scope.method = 'POST';

            var tempJsonRequest = {
                'Search': $scope.Search,
                'SelectedPage': $scope.selectedPage,
                'TripId': $scope.bundle.tripId
            };

            $http({ method: $scope.method, url: $scope.url, data: tempJsonRequest }).
                then(function (response) {

                    $scope.orderList = response.data.OrderList;

                    $scope.totalPages = response.data.PageSize;
                    $scope.totalPageArray = new Array($scope.totalPages);

                    $('div.block5').unblock();


                });
        }      


        $scope.ProductView = function (form) {

            window.location = '/app/orderdetail/index.aspx?orderId=' + form.Id;

        }

        $scope.ChangeDeliverStatus = function () {


            $scope.url = '/order/changedeliverstatus';
            $scope.method = 'POST';

            var tempJsonRequest = {
                'OrderId': $scope.form.Id,
                'DeliveryStatusId': $scope.form.DeliveryStatusId
            };
            console.log(tempJsonRequest);

            $scope.visivel = true;

            $http({ method: $scope.method, url: $scope.url, data: tempJsonRequest }).
                then(function (response) {
                    console.log(response.data);

                    $scope.visivel = false;

                    refreshTable();
            });
           
        }


        $scope.formatDate = function (date) {
            return utilities.converJsonDate(date);
        }

}]);

