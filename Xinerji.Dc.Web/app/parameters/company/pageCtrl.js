$('#blockbtn5').click(function () {
    
});

$('#unblockbtn5').click(function () {
   
});

var mainapp = angular.module('mainApp', ['ngSanitize']);



mainapp.controller('sectionCtrl', ['$scope', 'utilities', '$http', '$templateCache', '$location',
    function ($scope, utilities, $http, $templateCache, $location) {

        

        $scope.init = function () {           

            $scope.transactionName = 'TEDARİKÇİ ŞİRKET';
            $scope.transactionType = 'EKLE';

            $scope.form = {
                'Id': '',
                'Name': '',
                'Email': '',
                'Address': '',
                'Phone': '',
                'Location': ''
            };

            console.log($scope.form);
        }       

        $scope.routeToPage = function (pageName) {
           utilities.routeToPage(pageName);
        }

        $scope.search = function () {
            refreshTable();
        }

        $scope.clearForm = function () {

            $scope.form = {
                'Id' : '',
                'Name': '',
                'Email': '',
                'Address': '',
                'Phone': '',
                'Location': ''
            };

            $scope.transactionType = 'EKLE';

            $('#modal-form-succced').hide();
            $('#modal-form').show();
            $("#modal-loading-spinner").hide();
        }

        $scope.addFirm = function () {
            $scope.form.Location = $('#companyLocation').val();

            console.log($scope.form);

            var tempJsonRequest = {
                'Company': $scope.form
            };

            console.log(tempJsonRequest);

            $scope.warningMsg = "";
            if ($scope.form.Name.trim() == '') {
                $scope.warningMsg += '- Firma Adını giriniz.<br/>';
            }
            if ($scope.form.Email.trim() == '' || utilities.validateEmail($scope.form.Email) == false) {
                $scope.warningMsg += '- Uygun bir eposta giriniz.<br/>';
            }
            if ($scope.form.Address.trim() == '') {
                $scope.warningMsg += '- Adress giriniz.<br/>';
            }
            if ($scope.form.Location.trim() == '') {
                $scope.warningMsg += '- Lokasyon seçiniz.<br/>';
            }

            if ($scope.warningMsg.trim() == '') {
                $("#modal-loading-spinner").show();
                $('#modal-form').hide();

                $scope.method = "POST";
                $scope.url = jsonServiceURL + "/parameter/insertCompany";
                $http({
                    method: $scope.method, url: $scope.url, data: tempJsonRequest
                }).
                    then(function (response) {
                        console.log(response);

                        if (response.data.Header.Error.ErrorCode == 0) {
                            refreshTable();

                            $('#modal-form-succced').show();
                            $('#modal-form').hide();
                            $("#modal-loading-spinner").hide();

                            

                        } else {
                            $('#form-warning').show();
                            $('#modal-form').show();
                            $("#modal-loading-spinner").hide();

                            $scope.warningMsg = response.data.Header.Error.ErrorDescriptionTR;
                        }

                    }, function (response) {

                        $("#modal-loading-spinner").hide();
                        $('#form-warning').show();
                        $('#modal-form').show();

                        $scope.warningMsg = "Bağlantı hatası oluştu lütfen internet bağlantınızı kontrol ediniz.";

                        $('#modal-loading-spinner').hide();

                        $('#warning').show();
                        $('#loginPage01').show();
                        

                    });
            }
            else {
                $('#form-warning').show();
            }
           
        }

        $scope.EditView = function (form) {
            $('#modal-form-succced').hide();
            $('#modal-form').show();
            $scope.form = form;
            $scope.transactionType = 'DÜZENLE';
            $('#form-modal').modal('toggle');
        }

        $scope.DeleteConfirmation = function (form) {
            $('#modal-delete-succced').hide();
            $('#modal-delete').show();
            $scope.form = form;
            $scope.transactionType = 'SİL';
            $('#form-delete').modal('toggle');
        }

        $scope.Delete = function (form) {

            $("#delete-loading-spinner").show();
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
                        $("#delete-loading-spinner").hide();



                    } else {
                        $('#form-delete-warning').show();
                        $('#modal-delete-succced').hide();
                        $('#modal-delete').show();
                        $("#delete-loading-spinner").hide();

                        $scope.warningMsg = response.data.Header.Error.ErrorDescriptionTR;
                    }

                }, function (response) {
                    $('#form-delete-warning').show();
                    $('#modal-delete-succced').hide();
                    $('#modal-delete').show();
                    $("#delete-loading-spinner").hide();


                    $scope.warningMsg = "Bağlantı hatası oluştu lütfen internet bağlantınızı kontrol ediniz.";
                    


                });
        }

        $scope.View = function (form) {
            $scope.form = form;
            $scope.transactionType = 'DETAY';
            $('#form-view').modal('toggle');
        }

        var refreshTable = function () {
           

            $('div.block5').block({
                message: '<h4><img src="/plugins/images/busy.gif" /> Lütfen bekleyiniz...</h4>',
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
                'Search': $scope.Search
            };
            console.log(tempJsonRequest);

            $http({ method: $scope.method, url: $scope.url, data: tempJsonRequest }).
                then(function (response) {
                    console.log(response.data);
                    $scope.companyList = response.data.CompanyList;

                    $('div.block5').unblock();


                });
        }

        $(window).on('hashchange', function (e) {
            hashChanged();
        });

        $(document).ready(function () {
            hashChanged();
        });

        var hashChanged = function () {
            var hash = location.hash.replace(/^#/, '');

            if (hash == '' || hash =='/page01') {
                refreshTable();
            }
            else if (hash == '/page02') {
                $('#loadingspinner').hide();
                $('#page01').hide();
                $('#page02').show();
            }
        }

        
}]);

