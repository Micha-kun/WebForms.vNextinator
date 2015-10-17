(function () {
    'use strict';

    angular
        .module('app', [])
        .controller('SuperControl', ['$location', '$scope', '$http', function ($location, $scope, $http) {
            $scope.title = 'controller';
            $scope.serverResult = '';
            $scope.sendToServer = function () {
                $http.get('/SuperControl/Click?text=' + $scope.text).then(function (response) {
                    // this callback will be called asynchronously
                    // when the response is available
                        $scope.serverResult = response.data;
                }, function (response) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.
                });
            };
        }]);
})();