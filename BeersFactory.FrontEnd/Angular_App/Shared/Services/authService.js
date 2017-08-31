'use strict';

angular.module('App.shared').factory('authService', ['$http', '$location', '$q', 'localStorageService', 'ngAuthSettings', function ($http, $location, $q, localStorageService, ngAuthSettings) {
    var baseUri = ngAuthSettings.baseUri;
    var authServiceFactory = {};
    var authentication = {
        isAuth: false,
        token: "",
        UserName: "",
        UserId: "",
        Name: "",
        Address:"",
        PhoneNumber:""
    };
    var getUserInfo = function (registerExternalData) {

        return $http({
            method: 'GET',
            url: baseUri + '/api/Account/UserInfo',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded', 'Authorization': 'Bearer ' + registerExternalData.AccessToken }
        });


    };
    var logout = function () {

        clearAuthData();


    };
    var setPassword = function (setPassworddData) {
        var url = baseUri + 'api/Account/SetPassword';

        return $http({
            method: 'POST',
            url: url,
            data: setPassworddData,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    var verifyOTP = function (verifyOTPdData) {
        var url = baseUri + 'api/Account/VerifyOTP';

        return $http({
            method: 'POST',
            url: url,
            data: verifyOTPdData,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    var forgotPassord = function (forgotPassordData) {
        var url = baseUri + 'api/Account/ForgotPassword';

        return $http({
            method: 'POST',
            url: url,
            data: forgotPassordData,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    var changePassord = function (changePassordData) {
        var url = baseUri + 'api/Account/ChangePassword';

        return $http({
            method: 'POST',
            url: url,
            data: changePassordData,
            headers: { 'Content-Type': 'application/json' }
        });
    };
    var login = function (loginData) {
        var data = "grant_type=password&UserName=" + loginData.UserName + "&password=" + loginData.Password;
        var deferred = $q.defer();
        $http.post(baseUri + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {
         
            localStorageService.set('authorizationData', { token: response.access_token, UserName: response.UserName, UserID: response.UserId, Name: response.Name, Address: response.Adress, PhoneNumber: response.PhoneNumber });

            authentication.isAuth = true;
            authentication.UserName = response.UserName;
            authentication.Name = response.Name;
            authentication.Address = response.Adress;
            authentication.PhoneNumber = response.PhoneNumber;
            authentication.UserId = response.UserId;
            authentication.token = response.access_token;
            
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });

        return deferred.promise;

    };
    var fillAuthData = function () {
        //debugger;
        var authData = localStorageService.get('authorizationData');


        if (authData) {
                authentication.isAuth = true;
                authentication.token = authData.token;
                authentication.UserName = authData.UserName;
                authentication.UserId = authData.UserId;
                authentication.Address = authData.Address;
                authentication.Name = authData.Name;
                authentication.PhoneNumber = authData.PhoneNumber;


        } else {
            $location.url('home/login');

        }


    };
    var clearAuthData = function () {
        //debugger;
        var authData = localStorageService.get('authorizationData');




        if (authData) {
            authentication.isAuth = false;
            authentication.token = '';
            authentication.UserName = '';
            authentication.UserId = '';
            authentication.Name = '';
            authentication.Address = '';
            authentication.PhoneNumber = '';

        }
        localStorageService.remove('authorizationData');
        $location.url('/home/login');



    };


    authServiceFactory.Login = login;
    authServiceFactory.GetUserInfo = getUserInfo;
    authServiceFactory.FillAuthData = fillAuthData;
    authServiceFactory.authentication = authentication;
    authServiceFactory.Logout = logout;
    authServiceFactory.ChangePassord = changePassord;
    authServiceFactory.ForgotPassord = forgotPassord;
    authServiceFactory.VerifyOTP = verifyOTP;
    authServiceFactory.SetPassword = setPassword;

    return authServiceFactory;
}]);
