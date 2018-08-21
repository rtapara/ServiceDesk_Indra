app.factory("userFactory", function () {
    return {}
}).controller("usuarioController", function ($scope, $http, userFactory,$location) {
    $http.post('../C0002G0002',
                    JSON.stringify())
                .success(function (oList) {
                    return;
                }).error(function (err) {
                    $location.path("/");
                });

    var hgt1 = $('#mainContent').height();
    $scope.hgt = hgt1 - 0;
    userFactory.NUM_ACCI = 0;

    $scope.initData = function () {
        $http.post('../C0003G0001',
                        JSON.stringify({
                            NUM_ACCI: 1
                        }))
                    .success(function (oList) {
                        $("#gdvUsers").dxDataGrid("instance").option("dataSource", oList);
                    }).error(function (err) {
                        DevExpress.ui.notify(err.Message, 'error', 3000);
                    });
    }
    $scope.initDataUsersType = function () {
        $http.post('../C0004G0001',
                        JSON.stringify({
                            NUM_ACCI: 1
                        }))
                    .success(function (oList) {
                        $("#cmbCOD_TIPO").dxSelectBox("instance").option("dataSource", oList);
                    }).error(function (err) {
                        DevExpress.ui.notify(err.Message, 'error', 3000);
                    });
    }
    $scope.searchAgent = function () {
        $http.post('../C0001G0001',
                        JSON.stringify({
                            ALF_AGEN: $("#txtALF_AGEN_REFE").dxTextBox("instance").option("value"),
                            NUM_ACCI: 1
                        }))
                    .success(function (oList) {
                        $("#gdvColaborator").dxDataGrid("instance").option("dataSource", oList);
                    }).error(function (err) {
                        DevExpress.ui.notify(err.Message, 'error', 3000);
                    });
    }
    $scope.clearControl = function () {
        $("#txtCOD_AGEN").dxTextBox("instance").option("value","");
        $("#txtALF_AGEN").dxTextBox("instance").option("value","");
        $("#txtALF_DNII").dxTextBox("instance").option("value","");
        $("#txtALF_DIRE").dxTextBox("instance").option("value","");
        $("#txtCOD_USUA").dxTextBox("instance").option("value","");
        $("#txtALF_PASS").dxTextBox("instance").option("value","");
        $("#txtALF_PASS_REPE").dxTextBox("instance").option("value", "");
        $("#cmbCOD_TIPO").dxSelectBox("instance").option("value", 0);
        $("#txtNUM_TOKE").dxTextBox("instance").option("value", "");
        $("#chkIND_ESTA").dxCheckBox("instance").option("value", false);
    };
    $scope.showPopupNew = function () {
        var popup = $("#popupUser").dxPopup("instance");
        popup.option("title", "Nuevo");
        popup.show();
        $scope.clearControl();
        $("#txtCOD_USUA").dxTextBox("instance").option("readOnly", false);
        $("#cmbCOD_TIPO").dxSelectBox("instance").option("readOnly", false);
        userFactory.NUM_ACCI = 1;
    }
    $scope.showPopupEdit = function (row) {
        var popup = $("#popupUser").dxPopup("instance");
        popup.option("title", "Editar");
        popup.show();
        $scope.clearControl();
        userFactory.NUM_ACCI = 2;
        $http.post('../C0003G0001',
                        JSON.stringify({
                            COD_USUA: row.COD_USUA,
                            NUM_ACCI: 2
                        }))
                    .success(function (oList) {
                        var oBe = oList[0];
                        $("#txtCOD_AGEN").dxTextBox("instance").option("value", oBe.COD_AGEN);
                        $("#txtALF_AGEN").dxTextBox("instance").option("value", oBe.ALF_AGEN);
                        $("#txtALF_DNII").dxTextBox("instance").option("value", oBe.ALF_DNII);
                        $("#txtALF_DIRE").dxTextBox("instance").option("value", oBe.ALF_DIRE);
                        $("#txtCOD_USUA").dxTextBox("instance").option("value", oBe.COD_USUA);
                        $("#txtALF_PASS").dxTextBox("instance").option("value", oBe.ALF_PASS);
                        $("#txtALF_PASS_REPE").dxTextBox("instance").option("value", oBe.ALF_PASS);
                        $("#cmbCOD_TIPO").dxSelectBox("instance").option("value", oBe.COD_TIPO_USUA);
                        $("#txtNUM_TOKE").dxTextBox("instance").option("value", oBe.NUM_TOKE);
                        if (oBe.IND_ACTI)
                            $("#chkIND_ESTA").dxCheckBox("instance").option("value", true);
                        else
                            $("#chkIND_ESTA").dxCheckBox("instance").option("value", false);
                        $("#txtCOD_USUA").dxTextBox("instance").option("readOnly", true);
                        $("#cmbCOD_TIPO").dxSelectBox("instance").option("readOnly", true);
                    }).error(function (err) {
                        DevExpress.ui.notify(err.Message, 'error', 3000);
                    });
    }

    $scope.Save = function () {
        $http.post('../C0003S0002',
                        JSON.stringify({
                            COD_AGEN: $("#txtCOD_AGEN").dxTextBox("instance").option("value"),
                            COD_USUA: $("#txtCOD_USUA").dxTextBox("instance").option("value"),
                            ALF_PASS: $("#txtALF_PASS").dxTextBox("instance").option("value"),
                            ALF_PASS_REPE: $("#txtALF_PASS_REPE").dxTextBox("instance").option("value"),
                            COD_TIPO_USUA: $("#cmbCOD_TIPO").dxSelectBox("instance").option("value"),
                            IND_ACTI: $("#chkIND_ESTA").dxCheckBox("instance").option("value"),
                            NUM_ACCI: userFactory.NUM_ACCI
                        }))
                    .success(function (oBe) {
                        DevExpress.ui.notify(oBe, 'success', 3000);
                        $scope.initData;
                    }).error(function (err) {
                        DevExpress.ui.notify(err.Message, 'error', 3000);
                    });
    }

    $scope.hidePopupUser = function () {
        var popup = $("#popupUser").dxPopup("instance");
        popup.hide();
    }
    $scope.hidePopupSearchAgent = function () {
        var popup = $("#popupSearchAgent").dxPopup("instance");
        popup.hide();
    }
    $scope.showPopupSearchAgent = function () {
        var popup = $("#popupSearchAgent").dxPopup("instance");
        popup.show();
        $("#gdvColaborator").dxDataGrid("instance").option("dataSource", []);
    }

    $scope.headerTemplate = function (container) {
        $('<span id="spanicon" title="Nuevo" />')
           .attr('class', 'dx-icon-add icon')
           .on('dxclick', function () { $scope.showPopupNew(); })
           .appendTo(container);
    };
    $scope.cellTemplate = function (container,options) {
        $('<span id="spanicon" title="Editar" />')
           .attr('class', 'dx-icon-edit icon')
           .on('dxclick', function () { $scope.showPopupEdit(options.data); })
           .appendTo(container);
    };
    $scope.selectAgent = function (row) {
        $("#txtCOD_AGEN").dxTextBox("instance").option("value",row.COD_AGEN);
        $("#txtALF_AGEN").dxTextBox("instance").option("value",row.ALF_AGEN);
        $("#txtALF_DNII").dxTextBox("instance").option("value", row.ALF_DNII);
        $("#txtALF_DIRE").dxTextBox("instance").option("value", row.ALF_DIRE);
        $scope.hidePopupSearchAgent();
    };
    $scope.cellTemplateAgentSearch = function (container,options) {
        $('<span id="spanicon" title="Seleccionar" />')
           .attr('class', 'dx-icon-chevronprev icon')
           .on('dxclick', function () { $scope.selectAgent(options.data); })
           .appendTo(container);
    };

    $scope.buttonsActionUser = [
        {
            toolbar: 'bottom', location: 'after', widget: 'dxButton', options: {
                hint: 'Guardar', icon: 'save', width: 50, disabled: false,
                onClick: $scope.Save
            }
        },
        {
            toolbar: 'bottom', location: 'after', widget: 'dxButton', options: {
                hint: 'Cerrar', icon: 'close', width: 50, disabled: false,
                onClick: $scope.hidePopupUser
            }
        }
    ];

    $scope.buttonsActionSearchAgent = [
        {
            toolbar: 'bottom', location: 'after', widget: 'dxButton', options: {
                hint: 'Cerrar', icon: 'close', width: 50, disabled: false,
                onClick: $scope.hidePopupSearchAgent
            }
        }
    ];
});