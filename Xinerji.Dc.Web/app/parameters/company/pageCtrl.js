var mainapp = angular.module('mainApp', ['ngSanitize']);



mainapp.controller('sectionCtrl', ['$scope', 'utilities', '$http', '$templateCache', '$location',
    function ($scope, utilities, $http, $templateCache, $location) {

        $scope.init = function () {           
            
            
        }       

        $(window).on('hashchange', function (e) {
            hashChanged();
        });

        $(document).ready(function () {
            hashChanged();
        });


        var hashChanged = function () {
            var hash = location.hash.replace(/^#/, '');

            if (hash == '') {
                $('#page01').hide();
                $('#page02').hide();

                $scope.url = '/parameter/getcompanylist';
                $scope.method = 'GET';

                $http({ method: $scope.method, url: $scope.url, data: {} }).
                    then(function (response) {
                        console.log(response.data);
                        $scope.companyList = response.data.CompanyList;


                        $('#loadingspinner').hide();
                        $('#page01').show();


                    });
            }
            else if (hash == '/page02') {
                $('#loadingspinner').hide();
                $('#page01').hide();
                $('#page02').show();
            }
        }

        
}]);

