/* 
namespace: br.com.bemcomum.web
data: 30/10/2015
objective: some util services
dependencies: notyjs
dev: adriano.galesso
*/

var notyModule = angular.module('notyModule', []);

notyModule.factory('Noty', function () {
    return {
        alert: function (text, type, speed) {
            noty({
                text: text,
                type: type,
                dismissQueue: true,
                layout: 'topCenter',
                closeWith: ['click'],
                theme: 'relax',
                maxVisible: 10,
                animation: {
                    open: 'animated bounceInLeft',
                    close: 'animated bounceOutRight',
                    easing: 'swing',
                    speed: !speed ? 500 : speed
                }
            });
        },
        confirm: function (text, type, okCallBack, cancelCallBack, oktxt, canceltxt, speed) {
            noty({
                text: text,
                type: type,
                dismissQueue: true,
                layout: 'topCenter',
                theme: 'relax',
                animation: {
                    open: 'animated bounceInRight',
                    close: 'animated bounceOutLeft',
                    easing: 'swing',
                    speed: !speed ? 500 : speed
                },
                buttons: [
                    {
                        addClass: 'btn btn-primary',
                        text: oktxt ? oktxt : 'OK',
                        onClick: function ($noty) {
                            okCallBack();
                            $noty.close();
                        }
                    },
                    {
                        addClass: 'btn btn-danger',
                        text: canceltxt ? canceltxt : 'Cancel',
                        onClick: function ($noty) {
                            cancelCallBack();
                            $noty.close();
                        }
                    }
                ]
            });
        }
    };
});

var stringModule = angular.module('stringModule', []);

notyModule.factory('StringUtils', function () {
    return {
        removeSpecialChars: function(text)
        {
            return text.replace(/[^\w\s]/gi, '');
        }
    };
});

var objectModule = angular.module('objectModule', []);

objectModule.factory('ObjectUtils', function () {
    return {
        bind: function(oldObj, newObj)
        {
            for (var key in newObj) {
                if (oldObj.hasOwnProperty(key)) {
                    oldObj[key] = newObj[key];
                }
            }

            return oldObj;
        }
    };
});