"use strict";
angular.module('App.shared').controller("ticketGridController", function ticketFunction($scope, $rootScope, $location, ticketsGridService, ngAuthSettings, authService, lookUpService, servicesService, ngDialog, toaster, beersListService, $window, $state) {
    $scope.request = {
        RequestFieldList:[]
    };
    $rootScope.hideAside = false;
    $rootScope.hideAbove = false;

    $scope.UserId = authService.authentication.UserId;
    $scope.UserName = authService.authentication.UserName;
    $scope.token = authService.authentication.token;
    $scope.lookUp = {};
    $scope.ngDialog = ngDialog;

    $scope.clickToOpen = function (item) {

        $scope.ticketForHistory = item;
        $scope.value = true;
        var dialog = ngDialog.open({
            template: 'Angular_App/Components/TicketHistory/ticket-history.html',
            className: 'ngdialog-theme-default',
            appendClassName: 'ngdialog-custom',
            scope: $scope,
            width: 'auto',
            showClose: true,
            closeByDocument: true,
            closeByEscape: true,
        });
        dialog.closePromise.then(function (data) {
            console.log('ngDialog closed' + (data.value === 1 ? ' using the button' : '') + ' and notified by promise: ' + data.id);
            //loaditems();
           // $window.location.reload();
            $state.reload();

        });

    };

    $scope.getServiceFormByServiceId= function(serviceId) {
        servicesService.getServiceFormByServiceId(serviceId).then(function (res) {
            $scope.ServiceFormObj = res.data;
            $scope.request.ServiceId = $scope.ServiceFormObj.ServiceId;
            console.log($scope.ServiceFormObj);
            for (var i = 0; i < $scope.ServiceFormObj.ServiceFormFieldList.length; i++) {
            
                $scope.request.RequestFieldList[i] = { ServiceFormFieldId: $scope.ServiceFormObj.ServiceFormFieldList[i].ServiceFormFieldId, RequestFieldValuesList: [{ Value: "" }] };
            }

        }, function (err) {

        });
    }


     servicesService.getServiceTypes().then(function (response) {
            $scope.serviceTypes = response.data;
            console.log(response.data);
        },
        function (err) {
            $scope.errMessage = err.error_description;
            console.log($scope.errMessage);
        });

    $scope.getServicesByServiceTypeId = function (serviceTypeId) {
        servicesService.getServicesByServiceTypeId(serviceTypeId).then(function (response) {
            $scope.servicesByerviceType = response.data;
            console.log(response.data);
        },
        function (err) {
            $scope.errMessage = err.error_description;
            console.log($scope.errMessage);
        });
    }

    servicesService.getServices().then(function(response) {
            debugger;
            $scope.services = response.data;
            console.log(response.data);

        },
        function(err) {
            $scope.errMessage = err.error_description;
            console.log($scope.errMessage);

        });

    lookUpService.getChannels().then(
        function(response) {
            debugger;
            $scope.lookUp.channels = response.data;
            console.log(response.data);

        },
        function(err) {
            $scope.errMessage = err.error_description;
            console.log($scope.errMessage);

        });

    lookUpService.getTicketStatuses().then(
        function(response) {
            debugger;
            $scope.lookUp.ticketStatuses = response.data;
            console.log(response.data);

        },
        function(err) {
            $scope.errMessage = err.error_description;
            console.log($scope.errMessage);

        });
    $scope.loading = false;
    $scope.addMode = false;
    $scope.selected = {};


    $scope.pagingInfo = {
        page: 1,
        itemsPerPage: 20,
        sortBy: "CreationDateTime",
        reverse: "true",
        search: "",
        Owner: "",
        filters: {
            BasicFilters: [
                { Key: "TicketId", Label: "TicketId", Value: null, Op: "?==", VLabel: null, item: null },
                { Key: "CustomerId", Label: "CustomerId", Value: null, Op: "Contains", VLabel: null, item: null },
                { Key: "ChannelName", Label: "ChannelName", Value: null, Op: "Contains", VLabel: null, item: null },
                { Key: "OwnerName", Label: "OwnerName", Value: null, Op: "Contains", VLabel: null, item: null },
                { Key: "ServiceName", Label: "ServiceName", Value: null, Op: "Contains", VLabel: null, item: null },
                { Key: "TicketStatusName", Label: "TicketStatusName", Value: null, Op: "Contains", VLabel: null, item: null }
            ],
            RangeFilters: [
                { Key: "LastUpdate", Label: "Last Update", ValueFrom: null, ValueTo: null, Op: "Between" },
                { Key: "CreationDateTime", Label: "Creation Date", ValueFrom: null, ValueTo: null, Op: "Between" }
            ]
        },
        totalItems: 0,
        PendingCount:0,
        CanceledCount:0,
        ColsedCount:0
    };

    $scope.updateLabel = function(item, label, value) {
        item.VLabel = label;
        item.Value = value;
    };

    // initial table load
    loaditems();


    $scope.formatSort = function(sortField) {
        if (sortField == $scope.pagingInfo.sortBy && $scope.pagingInfo.reverse == "true") {
            return "fa-caret-up";
        }
        return "fa-caret-down";
    };

    $scope.IsSortedAscending = function(sortField) {
        if (sortField == $scope.pagingInfo.sortBy && $scope.pagingInfo.reverse == "true") {
            return true;
        }
        return false;
    };

    $scope.formatCell = function(i, sortField) {
        if (sortField == $scope.pagingInfo.sortBy) {
            $(".article-table tbody tr").each(function() {
                $(".article-table tbody tr td:nth-child(" + i + ")").addClass("bold");
            });
            //console.log(i);
            //console.log(sortField);
            return true;
        }
        return false;
    };

    $scope.search = function() {
        $scope.pagingInfo.page = 1;
        loaditems();
    };

    $scope.sort = function(sortBy) {
        if (sortBy === $scope.pagingInfo.sortBy) {
            $scope.pagingInfo.reverse = !$scope.pagingInfo.reverse;
        } else {
            $scope.pagingInfo.sortBy = sortBy;
            $scope.pagingInfo.reverse = false;
        }
        $scope.pagingInfo.page = 1;
        loaditems();
    };

    $scope.selectPage = function(page) {
        $scope.pagingInfo.page = page;
        loaditems();
    };

    function loaditems() {
        $scope.items = null;
        $scope.loading = true;
        ticketsGridService.getTickets($scope.pagingInfo, $scope.customerId).then(function (response) {
                $scope.items = response.data.data;
                $scope.pagingInfo.totalItems = response.data.count;
                $scope.pagingInfo.PendingCount = response.data.PendingCount;
                $scope.pagingInfo.ClosedCount = response.data.ClosedCount;
                $scope.pagingInfo.CanceledCount = response.data.CanceledCount;

                $scope.appliedFilters = response.data.appliedFilters;
                checkSelected_th();

            },
            function(err) {
                $scope.errMessage = err.error_description;
            });

    }

    function checkSelected_th() {
        $(".article-table thead th.selected").each(function() {
            var that = $(this),
                index = $(".article-table thead th").index(that) + 1; // To change it to 1-based

            $(".article-table tbody tr").each(function() {
                $(".article-table tbody tr td:nth-child(" + index + ")").addClass("bold");
            });

        });
    }

    $scope.getTemplate = function(item) {
        //if (item.MerchantId === $scope.selected.MerchantId) return 'edit';
        //else
        return "displayTicket";
    };

    $scope.editItem = function(item) {
        //console.log(round);
        $scope.selected = angular.copy(item);
    };

    $scope.reset = function() {
        $scope.selected = {};
    };

    $scope.toggleEdit = function() {
        this.item.editMode = !this.item.editMode;
    };
    $scope.toggleAdd = function() {
        $scope.addMode = !$scope.addMode;
    };

    //Used to save a record after edit
    $scope.save = function() {
        ////alert("Edit");
        //$scope.loading = true;
        //var item = $scope.selected;
        //var itemId = $scope.selected.MerchantId;
        ////alert(round);
        //round.id = itemId;
        //round.method = 'Put';

        //merchantsData.items.put(item, function () {
        //    round.editMode = false;
        //    $scope.loading = false;
        //    $scope.items[idx] = angular.copy($scope.selected);
        //    $scope.reset();
        //});
    };
    //Used to edit a record
    $scope.deleteitem = function() {
        //$scope.loading = true;
        //var item = {};
        //item.id = this.item.MerchantId;
        //item.method = 'Delete';

        //merchantsData.items.delete(item, function () {
        //    //alert("Deleted Successfully!!");
        //    $.each($scope.items, function (i) {
        //        if ($scope.items[i].MerchantId == item.id) {
        //            $scope.items.splice(i, 1);
        //            return false;
        //        }
        //    });
        //    $scope.loading = false;
        //});
    };
});