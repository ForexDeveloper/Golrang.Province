angular.module('Province')
    .factory('Province.webApi', ['$resource', function ($resource) {
        return $resource('api/province');
    }]);
