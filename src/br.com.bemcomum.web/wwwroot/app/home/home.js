/* 
namespace: br.com.bemcomum.web
data: 30/10/2015
objective: my home module
dev: adriano.galesso
*/

var homeModule = angular.module('homeModule', ['userModule', 'notyModule', 'ngMessages']);

homeModule.controller('HomeController', ['$scope', 'Noty', 'Donor', 'Address', function ($scope, Noty, Donor, Address) {

    $scope.donor = new Donor();
    $scope.secondStep = false;
    $scope.submitted = false;

    $scope.submit = function (isValid)
    {
        $scope.submitted = true;

        if (isValid) {
            $scope.donor.address = null;

            $scope.donor.add().then(function (response) {
                Noty.alert('Parabéns! Você está cadastrado <i class=\'fa fa-smile-o\'></i>. <br> Se puder, adicione seu endereço para acharmos as instituições próximas a você!', 'success');

                $scope.donor = response.data;

                $scope.donor.address = new Address();

                $scope.donor.address.getAdrressFromLatLog(function () {
                    if ($scope.donor.address.zipcode) {
                        Noty.confirm(
                            "Seu CEP é " + $scope.donor.address.zipcode + "?",
                            "alert",
                            function () {
                                $scope.donor.update();
                            },
                            function () {
                                $scope.donor.address.clearZipCode();
                            },
                            "Sim",
                            "Não");
                    }
                });
            });

            $scope.secondStep = true;
        }
    }

    $scope.submitAddress = function(isValid)
    {
        $scope.submittedAddress = true;

        if (isValid) {

        }
    }
}]);