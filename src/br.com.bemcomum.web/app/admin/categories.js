/* 
namespace: br.com.bemcomum.web
data: 30/10/2015
objective: my categories admin module
dev: adriano.galesso
*/

var categoriesModule = angular.module('categoriesModule', ['categoryModule', 'notyModule']);

categoriesModule.controller('CategoryController', ['$scope', '$filter', '$anchorScroll', 'Category', 'Noty',
    function ($scope, $filter, $anchorScroll, Category, Noty) {

    $scope.category = new Category();
    $scope.categoryList = [];
    $scope.editing = false;
    $scope.isFetching = true;

    $scope.submit = function (isValid) {
        if (isValid) {
            if (!$scope.category.id) {
                $scope.category.add().then(function (response) {
                    response.isNew = true;
                    $scope.categoryList.unshift(response);
                    $scope.category = new Category();
                    Noty.alert('É isso ai! Categoria ' + response.name + ' adicionada', 'success', true);
                });
            }
            else
            {
                $scope.category.post().then(function () {
                    Noty.alert('Categoria ' + $scope.category.name + ' editada!', 'success', true);
                    $scope.category = new Category();
                });
            }
        }
        else {
            Noty.alert('Desculpe =/. Os dados estão inválidos', 'error', true);
        }
    };

    $scope.getAll = function () {
        $scope.category.getAll().then(function (response) {
            $scope.categoryList = response;
            $scope.isFetching = false;
        });        
    };

    $scope.remove = function (category) {
        Noty.confirm(
            'Você tem certeza???', 
            'warning',
            function () {
                category.delete().then(function () {

                    var index = $scope.categoryList.indexOf(category);
                    if (index != -1) {
                        $scope.categoryList.splice(index, 1);
                    }

                    Noty.alert('Categoria Removida', 'success', true);
                })
            },
            function () { },
            "Claro!",
            "Ops, Não...",
            true);
    };

    $scope.edit = function (category) {
        $scope.editing = true;
        $scope.category = category;
        $anchorScroll();
    };

    $scope.cancel = function() {
        $scope.category = new Category();
        $scope.editing = false;
    }

    $scope.getAll();
}]);