/* 
namespace: br.com.bemcomum.web
data: 30/10/2015
objective: my global admin app
dev: adriano.galesso
*/

var app = angular.module("bemComumAdmin", ['ngRoute', 'dashboardModule']);

app.controller('AdminController', function () { });

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

    $routeProvider
        .when('/', {
            templateUrl: '../app/admin/_dashboard.html',
            controller: 'DashboardController'
        })

    $locationProvider.html5Mode(true);
}]);