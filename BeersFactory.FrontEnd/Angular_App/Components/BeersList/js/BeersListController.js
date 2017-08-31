"use strict";
angular.module("App.beersList").controller("beersListController", function ticketFunction($scope, $rootScope, $location, ngAuthSettings, authService, lookUpService, ngDialog, toaster, $stateParams, $state, beersListService, localStorageService) {

   $scope.load= function() {
        beersListService.getbeers($scope.pagingInfo).then(function (res) {
        
      $scope.beers = res.data;
  }, function (err) {
        
    });
   }
   $scope.getById = function (id,beer) {
       if (beer.details==undefined) {
           beersListService.getById(id).then(function (res) {
               
               beer.details = res.data;
           }, function (err) {
               
           });
           }
    
   }
    $scope.pagingInfo = {
        Page: 1,
        Sort: "ASC",
        Order: "createDate",
        filters: [{ Key: "", Value: "" }, { Key: "", Value: "" }, { Key: "", Value: "" }]
        

    };

       $scope.load();

       $scope.selectPage = function (page) {
           $scope.pagingInfo.Page = page;
           $scope.load();
       };
});