/* 
namespace: br.com.bemcomum.web
data: 01/11/2015
objective: the representation of a Base entity
dev: adriano.galesso
*/

var environment = null;
var _lock = false;
var baseModule = angular.module('baseModule', []);

baseModule.factory('Base', ['$http', function ($http) {

    var Base = function (base) {
        self = this;

        if (!base) {
            base = {};
        }

        this.id = base.id;
        this.isActive = base.isActive;
        this.save = base.save;
        this.update = base.update;

        Base.prototype.init = function()
        {
            var jEnv = localStorage.getItem("enviroment");

            if (!jEnv) {
                if (!_lock) {
                    _lock = true;

                    $http.get('app/config/bc.json')
                        .then(function (response) {
                            environment = response.data;
                            localStorage.setItem("enviroment", JSON.stringify(response.data));
                            _lock = false;
                        });
                }
            }
            else
            {
                environment = JSON.parse(jEnv);
            }

        };

        self.init();
    };

    return Base;
}]);