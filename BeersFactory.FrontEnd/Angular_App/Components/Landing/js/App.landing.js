'use strict';

angular.module('App.landing', [
         'ui.router', 'App.authInterceptor',
        'LocalStorageModule'
    ]).config(function ($stateProvider, $urlRouterProvider) {

    $stateProvider
        .state('landing', {
            url: '/landing',
            templateUrl: '/Angular_App/Components/Landing/html/landing.html',
            controller: 'landingController',
            abstract: true

        });

});

