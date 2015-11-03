/* 
namespace: br.com.bemcomum.web
data: 30/10/2015
objective: my global app
dev: adriano.galesso
*/

var app = angular.module("bemComum", ['ngRoute', 'homeModule']);

app.controller('GlobalController', function () { });

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

    $routeProvider
        .when('/', {
            templateUrl: '../app/home/home.html',
            controller: 'HomeController'
        })
        .when('/contact', {
            templateUrl: '../app/contact/contact.html',
            controller: 'ContactController'
        })
        .when('/faq', {
            templateUrl: '../app/faq/faq.html',
            controller: 'FaqController'
        })

    $locationProvider.html5Mode(true);
}]);