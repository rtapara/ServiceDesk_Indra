app.controller("logoutController", function ($scope, $http, $location) {
    $http.post('../C0002G0003')
                .success(function (oBe) {
                    $location.path("/");
                }).error(function (err) {
                    DevExpress.ui.notify(err.Message, 'error', 3000);
                });
});