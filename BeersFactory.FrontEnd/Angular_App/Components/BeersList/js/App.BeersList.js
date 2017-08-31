'use strict';

angular.module('App.beersList', [
         'ui.router', 'App.authInterceptor',
        'LocalStorageModule'
    ]).config(function ($stateProvider, $urlRouterProvider) {
    $stateProvider
        .state('landing.beers', {
            url: '/beers',
            templateUrl: '/Angular_App/Components/beersList/html/beersList.html',
            controller: 'beersListController',
            parent: 'landing'

        });

});

