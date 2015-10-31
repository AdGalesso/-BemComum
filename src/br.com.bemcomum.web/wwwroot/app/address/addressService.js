/* 
namespace: br.com.bemcomum.web
data: 30/10/2015
objective: the representation of the address
dev: adriano.galesso
*/

var addressModule = angular.module('addressModule', []);

addressModule.factory('Address', ["$http", function ($http) {

    var Address = function(address)
    {
        if (!address) {
            address = {};
        }

        this.street = address.street;
        this.distrct = address.distrct;
        this.number = address.number;
        this.complement = address.complement;
        this.zipcode = address.zipcode;
        this.city = address.city;
        this.state = address.state ? address.state : 'SP';
        this.phone = address.phone;

        Address.prototype.getAdrressFromLatLog = function (callBack) {
            var api = "http://maps.googleapis.com/maps/api/geocode/json?latlng=";
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
                                self.zipcode = aComponents[7].long_name;

                                callBack();
                            });
                    },
                    function () {
                    }
                );
            }
        };

        Address.prototype.clearZipCode = function () {
            var self = this;

            self.zipcode = "";

            return self;
        };
    }

    return Address;

}]);