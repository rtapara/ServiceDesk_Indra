app.factory("userFactory", function () {
    return {}
}).controller("ticketController", function ($scope, $http, userFactory, $location) {
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
        $http.post('../T0005G0001',
                        JSON.stringify({
                            NUM_ACCI: 1,
                            TIC_Id: $("#txt_Ticket").dxTextBox("instance").option("value"),
                            EMP_RazonSocial: $("#txt_Empresa").dxTextBox("instance").option("value"),
                            TIC_CodigoEstado: $("#c_Status").dxSelectBox("instance").option("value"),
                            TIC_StatDate: $('#d_fechaIni').val(),
                            TIC_EndDate: $('#d_fechaFin').val()
                            //TIC_StatDate: $("#d_fechaIni").dxDateBox("instance").option("value")
                        }))
                    .success(function (oList) {
                        console.log(oList);
                        if (oList.length == 0) DevExpress.ui.dialog.alert('No se encontraron coincidencias para la búsqueda realizada.', 'Aviso');
                        $("#gdvUsers").dxDataGrid("instance").option("dataSource", oList);
                        $("#txtUsuarioResponsable").dxTextBox("instance").option("value", "jcaceres");
                    }).error(function (err) {
                        DevExpress.ui.dialog.alert(err.Message, 'Error');
                    });
    }
    $scope.refreshData = function () {
        $http.post('../T0005G0001',
                        JSON.stringify({
                            NUM_ACCI: 1
                        }))
                    .success(function (oList) {
                        $("#gdvUsers").dxDataGrid("instance").option("dataSource", oList);
                    }).error(function (err) {
                        DevExpress.ui.dialog.alert(err.Message, 'Error');
                    });
    }


    $scope.initDataService = function () {
        $http.post('../Service',
                        JSON.stringify({
                            NUM_ACCI: 1
                        }))
                    .success(function (oList) {
                        $("#c_Service").dxSelectBox("instance").option("dataSource", oList);
                        $("#c_ServiceEdit").dxSelectBox("instance").option("dataSource", oList);
                    }).error(function (err) {
                        DevExpress.ui.dialog.alert(err.Message, 'Error');
                    });
    }

    $scope.initDataStatus = function () {
        $http.post('../Status',
                        JSON.stringify({
                            NUM_ACCI: 1
                        }))
                    .success(function (oList) {
                        $("#c_Status").dxSelectBox("instance").option("dataSource", oList);
                    }).error(function (err) {
                        DevExpress.ui.dialog.alert(err.Message, 'Error');
                    });
    }

    $scope.initDataProblemType = function () {
        $http.post('../ProblemType',
                        JSON.stringify({
                            NUM_ACCI: 1
                        }))
                    .success(function (oList) {
                        $("#c_ProblemType").dxSelectBox("instance").option("dataSource", oList);
                        $("#c_ProblemTypeEdit").dxSelectBox("instance").option("dataSource", oList);
                    }).error(function (err) {
                        DevExpress.ui.dialog.alert(err.Message, 'Error');
                    });
    }

    $scope.initDataPriority = function () {
        $http.post('../Priority',
                        JSON.stringify({
                            NUM_ACCI: 1
                        }))
                    .success(function (oList) {
                        $("#c_Priority").dxSelectBox("instance").option("dataSource", oList);
                        $("#c_PriorityEdit").dxSelectBox("instance").option("dataSource", oList);
                    }).error(function (err) {
                        DevExpress.ui.dialog.alert(err.Message, 'Error');
                    });
    }

    $scope.searchEnterprise = function () {
        $http.post('../Enterprise',
                        JSON.stringify({
                            EMP_RazonSocial: $("#txtEmpresa").dxTextBox("instance").option("value"),
                            NUM_ACCI: 1
                        }))
                    .success(function (oList) {
                        $("#gdvEnterprise").dxDataGrid("instance").option("dataSource", oList);
                    }).error(function (err) {
                        DevExpress.ui.dialog.alert(err.Message, 'Error');
                    });
    }

    $scope.searchUserClient = function () {
        $http.post('../UserClient',
                        JSON.stringify({
                            TIC_USU_CLIENT_Description: $("#txtUserClient").dxTextBox("instance").option("value"),
                            NUM_ACCI: 1
                        }))
                    .success(function (oList) {
                        $("#gdvUserClient").dxDataGrid("instance").option("dataSource", oList);
                    }).error(function (err) {
                        DevExpress.ui.dialog.alert(err.Message, 'Error');
                    });
    }

    $scope.initDataHistoric = function () {
        $http.post('../TicketHistorical',
                        JSON.stringify({
                            TIC_Id: $("#txt_TIC_Id").dxTextBox("instance").option("value"),
                            NUM_ACCI: 1
                        }))
                    .success(function (oList) {
                        $("#gdvTicketHistorical").dxDataGrid("instance").option("dataSource", oList);
                    }).error(function (err) {
                        DevExpress.ui.dialog.alert(err.Message, 'Error');
                    });
    }

    $scope.clearControl = function () {
        $("#txtRazonSocial").dxTextBox("instance").option("value", "");
        $("#txtEnterpriseId").dxTextBox("instance").option("value", "");
        $("#txtUser").dxTextBox("instance").option("value", "");
        $("#txtUserId").dxTextBox("instance").option("value", "");
        $("#txtDescripcion").dxTextArea("instance").option("value", "");
        $("#c_Service").dxSelectBox("instance").option("value", 0);
        $("#c_ProblemType").dxSelectBox("instance").option("value", 0);
        $("#c_Priority").dxSelectBox("instance").option("value", 0);
    };

    $scope.Save = function () {
        var result = DevExpress.ui.dialog.confirm("¿Confirma que desea realizar esta acción?", "Aviso");
        result.done(function (dialogResult) {
            if (dialogResult) {
                $http.post('../CreateTicket',
                                JSON.stringify({
                                    TIC_PRI_Id: $("#c_Priority").dxSelectBox("instance").option("value"),
                                    TIC_PRO_Id: $("#c_ProblemType").dxSelectBox("instance").option("value"),
                                    TIC_SOL_Id: 0,
                                    TIC_SER_Id: $("#c_Service").dxSelectBox("instance").option("value"),
                                    TIC_EMP_Id: $("#txtEnterpriseId").dxTextBox("instance").option("value"),
                                    TIC_USU_Id: $("#txtUserId").dxTextBox("instance").option("value"),
                                    TIC_Descripcion: $("#txtDescripcion").dxTextArea("instance").option("value")
                                }))
                            .success(function (oBe) {
                                DevExpress.ui.dialog.alert(oBe, 'Satisfactorio');
                                $scope.refreshData();
                                $scope.hidePopupTicket();
                            }).error(function (err) {
                                DevExpress.ui.dialog.alert(err.Message, 'Error');
                            });
            }
        });
    }


    //INICION ROLY

    $scope.showPopupOpen = function (row) {
        if (row.StatusName == "Pendiente" || row.StatusName == "En Proceso") {
            var popup = $("#popupAbrirTicket").dxPopup("instance");
            popup.option("title", "Abrir Ticket");
            popup.show();
            userFactory.NUM_ACCI = 3;
            $http.post('../T0005G0005',
                            JSON.stringify({
                                TIC_Id: row.TIC_Id,
                                TIC_CodigoEstado: 2,
                                NUM_ACCI: 3
                            }))
            .success(function (oBe) {
                $scope.refreshData();
            }).error(function (err) {
                DevExpress.ui.dialog.alert(err.Message, 'Error');
            });
            $http.post('../AbrirTicket',
                            JSON.stringify({
                                TIC_Id: row.TIC_Id,
                                NUM_ACCI: 3
                            }))
                        .success(function (oList) {
                            var oBe = oList[0];
                            $("#txtTicket").dxTextBox("instance").option("value", oBe.TIC_Code);
                            $("#txtEmpresaAbrir").dxTextBox("instance").option("value", oBe.EMP_RazonSocial);
                            $("#txtUsuSol").dxTextBox("instance").option("value", oBe.TIC_USU_Description);
                            $("#txtServiceId").dxTextBox("instance").option("value", oBe.SER_Id);
                            $("#txtServicioAbrir").dxTextBox("instance").option("value", oBe.SER_Descripcion);
                            $("#cmbCOD_PRO").dxSelectBox("instance").option("value", oBe.TIC_PRO_Id);
                            $("#txtTicket").dxTextBox("instance").option("readOnly", true);
                            $("#txtEmpresaAbrir").dxTextBox("instance").option("readOnly", true);
                            $("#txtUsuSol").dxTextBox("instance").option("readOnly", true);
                            $scope.initDataProblema();
                        }).error(function (err) {
                            DevExpress.ui.dialog.alert(err.Message, 'Error');
                        });

        }
    }
    $scope.FindSolutions = function () {
        $http.post('../T0005G0004',
                        JSON.stringify({
                            SOL_PROD_Id: $("#cmbCOD_PRO").dxSelectBox("instance").option("value"),
                            NUM_ACCI: 1
                        }))
                    .success(function (oList) {
                        console.log(oList);
                        $("#gdvSolution").dxDataGrid("instance").option("dataSource", oList);
                    }).error(function (err) {
                        DevExpress.ui.dialog.alert(err.Message, 'Error');
                    });
    }
    $scope.cellTemplateFile = function (container, options) {
        $('<span id="spanicon" title="Nuevo" />')
           .attr('class', 'dx-icon-doc icon')
           .on('dxclick', function () { $scope.DonwloadFile(options.data); })
           .appendTo(container);
    };
    $scope.DonwloadFile = function (row) {
        window.open(row.SOL_RutaArchivo, '_blank', 'location=yes,height=570,width=520,scrollbars=yes,status=yes');
    }
    $scope.showPopupEdit = function (row) {
        var popup = $("#popupTicketEdit").dxPopup("instance");
        popup.option("title", "Modificar Ticket");
        popup.show();
        userFactory.NUM_ACCI = 2;
        $http.post('../T0005G0001',
                        JSON.stringify({
                            TIC_Id: row.TIC_Id,
                            NUM_ACCI: 2
                        }))
                    .success(function (oList) {
                        var oBe = oList[0];
                        $("#txtTicketIdEdit").dxTextBox("instance").option("value", oBe.TIC_Id);
                        $("#tctTicketCodeEdit").dxTextBox("instance").option("value", oBe.TIC_Code);
                        $("#txtRazonSocialEdit").dxTextBox("instance").option("value", oBe.EMP_RazonSocial);
                        $("#txtUserEdit").dxTextBox("instance").option("value", oBe.TIC_USU_Description);
                        $("#c_ServiceEdit").dxSelectBox("instance").option("value", oBe.TIC_SER_Id);
                        $("#c_ProblemTypeEdit").dxSelectBox("instance").option("value", oBe.TIC_PRO_Id);
                        $("#c_PriorityEdit").dxSelectBox("instance").option("value", oBe.TIC_PRI_Id);
                        $("#txtUserResponsibleEdit").dxTextBox("instance").option("value", oBe.TIC_USU_RESP_Description);
                        $("#txtDescriptionEdit").dxTextArea("instance").option("value", oBe.TIC_Descripcion);
                        $("#txtRazonSocialEdit").dxTextBox("instance").option("readOnly", true);
                        $("#txtUserEdit").dxTextBox("instance").option("readOnly", true);
                        $("#txtUserResponsibleEdit").dxTextBox("instance").option("readOnly", true);
                        $("#c_ServiceEdit").dxSelectBox("instance").option("readOnly", true);
                        $("#c_ProblemTypeEdit").dxSelectBox("instance").option("readOnly", true);
                        $("#btnBuscarEmpresaEdit").css("display", "none");
                        $("#btnBuscarUsuarioEdit").css("display", "none");
                    }).error(function (err) {
                        DevExpress.ui.dialog.alert(err.Message, 'Error');
                    });
    }
    $scope.Edit = function () {
        var result = DevExpress.ui.dialog.confirm("¿Confirma que desea realizar esta acción?", "Aviso");
        result.done(function (dialogResult) {
            if (dialogResult) {
                $http.post('../T0005G0005',
                           JSON.stringify({
                               TIC_Id: $("#txtTicketIdEdit").dxTextBox("instance").option("value"),
                               TIC_SER_Id: $("#c_ServiceEdit").dxSelectBox("instance").option("value"),
                               TIC_PRO_Id: $("#c_ProblemTypeEdit").dxSelectBox("instance").option("value"),
                               TIC_PRI_Id: $("#c_PriorityEdit").dxSelectBox("instance").option("value"),
                               TIC_USU_RESP_Id: $("#txtIdResponsibleEdit").dxTextBox("instance").option("value"),
                               TIC_Descripcion: $("#txtDescriptionEdit").dxTextArea("instance").option("value"),
                               NUM_ACCI: 2
                           }))
                       .success(function (oBe) {
                           DevExpress.ui.dialog.alert(oBe, 'Satisfactorio');
                           $scope.refreshData();
                           $scope.hidePopupTicketEdit();
                       }).error(function (err) {
                           DevExpress.ui.dialog.alert(err.Message, 'Error');
                       });
            }
        });
    }
    $scope.initDataProblema = function () {
        $http.post('../T0005G0003',
                        JSON.stringify({
                            NUM_ACCI: 1,
                            SER_Id: $("#txtServiceId").dxTextBox("instance").option("value")
                        }))
                    .success(function (oList) {
                        $("#cmbCOD_PRO").dxSelectBox("instance").option("dataSource", oList);
                    }).error(function (err) {
                        DevExpress.ui.dialog.alert(err.Message, 'Error');
                    });
    }
    $scope.showPopupSearchResponsible = function () {
        var popup = $("#popupSearchResponsible").dxPopup("instance");
        popup.option("title", "Buscar Responsable");
        popup.show();
        $("#gdvResponsible").dxDataGrid("instance").option("dataSource", []);
    }
    $scope.searchResponsible = function () {
        $http.post('../C0006G0001',
                        JSON.stringify({
                            USU_RESP_Description: $("#txtALF_Responsible").dxTextBox("instance").option("value"),
                            NUM_ACCI: 1
                        }))
                    .success(function (oList) {
                        $("#gdvResponsible").dxDataGrid("instance").option("dataSource", oList);
                    }).error(function (err) {
                        DevExpress.ui.dialog.alert(err.Message, 'Error');
                    });
    }
    $scope.buttonsActionSearchResponsible = [
        {
            toolbar: 'bottom', location: 'after', widget: 'dxButton', options: {
                hint: 'Cerrar', icon: 'close', width: 50, disabled: false,
                onClick: $scope.hidePopupSearchResponsible
            }
        }
    ];
    $scope.hidePopupSearchResponsible = function () {
        var popup = $("#popupSearchResponsible").dxPopup("instance");
        popup.hide();
    }
    $scope.cellTemplateResponsibleSearch = function (container, options) {
        $('<span id="spanicon" title="Seleccionar" />')
           .attr('class', 'dx-icon-chevronprev icon')
           .on('dxclick', function () { $scope.selectResponsible(options.data); })
           .appendTo(container);
    };
    $scope.selectResponsible = function (row) {
        $("#txtIdResponsibleEdit").dxTextBox("instance").option("value", row.RES_Id);
        $("#txtUserResponsibleEdit").dxTextBox("instance").option("value", row.USU_RESP_Description);
        $scope.hidePopupSearchResponsible();
    };

    $scope.hidePopupTicketEdit = function () {
        var popup = $("#popupTicketEdit").dxPopup("instance");
        popup.hide();
    }

    $scope.buttonsActionTicketEdit = [
        {
            toolbar: 'bottom', location: 'after', widget: 'dxButton', options: {
                hint: 'Guardar', icon: 'save', width: 50, disabled: false,
                onClick: $scope.Edit
            }
        },
        {
            toolbar: 'bottom', location: 'after', widget: 'dxButton', options: {
                hint: 'Cerrar', icon: 'close', width: 50, disabled: false,
                onClick: $scope.hidePopupTicketEdit
            }
        }
    ];

    $scope.buttonsActionTicketAttendResult = [
        {
            toolbar: 'bottom', location: 'after', widget: 'dxButton', options: {
                hint: 'Guardar', icon: 'save', width: 50, disabled: false,
                onClick: $scope.AttendInsert
            }
        },
        {
            toolbar: 'bottom', location: 'after', widget: 'dxButton', options: {
                hint: 'Cerrar', icon: 'close', width: 50, disabled: false,
                onClick: $scope.hidePopupTicketAttend
            }
        }
    ];


    $scope.showPopupAttend = function (row) {
        if (row.StatusName == 'En Proceso') {
            if (row.RST_Id == 0) {
                var popup = $("#popupTicketAttend").dxPopup("instance");
                popup.option("title", "Registrar Atención");
                popup.show();
                userFactory.NUM_ACCI = 4;
                $http.post('../T0005G0001',
                                JSON.stringify({
                                    TIC_Id: row.TIC_Id,
                                    NUM_ACCI: 4
                                }))
                            .success(function (oList) {
                                var oBe = oList[0];
                                $("#txtTicketIdAttend").dxTextBox("instance").option("value", oBe.TIC_Id);
                                $("#txtTicketAttend").dxTextBox("instance").option("value", oBe.TIC_Code);
                                $("#txtDescripcionAttend").dxTextArea("instance").option("value", oBe.TIC_Descripcion);

                                $('#txtFechaIniAttend').val('');
                                $('#txtFechaFinAttend').val('');
                                $("#txtTrabajoAttend").dxTextArea("instance").option("value", '');

                                $('#txtFechaIniAttend').prop('readonly', false);
                                $('#txtFechaFinAttend').prop('readonly', false);
                                $("#chkResuelto").dxCheckBox("instance").option("readOnly", false);
                                $("#txtDescripcionAttend").dxTextArea("instance").option("readOnly", true);
                                $("#txtTrabajoAttend").dxTextArea("instance").option("readOnly", false);
                                $("#btnInsertAttend").css("display", "block");
                            }).error(function (err) {
                                DevExpress.ui.dialog.alert(err.Message, 'Error');
                            });
            } else {
                DevExpress.ui.dialog.alert("Ya hay un informe de atención registrado por el usuario responsable.", "Mensaje");
            }
        } else {
            DevExpress.ui.dialog.alert("Para generar un informe el ticket tiene que estar en estado En Proceso.", "Mensaje");
        }

    }
        
    
    $scope.AttendInsert = function () {
        var result = DevExpress.ui.dialog.confirm("¿Confirma que desea realizar esta acción?", "Aviso");
        result.done(function (dialogResult) {
            if (dialogResult) {
                $http.post('../T0005G0006',
                           JSON.stringify({
                               ATE_TIC_Id: $("#txtTicketIdAttend").dxTextBox("instance").option("value"),
                               ATE_FEC_INI: $('#txtFechaIniAttend').val(),
                               ATE_FEC_FIN: $('#txtFechaFinAttend').val(),
                               ATE_FLAG_RES: $("#chkResuelto").dxCheckBox("instance").option("value"),
                               ATE_DET_TRA: $("#txtTrabajoAttend").dxTextArea("instance").option("value"),
                               NUM_ACCI: 2
                           }))
                       .success(function (oBe) {
                           DevExpress.ui.dialog.alert(oBe, 'Satisfactorio');
                           $scope.refreshData();
                           $scope.hidePopupTicketAttend();
                       }).error(function (err) {
                           DevExpress.ui.dialog.alert(err.Message, 'Error');
                       });
            }
        });
    }

    $scope.hidePopupTicketAttend = function () {
        var popup = $("#popupTicketAttend").dxPopup("instance");
        popup.hide();
    }

    $scope.cellTemplateReport = function (container, options) {
        $('<span id="spanicon" title="Informe" />')
           .attr('class', 'dx-icon-user icon')
           .on('dxclick', function () { $scope.showPopupAttendConsult(options.data); })
           .appendTo(container);
    };

    $scope.showPopupAttendConsult = function (row) {
        if (row.ATE_RST_Id > 0) {
            var popup = $("#popupTicketAttend").dxPopup("instance");
            popup.option("title", "Consultar Atención");
            popup.show();
            $http.post('../ConsultarAtencion',
                            JSON.stringify({
                                ATE_ID: row.ATE_ID,
                                NUM_ACCI: 3
                            }))
                        .success(function (oList) {
                            var oBe = oList[0];
                            $("#txtTicketAttend").dxTextBox("instance").option("value", oBe.TIC_Code);
                            //$("#txtFechaIniAttend").dxTextBox("instance").option("value", oBe.ATE_FEC_INI);
                            $('#txtFechaIniAttend').val(oBe.ATE_FEC_INI)
                            //$("#txtFechaFinAttend").dxTextBox("instance").option("value", oBe.ATE_FEC_FIN);
                            $('#txtFechaFinAttend').val(oBe.ATE_FEC_FIN)
                            //$("#chkResuelto").dxSelectBox("instance").option("value", oBe.ATE_FLAG_RES);
                            if (oBe.ATE_FLAG_RES == 1)
                                $("#chkResuelto").dxCheckBox("instance").option("value", true);
                            else
                                $("#chkResuelto").dxCheckBox("instance").option("value", false);

                            $("#txtDescripcionAttend").dxTextArea("instance").option("value", oBe.TIC_Descripcion);
                            $("#txtTrabajoAttend").dxTextArea("instance").option("value", oBe.RST_Descripcion);


                            $("#txtTicketAttend").dxTextBox("instance").option("readOnly", true);
                            $('#txtFechaIniAttend').prop('readonly', true);
                            $('#txtFechaFinAttend').prop('readonly', true);
                            $("#chkResuelto").dxCheckBox("instance").option("readOnly", true);
                            $("#txtDescripcionAttend").dxTextArea("instance").option("readOnly", true);
                            $("#txtTrabajoAttend").dxTextArea("instance").option("readOnly", true);
                            $("#btnInsertAttend").css("display", "none");

                        }).error(function (err) {
                            DevExpress.ui.dialog.alert(err.Message, 'Error');
                        });

        } else {
            DevExpress.ui.dialog.alert("No hay un informe a mostrar","Mensaje");
        }
    }

    //FIN ROLY




    $scope.headerTemplate = function (container) {
        $('<span id="spanicon" title="Nuevo" />')
           .attr('class', 'dx-icon-add icon')
           .on('dxclick', function () { $scope.showPopupNew(); })
           .appendTo(container);
    };
    $scope.cellTemplate = function (container, options) {
        $('<span id="spanicon" title="Modificar" />')
           .attr('class', 'dx-icon-edit icon')
           .on('dxclick', function () { $scope.showPopupEdit(options.data); })
           .appendTo(container);
    };
    $scope.cellTemplateCheck = function (container, options) {
        $('<span id="spanicon" title="Abrir" />')
           .attr('class', 'dx-icon-check icon')
           .on('dxclick', function () { $scope.showPopupOpen(options.data); })
           .appendTo(container);
    };
    $scope.cellTemplateDoc = function (container, options) {
        $('<span id="spanicon" title="Informe" />')
           .attr('class', 'dx-icon-doc icon')
           .on('dxclick', function () { $scope.showPopupAttend(options.data); })
           .appendTo(container);
    };
    $scope.cellTemplateHistoric = function (container, options) {
        $('<span id="spanicon" title="Historial" />')
           .attr('class', 'dx-icon-clock icon')
           .on('dxclick', function () { $scope.showPopupTicketHistorical(options.data); })
           .appendTo(container);
    };

    $scope.showPopupNew = function () {
        var popup = $("#popupTicket").dxPopup("instance");
        popup.option("title", "Registrar Ticket");
        popup.show();
        $scope.clearControl();
        userFactory.NUM_ACCI = 1;
    }

    $scope.showPopupSearchEnterprise = function () {
        var popup = $("#popupSearchEnterprise").dxPopup("instance");
        popup.show();
        $("#gdvEnterprise").dxDataGrid("instance").option("dataSource", []);
    }

    $scope.showPopupSearchUserClient = function () {
        var popup = $("#popupSearchUserClient").dxPopup("instance");
        popup.show();
        $("#gdvUserClient").dxDataGrid("instance").option("dataSource", []);
    }

    $scope.hidePopupSearcEnterprise = function () {
        var popup = $("#popupSearchEnterprise").dxPopup("instance");
        popup.hide();
    }

    $scope.hidePopupSearcUserClient = function () {
        var popup = $("#popupSearchUserClient").dxPopup("instance");
        popup.hide();
    }

    $scope.hidePopupTicket = function () {
        var popup = $("#popupTicket").dxPopup("instance");
        popup.hide();
    }

    $scope.selectEnterprise = function (row) {
        console.log(row);
        $("#txtEnterpriseId").dxTextBox("instance").option("value", row.EMP_Id);
        $("#txtRazonSocial").dxTextBox("instance").option("value", row.EMP_RazonSocial);
        //$("#txtALF_AGEN").dxTextBox("instance").option("value", row.ALF_AGEN);
        //$("#txtALF_DNII").dxTextBox("instance").option("value", row.ALF_DNII);
        //$("#txtALF_DIRE").dxTextBox("instance").option("value", row.ALF_DIRE);
        $scope.hidePopupSearcEnterprise();
    };

    $scope.selectUserClient = function (row) {
        $("#txtUserId").dxTextBox("instance").option("value", row.USU_Id);
        $("#txtUser").dxTextBox("instance").option("value", row.TIC_USU_CLIENT_Description);
        $scope.hidePopupSearcUserClient();
    };

    $scope.cellTemplateEnterpriseSearch = function (container, options) {
        $('<span id="spanicon" title="Seleccionar" />')
           .attr('class', 'dx-icon-chevronprev icon')
           .on('dxclick', function () { $scope.selectEnterprise(options.data); })
           .appendTo(container);
    };

    $scope.cellTemplateUserClientSearch = function (container, options) {
        $('<span id="spanicon" title="Seleccionar" />')
           .attr('class', 'dx-icon-chevronprev icon')
           .on('dxclick', function () { $scope.selectUserClient(options.data); })
           .appendTo(container);
    };

    $scope.buttonsActionTicket = [
        {
            toolbar: 'bottom', location: 'after', widget: 'dxButton', options: {
                hint: 'Guardar', icon: 'save', width: 50, disabled: false,
                onClick: $scope.Save
            }
        },
        {
            toolbar: 'bottom', location: 'after', widget: 'dxButton', options: {
                hint: 'Cerrar', icon: 'close', width: 50, disabled: false,
                onClick: $scope.hidePopupTicket
            }
        }
    ];

    $scope.showPopupTicketHistorical = function (row) {
        var popup = $("#popupSearchTicketHistorical").dxPopup("instance");
        $http.post('../TicketHistorical',
                        JSON.stringify({
                            TIC_Id: row.TIC_Id,
                            NUM_ACCI: 1
                        }))
                    .success(function (oList) {
                        $("#gdvTicketHistorical").dxDataGrid("instance").option("dataSource", oList);
                    }).error(function (err) {
                        DevExpress.ui.dialog.alert(err.Message, 'Error');
                    });
        popup.show();
        
        $("#txt_TIC_Id").dxTextBox("instance").option("value", row.TIC_Id); 
        $("#gdvTicketHistorical").dxDataGrid("instance").option("dataSource", []);


    }


   

    

   
    
});