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
                'Name': '',
                'Email': '',
                'Address': '',
                'Phone': '',
                'Location': ''
            };

            refreshTable();

            console.log($scope.form);
        }       

        $scope.setPage = function (i) {
            $scope.selectedPage = i;
            refreshTable();
        }

        $scope.nextPage = function () {
            if ($scope.selectedPage < $scope.totalPages-1)
                $scope.selectedPage = $scope.selectedPage + 1;

            refreshTable();
        }

        $scope.prevPage = function () {
            if ($scope.selectedPage>0)
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

            window.location = '#add';
           
            $scope.savingType = 1;

            $scope.form = {
                'Id' : '',
                'Name': '',
                'Email': '',
                'Address': '',
                'Phone': '',
                'Location': ''
            };

            $scope.transactionType = $scope.bundle.add;

            $('#modal-form-succced').hide();
            $('#modal-form').show();
        }

        //EditView function
        $scope.EditView = function (form) {
            window.location = '#edit';

            $scope.savingType = 2;
            console.log(form);

            $('#modal-form-succced').hide();
            $('#modal-form').show();
            $scope.form = form;
            $scope.transactionType = $scope.bundle.edit;
            $('#form-modal').modal('toggle');

            var location = form.Location.replace('(', '').replace(')','').split(',');

            placeDefaultMarker(new google.maps.LatLng(parseFloat(location[0].trim().replace(",", ".")), parseFloat(location[1].trim().replace(",", "."))));
        }

        //DeleteView function
        $scope.DeleteView = function (form) {
            window.location = '#delete';

            $('#modal-delete-succced').hide();
            $('#modal-delete').show();
            $scope.form = form;
            $scope.transactionType = $scope.bundle.delete;
            $('#form-delete').modal('toggle');
        }

        //Save function
        $scope.Save = function () {
            $scope.form.Location = $('#companyLocation').val();

            console.log($scope.form);

            var tempJsonRequest = {
                'Company': $scope.form
            };

            console.log(tempJsonRequest);

            $scope.warningMsg = "";
            if ($scope.form.Name.trim() == '') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.companyName + '<br/>';
            }
            if ($scope.form.Email.trim() == '' || utilities.validateEmail($scope.form.Email) == false) {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.email + '<br/>';
            }
            if ($scope.form.Address.trim() == '') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.address + '<br/>';
            }
            if ($scope.form.Location.trim() == '') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.location + '<br/>';
            }

            if ($scope.warningMsg.trim() == '') {
                $('#modal-form').hide();
                $("#modal-form-loading").show();

                if ($scope.savingType == 1) {
                    $scope.url = jsonServiceURL + "/parameter/insertCompany";
                }
                else {
                    $scope.url = jsonServiceURL + "/parameter/editCompany";
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
            $scope.url = jsonServiceURL + "/parameter/deletecompany";
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
            window.location = '#view';
            $scope.form = form;
            $scope.transactionType = 'DETAY';
            $('#form-view').modal('toggle');
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

            $scope.url = '/parameter/getcompanylist';
            $scope.method = 'POST';

            var tempJsonRequest = {
                'Search': $scope.Search,
                'SelectedPage' : $scope.selectedPage
            };
           
            $http({ method: $scope.method, url: $scope.url, data: tempJsonRequest }).
                then(function (response) {
                    console.log(response.data);
                    $scope.companyList = response.data.CompanyList;

                    $scope.totalPages = response.data.PageSize;
                    $scope.totalPageArray = new Array($scope.totalPages);

                    $('div.block5').unblock();


                });
        }      

        $scope.ViewBranches = function (form) {

            window.location = '/app/parameters/branch/index.aspx?companyId=' + form.Id;

        }
}]);

