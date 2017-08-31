
'use strict';
angular.module('App.shared').factory('HubProxy', ['$rootScope', 'appSetting',
  function ($rootScope, appSetting) {
      var serviceBase = appSetting.AppSetting.serviceBase;

    function backendFactory(hubName) {
        var connection = $.hubConnection(serviceBase);
      var proxy = connection.createHubProxy(hubName);

      connection.start().done(function () { });

      return {
        on: function (eventName, callback) {
              proxy.on(eventName, function (result) {
                $rootScope.$apply(function () {
                  if (callback) {
                    callback(result);
                  }
                 });
               });
             },
        invoke: function (methodName, callback) {
                  proxy.invoke(methodName)
                  .done(function (result) {
                    $rootScope.$apply(function () {
                      if (callback) {
                        callback(result);
                      }
                    });
                  });
                }
      };
    };

    return backendFactory;
}]);