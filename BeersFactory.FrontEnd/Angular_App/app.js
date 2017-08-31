
"use strict";

var BaseUri = location.protocol + "//" + location.hostname + (location.port ? ":" + location.port : "") + "/";

// Declare app level module which depends on views, and components
angular.module("App", [
    "ui.router",
    "App.config",
    "App.httpInterceptor",
    "App.authInterceptor",
    "LocalStorageModule",
    "App.shared",
    "App.beersList",
    "App.landing",
     "ngSanitize"
]);

angular.module('App').run(['$state', '$stateParams',
function ($state, $stateParams) {
    //this solves page refresh and getting back to state
}]);
angular.module("App").config([
    "$locationProvider", "$urlRouterProvider", "$httpProvider", function($locationProvider, $urlRouterProvider, $httpProvider) {
        $urlRouterProvider.otherwise("landing/beers");
        $httpProvider.interceptors.push("httpInterceptor");
        $httpProvider.interceptors.push("authInterceptorService");
        $httpProvider.defaults.headers.common = {};
        $httpProvider.defaults.headers.post = {};
        $httpProvider.defaults.headers.put = {};
        $httpProvider.defaults.headers.patch = {};
    }
]).controller("AppController", function App($scope, $rootScope, $location, authService,servicesService,appSetting) {
    $scope.serviceBase = appSetting.AppSetting.serviceBase;
    $rootScope.UserName = authService.authentication.Name;
    $rootScope.isAuth = authService.authentication.isAuth;
 
   

}
);

angular.module("App.config", []).constant("ngAuthSettings",
{
    baseUri: BaseUri
});


angular.module("App").run([
    "authService", "appSetting", function(authService, appSetting) {
        appSetting.FillSettings();
        authService.FillAuthData();
    }
]);
angular.module("App.authInterceptor", [])
    .factory("authInterceptorService", [
        "$q", "$injector", "$location", "localStorageService", function($q, $injector, $location, localStorageService) {
            debugger;
            var authInterceptorServiceFactory = {};

            var request = function(config) {

                config.headers = config.headers || {};

                return config;
            };
            var responseError = function(rejection) {
                
                return $q.reject(rejection);
            };
            authInterceptorServiceFactory.request = request;
            authInterceptorServiceFactory.responseError = responseError;

            return authInterceptorServiceFactory;
        }
    ])
    .config([
        "$httpProvider", function($httpProvider) {
            $httpProvider.interceptors.push("authInterceptorService");
        }
    ]);

angular.module("App.httpInterceptor", []).factory("httpInterceptor", function($q, $rootScope, $log) {

        var numLoadings = 0;

        return {
            request: function(config) {
                
                numLoadings++;
                $("#dvLoader").addClass("shown");

                // Show loader
                return config || $q.when(config);

            },
            response: function(response) {

                if ((--numLoadings) === 0) {
                    $("#dvLoader").removeClass("shown");


                    // Hide loader
                }

                return response || $q.when(response);

            },
            responseError: function(response) {

                if (!(--numLoadings)) {
                    //$("#errorModalApp").modal('show');

                    // Hide loader
                    $("#dvLoader").removeClass("shown");

                }

                return $q.reject(response);
            }
        };
    })
    .config(function($httpProvider) {
        $httpProvider.interceptors.push("httpInterceptor");
    });