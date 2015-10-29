var app = angular.module("bemComum", ['ngRoute']);

app.controller('globalController', function () { });

app.config(function ($routeProvider, $locationProvider) {

    $routeProvider
        .when('/', {
            templateUrl: 'pages/home.html',
            controller: 'homeController'
        })
        .when('/contact', {
            templateUrl: 'pages/contact.html',
            controller: 'contactController'
        })
        .when('/faq', {
            templateUrl: 'pages/faq.html',
            controller: 'faqController'
        });


    $locationProvider.html5Mode(true);

});