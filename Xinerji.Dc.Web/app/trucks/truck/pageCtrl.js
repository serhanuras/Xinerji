var mainapp = angular.module('mainApp', ['ngSanitize']);



mainapp.controller('sectionCtrl', ['$scope', 'utilities', '$http', '$templateCache', '$location',
    function ($scope, utilities, $http, $templateCache, $location) {

        $scope.totalPages = -1;
        $scope.totalPageArray = new Array(0);
        $scope.selectedPage = 0;
        $scope.MemberSearch = '';

        

        $scope.visivel = false;

        //Init function
        $scope.init = function () {           
            $scope.savingType = 1; /* 1-New record saving, 2-Existing record updating...*/

           

            $scope.form = {
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
            };

            $scope.selectedMember = {
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
            }

            $scope.url = '/parameter/gettruckstatuslist';
            $scope.method = 'POST';

            var tempJsonRequest = {
                'Search': $scope.Search
            };
            console.log(tempJsonRequest);

            $http({ method: $scope.method, url: $scope.url, data: tempJsonRequest }).
                then(function (response) {
                    console.log(response.data);
                    $scope.truckStatusList = response.data.TruckStatusList;

                    $scope.totalPages = response.data.PageSize;
                    $scope.totalPageArray = new Array($scope.totalPages);

                    $('div.block5').unblock();

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
            $('#form-warning').hide();

            $scope.form = {
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


        //MemberSelectionView function
        $scope.MemberSelectionView = function () {
            $('#modal-member-selection-succced').hide();
            $('#modal-member-selection').show();
            $('#form-member-selection').modal('toggle');
            $('#form-warning').hide();
            $('#form-member-selection-warning').hide();
        }

        //Save function
        $scope.Save = function () {

            var tempJsonRequest = {
                'Truck': $scope.form
            };

            console.log(tempJsonRequest);

            $scope.warningMsg = '';
            if ($scope.form.TruckStatusId == '0') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.truckstatus + '<br/>';
            }
            if ($scope.form.MemberName.trim() == '') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.driver + '<br/>';
            }
            if ($scope.form.Plaque.trim() == '') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.plaque + '<br/>';
            }
            if ($scope.form.LicenceNo.trim() == '') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.licenceNo + '<br/>';
            }
            if ($scope.form.Capacity== '0') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.capacity + '<br/>';
            }
            if ($scope.form.Model == '0') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.model + '<br/>';
            }
            if ($scope.form.Year == '0') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.year + '<br/>';
            }

            if ($scope.warningMsg.trim() == '') {
                $('#modal-form').hide();
                $("#modal-form-loading").show();

                if ($scope.savingType == 1) {
                    $scope.url = jsonServiceURL + "/parameter/inserttruck";
                }
                else {
                    $scope.url = jsonServiceURL + "/parameter/edittruck";
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
            $scope.url = jsonServiceURL + "/parameter/deletetruck";
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

        

        $scope.SearchMember = function () {
            
            $('#form-member-selection-warning').hide();

            $scope.warningMsg = '';
            if ($scope.MemberSearch.trim() == '') {
                $scope.warningMsg += '- ' + $scope.bundle.js.warning.membersearch + '<br/>';
            }

            $scope.url = '/member/getmemberlist';
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
                    'Search': $scope.MemberSearch
                };
                console.log(tempJsonRequest);


                $http({ method: $scope.method, url: $scope.url, data: tempJsonRequest }).
                    then(function (response) {
                        console.log(response.data);
                        $scope.visivel = true;
                        $scope.memberList = response.data.MemberList;

                        $('div.block7').unblock();
                    });
            }
            else {
                console.log('aloa');
                $('#form-member-selection-warning').show();
            }
        }

        $scope.SelectMember = function (member) {
            $scope.selectedMember = member;

            $scope.form.MemberName = member.Name + ' ' + member.MiddleName + ' ' + member.Surname;
            $scope.form.MemberId = member.Id;

            $('#form-member-selection').modal('toggle');
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

            $scope.url = '/parameter/gettrucklist';
            $scope.method = 'POST';

            var tempJsonRequest = {
                'Search': $scope.Search,
                'SelectedPage': $scope.selectedPage
            };

            $http({ method: $scope.method, url: $scope.url, data: tempJsonRequest }).
                then(function (response) {

                    $scope.truckList = response.data.TruckList;

                    $scope.totalPages = response.data.PageSize;
                    $scope.totalPageArray = new Array($scope.totalPages);

                    $('div.block5').unblock();


                });
        }      


        


        $scope.formatDate = function (date) {
            return utilities.converJsonDate(date);
        }
}]);

