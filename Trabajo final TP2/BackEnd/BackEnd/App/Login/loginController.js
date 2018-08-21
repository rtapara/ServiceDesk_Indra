app.controller("loginController", function ($scope, $http, $location) {
    $scope.login = function () {
        $http.post('../C0002G0001',
                        JSON.stringify({
                            COD_USUA: $("#txtCOD_USUA").dxTextBox("instance").option("value"),
                            ALF_PASS: $("#txtALF_PASS").dxTextBox("instance").option("value"),
                            NUM_ACCI: 1
                        }))
                    .success(function (oBe) {
                        $location.path("/home");
                    }).error(function (err) {
                        DevExpress.ui.notify(err.Message, 'error', 3000);
                    });
    }
});