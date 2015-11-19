/* 
namespace: br.com.bemcomum.web
data: 01/11/2015
objective: the representation of a Base entity
dev: adriano.galesso
*/

var baseModule = angular.module('baseModule', []);

baseModule.factory('Base', [function () {

    var Base = function (base) {
        self = this;

        if (!base) {
            base = {};
        }

        this.id = base.id;
        this.isActive = base.isActive;
        this.save = base.save;
        this.update = base.update;
    };

    return Base;
}]);