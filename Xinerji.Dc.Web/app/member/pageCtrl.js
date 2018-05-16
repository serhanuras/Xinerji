var mainapp = angular.module('mainApp', ['ngSanitize']);



mainapp.controller('sectionCtrl', ['$scope', 'utilities', '$http', '$templateCache', '$location',
    function ($scope, utilities, $http, $templateCache, $location) {

        $scope.totalPages = -1;
        $scope.totalPageArray = new Array(0);
        $scope.selectedPage = 0;

        $scope.visivel = false;

        //Init function
        $scope.init = function () {           
            $scope.savingType = 1; /* 1-New record saving, 2-Existing record updating...*/

            $scope.form = {
                'Id': '',
                'TCIdentifier': '',
                'Name': '',
                'MiddleName': '',
                'Surname': '',
                'Birthdate': '',
                'Email': '',
                'CompanyId': '0',
                'Phone': '',
                'Phone': '',
                'MemberTypeId': '0'
            };


            //GET COMPANIES
            $scope.url = '/parameter/getcompanylist';
            $scope.method = 'POST';

            var tempJsonRequest = {
                'SelectedPage': -1
            };

            $http({ method: $scope.method, url: $scope.url, data: tempJsonRequest }).
                then(function (response) {

                    $scope.companyList = response.data.CompanyList;

                    $scope.url = '/parameter/getmembertypelist';
                    $scope.method = 'POST';

                    var tempJsonRequest = {
                        'Search': $scope.Search
                    };

                    $http({ method: $scope.method, url: $scope.url, data: tempJsonRequest }).
                        then(function (response) {
                            $scope.memberTypeList = response.data.MemberTypeList;
                        });

                    refreshTable();
                });
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
                'TCIdentifier': '',
                'Name': '',
                'MiddleName': '',
                'Surname': '',
                'Birthdate': '',
                'Email': '',
                'CompanyId': '0',
                'Phone': '',
                'Phone': '',
                'MemberTypeId': '0'
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
           
        }

        //DeleteView function
        $scope.DeleteView = function (form) {
            $('#modal-delete-succced').hide();
            $('#modal-delete').show();
            $scope.form = form;
            $scope.transactionType = $scope.bundle.delete;
            $('#form-delete').modal('toggle');
        }

        //Save function
        $scope.Save = function () {

            var tempJsonRequest = {
                'Member': $scope.form
            };

            console.log(tempJsonRequest);

            $scope.warningMsg = '';
            if ($scope.form.TCIdentifier.trim() == '') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.tc + '<br/>';
            }
            if ($scope.form.Name.trim() == '') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.name + '<br/>';
            }
            if ($scope.form.Surname.trim() == '') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.surname + '<br/>';
            }
            if ($scope.form.Email.trim() == '' || utilities.validateEmail($scope.form.Email) == false) {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.email + '<br/>';
            }
            if ($scope.form.CompanyId== '0') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.company + '<br/>';
            }
            if ($scope.form.MemberTypeId == '0') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.memberType + '<br/>';
            }

            if ($scope.warningMsg.trim() == '') {
                $('#modal-form').hide();
                $("#modal-form-loading").show();

                if ($scope.savingType == 1) {
                    $scope.url = jsonServiceURL + "/member/insertmember";
                }
                else {
                    $scope.url = jsonServiceURL + "/member/editmember";
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
            $scope.url = jsonServiceURL + "/member/deletemember";
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

            $scope.url = '/member/getmemberlist';
            $scope.method = 'POST';

            var tempJsonRequest = {
                'Search': $scope.Search,
                'SelectedPage': $scope.selectedPage
            };

            $http({ method: $scope.method, url: $scope.url, data: tempJsonRequest }).
                then(function (response) {

                    $scope.memberList = response.data.MemberList;

                    $scope.totalPages = response.data.PageSize;
                    $scope.totalPageArray = new Array($scope.totalPages);

                    $('div.block5').unblock();


                });
        }      
        


        $scope.findCompanyById = function (companyId) {

            var companyList = $scope.companyList;

            for (var key in companyList) {
                if (companyList.hasOwnProperty(key)) {

                    if (companyId == companyList[key].Id) {
                        return companyList[key].Name;
                    }
                }
            }
        };

        $scope.getMemberType = function (memberTypeId) {

            var memberTypeList = $scope.memberTypeList;

            for (var key in memberTypeList) {
                if (memberTypeList.hasOwnProperty(key)) {

                    if (memberTypeId == memberTypeList[key].Id) {

                        return memberTypeList[key].Type;
                    }
                }
            }
            
            
        };

        var findMemberTypesById = function (memberTypeId) {
            var memberTypeList = $scope.memberTypeList;

            for (var key in memberTypeList) {
                if (memberTypeList.hasOwnProperty(key)) {

                    if (memberTypeId == memberTypeList[key].Id) {

                        return memberTypeList[key];
                    }
                }
            }
        }


        $scope.formatDate = function (date) {
            return utilities.converJsonDate(date);
        }
}]);

