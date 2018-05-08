var mainapp = angular.module('mainApp', ['ngSanitize']);



mainapp.controller('sectionCtrl', ['$scope', 'utilities', '$http', '$templateCache', '$location',
    function ($scope, utilities, $http, $templateCache, $location) {

        

        $scope.init = function () {



        }    

        


        $scope.url = '/authentication/terminatesession';
        $scope.method = 'GET';

        $http({ method: $scope.method, url: $scope.url, data: {} }).
            then(function (response) {
                console.log(response.data);
                $scope.accounts = response.data.Accounts;


                $('#loadingspinner').hide();
                $('#teminateSessionPage01').show();


                window.location = '/app/auth/login/index.aspx';

            });

       

  
}]);

