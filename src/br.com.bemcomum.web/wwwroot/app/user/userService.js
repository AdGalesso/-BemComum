/* 
namespace: br.com.bemcomum.web
data: 30/10/2015
objective: the representation of the user
dev: adriano.galesso
*/

var userModule = angular.module('userModule', ['baseModule', 'addressModule']);

userModule.factory('User', ['$http', 'Base', 'ObjectUtils', function ($http, Base, ObjectUtils) {

    var api = 'user/';

    var User = function (user) {

        if (!user) {
            user = {};
        }

        Base.apply(this, user);

        this.name = user.name;
        this.password = user.password;
        this.email = user.email;
    };

    User.prototype = new Base();

    User.prototype.login = function () {
        var self = this;

        return $http.post(environment.api + api, self).then(function (response) {
            self = response.data;
            return response;
        });
    };

    User.prototype.logout = function ()
    {
        var self = this;

        self = new User();

        localStorage.removeItem("user")
    }

    User.prototype.setLocalUser = function()
    {
        var self = this;

        var local = {
            id: self.id,
            name: self.name,
            email: self.email,
        };

        localStorage.setItem("user", JSON.stringify(local));
    }

    User.prototype.getLocalUser = function () {
        var self = this;
        var local = localStorage.getItem("user");

        if (local) {
            ObjectUtils.bind(self, JSON.parse(local));
        }
    }

    return User;

}]);

userModule.factory('Donor', ['$http', 'User', 'Address', 'ObjectUtils', function ($http, User, Address, ObjectUtils) {

    var api = 'donor/';

    var Donor = function (donor) {

        if (!donor) {
            donor = {};
        }

        User.apply(this, donor);
        this.address = new Address(donor.address);
    };

    Donor.prototype = new User();

    Donor.prototype.add = function () {
        var self = this;

        return $http.put(environment.api + api, self).then(function (response) {
            self = ObjectUtils.bind(self, response.data);
            self.setLocalUser();
            return self;
        });
    };

    Donor.prototype.post = function () {
        var self = this;

        return $http.post(environment.api + api, self).then(function (response) {
            return ObjectUtils.bind(self, response.data);
        });
    };

    return Donor;

}]);