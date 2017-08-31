'use strict';

angular.module('App.shared').directive('offersDirective', function () {
    return {
        restrict: 'A',
        scope: {
            items: '=offersDirective'
        },
        templateUrl: '/offers/list'
    };
});