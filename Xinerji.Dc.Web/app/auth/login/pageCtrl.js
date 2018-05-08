var mainapp = angular.module('mainApp', ['ngSanitize']);


mainapp.controller('sectionCtrl', ['$scope', 'utilities', '$http', '$templateCache', '$location',
    function ($scope, utilities, $http, $templateCache, $location) {

        $scope.login = {
            email: "",
            password: "",
            errorMessage: ""

        };

        $scope.init = function () {
            $('#loadingspinner').hide();
            $('#loginPage01').show();

            
        }    

        $scope.logon = function () {
            console.log($scope.login);

            $('#loadingspinner').show();
            $('#loginPage01').hide();

            var tempJsonRequest = {
                Email: $scope.login.email,
                Password: $scope.login.password
            }

            $scope.method = "POST";
            $scope.url = jsonServiceURL + "/authentication/validatelogon";
            $http({ method: $scope.method, url: $scope.url, data: tempJsonRequest }).
                then(function (response) {
                    console.log(response);

                    if (response.data.Header.Error.ErrorCode == 0) {

                        window.location = "/app/dashboard/index.aspx";

                    } else {
                        console.log(response.data.Header.Error.ErrorDescriptionTR);
                        $scope.login.errorMessage = response.data.Header.Error.ErrorDescriptionTR;
                        $('#warning').show();
                        $('#loginPage01').show();
                        $('#loadingspinner').hide();

                    }

                    //$('#loginPage01').show();
                    //$('#loadingspinner').hide();

                }, function (response) {

                    $scope.login.errorMessage = "Bağlantı hatası oluştu lütfen internet bağlantınızı kontrol ediniz.";

                    $('#loadingspinner').hide();

                    $('#warning').show();
                    $('#loginPage01').show();
                    $('#loadingspinner').hide();

                });

        }

  
}]);

