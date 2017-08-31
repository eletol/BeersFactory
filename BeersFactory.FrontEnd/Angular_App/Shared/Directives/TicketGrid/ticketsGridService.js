
angular.module('App.shared').factory('ticketsGridService', function ticketfactory($http, $location, $q, appSetting) {
    var ticketsFactory = {};
    var serviceBase = appSetting.AppSetting.serviceBase;



    ticketsFactory.getTickets = function (pagingInfo, customerId) {
        if (customerId == undefined)
            customerId = null;
    

        var url = serviceBase + "api/Requests/GetFilteredRequests?$filter=CustomerId eq '" + customerId + "'";

        return $http({
            method: 'POST',
            url: url,
            data: pagingInfo,
            headers: { 'Content-Type': 'application/json' }
        });
    };
  

    return ticketsFactory;
});