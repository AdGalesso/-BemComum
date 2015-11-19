/* 
namespace: br.com.bemcomum.web
data: 30/10/2015
objective: the representation of the address
dev: adriano.galesso
*/

var institutionModule = angular.module('institutionModule', ['baseModule', 'addressModule', 'objectModule']);

institutionModule.factory('Institution', ['$http', 'Base', 'Address', 'ObjectUtils', function ($http, Base, Address, ObjectUtils) {

    var api = 'institution/';

    var Institution = function (institution) {
        if (!institution) {
            institution = {};
        }

        Base.apply(this, [institution]);

        this.name = institution.name;
        this.cnpj = institution.cnpj;
        this.email = institution.email;
        this.operation = institution.operation;
        this.description = institution.description;
        this.photo = institution.photo;
        this.status = institution.status ? institution.status : 0;
        this.address = new Address(institution.address);
    };

    Institution.prototype = new Base();

    Institution.prototype.add = function () {
        var self = this;

        return $http.put(environment.api + api, self).then(function (response) {
            return ObjectUtils.bind(self, response.data);
        });
    };

    Institution.prototype.post = function () {
        var self = this;

        return $http.post(environment.api + api, self).then(function (response) {
            self = response.data;
            return response;
        });
    };

    Institution.prototype.get = function (id) {
        var self = this;

        return $http.get(environment.api + api + id).then(function (response) {
            return new Institution(response.data);
        });
    };

    Institution.prototype.getAll = function () {
        var self = this;

        return $http.get(environment.api + api).then(function (response) {
            var institutions = [];

            for (var i = 0; i < response.data.length; i++) {
                institutions.push(new Institution(response.data[i]));
            }

            return institutions;
        });

    };

    Institution.prototype.delete = function () {
        var self = this;
        return $http.delete(environment.api + api + self.id);
    };

    return Institution;
}]);