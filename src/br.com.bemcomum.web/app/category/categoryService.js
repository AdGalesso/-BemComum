/* 
namespace: br.com.bemcomum.web
data: 03/11/2015
objective: the representation of the category
dev: adriano.galesso
*/

var categoryModule = angular.module('categoryModule', ['baseModule', 'objectModule']);

categoryModule.factory('Category', ['$http', 'Base', 'ObjectUtils', function ($http, Base, ObjectUtils) {

    var api = 'category/';

    var Category = function (category) {

        if (!category) {
            category = {};
        }

        Base.apply(this, [category]);

        this.name = category.name;
        this.description = category.description;
    };

    Category.prototype = new Base();

    Category.prototype.add = function () {
        var self = this;

        return $http.put(environment.api + api, self).then(function (response) {
            return ObjectUtils.bind(self, response.data);
        });
    };

    Category.prototype.post = function () {
        var self = this;

        return $http.post(environment.api + api, self);
    };

    Category.prototype.getAll = function () {
        var self = this;

        return $http.get(environment.api + api).then(function (response) {
            var categories = [];

            for (var i = 0; i < response.data.length; i++) {
                categories.push(new Category(response.data[i]))
            }

            return categories;
        });
    };

    Category.prototype.delete = function () {
        var self = this;
        return $http.delete(environment.api + api + self.id);
    };

    return Category;

}]);