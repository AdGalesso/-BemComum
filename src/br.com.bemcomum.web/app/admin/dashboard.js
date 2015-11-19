/* 
namespace: br.com.bemcomum.web
data: 30/10/2015
objective: my dashboard admin module
dev: adriano.galesso
*/

var dashboardModule = angular.module('dashboardModule', ['institutionModule', 'userModule']);

dashboardModule.controller('DashboardController', ['$scope', '$http', 'Institution', 'Donor', function ($scope, $http, Institution, Donor) {

    $scope.init = function () {

        var api = 'dashboard/';

        $scope.categoriesCount = 0;
        $scope.institutionsCount = 0;
        $scope.donorsCount = 0;
        $scope.institutions = [];
        $scope.donors = [];

        $http.get(environment.api + api).then(function (response) {
            $scope.categoriesCount = response.data.categoriesCount;
            $scope.institutionsCount = response.data.institutionsCount;
            $scope.donorsCount = response.data.donorsCount;

            var bounds = new google.maps.LatLngBounds();
            var markers = [];
            var map;

            map = new google.maps.Map(document.getElementById('map'), {});

            clearMarkers();

            for (var i = 0; i < response.data.donors.length; i++) {
                $scope.donors.push(new Donor(response.data.donors[i]));

                var content = '<b>Doador: ' + $scope.donors[i].name + '</b>';

                addMarkerWithTimeout($scope.donors[i], i * 200, '/images/group-2.png', content);
            }

            for (var i = 0; i < response.data.institutions.length; i++) {
                $scope.institutions.push(new Institution(response.data.institutions[i]));

                var content = '<b>Instituição: ' + $scope.institutions[i].name + '</b>';

                addMarkerWithTimeout($scope.institutions[i], i * 200, '/images/daycare.png', content);
            }

            function addMarkerWithTimeout(obj, timeout, icon, content) {

                obj.address.getMapMark(map).then(function (response) {

                    if (response) {

                        if (icon) {
                            response.setIcon(icon)
                        }
                        
                        response.title = obj.name;

                        window.setTimeout(function () {
                            markers.push(response);
                        }, timeout);

                        bounds.extend(response.position);
                        map.fitBounds(bounds);

                        var infowindow = new google.maps.InfoWindow({
                            content: content
                        });

                        response.addListener('click', function () {
                            infowindow.open(map, response);
                        });
                    }
                });
            }

            function clearMarkers() {
                for (var i = 0; i < markers.length; i++) {
                    markers[i].setMap(null);
                }
                markers = [];
            }
        });
    };

    $scope.init();

}]);