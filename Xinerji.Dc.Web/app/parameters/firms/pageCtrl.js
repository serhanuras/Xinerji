var mainapp = angular.module('mainApp', ['ngSanitize']);


mainapp.controller('sectionCtrl', ['$scope', 'utilities', '$http', '$templateCache', '$location',
    function ($scope, utilities, $http, $templateCache, $location) {


        $scope.init = function () {
           

            
        }          


        $scope.method = "POST";
        $scope.url = jsonServiceURL + "/parameter/get";

        $http({ method: $scope.method, url: $scope.url, data: dataPayeeRequest }).
            then(function (response) {

                console.log(response.data);
                $scope.payeeList = response.data.MoneyTransferPayeeList;


                $('#loadingspinner').hide();
                $('#payeelistPage01').show();


            });
  
}]);

