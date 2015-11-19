/* 
namespace: br.com.bemcomum.web
data: 30/10/2015
objective: my global admin app
dev: adriano.galesso
*/

var app = angular.module("bemComumAdmin", ['ngRoute', 'dashboardModule', 'categoriesModule', 'institutionsModule', 'instcreationModule']);

app.controller('AdminController', function () { });

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

    $routeProvider
        .when('/', {
            templateUrl: '../app/admin/dashboard.html',
            controller: 'DashboardController'
        })
        .when('/categories', {
            templateUrl: '../app/admin/categories.html',
            controller: 'CategoryController'
        })
        .when('/institutions', {
            templateUrl: '../app/admin/institutions.html',
            controller: 'InstitutionController'
        })
        .when('/institutions/add', {
            templateUrl: '../app/admin/institutioncreate.html',
            controller: 'InstCreationController'
        });

    $locationProvider.html5Mode(true);
}]);