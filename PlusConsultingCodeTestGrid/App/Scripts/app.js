var app = angular.module('formvalid', ['ui.bootstrap', 'ui.utils']);
app.controller('validationCtrl', function ($scope, $http, $uibModal, $log) {
    $scope.data = [];
    $scope.dataTableOpt = {
        "aLengthMenu": [[10, 50, 100, -1], [10, 50, 100, 'All']],
    };

    $scope.getData = function () {
        $http({
            method: "GET",
            url: "Values/Product"
        }).then(function mySuccess(response) {
            $scope.data = response.data;
            $scope.dataTableOpt = {
                "aLengthMenu": [[10, 50, 100, -1], [10, 50, 100, 'All']],
            };
        }, function myError(response) {
            $scope.data = response.statusText;
        });
    };

    $scope.getData();

    $scope.open = function () {
        $uibModal.open({
            templateUrl: 'App/Pages/AddProduct.html',
            backdrop: true,
            windowClass: 'modal', 
            controller: function ($scope, $uibModalInstance, $log) {
                $scope.productData = {
                    'Name': '',
                    'ProductNumber': '',
                    'Color': '',
                    'SafetyStockLevel': 0,
                    'ReorderPoint': 0,
                    'StandardCost': 0,
                    'ListPrice': 0
                    };
                $scope.submit = function () {
                    $http.post('Values/Product', JSON.stringify($scope.productData),{ headers: {'Content-Type': 'application/json'}
                     }).success(function (data) {
                    $scope.person = data;
                    });
                    $uibModalInstance.dismiss('cancel');
                }
                $scope.cancel = function () {
                    $uibModalInstance.dismiss('cancel');
                };
            },
            resolve: {
                
            }
        });
    };

});
