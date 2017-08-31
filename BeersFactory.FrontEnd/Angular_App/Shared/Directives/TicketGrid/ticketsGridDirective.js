'use strict';
angular.module('App.shared').directive('ticketsGrid', function () {
    return {
        templateUrl: 'Angular_App/Shared/Directives/TicketGrid/ticket.html',
        restrict: 'A',
        replace: true,
        scope: {
            customerId: '='
        },
        controller: 'ticketGridController'
    }
});
