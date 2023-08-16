angular.module('Province')
    .controller('Province.helloWorldController', ['$scope', 'Province.webApi', function ($scope, api) {
        var blade = $scope.blade;
        blade.title = 'Province';

        blade.refresh = function () {
            api.get(function (data) {
                blade.title = 'Province.blades.hello-world.title';
                blade.data = data.result;
                blade.isLoading = false;
            });
        };

        blade.refresh();
    }]);
