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

        Base.apply(this, address);

        this.street = address.street;
        this.distrct = address.distrct;
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

            var lat = "-23.6723470";
            var lon = "-46.4505230";

            //api + pos.coords.latitude + "," + pos.coords.longitude

            geolocation.getCurrentPosition(
                function (pos) {
                    $http.get(api + lat + "," + lon)
                        .then(function (response) {
                            var aComponents = response.data.results[0].address_components;

                            self.distrct = aComponents[2].long_name;
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

    Address.prototype.getAdrressByZipCode = function () {
        var api = environment.map + "&address=";
        var self = this;

        $http.get(api + StringUtils.removeSpecialChars(self.zipCode))
            .then(function (response) {
                var aComponents = response.data.results[0].address_components;

                self.distrct = aComponents[1].long_name;
                self.city = aComponents[3].short_name;
                self.state = aComponents[5].short_name;

                callBack();
            });
    }

    Address.prototype.clearZipCode = function () {
        var self = this;

        self.zipCode = "";

        return self;
    };

    return Address;

}]);