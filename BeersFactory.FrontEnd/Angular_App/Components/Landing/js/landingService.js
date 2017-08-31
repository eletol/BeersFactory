
angular.module('App.landing').factory('landingService', function landingfactory($http, $location, $q, appSetting, ngAuthSettings) {
    var landingFactory = {};
    var serviceBase = appSetting.AppSetting.serviceBase;
    var baseUri = ngAuthSettings.baseUri;
   
   
    return landingFactory;
});