'use strict';

angular.module('App.shared').factory('lookUpService', ['$http', '$location', '$q', 'localStorageService', 'ngAuthSettings', 'appSetting', function ($http, $location, $q, localStorageService, ngAuthSettings, appSetting) {
    var lookUpServiceFactory = {};
    var baseUri = ngAuthSettings.baseUri;

    var serviceBase = appSetting.AppSetting.serviceBase;
    lookUpServiceFactory.getChannels = function () {
        var url = serviceBase + 'api/Channel';

        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    lookUpServiceFactory.getPaymentMethods = function () {
        var url = serviceBase + 'api/Payment/GetPaymentMethods';

        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    lookUpServiceFactory.getPaymentTypes = function () {
        var url = serviceBase + 'api/Payment/GetPaymentTypes';

        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    lookUpServiceFactory.getPaymentStatuses = function () {
        var url = serviceBase + 'api/Payment/GetPaymentStatuses';

        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    lookUpServiceFactory.getTicketStatuses = function () {
        var url = serviceBase + 'api/TicketStatus';

        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    lookUpServiceFactory.getAgents = function () {
        var url = serviceBase + 'api/Users/';

        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    lookUpServiceFactory.getRoles = function () {
        var url = baseUri + 'api/Account/GetRoles';

        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    lookUpServiceFactory.getAgentsFiltered = function (filter) {
        var url = serviceBase + 'api/Users/GetUserFiltered';

        return $http({
            method: 'POST',
            url: url,
            data:filter,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    lookUpServiceFactory.getAgents = function () {
        var url = serviceBase + 'api/Users';

        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    lookUpServiceFactory.GetByTicketId = function (ticketId) {
        var url = serviceBase + 'api/Customers/GetByTicketId?ticketId=' + ticketId;

        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };

    lookUpServiceFactory.getCustomerByPhoneNumber = function (phoneNumber) {
        var url = serviceBase + 'api/Customers/GetCustomerByPhoneNumber?phoneNumber=' + phoneNumber;

        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    lookUpServiceFactory.getCustomerByPhoneOrEmail = function (phoneNumber, email) {
        if (email == undefined) {
            email = '';
        }
        var url = serviceBase + 'api/Customers/GetCustomerByPhoneOrEmail?phoneNumber=' + phoneNumber + '&email=' + email;

        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    return lookUpServiceFactory;
}]);
