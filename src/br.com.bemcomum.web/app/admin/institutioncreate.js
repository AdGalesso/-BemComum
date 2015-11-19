/* 
namespace: br.com.bemcomum.web
data: 30/10/2015
objective: the institution module
dev: adriano.galesso
*/

var instcreationModule = angular.module('instcreationModule', ['ui.mask', 'institutionModule', 'notyModule']);

instcreationModule.controller('InstCreationController', ['$scope', '$location', 'Institution', 'Noty', function ($scope, $location, Institution, Noty) {

    $scope.institution = new Institution();

    $scope.submit = function (isValid)
    {
        if (isValid) {
            if (!$scope.institution.id) {
                $scope.institution.add().then(function (response) {
                    Noty.alert('Instituição adicionada! \\o/', 'success', true);
                    confirmCallback(response);
                });
            }
            else {
                $scope.institution.post().then(function () {
                    Noty.alert('Instituição ' + $scope.institution.name + ' editada com sucesso!', 'success', true);
                    confirmCallback(response);
                });
            }

            function confirmCallback(response) {
                Noty.confirm(
                    'Você deseja continuar editando ou quer criar uma nova instituição?',
                    'alert',
                    function () {
                        location.hash = response.id;
                    },
                    function () {
                        $scope.institutionForm.$setPristine();
                        $scope.institution = new Institution();
                    },
                    'Continuar aqui',
                    'Criar uma nova',
                    true);
            }
        }
        else {
            Noty.alert('Desculpe =/. Os dados estão inválidos', 'error', true);
        }
    }

    $scope.init = function () {

        var hash = $location.hash();

        if (hash) {
            $scope.institution.get(hash).then(function (response) {
                $scope.institution = response;
            });
        }

    };

    $scope.init();
}]);