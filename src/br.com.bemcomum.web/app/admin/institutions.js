/* 
namespace: br.com.bemcomum.web
data: 30/10/2015
objective: the institution module
dev: adriano.galesso
*/

var institutionsModule = angular.module('institutionsModule', ['institutionModule', 'notyModule']);

institutionsModule.controller('InstitutionController', ['$scope', 'Institution', 'Noty', function ($scope, Institution, Noty) {

    $scope.institutionList = [];
    $scope.isFetching = true;

    $scope.getAll = function () {
        //To do - Fix this new
        (new Institution()).getAll().then(function (response) {
            $scope.institutionList = response;
            $scope.isFetching = false;
        });
    };

    $scope.remove = function (institution) {
        Noty.confirm(
            'Você tem certeza???',
            'warning',
            function () {
                institution.delete().then(function () {

                    var index = $scope.institutionList.indexOf(institution);
                    if (index != -1) {
                        $scope.institutionList.splice(index, 1);
                    }

                    Noty.alert('Instituição Removida', 'success', true);
                })
            },
            function () { },
            "Claro!",
            "Ops, Não...",
            true);
    };

    $scope.getAll();

}]);