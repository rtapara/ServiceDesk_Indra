app.controller("homeController", function ($scope, $location, $http) {
    $http.post('../C0002G0002',
                    JSON.stringify())
                .success(function (oList) {
                    return;
                }).error(function (err) {
                    $location.path("/");
                });

    $scope.menu = true;
    $scope.navItemClicked = function (e) {
        if (e.itemData.text === "Registrar usuario") {
            $location.path("/usuario");
        }
        else if (e.itemData.text === "Registrar ticket") {
            $location.path("/ticket");
        }
        else if (e.itemData.text === "Crear campaña") {
            $location.path("/home");
        }
        else if (e.itemData.text === "Cerrar campaña") {
            $location.path("/home");
        }
        else if (e.itemData.text === "Cargar morosos") {
            $location.path("/home");
        }
        else if (e.itemData.text === "Cargar agentes") {
            $location.path("/home");
        }
        else if (e.itemData.text === "Verificar avance") {
            $location.path("/home");
        }
        else if (e.itemData.text === "Salir") {
            $location.path("/logout");
        }
    };
});