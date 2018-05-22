var mainapp = angular.module('mainApp', ['ngSanitize']);



mainapp.controller('sectionCtrl', ['$scope', 'utilities', '$http', '$templateCache', '$location',
    function ($scope, utilities, $http, $templateCache, $location) {

        $scope.totalPages = 0;
        $scope.totalPageArray = new Array(0);
        $scope.selectedPage = 0;
        
        //Init function
        $scope.init = function () {           
            $scope.savingType = 1; /* 1-New record saving, 2-Existing record updating...*/

            $scope.form = {
                'Id': '',
                'OrderId': 0,
                'ProductId': 0,
                'ProductName':'',
                'Quantity': 0
            };

            $scope.selectedProduct = {
                'Id': '',
                'Name': '',
                'Barcode': '',
                'Weight': 0,
                'Height': 0,
                'Width': 0,
                'Volume': 0
            }

            refreshTable();

            console.log($scope.form);
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

            $scope.form = {
                'Id': '',
                'OrderId': 0,
                'ProductId': 0,
                'ProductName': '',
                'Quantity': 0
            };

            $scope.transactionType = $scope.bundle.add;

            $('#modal-form-succced').hide();
            $('#modal-form').show();
            $('#form-warning').hide();
        }

        //EditView function
        $scope.EditView = function (form) {
            $scope.savingType = 2;
            console.log(form);

            $('#modal-form-succced').hide();
            $('#modal-form').show();
            $scope.form = form;
            $scope.transactionType = $scope.bundle.edit;
            $('#form-modal').modal('toggle');
           
        }

        //DeleteView function
        $scope.DeleteView = function (form) {
            $('#modal-delete-succced').hide();
            $('#modal-delete').show();
            $scope.form = form;
            $scope.transactionType = $scope.bundle.delete;
            $('#form-delete').modal('toggle');
        }


        //ProductSelectionView function
        $scope.ProductSelectionView = function () {
            $('#modal-product-selection-succced').hide();
            $('#modal-product-selection').show();
            $('#form-product-selection').modal('toggle');
            $('#form-warning').hide();
            $('#form-product-selection-warning').hide();
        }

        //Save function
        $scope.Save = function () {
            $scope.form.Location = $('#branchLocation').val();

            $scope.form.OrderId = $scope.bundle.orderId;

            console.log($scope.form);


            var tempJsonRequest = {
                'OrderDetail': $scope.form
            };

            console.log(tempJsonRequest);

            $scope.warningMsg = "";
            if ($scope.form.ProductName.trim() == '') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.productName + '<br/>';
            }
            if ($scope.form.Quantity == 0) {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.quantity + '<br/>';
            }

            if ($scope.warningMsg.trim() == '') {
                $('#modal-form').hide();
                $("#modal-form-loading").show();

                if ($scope.savingType == 1) {
                    $scope.url = jsonServiceURL + "/order/insertorderdetail";
                }
                else {
                    $scope.url = jsonServiceURL + "/order/editorderdetail";
                }
                $scope.method = "POST";

                $http({
                    method: $scope.method, url: $scope.url, data: tempJsonRequest
                }).
                    then(function (response) {
                        console.log(response);

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
            $scope.url = jsonServiceURL + "/order/deleteorderdetail";
            $http({
                method: $scope.method, url: $scope.url, data: tempJsonRequest
            }).
                then(function (response) {
                    console.log(response);

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

        $scope.SearchProduct = function () {

            $('#form-branch-selection-warning').hide();

            $scope.warningMsg = '';
            if ($scope.ProductSearch.trim() == '') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.branchsearch + '<br/>';
            }

            $scope.url = '/product/getproductlist';
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
                    'Search': $scope.ProductSearch,
                    'SelectedPage': 0
                };
                console.log(tempJsonRequest);


                $http({ method: $scope.method, url: $scope.url, data: tempJsonRequest }).
                    then(function (response) {
                        console.log(response.data);
                        $scope.visivel = true;
                        $scope.productList = response.data.ProductList;

                        $('div.block7').unblock();
                    });
            }
            else {
                console.log('aloa');
                $('#form-branch-selection-warning').show();
            }
        }

        $scope.SelectProduct = function (product) {
            $scope.selectedProduct = product;

            $scope.form.ProductName = product.Name + "-" + product.Barcode;
            $scope.form.ProductId = product.Id;

            $('#form-product-selection').modal('toggle');
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

            $scope.url = '/order/getorderdetaillist';
            $scope.method = 'POST';

            var tempJsonRequest = {
                'OrderId': $scope.bundle.orderId,
                'SelectedPage': $scope.selectedPage
            };
            console.log(tempJsonRequest);

            $http({ method: $scope.method, url: $scope.url, data: tempJsonRequest }).
                then(function (response) {
                    console.log(response.data);
                    $scope.orderDetails = response.data.OrderDetailList;

                    $scope.totalPages = response.data.PageSize;
                    $scope.totalPageArray = new Array($scope.totalPages);

                    $('div.block5').unblock();


                });
        }      

        
}]);

