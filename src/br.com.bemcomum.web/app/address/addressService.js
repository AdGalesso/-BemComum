/* 
namespace: br.com.bemcomum.web
data: 30/10/2015
objective: the representation of the address
dev: adriano.galesso
*/

var addressModule = angular.module('addressModule', ['baseModule', 'stringModule', 'objectModule']);

addressModule.factory('Address', ['$http', 'Base', 'StringUtils', 'ObjectUtils', function ($http, Base, StringUtils, ObjectUtils) {

    var api = 'address/';

    var Address = function (address) {
        if (!address) {
            address = {};
        }

        Base.apply(this, [address]);

        this.street = address.street;
        this.district = address.district;
        this.number = address.number;
        this.complement = address.complement;
        this.zipCode = address.zipCode;
        this.city = address.city;
        this.state = address.state ? address.state : 'SP';
        this.phone = address.phone;
    };

    Address.prototype = new Base();

    Address.prototype.add = function() {
        var self = this;

        return $http.put(environment.api + api, self).then(function (response) {
            return ObjectUtils.bind(self, response.data);
        });
    }

    Address.prototype.post = function () {
        var self = this;

        return $http.post(environment.api + api, self).then(function (response) {
            self = response.data;
            return response;
        });
    }

    Address.prototype.getAdrressByLatLog = function (callBack) {
        var api = environment.map + "&latlng=";
        var self = this;

        if (window.navigator && window.navigator.geolocation) {
            var geolocation = window.navigator.geolocation;

            geolocation.getCurrentPosition(
                function (pos) {
                    $http.get(api + pos.coords.latitude + "," + pos.coords.longitude)
                        .then(function (response) {
                            var aComponents = response.data.results[0].address_components;

                            self.district = aComponents[2].long_name;
                            self.city = aComponents[3].short_name;
                            self.state = aComponents[5].short_name;
                            self.zipCode = aComponents[7].long_name;

                            callBack();
                        });
                },
                function () {
                }
            );
        }
    };

    Address.prototype.getAdrressByZipCode = function (callBack) {
        var api = environment.map + "&address=";
        var self = this;

        if (self.zipCode) {
            $http.get(api + StringUtils.removeSpecialChars(self.zipCode))
                .then(function (response) {
                    if (response.data.results.length) {
                        var aComponents = response.data.results[0].address_components;

                        self.district = aComponents[1].long_name;
                        self.city = aComponents[3].short_name;
                        self.state = aComponents[4].short_name;

                        if (callBack) {
                            callBack();
                        }
                    }
                });
        }
    }

    Address.prototype.getMapMark = function (map, callBack) {
        var api = environment.map + "&address=";
        var self = this;

        return $http.get(api + self.street + ', ' + self.number + ', ' + self.district + ', ' + self.city + ', ' + self.state + ', ' + StringUtils.removeSpecialChars(self.zipCode)).then(function (response) {

            var marker = null;

            if (response.data.results.length) {

                var geometry = response.data.results[0].geometry;

                marker = new google.maps.Marker({
                    position: { lat: geometry.location.lat, lng: geometry.location.lng },
                    map: map,
                    animation: google.maps.Animation.DROP
                })

                if (callBack) {
                    callBack();
                }
            }

            return marker;
        });
    }

    Address.prototype.clearZipCode = function () {
        var self = this;

        self.zipCode = "";

        return self;
    };

    return Address;
}]);