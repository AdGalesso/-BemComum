/* 
namespace: br.com.bemcomum.web
data: 30/10/2015
objective: my global admin app
dev: adriano.galesso
*/

var app = angular.module("bemComumAdmin", ['ngRoute', 'dashboardModule', 'categoriesModule']);

app.controller('AdminController', function () { });

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

    $routeProvider
        .when('/', {
            templateUrl: '../app/admin/dashboard.html',
            controller: 'DashboardController'
        })
        .when('/categories', {
            templateUrl: '../app/admin/categories.html',
            controller: 'CategoriesController'
        });

    $locationProvider.html5Mode(true);
}]);