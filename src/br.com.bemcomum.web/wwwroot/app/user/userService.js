/* 
namespace: br.com.bemcomum.web
data: 30/10/2015
objective: the representation of the user
dev: adriano.galesso
*/

var userModule = angular.module('userModule', ['addressModule']);

userModule.factory('User', ['$http', function ($http) {

    var api = '//localhost:63858/api/donor/';

    var User = function (user) {

        if (!user) {
            user = {};
        }

        this.id = user.id;
        this.name = user.name;
        this.password = user.password;
        this.email = user.email;
    };

    User.prototype.login = function () {
        var self = this;

        return $http.post(api, self).then(function (response) {
            self = response.data;
            return response;
        });
    };

    return User;

}]);

userModule.factory('Donor', ['$http', 'User', 'Address', function ($http, User, Address) {

    var api = '//localhost:63858/api/donor/';

    var Donor = function (donor) {

        if (!donor) {
            donor = {};
        }

        User.call(this, donor);
        this.secondStep = false;
        this.address = new Address(donor.address);
    };

    Donor.prototype = new User();

    Donor.prototype.add = function () {
        var self = this;

        return $http.put(api, self).then(function (response) {
            self = response.data;
            return response;
        });
    };

    return Donor;

}]);