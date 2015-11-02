/* 
namespace: br.com.bemcomum.web
data: 30/10/2015
objective: my home module
dev: adriano.galesso
*/

var homeModule = angular.module('homeModule', ['userModule', 'notyModule', 'ngMessages']);

homeModule.controller('HomeController', ['$scope', 'Noty', 'Donor', 'Address', function ($scope, Noty, Donor, Address) {

    $scope.donor = new Donor();
    $scope.step = 1;
    $scope.submitted = false;

    $scope.submit = function (isValid)
    {
        $scope.submitted = true;

        if (isValid) {
            $scope.donor.address = null;

            $scope.donor.add().then(function (response) {
                Noty.alert('Parabéns! Você está cadastrado <i class=\'fa fa-smile-o\'></i>. <br> Se puder, adicione seu endereço para acharmos as instituições próximas a você!', 'success');

                $scope.donor.address = new Address();

                $scope.donor.address.getAdrressByLatLog(function () {
                    if ($scope.donor.address.zipCode) {
                        Noty.confirm(
                            "Seu CEP é " + $scope.donor.address.zipCode + "?",
                            "alert",
                            function () {
                                $scope.donor.address.add();
                            },
                            function () {
                                $scope.donor.address.clearZipCode();
                                $("[name='zipCodeDonor']").val(''); //Todo - Why wasn't cleaninng
                            },
                            "Sim",
                            "Não");
                    }
                });
            });

            $scope.step = 2;
        }
    }

    $scope.submitAddress = function (isValid) {
        $scope.submittedAddress = true;

        if (isValid) {

        }
    };

    $scope.skip = function (step) {
        $scope.step = step;
    };

    $scope.init = function () {
        $scope.donor.getLocalUser();

        if ($scope.donor.id) {
            $scope.skip(3);
        }
    };

    $scope.init();
}]);