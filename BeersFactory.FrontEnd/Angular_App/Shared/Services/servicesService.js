'use strict';

angular.module('App.shared').factory('servicesService', ['$http', '$location', '$q', 'localStorageService', 'ngAuthSettings', 'appSetting', function ($http, $location, $q, localStorageService, ngAuthSettings, appSetting) {
    var servicesServiceFactory = {};

    var serviceBase = appSetting.AppSetting.serviceBase;
    servicesServiceFactory.getServices = function () {
        var url = serviceBase + 'api/Services';

        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    servicesServiceFactory.getServiceFormByTicketId = function (ticketId) {
        var url = serviceBase + 'api/ServiceForms/GetServiceFormByTicketId?id=' + ticketId;
        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    servicesServiceFactory.getOffersCustomerHistory = function (msisdn) {
        var url = 'https://visacouponzapi.dsquares.com/api/Couponz/GetCustomerHistoryJsonResult?msisdn=' + msisdn;
        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };

    servicesServiceFactory.getOfferDetails = function (offerId) {
        var url = 'https://visacouponzapi.dsquares.com/api/flexdeals/getdealdetails?offerId=' + offerId+'&lang=en';
        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    servicesServiceFactory.readNotification = function (notificationId) {
        var url = serviceBase + 'api/CustomerNotifications/ReadNotification?notificationId='+notificationId;
        return $http({
            method: 'PUT',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    servicesServiceFactory.getNotificationCount = function () {
        var url = serviceBase + 'api/CustomerNotifications/GetNotificationCount';
        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    servicesServiceFactory.subscribeToOffer = function (msisdn, offerNumber) {
        var url = 'https://visacouponzapi.dsquares.com/api/couponz/SubscribeToOffer?msisdn=' + msisdn + '&offerNumber=' + offerNumber + '&ratePlan=200&channel=USSD&forceXMLResult=false';
        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    servicesServiceFactory.getdeals = function () {
        var url = 'https://visacouponzapi.dsquares.com/api/flexdeals/getdeals?ratePlan=200&lang=en';
        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    servicesServiceFactory.getServicesByServiceTypeId = function (serviceTypeId) {
        var url = serviceBase + 'api/Services/GetServicesByServiceTypeId?serviceTypeId=' + serviceTypeId;
        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    servicesServiceFactory.getServiceFormByServiceId = function (serviceId) {
        var url = serviceBase + 'api/ServiceForms/GetServiceFormByServiceId?id=' + serviceId;
        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    servicesServiceFactory.getServiceTypes = function () {
        var url = serviceBase + 'api/ServicesTypes/';
        return $http({
            method: 'GET',
            url: url,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    return servicesServiceFactory;
}]);
