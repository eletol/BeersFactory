
angular.module('App.beersList').factory('beersListService', function beersListfactory($http, $location, $q, appSetting, ngAuthSettings) {
    var beersListFactory = {};
    var serviceBase = appSetting.AppSetting.serviceBase;
    var baseUri =ngAuthSettings.baseUri;

    beersListFactory.getbeers = function (pageInfo) {
        debugger;
        var url = "http://localhost:56553/api/Beers/GetByFilter";
       return $http({
            method: 'POST',
            url: url,
            data: pageInfo,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    beersListFactory.getById = function (id) {
        debugger;
        var url = "http://localhost:56553/api/Beers/GetById?id=" + id;
       return $http({
            method: 'Get',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    return beersListFactory;
});